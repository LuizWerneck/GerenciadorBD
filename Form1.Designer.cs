namespace gerenciadorBanco
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.menuButton = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnIncosistencia = new System.Windows.Forms.Button();
            this.lblDataHora = new System.Windows.Forms.Label();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnMinimiza = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sidebar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sidebar.Controls.Add(this.menuButton);
            this.sidebar.Controls.Add(this.btnLimpar);
            this.sidebar.Controls.Add(this.btnIncosistencia);
            this.sidebar.Controls.Add(this.lblDataHora);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.MaximumSize = new System.Drawing.Size(171, 563);
            this.sidebar.MinimumSize = new System.Drawing.Size(65, 563);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(171, 563);
            this.sidebar.TabIndex = 0;
            // 
            // menuButton
            // 
            this.menuButton.FlatAppearance.BorderSize = 0;
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.ForeColor = System.Drawing.Color.White;
            this.menuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuButton.Location = new System.Drawing.Point(3, 32);
            this.menuButton.Margin = new System.Windows.Forms.Padding(3, 32, 3, 30);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(165, 62);
            this.menuButton.TabIndex = 1;
            this.menuButton.Text = "Início";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            this.menuButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.menuButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.menuButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            // 
            // btnLimpar
            // 
            this.btnLimpar.FlatAppearance.BorderSize = 0;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.ForeColor = System.Drawing.Color.White;
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpar.Location = new System.Drawing.Point(3, 127);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(165, 62);
            this.btnLimpar.TabIndex = 2;
            this.btnLimpar.Text = "Limpeza de Banco";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnIncosistencia
            // 
            this.btnIncosistencia.FlatAppearance.BorderSize = 0;
            this.btnIncosistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncosistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncosistencia.ForeColor = System.Drawing.Color.White;
            this.btnIncosistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncosistencia.Location = new System.Drawing.Point(3, 222);
            this.btnIncosistencia.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.btnIncosistencia.Name = "btnIncosistencia";
            this.btnIncosistencia.Size = new System.Drawing.Size(165, 62);
            this.btnIncosistencia.TabIndex = 3;
            this.btnIncosistencia.Text = "Verificar Inconsistências";
            this.btnIncosistencia.UseVisualStyleBackColor = true;
            this.btnIncosistencia.Click += new System.EventHandler(this.btnIncosistencia_Click);
            // 
            // lblDataHora
            // 
            this.lblDataHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataHora.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDataHora.Location = new System.Drawing.Point(3, 314);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Padding = new System.Windows.Forms.Padding(0, 230, 0, 0);
            this.lblDataHora.Size = new System.Drawing.Size(0, 245);
            this.lblDataHora.TabIndex = 4;
            this.lblDataHora.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.pnlPrincipal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlPrincipal.BackgroundImage")));
            this.pnlPrincipal.Location = new System.Drawing.Point(171, 31);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(722, 532);
            this.pnlPrincipal.TabIndex = 1;
            this.pnlPrincipal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.pnlPrincipal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.pnlPrincipal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flowLayoutPanel1.Controls.Add(this.btnFechar);
            this.flowLayoutPanel1.Controls.Add(this.btnMinimiza);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(171, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(722, 32);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.flowLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.flowLayoutPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            // 
            // btnFechar
            // 
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(692, 5);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(20, 20);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnMinimiza
            // 
            this.btnMinimiza.FlatAppearance.BorderSize = 0;
            this.btnMinimiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimiza.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimiza.Image")));
            this.btnMinimiza.Location = new System.Drawing.Point(657, 5);
            this.btnMinimiza.Margin = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.btnMinimiza.Name = "btnMinimiza";
            this.btnMinimiza.Size = new System.Drawing.Size(20, 20);
            this.btnMinimiza.TabIndex = 1;
            this.btnMinimiza.UseVisualStyleBackColor = true;
            this.btnMinimiza.Click += new System.EventHandler(this.btnMinimiza_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 563);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.pnlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciador Banco Firebird";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_MouseUp);
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnMinimiza;
        private System.Windows.Forms.Button btnIncosistencia;
        private System.Windows.Forms.Label lblDataHora;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
    }
}

