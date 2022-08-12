namespace Agencia.Relatorios
{
    partial class frmResumoNF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResumoNF));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.p_geraRptResumoNotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAgenciaDataSet = new Agencia.Relatorios.dbAgenciaDataSet();
            this.p_geraRptResumoNotaTableAdapter = new Agencia.Relatorios.dbAgenciaDataSetTableAdapters.p_geraRptResumoNotaTableAdapter();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.cboNmeFirma = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbNotaFiscal = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFiltraRegistro = new System.Windows.Forms.ToolStripButton();
            this.rpt = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptResumoNotaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).BeginInit();
            this.toolMenuColaborador.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_geraRptResumoNotaBindingSource
            // 
            this.p_geraRptResumoNotaBindingSource.DataMember = "p_geraRptResumoNota";
            this.p_geraRptResumoNotaBindingSource.DataSource = this.dbAgenciaDataSet;
            // 
            // dbAgenciaDataSet
            // 
            this.dbAgenciaDataSet.DataSetName = "dbAgenciaDataSet";
            this.dbAgenciaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // p_geraRptResumoNotaTableAdapter
            // 
            this.p_geraRptResumoNotaTableAdapter.ClearBeforeFill = true;
            // 
            // toolMenuColaborador
            // 
            this.toolMenuColaborador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenuColaborador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripLabel4,
            this.cboNmeFirma,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cmbNotaFiscal,
            this.toolStripSeparator2,
            this.btnFiltraRegistro});
            this.toolMenuColaborador.Location = new System.Drawing.Point(0, 0);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(1020, 25);
            this.toolMenuColaborador.TabIndex = 270;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Teal;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabel2.Text = "Nome-Firma:";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(0, 22);
            // 
            // cboNmeFirma
            // 
            this.cboNmeFirma.Name = "cboNmeFirma";
            this.cboNmeFirma.Size = new System.Drawing.Size(250, 25);
            this.cboNmeFirma.SelectedIndexChanged += new System.EventHandler(this.cboNmeFirma_SelectedIndexChanged);
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
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel1.Text = "Nota-Fiscal:";
            // 
            // cmbNotaFiscal
            // 
            this.cmbNotaFiscal.Name = "cmbNotaFiscal";
            this.cmbNotaFiscal.Size = new System.Drawing.Size(121, 25);
            this.cmbNotaFiscal.SelectedIndexChanged += new System.EventHandler(this.cmbNotaFiscal_SelectedIndexChanged);
            this.cmbNotaFiscal.Click += new System.EventHandler(this.cmbNotaFiscal_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFiltraRegistro
            // 
            this.btnFiltraRegistro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFiltraRegistro.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltraRegistro.Image")));
            this.btnFiltraRegistro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltraRegistro.Name = "btnFiltraRegistro";
            this.btnFiltraRegistro.Size = new System.Drawing.Size(23, 22);
            this.btnFiltraRegistro.Text = "toolStripButton1";
            this.btnFiltraRegistro.Click += new System.EventHandler(this.btnFiltraRegistro_Click);
            // 
            // rpt
            // 
            this.rpt.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dtResumoNota";
            reportDataSource1.Value = this.p_geraRptResumoNotaBindingSource;
            this.rpt.LocalReport.DataSources.Add(reportDataSource1);
            this.rpt.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.resumoNota.rdlc";
            this.rpt.Location = new System.Drawing.Point(0, 25);
            this.rpt.Name = "rpt";
            this.rpt.Size = new System.Drawing.Size(1020, 668);
            this.rpt.TabIndex = 272;
            // 
            // frmResumoNF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 693);
            this.Controls.Add(this.rpt);
            this.Controls.Add(this.toolMenuColaborador);
            this.Name = "frmResumoNF";
            this.Text = "frmResumoNF";
            this.Load += new System.EventHandler(this.frmResumoNF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptResumoNotaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).EndInit();
            this.toolMenuColaborador.ResumeLayout(false);
            this.toolMenuColaborador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource p_geraRptResumoNotaBindingSource;
        private dbAgenciaDataSet dbAgenciaDataSet;
        private dbAgenciaDataSetTableAdapters.p_geraRptResumoNotaTableAdapter p_geraRptResumoNotaTableAdapter;
        private System.Windows.Forms.ToolStrip toolMenuColaborador;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private Microsoft.Reporting.WinForms.ReportViewer rpt;
        private System.Windows.Forms.ToolStripComboBox cboNmeFirma;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbNotaFiscal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnFiltraRegistro;
    }
}