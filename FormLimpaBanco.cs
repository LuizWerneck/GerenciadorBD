using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;

namespace gerenciadorBanco
{
    public partial class FormLimpaBanco : Form
    {
        
        private FbConnection con;
        

        public FormLimpaBanco()
        {
            InitializeComponent();
        }

        private void ConnectToDatabase(string caminho)
        {
            string strConexao = $"User=SYSDBA;Password=masterkey;Database=localhost:{caminho};DataSource=localhost;Port=3050;Dialect=3;Charset=UTF8;Role=;Connection lifetime=15;Pooling=true;Packet Size=8192;ServerType=0;";
            try
            {
                con = new FbConnection(strConexao);
                con.Open();
                lblStatus.Text = "CONECTADO";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                chkList.Enabled = true;
                btnMarcar.Enabled = true;
                btnLimpar.Enabled = true;
                
            }
            catch (Exception ex)
            {
                lblStatus.Text = "NÃO CONECTADO";
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var caminho = openFileDialog1.FileName;
                lblCaminho.Text = caminho;
                ConnectToDatabase(caminho);
            }
        }



        public class FirebirdBackupRestore
        {
            private string _connectionString;
            private string _databaseString;
            private TextBox _outputTextBox;

            public FirebirdBackupRestore(string connectionString, TextBox outputTextBox)
            {
                _connectionString = connectionString;
                _outputTextBox = outputTextBox;
                
            }

            public async Task BackupDatabaseAsync(string backupFilePath)
            {
                try
                {
                    FbBackup backupService = new FbBackup
                    {
                        ConnectionString = _connectionString,
                        Verbose = true,
                        Options = FbBackupFlags.NoGarbageCollect,
                    };
                    backupService.BackupFiles.Add(new FbBackupFile(backupFilePath, 2048));

                    backupService.ServiceOutput += (sender, args) =>
                    {
                        AppendTextToOutput(args.Message);
                    };

                    await Task.Run(() => backupService.Execute());
                    AppendTextToOutput("Backup realizado com sucesso!");
                }
                catch (Exception ex)
                {
                    AppendTextToOutput("Erro ao realizar o backup: " + ex.Message);
                }
            }

            public async Task RestoreDatabaseAsync(string backupFilePath, string restoreFilePath)
            {
                _databaseString = "User=SYSDBA;Password=masterkey;Database=localhost:" + restoreFilePath + ";DataSource=localhost;Port=3050;Dialect=3;Charset=UTF8;Role=;Connection lifetime=15;Pooling=true;Packet Size=8192;ServerType=0";
                try
                {
                    FbRestore restoreService = new FbRestore
                    {
                        ConnectionString = _databaseString,
                        Verbose = true,
                        Options = FbRestoreFlags.UseAllSpace | FbRestoreFlags.Create, // Ou FbRestoreFlags.Replace se for substituir
                    };

                    restoreService.BackupFiles.Add(new FbBackupFile(backupFilePath, 2048));


                    restoreService.ServiceOutput += (sender, args) =>
                    {
                        AppendTextToOutput(args.Message);
                    };

                    try
                    {
                        await Task.Run(() => restoreService.ExecuteAsync());
                        AppendTextToOutput("Restore realizado com sucesso!");
                    }
                    catch (Exception e) { AppendTextToOutput("Erro ai ó: " + e.Message); }

                }
                catch (Exception ex)
                {
                    AppendTextToOutput("Erro ao realizar o restore: " + ex.Message);
                }
            }

            private void AppendTextToOutput(string message)
            {
                if (_outputTextBox.InvokeRequired)
                {
                    _outputTextBox.Invoke(new Action(() => _outputTextBox.AppendText(message + Environment.NewLine)));
                }
                else
                {
                    _outputTextBox.AppendText(message + Environment.NewLine);
                }
            }
        }



        private async void btnBackup_Click(object sender, EventArgs e)
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                saveFileDialog1.FileName = "backup.fbk";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var backupFilePath = saveFileDialog1.FileName;
                    txtOutput.Clear();
                    var backupService = new FirebirdBackupRestore(con.ConnectionString, txtOutput);

                    chkList.Enabled = false;
                    btnLocalizaBD.Enabled = false;
                    btnBackup.Enabled = false;
                    btnRestore.Enabled = false;
                    btnMarcar.Enabled = false;
                    btnLimpar.Enabled = false;
                    
                    
                    
                    await backupService.BackupDatabaseAsync(backupFilePath);
 
                    chkList.Enabled = true;
                    btnLocalizaBD.Enabled = true;
                    btnBackup.Enabled = true;
                    btnRestore.Enabled = true;
                    btnMarcar.Enabled = true;
                    btnLimpar.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Não há conexão ativa com o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRestore_Click(object sender, EventArgs e)
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                openFileDialog2.FileName = "backup.fbk";
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    var backupFilePath = openFileDialog2.FileName;

                    // Solicitar ao usuário o caminho onde o banco de dados restaurado será salvo
                    saveFileDialog2.FileName = "NOVO.fdb";
                    if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        var restoreFilePath = saveFileDialog2.FileName;

