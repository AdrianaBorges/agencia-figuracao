namespace Agencia.Relatorios
{
    partial class frmCachePago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCachePago));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.p_geraRptCachePagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAgenciaDataSet = new Agencia.Relatorios.dbAgenciaDataSet();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.rpt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.p_geraRptCachePagoTableAdapter = new Agencia.Relatorios.dbAgenciaDataSetTableAdapters.p_geraRptCachePagoTableAdapter();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cboNmeFirma = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptCachePagoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).BeginInit();
            this.toolMenuColaborador.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_geraRptCachePagoBindingSource
            // 
            this.p_geraRptCachePagoBindingSource.DataMember = "p_geraRptCachePago";
            this.p_geraRptCachePagoBindingSource.DataSource = this.dbAgenciaDataSet;
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
            this.toolStripLabel3,
            this.cboNmeFirma,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.btnFiltrar});
            this.toolMenuColaborador.Location = new System.Drawing.Point(0, 0);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(1155, 25);
            this.toolMenuColaborador.TabIndex = 259;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel2.Text = "Período:";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(193, 22);
            this.toolStripLabel1.Text = "                                                              ";
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
            // dtpDe
            // 
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(445, 1);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(95, 23);
            this.dtpDe.TabIndex = 260;
            // 
            // dtpAte
            // 
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(543, 1);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(95, 23);
            this.dtpAte.TabIndex = 261;
            // 
            // rpt
            // 
            this.rpt.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "dtCachePgtoPeriodo";
            reportDataSource3.Value = this.p_geraRptCachePagoBindingSource;
            this.rpt.LocalReport.DataSources.Add(reportDataSource3);
            this.rpt.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.cachePgtoPeriodo.rdlc";
            this.rpt.Location = new System.Drawing.Point(0, 25);
            this.rpt.Name = "rpt";
            this.rpt.Size = new System.Drawing.Size(1155, 695);
            this.rpt.TabIndex = 262;
            // 
            // p_geraRptCachePagoTableAdapter
            // 
            this.p_geraRptCachePagoTableAdapter.ClearBeforeFill = true;
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
            this.cboNmeFirma.Size = new System.Drawing.Size(300, 25);
            this.cboNmeFirma.SelectedIndexChanged += new System.EventHandler(this.cboNmeFirma_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // frmCachePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 720);
            this.Controls.Add(this.rpt);
            this.Controls.Add(this.dtpAte);
            this.Controls.Add(this.dtpDe);
            this.Controls.Add(this.toolMenuColaborador);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.Teal;
            this.Name = "frmCachePago";
            this.Text = "frmCachePago";
            this.Load += new System.EventHandler(this.frmCachePago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptCachePagoBindingSource)).EndInit();
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
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private Microsoft.Reporting.WinForms.ReportViewer rpt;
        private System.Windows.Forms.BindingSource p_geraRptCachePagoBindingSource;
        private dbAgenciaDataSet dbAgenciaDataSet;
        private dbAgenciaDataSetTableAdapters.p_geraRptCachePagoTableAdapter p_geraRptCachePagoTableAdapter;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox cboNmeFirma;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}