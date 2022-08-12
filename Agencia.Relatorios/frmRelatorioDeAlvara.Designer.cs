namespace Agencia.Relatorios
{
    partial class frmRelatorioDeAlvara
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorioDeAlvara));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.toolCmbPrograma = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tooProcesso = new System.Windows.Forms.ToolStripComboBox();
            this.rptAlvara = new Microsoft.Reporting.WinForms.ReportViewer();
            this.p_geraRptAlvaraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAgenciaDataSet = new Agencia.Relatorios.dbAgenciaDataSet();
            this.p_geraRptAlvaraTableAdapter = new Agencia.Relatorios.dbAgenciaDataSetTableAdapters.p_geraRptAlvaraTableAdapter();
            this.toolMenuColaborador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptAlvaraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // toolMenuColaborador
            // 
            this.toolMenuColaborador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenuColaborador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripLabel4,
            this.toolCmbPrograma,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tooProcesso,
            this.btnFiltrar});
            this.toolMenuColaborador.Location = new System.Drawing.Point(0, 0);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(756, 25);
            this.toolMenuColaborador.TabIndex = 263;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Teal;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(110, 22);
            this.toolStripLabel2.Text = "Produto-Programa:";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(0, 22);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(23, 22);
            this.btnFiltrar.ToolTipText = "Filtrar registros";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // toolCmbPrograma
            // 
            this.toolCmbPrograma.Name = "toolCmbPrograma";
            this.toolCmbPrograma.Size = new System.Drawing.Size(200, 25);
            this.toolCmbPrograma.ToolTipText = "Programas com Alvará registrado(s)";
            this.toolCmbPrograma.DropDownClosed += new System.EventHandler(this.toolCmbPrograma_DropDownClosed);
            this.toolCmbPrograma.SelectedIndexChanged += new System.EventHandler(this.toolCmbPrograma_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Teal;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel1.Text = "Nº Processo(s):";
            // 
            // tooProcesso
            // 
            this.tooProcesso.Name = "tooProcesso";
            this.tooProcesso.Size = new System.Drawing.Size(150, 25);
            // 
            // rptAlvara
            // 
            this.rptAlvara.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "dtAlvara";
            reportDataSource3.Value = this.p_geraRptAlvaraBindingSource;
            this.rptAlvara.LocalReport.DataSources.Add(reportDataSource3);
            this.rptAlvara.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.Alvara.rdlc";
            this.rptAlvara.Location = new System.Drawing.Point(0, 25);
            this.rptAlvara.Name = "rptAlvara";
            this.rptAlvara.Size = new System.Drawing.Size(756, 526);
            this.rptAlvara.TabIndex = 264;
            // 
            // p_geraRptAlvaraBindingSource
            // 
            this.p_geraRptAlvaraBindingSource.DataMember = "p_geraRptAlvara";
            this.p_geraRptAlvaraBindingSource.DataSource = this.dbAgenciaDataSet;
            // 
            // dbAgenciaDataSet
            // 
            this.dbAgenciaDataSet.DataSetName = "dbAgenciaDataSet";
            this.dbAgenciaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // p_geraRptAlvaraTableAdapter
            // 
            this.p_geraRptAlvaraTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelatorioDeAlvara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 551);
            this.Controls.Add(this.rptAlvara);
            this.Controls.Add(this.toolMenuColaborador);
            this.Name = "frmRelatorioDeAlvara";
            this.Text = "frmRelatorioDeAlvara";
            this.Load += new System.EventHandler(this.frmRelatorioDeAlvara_Load);
            this.toolMenuColaborador.ResumeLayout(false);
            this.toolMenuColaborador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptAlvaraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolMenuColaborador;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox toolCmbPrograma;
        private System.Windows.Forms.ToolStripButton btnFiltrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tooProcesso;
        private Microsoft.Reporting.WinForms.ReportViewer rptAlvara;
        private System.Windows.Forms.BindingSource p_geraRptAlvaraBindingSource;
        private dbAgenciaDataSet dbAgenciaDataSet;
        private dbAgenciaDataSetTableAdapters.p_geraRptAlvaraTableAdapter p_geraRptAlvaraTableAdapter;
    }
}