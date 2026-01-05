using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gerenciadorBanco
{
    public partial class FormAlteracaoDados : Form
    {

        private FbConnection con;
        private Form1 _form1;
        private bool modoEdicao = false;

        public FormAlteracaoDados()
        {
            InitializeComponent();
            _form1 = new Form1();
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

                // Carrega os dados mas mantém os campos desabilitados
                CarregarDados();

                // Habilita apenas os botões de ação
                btnEditar.Enabled = true;
                btnCarregaCert.Enabled = true;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "NÃO CONECTADO";
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDados()
        {
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "select p.cd_filial, p.codigousuario, p.nomefantasia, p.razao, p.endereco,p.complemento, p.numero, p.bairro, p.cidade, p.uf, p.cep, p.cgc, p.inscricao, p.nfceserie, p.nfcecidtoken, p.nfcetoken from parametros p";

                using (var da = new FbDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        var row = dt.Rows[0];
                        txtCDFILIAL.Text = row["cd_filial"].ToString();
                        txtCODIGO.Text = row["codigousuario"].ToString();
                        txtNomeFantasia.Text = row["nomefantasia"].ToString();
                        txtRazao.Text = row["razao"].ToString();
                        txtEndereco.Text = row["endereco"].ToString();
                        txtComplemento.Text = row["complemento"].ToString();
                        txtNumero.Text = row["numero"].ToString();
                        txtBairro.Text = row["bairro"].ToString();
                        txtCidade.Text = row["cidade"].ToString();
                        txtUF.Text = row["uf"].ToString();
                        txtCEP.Text = row["cep"].ToString();
                        txtCNPJ.Text = row["cgc"].ToString();
                        txtIE.Text = row["inscricao"].ToString();
                        txtNFCESerie.Text = row["nfceserie"].ToString();
                        txtNFCEIDtoken.Text = row["nfcecidtoken"].ToString();
                        txtNFCEToken.Text = row["nfcetoken"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum dado encontrado na tabela 'parametros'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void HabilitarCamposParaEdicao(bool habilitar)
        {
            txtCODIGO.Enabled = habilitar;
            txtBairro.Enabled = habilitar;
            txtCEP.Enabled = habilitar;
            txtCNPJ.Enabled = habilitar;
            txtCidade.Enabled = habilitar;
            txtComplemento.Enabled = habilitar;
            txtEndereco.Enabled = habilitar;
            txtIE.Enabled = habilitar;
            txtNomeFantasia.Enabled = habilitar;
            txtNumero.Enabled = habilitar;
            txtRazao.Enabled = habilitar;
            txtUF.Enabled = habilitar;
            txtNFCESerie.Enabled = habilitar;
            txtNFCEIDtoken.Enabled = habilitar;
            txtNFCEToken.Enabled = habilitar;
            txtSenha.Enabled = habilitar;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (con == null || con.State != ConnectionState.Open)
            {
                MessageBox.Show("É necessário conectar ao banco de dados primeiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            modoEdicao = true;
            HabilitarCamposParaEdicao(true);
            btnSalvar.Enabled = true;
            btnEditar.Enabled = false;
            MessageBox.Show("Modo de edição ativado. Altere os campos necessários e clique em Salvar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (con == null || con.State != ConnectionState.Open)
            {
                MessageBox.Show("Conexão com o banco de dados não está ativa!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Confirmação antes de salvar
                var confirmacao = MessageBox.Show("Deseja realmente salvar as alterações?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacao == DialogResult.No)
                {
                    return;
                }

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE parametros SET 
                        codigousuario = @codigousuario,
                        nomefantasia = @nomefantasia,
                        razao = @razao,
                        endereco = @endereco,
                        complemento = @complemento,
                        numero = @numero,
                        bairro = @bairro,
                        cidade = @cidade,
                        uf = @uf,
                        cep = @cep,
                        cgc = @cgc,
                        inscricao = @inscricao,
                        nfceserie = @nfceserie,
                        nfcecidtoken = @nfcecidtoken,
                        nfcetoken = @nfcetoken
                        WHERE cd_filial = @cd_filial";

                    // Adiciona os parâmetros
                    cmd.Parameters.AddWithValue("@cd_filial", txtCDFILIAL.Text);
                    cmd.Parameters.AddWithValue("@codigousuario", txtCODIGO.Text);
                    cmd.Parameters.AddWithValue("@nomefantasia", txtNomeFantasia.Text);
                    cmd.Parameters.AddWithValue("@razao", txtRazao.Text);
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                    cmd.Parameters.AddWithValue("@complemento", txtComplemento.Text);
                    cmd.Parameters.AddWithValue("@numero", txtNumero.Text);
                    cmd.Parameters.AddWithValue("@bairro", txtBairro.Text);
                    cmd.Parameters.AddWithValue("@cidade", txtCidade.Text);
                    cmd.Parameters.AddWithValue("@uf", txtUF.Text);
                    cmd.Parameters.AddWithValue("@cep", txtCEP.Text);
                    cmd.Parameters.AddWithValue("@cgc", txtCNPJ.Text);
                    cmd.Parameters.AddWithValue("@inscricao", txtIE.Text);
                    cmd.Parameters.AddWithValue("@nfceserie", txtNFCESerie.Text);
                    cmd.Parameters.AddWithValue("@nfcecidtoken", txtNFCEIDtoken.Text);
                    cmd.Parameters.AddWithValue("@nfcetoken", txtNFCEToken.Text);

                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Desabilita o modo de edição
                        modoEdicao = false;
                        HabilitarCamposParaEdicao(false);
                        btnSalvar.Enabled = false;
                        btnEditar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro foi atualizado. Verifique se o CD_FILIAL existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCarregaCert_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Arquivos de Certificado (*.pfx;*.p12)|*.pfx;*.p12|Todos os Arquivos (*.*)|*.*",
                Title = "Selecione o arquivo de certificado"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string certPath = openFileDialog.FileName;
                    string senha = txtSenha.Text;
                    if (string.IsNullOrWhiteSpace(senha))
                    {
                        MessageBox.Show("Por favor, insira a senha do certificado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var cert = new X509Certificate2(certPath, senha);
                    string cnpjCert = GetCnpjFromCertificate(cert);

                    if (string.IsNullOrWhiteSpace(cnpjCert))
                    {
                        MessageBox.Show("Não foi possível extrair o CNPJ do certificado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Busca o CGC da tabela parametros
                    string cgcBanco = null;
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "SELECT FIRST 1 cgc FROM parametros";
                        cgcBanco = cmd.ExecuteScalar()?.ToString();
                    }

                    if (cgcBanco == null)
                    {
                        MessageBox.Show("Não foi possível encontrar o campo CGC no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Normaliza (tira máscara, só números)
                    string normalize(string v) => new string(v.Where(char.IsDigit).ToArray());

                    if (normalize(cgcBanco) != normalize(cnpjCert))
                    {
                        MessageBox.Show($"O CNPJ do certificado ({cnpjCert}) é diferente do cadastrado no banco ({cgcBanco}).",
                                        "Certificado inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Se chegou até aqui, certificado válido
                    DateTime validadeInicio = cert.NotBefore;
                    DateTime validadeFim = cert.NotAfter;
                    lblValidade.Text = $"Validade: {validadeInicio:dd/MM/yyyy} a {validadeFim:dd/MM/yyyy}";

                    MessageBox.Show("Certificado validado com sucesso!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar o certificado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GetCnpjFromCertificate(X509Certificate2 certificado)
        {
            var subject = certificado.Subject;
            string cnpj = string.Empty;

            var subjectParts = subject.Split(',');

            foreach (var part in subjectParts)
            {
                if (part.Trim().StartsWith("CN="))
                {
                    var cnPart = part.Trim().Split('=')[1];
                    var separatorIndex = cnPart.LastIndexOf(':');

                    if (separatorIndex > 0)
                    {
                        cnpj = cnPart.Substring(separatorIndex + 1);
                    }
                    break;
                }
            }

            return cnpj;
        }
    }
}