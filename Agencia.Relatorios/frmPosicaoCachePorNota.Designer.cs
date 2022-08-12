namespace Agencia.Relatorios
{
    partial class frmPosicaoCachePorNota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosicaoCachePorNota));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.p_geraRptCachePagoPorNotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAgenciaDataSet = new Agencia.Relatorios.dbAgenciaDataSet();
            this.p_geraRptCachePendentePorNotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.p_geraRptPendenteTotalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboNmeFirma = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.cmbNotaFiscal = new System.Windows.Forms.ToolStripComboBox();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rptPago = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabDiversos = new System.Windows.Forms.TabControl();
            this.tabPendente = new System.Windows.Forms.TabPage();
            this.rptPendente = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPago = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rptAgrupadoPorBanco = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rpt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rptTotal = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.p_geraRptCachePagoPorNotaTableAdapter = new Agencia.Relatorios.dbAgenciaDataSetTableAdapters.p_geraRptCachePagoPorNotaTableAdapter();
            this.p_geraRptCachePendentePorNotaTableAdapter = new Agencia.Relatorios.dbAgenciaDataSetTableAdapters.p_geraRptCachePendentePorNotaTableAdapter();
            this.p_geraRptPendenteTotalTableAdapter = new Agencia.Relatorios.dbAgenciaDataSetTableAdapters.p_geraRptPendenteTotalTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptCachePagoPorNotaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptCachePendentePorNotaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptPendenteTotalBindingSource)).BeginInit();
            this.toolMenuColaborador.SuspendLayout();
            this.tabDiversos.SuspendLayout();
            this.tabPendente.SuspendLayout();
            this.tabPago.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.dbAgenciaDataSet.EnforceConstraints = false;
            this.dbAgenciaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // p_geraRptCachePendentePorNotaBindingSource
            // 
            this.p_geraRptCachePendentePorNotaBindingSource.DataMember = "p_geraRptCachePendentePorNota";
            this.p_geraRptCachePendentePorNotaBindingSource.DataSource = this.dbAgenciaDataSet;
            // 
            // p_geraRptPendenteTotalBindingSource
            // 
            this.p_geraRptPendenteTotalBindingSource.DataMember = "p_geraRptPendenteTotal";
            this.p_geraRptPendenteTotalBindingSource.DataSource = this.dbAgenciaDataSet;
            // 
            // toolMenuColaborador
            // 
            this.toolMenuColaborador.Dock = System.Windows.Forms.DockStyle.None;
            this.toolMenuColaborador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenuColaborador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cboNmeFirma,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripLabel4,
            this.cmbNotaFiscal,
            this.btnFiltrar,
            this.toolStripSeparator2});
            this.toolMenuColaborador.Location = new System.Drawing.Point(0, 0);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(600, 25);
            this.toolMenuColaborador.TabIndex = 262;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabel1.Text = "Nome-Firma:";
            // 
            // cboNmeFirma
            // 
            this.cboNmeFirma.Name = "cboNmeFirma";
            this.cboNmeFirma.Size = new System.Drawing.Size(260, 25);
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
            this.toolStripLabel2.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel2.Text = "Nota-Fiscal:";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(0, 22);
            // 
            // cmbNotaFiscal
            // 
            this.cmbNotaFiscal.Name = "cmbNotaFiscal";
            this.cmbNotaFiscal.Size = new System.Drawing.Size(110, 25);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(23, 22);
            this.btnFiltrar.ToolTipText = "Filtrar por Nota Fiscal";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // rptPago
            // 
            this.rptPago.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dtCachePagoPorNota";
            reportDataSource1.Value = this.p_geraRptCachePagoPorNotaBindingSource;
            this.rptPago.LocalReport.DataSources.Add(reportDataSource1);
            this.rptPago.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.cachePagoPorNota.rdlc";
            this.rptPago.Location = new System.Drawing.Point(3, 3);
            this.rptPago.Name = "rptPago";
            this.rptPago.Size = new System.Drawing.Size(979, 663);
            this.rptPago.TabIndex = 265;
            // 
            // tabDiversos
            // 
            this.tabDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDiversos.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabDiversos.Controls.Add(this.tabPendente);
            this.tabDiversos.Controls.Add(this.tabPago);
            this.tabDiversos.Controls.Add(this.tabPage1);
            this.tabDiversos.Controls.Add(this.tabPage2);
            this.tabDiversos.Controls.Add(this.tabPage3);
            this.tabDiversos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabDiversos.Location = new System.Drawing.Point(12, 30);
            this.tabDiversos.Name = "tabDiversos";
            this.tabDiversos.SelectedIndex = 0;
            this.tabDiversos.Size = new System.Drawing.Size(993, 700);
            this.tabDiversos.TabIndex = 268;
            // 
            // tabPendente
            // 
            this.tabPendente.Controls.Add(this.rptPendente);
            this.tabPendente.Location = new System.Drawing.Point(4, 27);
            this.tabPendente.Name = "tabPendente";
            this.tabPendente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPendente.Size = new System.Drawing.Size(985, 669);
            this.tabPendente.TabIndex = 1;
            this.tabPendente.Text = "CACHE PENDENTE";
            this.tabPendente.UseVisualStyleBackColor = true;
            // 
            // rptPendente
            // 
            this.rptPendente.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "dtCachePendente";
            reportDataSource2.Value = this.p_geraRptCachePendentePorNotaBindingSource;
            this.rptPendente.LocalReport.DataSources.Add(reportDataSource2);
            this.rptPendente.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.cachePendentPorNota.rdlc";
            this.rptPendente.Location = new System.Drawing.Point(3, 3);
            this.rptPendente.Name = "rptPendente";
            this.rptPendente.Size = new System.Drawing.Size(979, 663);
            this.rptPendente.TabIndex = 0;
            // 
            // tabPago
            // 
            this.tabPago.Controls.Add(this.rptPago);
            this.tabPago.ForeColor = System.Drawing.Color.Teal;
            this.tabPago.Location = new System.Drawing.Point(4, 27);
            this.tabPago.Name = "tabPago";
            this.tabPago.Padding = new System.Windows.Forms.Padding(3);
            this.tabPago.Size = new System.Drawing.Size(985, 669);
            this.tabPago.TabIndex = 0;
            this.tabPago.Text = "Cache Efetuado";
            this.tabPago.ToolTipText = "Consultas Diversas";
            this.tabPago.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rptAgrupadoPorBanco);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(985, 669);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Cache Pendente - Agrupado por Banco";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rptAgrupadoPorBanco
            // 
            this.rptAgrupadoPorBanco.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "dtCachePendente";
            reportDataSource3.Value = this.p_geraRptCachePendentePorNotaBindingSource;
            this.rptAgrupadoPorBanco.LocalReport.DataSources.Add(reportDataSource3);
            this.rptAgrupadoPorBanco.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.pendenciaAgrupadaPorBanco.rdlc";
            this.rptAgrupadoPorBanco.Location = new System.Drawing.Point(3, 3);
            this.rptAgrupadoPorBanco.Name = "rptAgrupadoPorBanco";
            this.rptAgrupadoPorBanco.Size = new System.Drawing.Size(979, 663);
            this.rptAgrupadoPorBanco.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rpt);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(985, 669);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rpt
            // 
            this.rpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpt.LocalReport.DataSources.Add(reportDataSource3);
            this.rpt.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.pendenciaPorNota.rdlc";
            this.rpt.Location = new System.Drawing.Point(0, 0);
            this.rpt.Name = "rpt";
            this.rpt.Size = new System.Drawing.Size(985, 669);
            this.rpt.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rptTotal);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(985, 669);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Pendência Total";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rptTotal
            // 
            this.rptTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "dtPendenciaTotal";
            reportDataSource4.Value = this.p_geraRptPendenteTotalBindingSource;
            this.rptTotal.LocalReport.DataSources.Add(reportDataSource4);
            this.rptTotal.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.pendenciaTotalNotas.rdlc";
            this.rptTotal.Location = new System.Drawing.Point(3, 3);
            this.rptTotal.Name = "rptTotal";
            this.rptTotal.Size = new System.Drawing.Size(979, 663);
            this.rptTotal.TabIndex = 0;
            // 
            // dtpAte
            // 
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(749, 2);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(95, 23);
            this.dtpAte.TabIndex = 271;
            // 
            // dtpDe
            // 
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(651, 2);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(95, 23);
            this.dtpDe.TabIndex = 270;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripLabel5,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(593, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(322, 25);
            this.toolStrip1.TabIndex = 269;
            this.toolStrip1.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel3.Text = "Período:";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(202, 22);
            this.toolStripLabel5.Text = "                                                                 ";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(57, 22);
            this.toolStripButton1.Text = "Filtrar";
            // 
            // p_geraRptCachePagoPorNotaTableAdapter
            // 
            this.p_geraRptCachePagoPorNotaTableAdapter.ClearBeforeFill = true;
            // 
            // p_geraRptCachePendentePorNotaTableAdapter
            // 
            this.p_geraRptCachePendentePorNotaTableAdapter.ClearBeforeFill = true;
            // 
            // p_geraRptPendenteTotalTableAdapter
            // 
            this.p_geraRptPendenteTotalTableAdapter.ClearBeforeFill = true;
            // 
            // frmPosicaoCachePorNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 733);
            this.Controls.Add(this.dtpAte);
            this.Controls.Add(this.tabDiversos);
            this.Controls.Add(this.dtpDe);
            this.Controls.Add(this.toolMenuColaborador);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.Teal;
            this.Name = "frmPosicaoCachePorNota";
            this.Text = "frmCachePorNota";
            this.Load += new System.EventHandler(this.frmCachePorNota_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptCachePagoPorNotaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptCachePendentePorNotaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptPendenteTotalBindingSource)).EndInit();
            this.toolMenuColaborador.ResumeLayout(false);
            this.toolMenuColaborador.PerformLayout();
            this.tabDiversos.ResumeLayout(false);
            this.tabPendente.ResumeLayout(false);
            this.tabPago.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolMenuColaborador;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton btnFiltrar;
        private Microsoft.Reporting.WinForms.ReportViewer rptPago;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.BindingSource p_geraRptCachePagoPorNotaBindingSource;
        private dbAgenciaDataSet dbAgenciaDataSet;
        private dbAgenciaDataSetTableAdapters.p_geraRptCachePagoPorNotaTableAdapter p_geraRptCachePagoPorNotaTableAdapter;
        private System.Windows.Forms.TabControl tabDiversos;
        private System.Windows.Forms.TabPage tabPago;
        private System.Windows.Forms.TabPage tabPendente;
        private Microsoft.Reporting.WinForms.ReportViewer rptPendente;
        private System.Windows.Forms.BindingSource p_geraRptCachePendentePorNotaBindingSource;
        private dbAgenciaDataSetTableAdapters.p_geraRptCachePendentePorNotaTableAdapter p_geraRptCachePendentePorNotaTableAdapter;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer rptAgrupadoPorBanco;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer rpt;
        private System.Windows.Forms.TabPage tabPage3;
        private Microsoft.Reporting.WinForms.ReportViewer rptTotal;
        private System.Windows.Forms.BindingSource p_geraRptPendenteTotalBindingSource;
        private dbAgenciaDataSetTableAdapters.p_geraRptPendenteTotalTableAdapter p_geraRptPendenteTotalTableAdapter;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboNmeFirma;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cmbNotaFiscal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}