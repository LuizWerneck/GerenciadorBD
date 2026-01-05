namespace gerenciadorBanco
{
    partial class FormAlteracaoDados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlteracaoDados));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.btnLocalizaBD = new System.Windows.Forms.Button();
            this.pnlLimpa = new System.Windows.Forms.Panel();
            this.pnlAguarde = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblValidade = new System.Windows.Forms.Label();
            this.btnCarregaCert = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNFCEToken = new System.Windows.Forms.TextBox();
            this.txtNFCEIDtoken = new System.Windows.Forms.TextBox();
            this.txtNFCESerie = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtIE = new System.Windows.Forms.TextBox();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.txtNomeFantasia = new System.Windows.Forms.TextBox();
            this.txtCODIGO = new System.Windows.Forms.TextBox();
            this.txtCDFILIAL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pnlLimpa.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(471, 70);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(239, 452);
            this.txtOutput.TabIndex = 4;
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
            this.pnlLimpa.Controls.Add(this.pnlAguarde);
            this.pnlLimpa.Controls.Add(this.panel1);
            this.pnlLimpa.Controls.Add(this.btnLocalizaBD);
            this.pnlLimpa.Controls.Add(this.lblCaminho);
            this.pnlLimpa.Controls.Add(this.lblStatus);
            this.pnlLimpa.Controls.Add(this.txtOutput);
            this.pnlLimpa.Location = new System.Drawing.Point(0, 0);
            this.pnlLimpa.Name = "pnlLimpa";
            this.pnlLimpa.Size = new System.Drawing.Size(722, 532);
            this.pnlLimpa.TabIndex = 9;
            // 
            // pnlAguarde
            // 
            this.pnlAguarde.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlAguarde.BackgroundImage")));
            this.pnlAguarde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAguarde.Location = new System.Drawing.Point(219, 11);
            this.pnlAguarde.Name = "pnlAguarde";
            this.pnlAguarde.Size = new System.Drawing.Size(596, 40);
            this.pnlAguarde.TabIndex = 9;
            this.pnlAguarde.Tag = "";
            this.pnlAguarde.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.lblValidade);
            this.panel1.Controls.Add(this.btnCarregaCert);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtNFCEToken);
            this.panel1.Controls.Add(this.txtNFCEIDtoken);
            this.panel1.Controls.Add(this.txtNFCESerie);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtIE);
            this.panel1.Controls.Add(this.txtCNPJ);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtCEP);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtUF);
            this.panel1.Controls.Add(this.txtCidade);
            this.panel1.Controls.Add(this.txtBairro);
            this.panel1.Controls.Add(this.txtNumero);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtComplemento);
            this.panel1.Controls.Add(this.txtEndereco);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtRazao);
            this.panel1.Controls.Add(this.txtNomeFantasia);
            this.panel1.Controls.Add(this.txtCODIGO);
            this.panel1.Controls.Add(this.txtCDFILIAL);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 452);
            this.panel1.TabIndex = 10;
            // 
            // lblValidade
            // 
            this.lblValidade.AutoSize = true;
            this.lblValidade.ForeColor = System.Drawing.Color.White;
            this.lblValidade.Location = new System.Drawing.Point(242, 355);
            this.lblValidade.Name = "lblValidade";
            this.lblValidade.Size = new System.Drawing.Size(0, 13);
            this.lblValidade.TabIndex = 36;
            // 
            // btnCarregaCert
            // 
            this.btnCarregaCert.Enabled = false;
            this.btnCarregaCert.Location = new System.Drawing.Point(115, 350);
            this.btnCarregaCert.Name = "btnCarregaCert";
            this.btnCarregaCert.Size = new System.Drawing.Size(114, 23);
            this.btnCarregaCert.TabIndex = 35;
            this.btnCarregaCert.Text = "Carregar Certificado";
            this.btnCarregaCert.UseVisualStyleBackColor = true;
            this.btnCarregaCert.Click += new System.EventHandler(this.btnCarregaCert_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Enabled = false;
            this.txtSenha.Location = new System.Drawing.Point(3, 353);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(91, 20);
            this.txtSenha.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(3, 337);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Senha Certificado";
            // 
            // txtNFCEToken
            // 
            this.txtNFCEToken.Enabled = false;
            this.txtNFCEToken.Location = new System.Drawing.Point(144, 305);
            this.txtNFCEToken.Name = "txtNFCEToken";
            this.txtNFCEToken.Size = new System.Drawing.Size(291, 20);
            this.txtNFCEToken.TabIndex = 32;
            this.txtNFCEToken.Tag = "nfcetoken";
            // 
            // txtNFCEIDtoken
            // 
            this.txtNFCEIDtoken.Enabled = false;
            this.txtNFCEIDtoken.Location = new System.Drawing.Point(65, 305);
            this.txtNFCEIDtoken.Name = "txtNFCEIDtoken";
            this.txtNFCEIDtoken.Size = new System.Drawing.Size(62, 20);
            this.txtNFCEIDtoken.TabIndex = 31;
            this.txtNFCEIDtoken.Tag = "nfcecidtoken";
            // 
            // txtNFCESerie
            // 
            this.txtNFCESerie.Enabled = false;
            this.txtNFCESerie.Location = new System.Drawing.Point(3, 305);
            this.txtNFCESerie.Name = "txtNFCESerie";
            this.txtNFCESerie.Size = new System.Drawing.Size(44, 20);
            this.txtNFCESerie.TabIndex = 30;
            this.txtNFCESerie.Tag = "nfceserie";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(141, 289);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "Token";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(3, 267);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "- NFCE -";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(62, 289);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "ID Token";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(3, 289);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Série";
            // 
            // txtIE
            // 
            this.txtIE.Enabled = false;
            this.txtIE.Location = new System.Drawing.Point(245, 231);
            this.txtIE.Name = "txtIE";
            this.txtIE.Size = new System.Drawing.Size(131, 20);
            this.txtIE.TabIndex = 25;
            this.txtIE.Tag = "inscricao";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.Enabled = false;
            this.txtCNPJ.Location = new System.Drawing.Point(101, 231);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(113, 20);
            this.txtCNPJ.TabIndex = 24;
            this.txtCNPJ.Tag = "cgc";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(242, 215);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Inscrição Estadual";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(98, 215);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "CNPJ (CGC)";
            // 
            // txtCEP
            // 
            this.txtCEP.Enabled = false;
            this.txtCEP.Location = new System.Drawing.Point(3, 231);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(78, 20);
            this.txtCEP.TabIndex = 21;
            this.txtCEP.Tag = "cep";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(3, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "CEP";
            // 
            // txtUF
            // 
            this.txtUF.Enabled = false;
            this.txtUF.Location = new System.Drawing.Point(397, 192);
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(38, 20);
            this.txtUF.TabIndex = 19;
            this.txtUF.Tag = "uf";
            // 
            // txtCidade
            // 
            this.txtCidade.Enabled = false;
            this.txtCidade.Location = new System.Drawing.Point(245, 192);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(131, 20);
            this.txtCidade.TabIndex = 18;
            this.txtCidade.Tag = "cidade";
            // 
            // txtBairro
            // 
            this.txtBairro.Enabled = false;
            this.txtBairro.Location = new System.Drawing.Point(83, 192);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(131, 20);
            this.txtBairro.TabIndex = 17;
            this.txtBairro.Tag = "bairro";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(3, 192);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(59, 20);
            this.txtNumero.TabIndex = 16;
            this.txtNumero.Tag = "numero";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(394, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "UF";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(242, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Cidade";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(80, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Bairro";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Número";
            // 
            // txtComplemento
            // 
            this.txtComplemento.Enabled = false;
            this.txtComplemento.Location = new System.Drawing.Point(283, 153);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(127, 20);
            this.txtComplemento.TabIndex = 11;
            this.txtComplemento.Tag = "complemento";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Enabled = false;
            this.txtEndereco.Location = new System.Drawing.Point(3, 153);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(244, 20);
            this.txtEndereco.TabIndex = 10;
            this.txtEndereco.Tag = "endereco";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(280, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Complemento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Endereço";
            // 
            // txtRazao
            // 
            this.txtRazao.Enabled = false;
            this.txtRazao.Location = new System.Drawing.Point(3, 114);
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(244, 20);
            this.txtRazao.TabIndex = 7;
            this.txtRazao.Tag = "razao";
            // 
            // txtNomeFantasia
            // 
            this.txtNomeFantasia.Enabled = false;
            this.txtNomeFantasia.Location = new System.Drawing.Point(3, 75);
            this.txtNomeFantasia.Name = "txtNomeFantasia";
            this.txtNomeFantasia.Size = new System.Drawing.Size(244, 20);
            this.txtNomeFantasia.TabIndex = 6;
            this.txtNomeFantasia.Tag = "nomefantasia";
            // 
            // txtCODIGO
            // 
            this.txtCODIGO.Enabled = false;
            this.txtCODIGO.Location = new System.Drawing.Point(115, 28);
            this.txtCODIGO.Name = "txtCODIGO";
            this.txtCODIGO.Size = new System.Drawing.Size(76, 20);
            this.txtCODIGO.TabIndex = 5;
            this.txtCODIGO.Tag = "codigousuario";
            // 
            // txtCDFILIAL
            // 
            this.txtCDFILIAL.Enabled = false;
            this.txtCDFILIAL.Location = new System.Drawing.Point(3, 28);
            this.txtCDFILIAL.Name = "txtCDFILIAL";
            this.txtCDFILIAL.Size = new System.Drawing.Size(56, 20);
            this.txtCDFILIAL.TabIndex = 4;
            this.txtCDFILIAL.Tag = "CD_FILIAL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Razão";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nome Fantasia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(112, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código Usuário";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CD_FILIAL";
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(0, 388);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(106, 50);
            this.btnEditar.TabIndex = 37;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(124, 388);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(105, 50);
            this.btnSalvar.TabIndex = 38;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FormAlteracaoDados
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
            this.Name = "FormAlteracaoDados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LimpaBanco";
            this.pnlLimpa.ResumeLayout(false);
            this.pnlLimpa.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCaminho;
        private System.Windows.Forms.Button btnLocalizaBD;
        private System.Windows.Forms.Panel pnlLimpa;
        private System.Windows.Forms.Panel pnlAguarde;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCDFILIAL;
        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.TextBox txtNomeFantasia;
        private System.Windows.Forms.TextBox txtCODIGO;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtIE;
        private System.Windows.Forms.TextBox txtCNPJ;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNFCEToken;
        private System.Windows.Forms.TextBox txtNFCEIDtoken;
        private System.Windows.Forms.TextBox txtNFCESerie;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnCarregaCert;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblValidade;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnSalvar;
    }
}

