namespace Agencia.WindowsUI
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plnLogin = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.BtnEntrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSair = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMens1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CboUsuario = new System.Windows.Forms.ComboBox();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtSenha = new System.Windows.Forms.TextBox();
            this.stStatusApp = new System.Windows.Forms.StatusStrip();
            this.tsUsuarioLogado = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plnLogin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.stStatusApp.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plnLogin
            // 
            this.plnLogin.Controls.Add(this.topPanel);
            this.plnLogin.Controls.Add(this.BtnEntrar);
            this.plnLogin.Controls.Add(this.label1);
            this.plnLogin.Controls.Add(this.label2);
            this.plnLogin.Controls.Add(this.BtnSair);
            this.plnLogin.Controls.Add(this.groupBox2);
            this.plnLogin.Controls.Add(this.groupBox1);
            this.plnLogin.Location = new System.Drawing.Point(265, 135);
            this.plnLogin.Name = "plnLogin";
            this.plnLogin.Size = new System.Drawing.Size(461, 285);
            this.plnLogin.TabIndex = 15;
            // 
            // topPanel
            // 
            this.topPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            this.topPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanel.BackColor = System.Drawing.Color.Teal;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(461, 21);
            this.topPanel.TabIndex = 186;
            // 
            // BtnEntrar
            // 
            this.BtnEntrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnEntrar.ForeColor = System.Drawing.Color.Teal;
            this.BtnEntrar.Location = new System.Drawing.Point(223, 249);
            this.BtnEntrar.Name = "BtnEntrar";
            this.BtnEntrar.Size = new System.Drawing.Size(104, 26);
            this.BtnEntrar.TabIndex = 3;
            this.BtnEntrar.Text = "&Entrar";
            this.BtnEntrar.UseVisualStyleBackColor = true;
            this.BtnEntrar.Click += new System.EventHandler(this.BtnEntrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(17, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 184;
            this.label1.Text = "Versão 2014.01.21";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(17, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 185;
            this.label2.Text = "Borges Tecnology";
            // 
            // BtnSair
            // 
            this.BtnSair.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnSair.ForeColor = System.Drawing.Color.Teal;
            this.BtnSair.Location = new System.Drawing.Point(344, 249);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(104, 26);
            this.BtnSair.TabIndex = 4;
            this.BtnSair.Text = "&Sair";
            this.BtnSair.UseVisualStyleBackColor = true;
            this.BtnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMens1);
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(19, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 105);
            this.groupBox2.TabIndex = 181;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mensagem(s):";
            // 
            // lblMens1
            // 
            this.lblMens1.AutoSize = true;
            this.lblMens1.ForeColor = System.Drawing.Color.Red;
            this.lblMens1.Location = new System.Drawing.Point(14, 28);
            this.lblMens1.Name = "lblMens1";
            this.lblMens1.Size = new System.Drawing.Size(49, 13);
            this.lblMens1.TabIndex = 0;
            this.lblMens1.Text = "lblMens1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CboUsuario);
            this.groupBox1.Controls.Add(this.BtnRegistrar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtSenha);
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(19, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 83);
            this.groupBox1.TabIndex = 180;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do Usuário:";
            // 
            // CboUsuario
            // 
            this.CboUsuario.FormattingEnabled = true;
            this.CboUsuario.Location = new System.Drawing.Point(81, 22);
            this.CboUsuario.Name = "CboUsuario";
            this.CboUsuario.Size = new System.Drawing.Size(339, 21);
            this.CboUsuario.TabIndex = 0;
            this.CboUsuario.SelectedIndexChanged += new System.EventHandler(this.CboUsuario_SelectedIndexChanged);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnRegistrar.ForeColor = System.Drawing.Color.Teal;
            this.BtnRegistrar.Location = new System.Drawing.Point(204, 44);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(126, 27);
            this.BtnRegistrar.TabIndex = 2;
            this.BtnRegistrar.Text = "&Registrar Senha";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(17, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 180;
            this.label3.Text = "Senha:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(9, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 179;
            this.label6.Text = "Usuário:";
            // 
            // TxtSenha
            // 
            this.TxtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSenha.Location = new System.Drawing.Point(81, 47);
            this.TxtSenha.Name = "TxtSenha";
            this.TxtSenha.PasswordChar = '*';
            this.TxtSenha.Size = new System.Drawing.Size(100, 20);
            this.TxtSenha.TabIndex = 1;
            this.TxtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSenha_KeyPress);
            // 
            // stStatusApp
            // 
            this.stStatusApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsUsuarioLogado});
            this.stStatusApp.Location = new System.Drawing.Point(0, 525);
            this.stStatusApp.Name = "stStatusApp";
            this.stStatusApp.Size = new System.Drawing.Size(954, 22);
            this.stStatusApp.TabIndex = 17;
            this.stStatusApp.Text = "statusStrip1";
            // 
            // tsUsuarioLogado
            // 
            this.tsUsuarioLogado.ForeColor = System.Drawing.Color.Teal;
            this.tsUsuarioLogado.Name = "tsUsuarioLogado";
            this.tsUsuarioLogado.Size = new System.Drawing.Size(79, 17);
            this.tsUsuarioLogado.Text = "tsUsuarioLogado";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivosToolStripMenuItem,
            this.cadastrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(954, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivosToolStripMenuItem
            // 
            this.arquivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.arquivosToolStripMenuItem.Name = "arquivosToolStripMenuItem";
            this.arquivosToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.arquivosToolStripMenuItem.Text = "Arquivos";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtoToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.produtoToolStripMenuItem.Text = "Produto";
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 547);
            this.Controls.Add(this.stStatusApp);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.plnLogin);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenuPrincipal";
            this.Text = "frmMenuPrincipal";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.plnLogin.ResumeLayout(false);
            this.plnLogin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.stStatusApp.ResumeLayout(false);
            this.stStatusApp.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plnLogin;
        private System.Windows.Forms.Button BtnEntrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMens1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CboUsuario;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtSenha;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.StatusStrip stStatusApp;
        private System.Windows.Forms.ToolStripStatusLabel tsUsuarioLogado;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
    }
}