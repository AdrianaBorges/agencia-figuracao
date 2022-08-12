namespace Agencia.Relatorios
{
    partial class frmConsolidado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsolidado));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.p_geraRptConsolidadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAgenciaDataSet = new Agencia.Relatorios.dbAgenciaDataSet();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tspStatus = new System.Windows.Forms.ToolStripComboBox();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.cboNmeFirma = new System.Windows.Forms.ToolStripComboBox();
            this.rpt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.p_geraRptConsolidadoTableAdapter = new Agencia.Relatorios.dbAgenciaDataSetTableAdapters.p_geraRptConsolidadoTableAdapter();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptConsolidadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).BeginInit();
            this.toolMenuColaborador.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_geraRptConsolidadoBindingSource
            // 
            this.p_geraRptConsolidadoBindingSource.DataMember = "p_geraRptConsolidado";
            this.p_geraRptConsolidadoBindingSource.DataSource = this.dbAgenciaDataSet;
            // 
            // dbAgenciaDataSet
            // 
            this.dbAgenciaDataSet.DataSetName = "dbAgenciaDataSet";
            this.dbAgenciaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpAte
            // 
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(576, 1);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(78, 20);
            this.dtpAte.TabIndex = 266;
            // 
            // dtpDe
            // 
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(495, 1);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(78, 20);
            this.dtpDe.TabIndex = 265;
            // 
            // toolMenuColaborador
            // 
            this.toolMenuColaborador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenuColaborador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel5,
            this.cboNmeFirma,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.tspStatus,
            this.btnFiltrar});
            this.toolMenuColaborador.Location = new System.Drawing.Point(0, 0);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(976, 25);
            this.toolMenuColaborador.TabIndex = 264;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.ForeColor = System.Drawing.Color.Teal;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabel5.Text = "Nome-Firma:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Teal;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel2.Text = "Período:";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(169, 22);
            this.toolStripLabel1.Text = "                                                      ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.ForeColor = System.Drawing.Color.Teal;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel3.Text = "Status:";
            // 
            // tspStatus
            // 
            this.tspStatus.Items.AddRange(new object[] {
            "0 - PENDENTE",
            "1 - PAGO"});
            this.tspStatus.Name = "tspStatus";
            this.tspStatus.Size = new System.Drawing.Size(100, 25);
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
            // cboNmeFirma
            // 
            this.cboNmeFirma.Name = "cboNmeFirma";
            this.cboNmeFirma.Size = new System.Drawing.Size(350, 25);
            this.cboNmeFirma.SelectedIndexChanged += new System.EventHandler(this.cboNmeFirma_SelectedIndexChanged);
            // 
            // rpt
            // 
            this.rpt.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "dtConsolidado";
            reportDataSource3.Value = this.p_geraRptConsolidadoBindingSource;
            this.rpt.LocalReport.DataSources.Add(reportDataSource3);
            this.rpt.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.consolidado.rdlc";
            this.rpt.Location = new System.Drawing.Point(0, 25);
            this.rpt.Name = "rpt";
            this.rpt.Size = new System.Drawing.Size(976, 608);
            this.rpt.TabIndex = 267;
            // 
            // p_geraRptConsolidadoTableAdapter
            // 
            this.p_geraRptConsolidadoTableAdapter.ClearBeforeFill = true;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // frmConsolidado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 633);
            this.Controls.Add(this.dtpAte);
            this.Controls.Add(this.dtpDe);
            this.Controls.Add(this.rpt);
            this.Controls.Add(this.toolMenuColaborador);
            this.Name = "frmConsolidado";
            this.Text = "frmConsolidado";
            this.Load += new System.EventHandler(this.frmConsolidado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptConsolidadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).EndInit();
            this.toolMenuColaborador.ResumeLayout(false);
            this.toolMenuColaborador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.ToolStrip toolMenuColaborador;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnFiltrar;
        private Microsoft.Reporting.WinForms.ReportViewer rpt;
        private System.Windows.Forms.ToolStripComboBox tspStatus;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource p_geraRptConsolidadoBindingSource;
        private dbAgenciaDataSet dbAgenciaDataSet;
        private dbAgenciaDataSetTableAdapters.p_geraRptConsolidadoTableAdapter p_geraRptConsolidadoTableAdapter;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripComboBox cboNmeFirma;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}