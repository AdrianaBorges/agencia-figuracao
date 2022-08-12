namespace Agencia.WindowsUI
{
    partial class frmUnificaPessoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnificaPessoa));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TxtConsultaC = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAtualizar = new System.Windows.Forms.ToolStripButton();
            this.qtdCorreto = new System.Windows.Forms.ToolStripLabel();
            this.lstCorreto = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.TxtConsultaE = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tooAtualizaE = new System.Windows.Forms.ToolStripButton();
            this.qtdErrado = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.TxtDefinitivo = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tooUnificar = new System.Windows.Forms.ToolStripButton();
            this.lstErrado = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.toolMenuColaborador.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolMenuColaborador);
            this.groupBox1.Controls.Add(this.lstCorreto);
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(945, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1º Localizar Registro CORRETO:";
            // 
            // toolMenuColaborador
            // 
            this.toolMenuColaborador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenuColaborador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TxtConsultaC,
            this.toolStripSeparator1,
            this.toolAtualizar,
            this.qtdCorreto});
            this.toolMenuColaborador.Location = new System.Drawing.Point(3, 19);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(939, 25);
            this.toolMenuColaborador.TabIndex = 260;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(98, 22);
            this.toolStripLabel1.Text = "Nome-Figurante:";
            // 
            // TxtConsultaC
            // 
            this.TxtConsultaC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtConsultaC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConsultaC.Name = "TxtConsultaC";
            this.TxtConsultaC.Size = new System.Drawing.Size(350, 25);
            this.TxtConsultaC.ToolTipText = "Digite aqui para filtrar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAtualizar
            // 
            this.toolAtualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAtualizar.Image = global::Agencia.WindowsUI.Properties.Resources.arrow_refresh;
            this.toolAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAtualizar.Name = "toolAtualizar";
            this.toolAtualizar.Size = new System.Drawing.Size(23, 22);
            this.toolAtualizar.Text = "toolStripLabel2";
            this.toolAtualizar.ToolTipText = "Filtrar Figurante(s)";
            this.toolAtualizar.Click += new System.EventHandler(this.toolAtualizar_Click);
            // 
            // qtdCorreto
            // 
            this.qtdCorreto.Name = "qtdCorreto";
            this.qtdCorreto.Size = new System.Drawing.Size(13, 22);
            this.qtdCorreto.Text = "0";
            // 
            // lstCorreto
            // 
            this.lstCorreto.AllowColumnReorder = true;
            this.lstCorreto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCorreto.AutoArrange = false;
            this.lstCorreto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstCorreto.ForeColor = System.Drawing.Color.Teal;
            this.lstCorreto.FullRowSelect = true;
            this.lstCorreto.GridLines = true;
            this.lstCorreto.Location = new System.Drawing.Point(6, 46);
            this.lstCorreto.MultiSelect = false;
            this.lstCorreto.Name = "lstCorreto";
            this.lstCorreto.Size = new System.Drawing.Size(933, 169);
            this.lstCorreto.TabIndex = 259;
            this.lstCorreto.UseCompatibleStateImageBehavior = false;
            this.lstCorreto.View = System.Windows.Forms.View.Details;
            this.lstCorreto.SelectedIndexChanged += new System.EventHandler(this.lstCorreto_SelectedIndexChanged);
            this.lstCorreto.Click += new System.EventHandler(this.lstCorreto_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Controls.Add(this.lstErrado);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(12, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(942, 277);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2º Localizar Registro ERRADO:";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.TxtConsultaE,
            this.toolStripSeparator3,
            this.tooAtualizaE,
            this.qtdErrado});
            this.toolStrip2.Location = new System.Drawing.Point(3, 44);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(936, 25);
            this.toolStrip2.TabIndex = 263;
            this.toolStrip2.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(98, 22);
            this.toolStripLabel3.Text = "Nome-Figurante:";
            // 
            // TxtConsultaE
            // 
            this.TxtConsultaE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtConsultaE.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConsultaE.Name = "TxtConsultaE";
            this.TxtConsultaE.Size = new System.Drawing.Size(300, 25);
            this.TxtConsultaE.ToolTipText = "Digite aqui para filtrar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tooAtualizaE
            // 
            this.tooAtualizaE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tooAtualizaE.Image = global::Agencia.WindowsUI.Properties.Resources.arrow_refresh;
            this.tooAtualizaE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooAtualizaE.Name = "tooAtualizaE";
            this.tooAtualizaE.Size = new System.Drawing.Size(23, 22);
            this.tooAtualizaE.Text = "toolStripLabel2";
            this.tooAtualizaE.ToolTipText = "Filtrar Figurante(s)";
            this.tooAtualizaE.Click += new System.EventHandler(this.tooAtualizaE_Click);
            // 
            // qtdErrado
            // 
            this.qtdErrado.Name = "qtdErrado";
            this.qtdErrado.Size = new System.Drawing.Size(13, 22);
            this.qtdErrado.Text = "0";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.TxtDefinitivo,
            this.toolStripSeparator2,
            this.tooUnificar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 19);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(936, 25);
            this.toolStrip1.TabIndex = 262;
            this.toolStrip1.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(99, 22);
            this.toolStripLabel2.Text = "Nome-Mantido:  ";
            // 
            // TxtDefinitivo
            // 
            this.TxtDefinitivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtDefinitivo.Enabled = false;
            this.TxtDefinitivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDefinitivo.Name = "TxtDefinitivo";
            this.TxtDefinitivo.Size = new System.Drawing.Size(350, 25);
            this.TxtDefinitivo.ToolTipText = "Digite aqui para filtrar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tooUnificar
            // 
            this.tooUnificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tooUnificar.Image = ((System.Drawing.Image)(resources.GetObject("tooUnificar.Image")));
            this.tooUnificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooUnificar.Name = "tooUnificar";
            this.tooUnificar.Size = new System.Drawing.Size(108, 22);
            this.tooUnificar.Text = "Unificar Dados";
            this.tooUnificar.ToolTipText = "Filtrar Fatura(s)";
            this.tooUnificar.Click += new System.EventHandler(this.tooUnificar_Click);
            // 
            // lstErrado
            // 
            this.lstErrado.AllowColumnReorder = true;
            this.lstErrado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstErrado.AutoArrange = false;
            this.lstErrado.CheckBoxes = true;
            this.lstErrado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstErrado.ForeColor = System.Drawing.Color.Teal;
            this.lstErrado.FullRowSelect = true;
            this.lstErrado.GridLines = true;
            this.lstErrado.Location = new System.Drawing.Point(6, 72);
            this.lstErrado.MultiSelect = false;
            this.lstErrado.Name = "lstErrado";
            this.lstErrado.Size = new System.Drawing.Size(930, 199);
            this.lstErrado.TabIndex = 260;
            this.lstErrado.UseCompatibleStateImageBehavior = false;
            this.lstErrado.View = System.Windows.Forms.View.Details;
            // 
            // frmUnificaPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 577);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmUnificaPessoa";
            this.Text = "frmUnificaPessoa";
            this.Load += new System.EventHandler(this.frmUnificaPessoa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolMenuColaborador.ResumeLayout(false);
            this.toolMenuColaborador.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolMenuColaborador;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox TxtConsultaC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolAtualizar;
        private System.Windows.Forms.ToolStripLabel qtdCorreto;
        private System.Windows.Forms.ListView lstCorreto;
        private System.Windows.Forms.ListView lstErrado;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox TxtConsultaE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tooAtualizaE;
        private System.Windows.Forms.ToolStripLabel qtdErrado;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox TxtDefinitivo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tooUnificar;
    }
}