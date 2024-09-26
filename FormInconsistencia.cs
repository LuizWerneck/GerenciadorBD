using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using static gerenciadorBanco.FormLimpaBanco;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace gerenciadorBanco
{
    public partial class FormInconsistencia : Form
    {
        private FbConnection con;
        Dictionary<string, string> querys = new Dictionary<string, string>
        {
            {"ID_FAMILIA", "update produtos set id_familia = NULL where id_familia not in (select id_familia from familias) and id_familia is not NULL" },
            {"CD_GRUPOBALANCO", "update produtos set cd_grupobalanco = 9999 where cd_grupobalanco not in (select cd_grupobalanco from gruposbalanco)" },
            {"CD_GRUPOCOMPRA", "update produtos set cd_grupocompra = 9999 where cd_grupocompra not in (select cd_grupocompra from gruposcompras)" },
            {"CD_CLASSE","update produtos set cd_classe = (select first 1 (cd_classe) from classes) where cd_classe not in(select cd_classe from classes) or (cd_classe is NULL)"},
            {"CD_GRUPO", "update produtos set cd_grupo = (select first 1 (cd_grupo) from grupos) where cd_grupo not in(select cd_grupo from grupos) or (cd_grupo is NULL)" },
            {"CD_LABORATORIO","update produtos set cd_laboratorio = (select first 1 (cd_laboratorio) from laboratorios) where cd_laboratorio not in(select cd_laboratorio from laboratorios) or (cd_laboratorio is NULL)" },
            {"ID_PRODUTO", "UPDATE PRODUTOS SET ID_PRODUTO = (SELECT FIRST 1 ID_PRODUTO + 1 FROM PRODUTOS p WHERE NOT EXISTS (SELECT 1 FROM PRODUTOS p2 WHERE p2.ID_PRODUTO = p.ID_PRODUTO + 1) ORDER BY ID_PRODUTO) WHERE ID_PRODUTO = 0" },
            {"CD_PRODUTO", @"UPDATE produtos SET CD_PRODUTO = LPAD(CAST(CAST(ID_PRODUTO AS INTEGER) AS VARCHAR (6)),6,0 ) WHERE CD_PRODUTO = '000000' or (cd_produto = '0')" }
        };

        string queryListar = @"SELECT 
                            CASE
                                WHEN (p.id_produto is null OR p.id_produto = 0) THEN 'ID Produto faltando'
                                WHEN (p.cd_produto = '0' OR p.cd_produto = '') THEN 'Código Produto faltando'
                                WHEN (p.cd_classe IS NOT NULL AND c.cd_classe IS NULL) THEN 'Classe Divergente'
                                WHEN (p.cd_classe IS NULL) THEN 'Classe faltando'
                                WHEN (p.cd_grupo IS NOT NULL AND g.cd_grupo IS NULL) THEN 'Grupo Divergente'
                                WHEN (p.cd_grupo IS NULL) THEN 'Grupo faltando'
                                WHEN (p.cd_laboratorio IS NOT NULL AND l.cd_laboratorio IS NULL) THEN 'Laboratório Divergente'
                                WHEN (p.cd_laboratorio IS NULL) THEN 'Laboratório faltando'
                                WHEN (p.cd_grupocompra IS NOT NULL AND gc.cd_grupocompra IS NULL) THEN 'Grupo Compra Divergente'
                                WHEN (p.cd_grupobalanco IS NOT NULL AND gb.cd_grupobalanco IS NULL) THEN 'Grupo Balanço Divergente'
                                WHEN (p.id_familia IS NOT NULL AND f.id_familia IS NULL) THEN 'Família Divergente'
                                ELSE 'Nenhuma inconsistência'
                            END AS campo_inconsistente,
                            p.id_produto,
                            p.cd_produto,
                            p.descricao,
                            p.cd_classe,
                            p.cd_grupo,
                            p.cd_laboratorio,
                            p.cd_grupocompra,
                            p.cd_grupobalanco,
                            p.id_familia
                        FROM PRODUTOS p
                        LEFT JOIN CLASSES c ON p.cd_classe = c.cd_classe
                        LEFT JOIN GRUPOS g ON p.cd_grupo = g.cd_grupo
                        LEFT JOIN LABORATORIOS l ON p.cd_laboratorio = l.cd_laboratorio
                        LEFT JOIN GRUPOSCOMPRAS gc ON p.cd_grupocompra = gc.cd_grupocompra
                        LEFT JOIN GRUPOSBALANCO gb ON p.cd_grupobalanco = gb.cd_grupobalanco
                        LEFT JOIN FAMILIAS f ON p.id_familia = f.id_familia
                        WHERE 
                            (p.id_produto is null OR p.id_produto = 0) OR
                            (p.cd_produto = '0' OR p.cd_produto = '') OR
                            (p.cd_classe IS NOT NULL AND c.cd_classe IS NULL) OR
                            (p.cd_classe IS NULL) or
                            (p.cd_grupo IS NOT NULL AND g.cd_grupo IS NULL) OR
                            (p.cd_grupo IS NULL) OR
                            (p.cd_laboratorio IS NOT NULL AND l.cd_laboratorio IS NULL) OR
                            (p.cd_laboratorio IS NULL) OR
                            (p.cd_grupocompra IS NOT NULL AND gc.cd_grupocompra IS NULL) OR
                            (p.cd_grupobalanco IS NOT NULL AND gb.cd_grupobalanco IS NULL) OR
                            (p.id_familia IS NOT NULL AND f.id_familia IS NULL)";

        public FormInconsistencia()
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
                lblConect.Text = "CONECTADO";
                lblConect.ForeColor = System.Drawing.Color.Green;
                fetchButton.Visible = true;
            }
            catch (Exception ex)
            {
                lblConect.Text = "NÃO CONECTADO";
                lblConect.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool VerificarConexao()
        {
            if (con == null || con.State != ConnectionState.Open)
            {
                MessageBox.Show("Sem conexão com o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var caminho = openFileDialog1.FileName;
                lblCaminho.Text = caminho;
                ConnectToDatabase(caminho);
                
            }

        }

        public void btnCorrige_Click(object sender, EventArgs e)
        {
            if (!VerificarConexao())
            {
                return;
            }

            pnlAguarde.Visible = true;
            txtCorrige.Visible = true;

            try
            {
                foreach (var query in querys)
                {
                    using (FbCommand command1 = new FbCommand(query.Value, con))
                    {
                        try
                        {
                            int registrosCorrigidos = command1.ExecuteNonQuery();
                            txtCorrige.AppendText($"{registrosCorrigidos} registros foram corrigidos no campo {query.Key}.\r\n");
                            dataGridView1.DataSource = null;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao corrigir registros: " + ex.Message);
                        }
                    }
                }

                listarInconsistencia();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao corrigir as inconsistências: {ex.Message}");
            }
            finally
            {
                pnlAguarde.Visible = false;
            }
        }


        private void listarInconsistencia()
        {
            
            pnlAguarde.Visible = true;
            
            using (FbCommand command = new FbCommand(queryListar, con))
            {
                using (FbDataAdapter adapter = new FbDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();

                    //await Task.Run(() => adapter.Fill(dataTable));
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;                        
                    }
                    else
                    {
                        pnlAguarde.Visible = false;
                        MessageBox.Show("Nenhuma inconsistência encontrada");
                    }
                }
            }
            pnlAguarde.Visible= false;

        }

        public void fetchButton_Click(object sender, EventArgs e)
        {
            if (!VerificarConexao())
            {
                return;
            }

            try
            {
                listarInconsistencia();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar as inconsistências: {ex.Message}");
            }

        }
    }
}
