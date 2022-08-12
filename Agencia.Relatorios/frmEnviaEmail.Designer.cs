namespace Agencia.Relatorios
{
    partial class frmEnviaEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnviaEmail));
            this.tabDiversos = new System.Windows.Forms.TabControl();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.cboNmeFirma = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstMatricula = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tstNome = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAtualizar = new System.Windows.Forms.ToolStripButton();
            this.qtdPorNota = new System.Windows.Forms.ToolStripLabel();
            this.toolEnviaEmail = new System.Windows.Forms.ToolStripButton();
            this.lstRecibo = new System.Windows.Forms.ListView();
            this.tabDiversos.SuspendLayout();
            this.tabConsulta.SuspendLayout();
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
            this.tabDiversos.Location = new System.Drawing.Point(12, 15);
            this.tabDiversos.Name = "tabDiversos";
            this.tabDiversos.SelectedIndex = 0;
            this.tabDiversos.Size = new System.Drawing.Size(1178, 542);
            this.tabDiversos.TabIndex = 139;
            // 
            // tabConsulta
            // 
            this.tabConsulta.Controls.Add(this.toolMenuColaborador);
            this.tabConsulta.Controls.Add(this.lstRecibo);
            this.tabConsulta.ForeColor = System.Drawing.Color.Teal;
            this.tabConsulta.Location = new System.Drawing.Point(4, 24);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsulta.Size = new System.Drawing.Size(1170, 514);
            this.tabConsulta.TabIndex = 0;
            this.tabConsulta.Text = "Consulta(s)";
            this.tabConsulta.ToolTipText = "Consultas Diversas";
            this.tabConsulta.UseVisualStyleBackColor = true;
            // 
            // toolMenuColaborador
            // 
            this.toolMenuColaborador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenuColaborador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel5,
            this.cboNmeFirma,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.tstMatricula,
            this.toolStripLabel4,
            this.tstNome,
            this.toolStripSeparator5,
            this.toolAtualizar,
            this.qtdPorNota,
            this.toolEnviaEmail});
            this.toolMenuColaborador.Location = new System.Drawing.Point(3, 3);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(1164, 25);
            this.toolMenuColaborador.TabIndex = 258;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabel5.Text = "Nome-Firma:";
            // 
            // cboNmeFirma
            // 
            this.cboNmeFirma.Name = "cboNmeFirma";
            this.cboNmeFirma.Size = new System.Drawing.Size(200, 25);
            this.cboNmeFirma.SelectedIndexChanged += new System.EventHandler(this.cboNmeFirma_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(104, 22);
            this.toolStripLabel2.Text = "Código-Matricula:";
            // 
            // tstMatricula
            // 
            this.tstMatricula.Name = "tstMatricula";
            this.tstMatricula.Size = new System.Drawing.Size(100, 25);
            this.tstMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstMatricula_KeyPress);
            this.tstMatricula.Click += new System.EventHandler(this.tstMatricula_Click);
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
            this.tstNome.Size = new System.Drawing.Size(233, 25);
            this.tstNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstNome_KeyPress);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAtualizar
            // 
            this.toolAtualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("toolAtualizar.Image")));
            this.toolAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAtualizar.Name = "toolAtualizar";
            this.toolAtualizar.Size = new System.Drawing.Size(23, 22);
            this.toolAtualizar.Text = "toolStripLabel2";
            this.toolAtualizar.ToolTipText = "Filtrar Figurante";
            this.toolAtualizar.Click += new System.EventHandler(this.toolAtualizar_Click);
            // 
            // qtdPorNota
            // 
            this.qtdPorNota.Name = "qtdPorNota";
            this.qtdPorNota.Size = new System.Drawing.Size(13, 22);
            this.qtdPorNota.Text = "0";
            // 
            // toolEnviaEmail
            // 
            this.toolEnviaEmail.Image = ((System.Drawing.Image)(resources.GetObject("toolEnviaEmail.Image")));
            this.toolEnviaEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEnviaEmail.Name = "toolEnviaEmail";
            this.toolEnviaEmail.Size = new System.Drawing.Size(147, 22);
            this.toolEnviaEmail.Text = "Envia Recibo por Email";
            this.toolEnviaEmail.Click += new System.EventHandler(this.toolEnviaEmail_Click);
            // 
            // lstRecibo
            // 
            this.lstRecibo.AllowColumnReorder = true;
            this.lstRecibo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRecibo.AutoArrange = false;
            this.lstRecibo.CheckBoxes = true;
            this.lstRecibo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstRecibo.ForeColor = System.Drawing.Color.Teal;
            this.lstRecibo.FullRowSelect = true;
            this.lstRecibo.GridLines = true;
            this.lstRecibo.Location = new System.Drawing.Point(2, 31);
            this.lstRecibo.MultiSelect = false;
            this.lstRecibo.Name = "lstRecibo";
            this.lstRecibo.Size = new System.Drawing.Size(1147, 477);
            this.lstRecibo.TabIndex = 247;
            this.lstRecibo.UseCompatibleStateImageBehavior = false;
            this.lstRecibo.View = System.Windows.Forms.View.Details;
            this.lstRecibo.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstRecibo_ColumnClick);
            // 
            // frmEnviaEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 612);
            this.Controls.Add(this.tabDiversos);
            this.Name = "frmEnviaEmail";
            this.Text = "frmEnviaEmail";
            this.Load += new System.EventHandler(this.frmEnviaEmail_Load);
            this.tabDiversos.ResumeLayout(false);
            this.tabConsulta.ResumeLayout(false);
            this.tabConsulta.PerformLayout();
            this.toolMenuColaborador.ResumeLayout(false);
            this.toolMenuColaborador.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDiversos;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.ToolStrip toolMenuColaborador;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox tstNome;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolAtualizar;
        private System.Windows.Forms.ToolStripLabel qtdPorNota;
        private System.Windows.Forms.ListView lstRecibo;
        private System.Windows.Forms.ToolStripButton toolEnviaEmail;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tstMatricula;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripComboBox cboNmeFirma;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}