                        // Verificação de existência do arquivo
                        if (File.Exists(restoreFilePath))
                        {
                            MessageBox.Show("O arquivo já existe. Por favor, escolha um nome ou caminho diferente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        txtOutput.Clear();
                        var restoreService = new FirebirdBackupRestore(con.ConnectionString, txtOutput);

                        chkList.Enabled = false;
                        btnLocalizaBD.Enabled = false;
                        btnBackup.Enabled = false;
                        btnRestore.Enabled = false;
                        btnMarcar.Enabled = false;
                        btnLimpar.Enabled = false;

                        await restoreService.RestoreDatabaseAsync(backupFilePath, restoreFilePath);

                        chkList.Enabled = true;
                        btnLocalizaBD.Enabled = true;
                        btnBackup.Enabled = true;
                        btnRestore.Enabled = true;
                        btnMarcar.Enabled = true;
                        btnLimpar.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há conexão ativa com o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class tabela2
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            pnlAguarde.Visible = true;

            if (con != null && con.State == ConnectionState.Open)
            {


                for (int i = 0; i < chkList.Items.Count; i++)
                {
                    if (chkList.GetItemChecked(i))
                    {
                        string tabela = string.Empty;
                        string tabela2 = string.Empty;
                        string tabela3 = string.Empty;
                        string tabela4 = string.Empty;
                        string tabela5 = string.Empty;
                        string tabela6 = string.Empty;
                        string tabela7 = string.Empty;
                        string tabela8 = string.Empty;
                        string tabela9 = string.Empty;
                        string tabela10 = string.Empty;
                        string tabela11 = string.Empty;
                        string tabela12 = string.Empty;
                        string tabela13 = string.Empty;
                        string tabela14 = string.Empty;
                        string tabelaClientes = string.Empty;



                        switch (i)
                        {
                            case 0:
                                tabela = "lancamentos2";
                                tabela2 = "lancamentos";
                                tabela3 = "lancamentos_aprazo";
                                tabela4 = "SALDO_COMISSAO";
                                tabela5 = "FPAUTORIZACOES";
                               

                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela4}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela4}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela4 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela5}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela5}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela5 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 1:
                                tabela = "caixa2";
                                tabela2 = "caixa";
                                tabela3 = "MOVIMENTOCAIXA";
                                tabela4 = "CHEQUESRECEBIDOS";

                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela4}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela4}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela4 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 2:
                                tabela = "operadores";
                                break;
                            case 3:
                                tabela = "vendedores";
                                break;
                            case 4:
                                tabela = "vendas2";
                                tabela2 = "vendas";
                                tabela3 = "VENDAS_FP";
                                tabela4 = "entregas";
                                tabela5 = "KMENTREGADORES";


                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela4}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela4}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela4 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela5}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela5}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela5 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 5:
                                tabela = "NFCECOPIA";
                                tabela2 = "NFCE";
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 6:
                                tabela = "ITENS_COMPRA_LOTE";
                                tabela2 = "COMPRAS";
                                tabela3 = "ITENS_COMPRA";
                                tabela4 = "CONFERENCIA_NOTA";
                                tabela5 = "CADERNO_FALTAS";
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela4}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela4}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela4 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela5}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela5}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela5 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 7:
                                tabela = "CONTAS_RECEBER";                                
                                break;
                            case 8:
                                tabela = "CONTAS_PAGAR";
                                break;
                            case 9:
                                tabela = "ITENS_TRANSFER";
                                tabela2 = "TRANSFER";
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 10:
                                tabela = "NFEITENSLOTES";
                                tabela2 = "NFES";
                                tabela3 = "NFECABECALHO";
                                tabela4 = "NF";
                                tabela5 = "NFEITENS";
                                tabela6 = "NFEDUPLICATAS";
                                tabela7 = "NFEFATURAMENTO";
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela4}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela4}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela4 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela5}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela5}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela5 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela6}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela6}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela6 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela7}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela7}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela7 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 11:
                                tabela = "PIX_TRANSACOES";
                                tabela2 = "PIX_PARAMETROS";
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 12:
                                tabela = "IFOOD_ITENS";
                                tabela2 = "IFOOD_MONITOR";
                                tabela3 = "IFOOD_PEDIDOS";
                                tabela4 = "IFOOD_PRODUTOS";
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela4}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela4}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela4 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 13:
                                tabela = "FARMACIASAPP_ITENS";
                                tabela2 = "FARMACIASAPP_MONITOR";
                                tabela3 = "FARMACIASAPP_OFERTAS";
                                tabela4 = "FARMACIASAPP_PEDIDOS";
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }

                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela4}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela4}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela4 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 14:
                                tabela = "logacesso";
                                tabela2 = "ERROS_LOG";
                                tabela3 = "AUTENTICACAO";
                                
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                                               
                                break;
                            case 15:
                                tabela = "PAF_R02DELETADOS";
                                tabela2 = "PAF_R03DELETADOS";
                                tabela3 = "PAF_R04DELETADOS";
                                tabela4 = "PAF_R05DELETADOS";
                                tabela5 = "PAF_R06DELETADOS";
                                tabela6 = "PAF_R07DELETADOS";
                                tabela7 = "PAF_EAD";
                                tabela8 = "PAF_R01";
                                tabela9 = "PAF_R02";
                                tabela10 = "PAF_R03";
                                tabela11 = "PAF_R04";
                                tabela12 = "PAF_R05";
                                tabela13 = "PAF_R06";
                                tabela14 = "PAF_R07";
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }

                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela4}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela4}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela4 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela5}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela5}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela5 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela6}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela6}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela6 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela7}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela7}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela7 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela8}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela8}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela8 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela9}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela9}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela9 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela10}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela10}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela10 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela11}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela11}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela11 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela12}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela12}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela12 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela13}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela13}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela13 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela14}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela14}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela14 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 16:
                                tabela = "SINTEGRA_61";
                                tabela2 = "SINTEGRA_61R";
                                tabela3 = "SINTEGRA_NF_ENTRADA";
                                tabela4 = "SINTEGRA_NF_ENTRADA_ITENS";
                                tabela5 = "SINTEGRA_PEDIDOS_ITENS";
                                tabela6 = "SINTEGRA_PEDIDOS_ITENS_TEMP";
                                tabela7 = "SINTEGRA_R60";
                                tabela8 = "SINTEGRA_R60I";
                                tabela9 = "SINTEGRA_R60I_TEMP";
                                
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }

                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela4}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela4}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela4 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela5}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela5}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela5 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela6}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela6}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela6 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela7}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela7}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela7 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela8}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela8}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela8 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela9}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela9}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela9 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                               
                                break;
                            case 17:
                                tabela = "ENCARTE";
                                tabela2 = "ENCARTE_ITENS";
                                tabela3 = "ENCARTES_FILIAIS";
                                tabela4 = "REAJUSTE";
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela4}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela4}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela4 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 18:
                                tabela = "AUDITORIA";
                                tabela2 = "ITENS_AUDITORIA";
                                tabela3 = "INFORMANTE";
                                tabela4 = "EVENTOS";

                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela3}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela3}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela3 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela4}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela4}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela4 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 19:
                                tabela = "POSICAOESTOQUEDATA";
                                tabela2 = "ESTOQUEPOSVENDA";
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabela2}", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela2}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabela2 + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;
                            case 20:
                                tabela = "BALANCO";
                                break;
                            case 21:
                                tabela = "PRODUTOS_LOTES";
                                break;
                            case 22:
                                tabela = "DELETADOS";
                                break;
                            case 23:
                                tabelaClientes = "CLIENTES";
                                using (FbCommand comando = new FbCommand($"DELETE FROM {tabelaClientes} WHERE CD_CLIENTE <> 999999", con))
                                {
                                    try
                                    {
                                        int registrosExcluidos = comando.ExecuteNonQuery();
                                        txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabelaClientes}.\r\n");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Erro ao excluir da tabela " + tabelaClientes + ": " + ex.Message);
                                        continue;
                                    }

                                }
                                break;

                            default:
                                MessageBox.Show($"Seleção inválida no índice {i}.");
                                continue;
                        }

                        if (!string.IsNullOrEmpty(tabela))
                        {
                            using (FbCommand comando = new FbCommand($"DELETE FROM {tabela}", con))
                            {
                                try
                                {
                                    int registrosExcluidos = comando.ExecuteNonQuery();
                                    txtOutput.AppendText($"{registrosExcluidos} registros foram excluídos da tabela {tabela}.\r\n");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro ao excluir da tabela " + tabela + ": " + ex.Message);
                                    continue;
                                }
                            }
                        }
                    }
                }
                if (chkControle.Checked == true)
                {
                    using (FbCommand controle = new FbCommand("EXECUTE PROCEDURE SP_ATUALIZA_CONTROLE", con))
                    {
                        try
                        {
                            controle.ExecuteNonQuery();
                            txtOutput.AppendText($" Controle atualizado.\r\n");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao atualizar o controle: " + ex.Message);
                        }
                    }
                };
                pnlAguarde.Visible = false;
                MessageBox.Show("Operação concluída.");
            }
            else
                {
                MessageBox.Show("Sem conexão com o banco de dados");
                return;
            }
            
        }

        

        private void btnMarcar_Click(object sender, EventArgs e)
        {
            bool allChecked = true;

            // Verifica se todos os itens estão marcados
            for (int i = 0; i < chkList.Items.Count; i++)
            {
                if (!chkList.GetItemChecked(i))
                {
                    allChecked = false;
                    break;
                }
            }

            // Se todos estiverem marcados, desmarca todos e altera o texto do botão para "Marcar"
            if (allChecked)
            {
                for (int i = 0; i < chkList.Items.Count; i++)
                {
                    chkList.SetItemChecked(i, false);
                }
                btnMarcar.Text = "Marcar";
            }
            // Caso contrário, marca todos e altera o texto do botão para "Desmarcar"
            else
            {
                for (int i = 0; i < chkList.Items.Count; i++)
                {
                    chkList.SetItemChecked(i, true);
                }
                btnMarcar.Text = "Desmarcar";
            }

        }

    }
}
