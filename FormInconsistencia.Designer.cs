namespace gerenciadorBanco
{
    partial class FormInconsistencia

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInconsistencia));
            this.fetchButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblConect = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.btnCorrige = new System.Windows.Forms.Button();
            this.txtCorrige = new System.Windows.Forms.TextBox();
            this.pnlAguarde = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fetchButton
            // 
            this.fetchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchButton.Location = new System.Drawing.Point(573, 11);
            this.fetchButton.Name = "fetchButton";
            this.fetchButton.Size = new System.Drawing.Size(137, 35);
            this.fetchButton.TabIndex = 0;
            this.fetchButton.Text = "Listar Inconsistências";
            this.fetchButton.UseVisualStyleBackColor = true;
            this.fetchButton.Visible = false;
            this.fetchButton.Click += new System.EventHandler(this.fetchButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(698, 369);
            this.dataGridView1.TabIndex = 1;
            // 
            // lblConect
            // 
            this.lblConect.AutoSize = true;
            this.lblConect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConect.ForeColor = System.Drawing.Color.Red;
            this.lblConect.Location = new System.Drawing.Point(604, 48);
            this.lblConect.MaximumSize = new System.Drawing.Size(150, 100);
            this.lblConect.Name = "lblConect";
            this.lblConect.Size = new System.Drawing.Size(106, 17);
            this.lblConect.TabIndex = 2;
            this.lblConect.Text = "Não Conectado";
            this.lblConect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Localizar Banco de Dados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblCaminho
            // 
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaminho.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCaminho.Location = new System.Drawing.Point(12, 50);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(167, 15);
            this.lblCaminho.TabIndex = 4;
            this.lblCaminho.Text = "Caminho do banco de Dados";
            // 
            // btnCorrige
            // 
            this.btnCorrige.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorrige.Location = new System.Drawing.Point(514, 452);
            this.btnCorrige.Name = "btnCorrige";
            this.btnCorrige.Size = new System.Drawing.Size(196, 68);
            this.btnCorrige.TabIndex = 5;
            this.btnCorrige.Text = "Realizar correções básicas";
            this.btnCorrige.UseVisualStyleBackColor = true;
            this.btnCorrige.Click += new System.EventHandler(this.btnCorrige_Click);
            // 
            // txtCorrige
            // 
            this.txtCorrige.Location = new System.Drawing.Point(12, 452);
            this.txtCorrige.Multiline = true;
            this.txtCorrige.Name = "txtCorrige";
            this.txtCorrige.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCorrige.Size = new System.Drawing.Size(496, 68);
            this.txtCorrige.TabIndex = 6;
            this.txtCorrige.Visible = false;
            // 
            // pnlAguarde
            // 
            this.pnlAguarde.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAguarde.BackgroundImage")));
            this.pnlAguarde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAguarde.Location = new System.Drawing.Point(83, 222);
            this.pnlAguarde.Name = "pnlAguarde";
            this.pnlAguarde.Size = new System.Drawing.Size(596, 40);
            this.pnlAguarde.TabIndex = 7;
            this.pnlAguarde.Tag = "";
            this.pnlAguarde.Visible = false;
            // 
            // FormInconsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(722, 532);
            this.Controls.Add(this.pnlAguarde);
            this.Controls.Add(this.txtCorrige);
            this.Controls.Add(this.btnCorrige);
            this.Controls.Add(this.lblCaminho);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblConect);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.fetchButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormInconsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inconsistências Cadastro Produtos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fetchButton;
        private System.Windows.Forms.Label lblConect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.Button btnCorrige;
        private System.Windows.Forms.TextBox txtCorrige;
        private System.Windows.Forms.Panel pnlAguarde;
    }
}

