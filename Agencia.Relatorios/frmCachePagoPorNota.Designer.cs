namespace Agencia.Relatorios
{
    partial class frmCachePagoPorNota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCachePagoPorNota));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.p_geraRptCachePagoPorNotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAgenciaDataSet = new Agencia.Relatorios.dbAgenciaDataSet();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.rpt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbNotaFiscal = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.p_geraRptCachePagoPorNotaTableAdapter = new Agencia.Relatorios.dbAgenciaDataSetTableAdapters.p_geraRptCachePagoPorNotaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptCachePagoPorNotaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).BeginInit();
            this.toolMenuColaborador.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_geraRptCachePagoPorNotaBindingSource
            // 
            this.p_geraRptCachePagoPorNotaBindingSource.DataMember = "p_geraRptCachePagoPorNota";
            this.p_geraRptCachePagoPorNotaBindingSource.DataSource = this.dbAgenciaDataSet;
            // 
            // dbAgenciaDataSet
            // 
            this.dbAgenciaDataSet.DataSetName = "dbAgenciaDataSet";
            this.dbAgenciaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolMenuColaborador
            // 
            this.toolMenuColaborador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenuColaborador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripLabel1,
            this.toolStripLabel3,
            this.toolStripLabel4,
            this.btnFiltrar});
            this.toolMenuColaborador.Location = new System.Drawing.Point(0, 0);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(1200, 25);
            this.toolMenuColaborador.TabIndex = 262;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel2.Text = "Nota-Fiscal:";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(139, 22);
            this.toolStripLabel1.Text = "                                            ";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel3.Text = "Status:";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(103, 22);
            this.toolStripLabel4.Text = "                                ";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(57, 22);
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // rpt
            // 
            this.rpt.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dtCachePagoPorNota";
            reportDataSource1.Value = this.p_geraRptCachePagoPorNotaBindingSource;
            this.rpt.LocalReport.DataSources.Add(reportDataSource1);
            this.rpt.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.cachePagoPorNota.rdlc";
            this.rpt.Location = new System.Drawing.Point(0, 25);
            this.rpt.Name = "rpt";
            this.rpt.Size = new System.Drawing.Size(1200, 725);
            this.rpt.TabIndex = 265;
            // 
            // cmbNotaFiscal
            // 
            this.cmbNotaFiscal.FormattingEnabled = true;
            this.cmbNotaFiscal.Location = new System.Drawing.Point(80, 1);
            this.cmbNotaFiscal.Name = "cmbNotaFiscal";
            this.cmbNotaFiscal.Size = new System.Drawing.Size(134, 23);
            this.cmbNotaFiscal.TabIndex = 266;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "0- PENDENTE",
            "1- PAGO"});
            this.cmbStatus.Location = new System.Drawing.Point(258, 1);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(100, 23);
            this.cmbStatus.TabIndex = 267;
            // 
            // p_geraRptCachePagoPorNotaTableAdapter
            // 
            this.p_geraRptCachePagoPorNotaTableAdapter.ClearBeforeFill = true;
            // 
            // frmCachePorNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbNotaFiscal);
            this.Controls.Add(this.rpt);
            this.Controls.Add(this.toolMenuColaborador);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.Teal;
            this.Name = "frmCachePorNota";
            this.Text = "frmCachePorNota";
            this.Load += new System.EventHandler(this.frmCachePorNota_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptCachePagoPorNotaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).EndInit();
            this.toolMenuColaborador.ResumeLayout(false);
            this.toolMenuColaborador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolMenuColaborador;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnFiltrar;
        private Microsoft.Reporting.WinForms.ReportViewer rpt;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ComboBox cmbNotaFiscal;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.BindingSource p_geraRptCachePagoPorNotaBindingSource;
        private dbAgenciaDataSet dbAgenciaDataSet;
        private dbAgenciaDataSetTableAdapters.p_geraRptCachePagoPorNotaTableAdapter p_geraRptCachePagoPorNotaTableAdapter;
    }
}