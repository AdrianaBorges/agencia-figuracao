namespace Agencia.Relatorios
{
    partial class frmInformeINSS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformeINSS));
            this.tabDiversos = new System.Windows.Forms.TabControl();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.qtdPorNota = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstRecibo = new System.Windows.Forms.ListView();
            this.chkSelecionar = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cboNmeFirma = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.txtDe = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtAte = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstMatricula = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tstNome = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAtualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tabDiversos.SuspendLayout();
            this.tabConsulta.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolMenuColaborador.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDiversos
            // 
            this.tabDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDiversos.Controls.Add(this.tabConsulta);
            this.tabDiversos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabDiversos.Location = new System.Drawing.Point(6, 6);
            this.tabDiversos.Name = "tabDiversos";
            this.tabDiversos.SelectedIndex = 0;
            this.tabDiversos.Size = new System.Drawing.Size(1212, 541);
            this.tabDiversos.TabIndex = 140;
            // 
            // tabConsulta
            // 
            this.tabConsulta.Controls.Add(this.statusStrip1);
            this.tabConsulta.Controls.Add(this.lstRecibo);
            this.tabConsulta.Controls.Add(this.chkSelecionar);
            this.tabConsulta.Controls.Add(this.toolStrip1);
            this.tabConsulta.Controls.Add(this.toolMenuColaborador);
            this.tabConsulta.ForeColor = System.Drawing.Color.Teal;
            this.tabConsulta.Location = new System.Drawing.Point(4, 24);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsulta.Size = new System.Drawing.Size(1204, 513);
            this.tabConsulta.TabIndex = 0;
            this.tabConsulta.Text = "Consulta(s)";
            this.tabConsulta.ToolTipText = "Consultas Diversas";
            this.tabConsulta.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qtdPorNota});
            this.statusStrip1.Location = new System.Drawing.Point(3, 488);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1198, 22);
            this.statusStrip1.TabIndex = 262;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // qtdPorNota
            // 
            this.qtdPorNota.Name = "qtdPorNota";
            this.qtdPorNota.Size = new System.Drawing.Size(1183, 17);
            this.qtdPorNota.Spring = true;
            this.qtdPorNota.Text = "0";
            // 
            // lstRecibo
            // 
            this.lstRecibo.AllowColumnReorder = true;
            this.lstRecibo.AutoArrange = false;
            this.lstRecibo.CheckBoxes = true;
            this.lstRecibo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstRecibo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRecibo.ForeColor = System.Drawing.Color.Teal;
            this.lstRecibo.FullRowSelect = true;
            this.lstRecibo.GridLines = true;
            this.lstRecibo.Location = new System.Drawing.Point(3, 53);
            this.lstRecibo.MultiSelect = false;
            this.lstRecibo.Name = "lstRecibo";
            this.lstRecibo.Size = new System.Drawing.Size(1198, 457);
            this.lstRecibo.TabIndex = 261;
            this.lstRecibo.UseCompatibleStateImageBehavior = false;
            this.lstRecibo.View = System.Windows.Forms.View.Details;
            // 
            // chkSelecionar
            // 
            this.chkSelecionar.AutoSize = true;
            this.chkSelecionar.Location = new System.Drawing.Point(13, 26);
            this.chkSelecionar.Name = "chkSelecionar";
            this.chkSelecionar.Size = new System.Drawing.Size(113, 19);
            this.chkSelecionar.TabIndex = 260;
            this.chkSelecionar.Text = "Selecionar todos";
            this.chkSelecionar.UseVisualStyleBackColor = true;
            this.chkSelecionar.CheckedChanged += new System.EventHandler(this.chkSelecionar_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(3, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1198, 25);
            this.toolStrip1.TabIndex = 259;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolMenuColaborador
            // 
            this.toolMenuColaborador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenuColaborador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.cboNmeFirma,
            this.toolStripSeparator4,
            this.toolStripLabel5,
            this.txtDe,
            this.toolStripLabel1,
            this.txtAte,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.tstMatricula,
            this.toolStripLabel4,
            this.tstNome,
            this.toolStripSeparator5,
            this.toolAtualizar,
            this.toolStripSeparator2,
            this.toolImprimir,
            this.toolStripSeparator3});
            this.toolMenuColaborador.Location = new System.Drawing.Point(3, 3);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(1198, 25);
            this.toolMenuColaborador.TabIndex = 258;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabel3.Text = "Nome-Firma:";
            // 
            // cboNmeFirma
            // 
            this.cboNmeFirma.Name = "cboNmeFirma";
            this.cboNmeFirma.Size = new System.Drawing.Size(250, 25);
            this.cboNmeFirma.SelectedIndexChanged += new System.EventHandler(this.cboNmeFirma_SelectedIndexChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel5.Text = "Período:";
            // 
            // txtDe
            // 
            this.txtDe.Name = "txtDe";
            this.txtDe.Size = new System.Drawing.Size(70, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(23, 22);
            this.toolStripLabel1.Text = "até";
            // 
            // txtAte
            // 
            this.txtAte.Name = "txtAte";
            this.txtAte.Size = new System.Drawing.Size(70, 25);
            this.txtAte.ToolTipText = "DD/MM/YYYY";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel2.Text = "Código:";
            // 
            // tstMatricula
            // 
            this.tstMatricula.Name = "tstMatricula";
            this.tstMatricula.Size = new System.Drawing.Size(70, 25);
            this.tstMatricula.ToolTipText = "DD/MM/YYYY";
            this.tstMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstMatricula_KeyPress);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(98, 22);
            this.toolStripLabel4.Text = "Nome-Figurante:";
            // 
            // tstNome
            // 
            this.tstNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tstNome.Name = "tstNome";
            this.tstNome.Size = new System.Drawing.Size(150, 25);
            this.tstNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstNome_KeyPress);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAtualizar
            // 
            this.toolAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("toolAtualizar.Image")));
            this.toolAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAtualizar.Name = "toolAtualizar";
            this.toolAtualizar.Size = new System.Drawing.Size(57, 22);
            this.toolAtualizar.Text = "Filtrar";
            this.toolAtualizar.ToolTipText = "Filtrar Figurante";
            this.toolAtualizar.Click += new System.EventHandler(this.toolAtualizar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolImprimir
            // 
            this.toolImprimir.Image = ((System.Drawing.Image)(resources.GetObject("toolImprimir.Image")));
            this.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolImprimir.Name = "toolImprimir";
            this.toolImprimir.Size = new System.Drawing.Size(73, 22);
            this.toolImprimir.Text = "Imprimir";
            this.toolImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolImprimir.Click += new System.EventHandler(this.toolImprimir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // frmInformeINSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 614);
            this.Controls.Add(this.tabDiversos);
            this.Name = "frmInformeINSS";
            this.Text = "frmInformeINSS";
            this.Load += new System.EventHandler(this.frmInformeINSS_Load);
            this.tabDiversos.ResumeLayout(false);
            this.tabConsulta.ResumeLayout(false);
            this.tabConsulta.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolMenuColaborador.ResumeLayout(false);
            this.toolMenuColaborador.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDiversos;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.ToolStrip toolMenuColaborador;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tstMatricula;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox tstNome;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolAtualizar;
        private System.Windows.Forms.ToolStripButton toolImprimir;
        private System.Windows.Forms.ToolStripTextBox txtDe;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtAte;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox cboNmeFirma;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox chkSelecionar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ListView lstRecibo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel qtdPorNota;
    }
}