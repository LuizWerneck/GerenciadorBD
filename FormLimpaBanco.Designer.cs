namespace gerenciadorBanco
{
    partial class FormLimpaBanco
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLimpaBanco));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.btnMarcar = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.chkList = new System.Windows.Forms.CheckedListBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.btnLocalizaBD = new System.Windows.Forms.Button();
            this.pnlLimpa = new System.Windows.Forms.Panel();
            this.pnlAguarde = new System.Windows.Forms.Panel();
            this.chkControle = new System.Windows.Forms.CheckBox();
            this.pnlLimpa.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btnMarcar
            // 
            this.btnMarcar.Enabled = false;
            this.btnMarcar.Location = new System.Drawing.Point(12, 473);
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.Size = new System.Drawing.Size(107, 33);
            this.btnMarcar.TabIndex = 8;
            this.btnMarcar.Text = "Marcar Todos";
            this.btnMarcar.UseVisualStyleBackColor = true;
            this.btnMarcar.Click += new System.EventHandler(this.btnMarcar_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(471, 473);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(108, 33);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(355, 70);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(355, 394);
            this.txtOutput.TabIndex = 4;
            // 
            // chkList
            // 
            this.chkList.CheckOnClick = true;
            this.chkList.Enabled = false;
            this.chkList.FormattingEnabled = true;
            this.chkList.Items.AddRange(new object[] {
            "Deletar Lançamentos",
            "Deletar Caixas",
            "Deletar Operadores",
            "Deletar Vendedores",
            "Deletar Vendas/Entregas",
            "Deletar NFCE/NFCECOPIA",
            "Deletar Compras",
            "Deletar Contas a Receber",
            "Deletar Contas a Pagar",
            "Deletar Transferências",
            "Deletar NFEs",
            "Deletar Parametros de PIX",
            "Deletar Dados IFOOD",
            "Deletar Dados FarmaciasAPP",
            "Deletar LOGs",
            "Deletar Dados PAF",
            "Deletar Dados SINTEGRA",
            "Deletar Encartes",
            "Deletar Auditoria/Informante/Eventos",
            "Deletar EstoquePosVenda/PosicaoEstoqueData",
            "Deletar Balanço",
            "Deletar Produtos_Lotes",
            "Deletar Deletados",
            "Deletar Clientes"});
            this.chkList.Location = new System.Drawing.Point(12, 70);
            this.chkList.Name = "chkList";
            this.chkList.Size = new System.Drawing.Size(326, 394);
            this.chkList.TabIndex = 5;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(602, 473);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(108, 33);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Enabled = false;
            this.btnLimpar.Location = new System.Drawing.Point(137, 473);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(108, 33);
            this.btnLimpar.TabIndex = 6;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(604, 50);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(106, 17);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Não Conectado";
            // 
            // lblCaminho
            // 
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCaminho.Location = new System.Drawing.Point(12, 54);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(146, 13);
            this.lblCaminho.TabIndex = 1;
            this.lblCaminho.Text = "Caminho do Banco de Dados";
            // 
            // btnLocalizaBD
            // 
            this.btnLocalizaBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocalizaBD.Location = new System.Drawing.Point(12, 13);
            this.btnLocalizaBD.Name = "btnLocalizaBD";
            this.btnLocalizaBD.Size = new System.Drawing.Size(163, 38);
            this.btnLocalizaBD.TabIndex = 0;
            this.btnLocalizaBD.Text = "Localizar Banco de Dados";
            this.btnLocalizaBD.UseVisualStyleBackColor = true;
            this.btnLocalizaBD.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlLimpa
            // 
            this.pnlLimpa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.pnlLimpa.Controls.Add(this.chkControle);
            this.pnlLimpa.Controls.Add(this.pnlAguarde);
            this.pnlLimpa.Controls.Add(this.btnMarcar);
            this.pnlLimpa.Controls.Add(this.btnLocalizaBD);
            this.pnlLimpa.Controls.Add(this.lblCaminho);
            this.pnlLimpa.Controls.Add(this.lblStatus);
            this.pnlLimpa.Controls.Add(this.btnLimpar);
            this.pnlLimpa.Controls.Add(this.btnRestore);
            this.pnlLimpa.Controls.Add(this.chkList);
            this.pnlLimpa.Controls.Add(this.txtOutput);
            this.pnlLimpa.Controls.Add(this.btnBackup);
            this.pnlLimpa.Location = new System.Drawing.Point(0, 0);
            this.pnlLimpa.Name = "pnlLimpa";
            this.pnlLimpa.Size = new System.Drawing.Size(722, 532);
            this.pnlLimpa.TabIndex = 9;
            // 
            // pnlAguarde
            // 
            this.pnlAguarde.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAguarde.BackgroundImage")));
            this.pnlAguarde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAguarde.Location = new System.Drawing.Point(61, 249);
            this.pnlAguarde.Name = "pnlAguarde";
            this.pnlAguarde.Size = new System.Drawing.Size(596, 40);
            this.pnlAguarde.TabIndex = 9;
            this.pnlAguarde.Tag = "";
            this.pnlAguarde.Visible = false;
            // 
            // chkControle
            // 
            this.chkControle.AutoSize = true;
            this.chkControle.ForeColor = System.Drawing.SystemColors.Control;
            this.chkControle.Location = new System.Drawing.Point(252, 482);
            this.chkControle.Name = "chkControle";
            this.chkControle.Size = new System.Drawing.Size(108, 17);
            this.chkControle.TabIndex = 10;
            this.chkControle.Text = "Atualizar Controle";
            this.chkControle.UseVisualStyleBackColor = true;
            // 
            // FormLimpaBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(725, 534);
            this.Controls.Add(this.pnlLimpa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormLimpaBanco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LimpaBanco";
            this.pnlLimpa.ResumeLayout(false);
            this.pnlLimpa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.Button btnMarcar;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.CheckedListBox chkList;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.Button btnLocalizaBD;
        private System.Windows.Forms.Panel pnlLimpa;
        private System.Windows.Forms.Panel pnlAguarde;
        private System.Windows.Forms.CheckBox chkControle;
    }
}

