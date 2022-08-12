namespace Agencia.Relatorios
{
    partial class frmReciboCache
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.p_geraRptReciboCacheBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAgenciaDataSet = new Agencia.Relatorios.dbAgenciaDataSet();
            this.rptV = new Microsoft.Reporting.WinForms.ReportViewer();
            this.p_geraRptReciboCacheTableAdapter = new Agencia.Relatorios.dbAgenciaDataSetTableAdapters.p_geraRptReciboCacheTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptReciboCacheBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // p_geraRptReciboCacheBindingSource
            // 
            this.p_geraRptReciboCacheBindingSource.DataMember = "p_geraRptReciboCache";
            this.p_geraRptReciboCacheBindingSource.DataSource = this.dbAgenciaDataSet;
            // 
            // dbAgenciaDataSet
            // 
            this.dbAgenciaDataSet.DataSetName = "dbAgenciaDataSet";
            this.dbAgenciaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptV
            // 
            this.rptV.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dtReciboCache";
            reportDataSource1.Value = this.p_geraRptReciboCacheBindingSource;
            this.rptV.LocalReport.DataSources.Add(reportDataSource1);
            this.rptV.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.reciboCache.rdlc";
            this.rptV.Location = new System.Drawing.Point(0, 0);
            this.rptV.Name = "rptV";
            this.rptV.Size = new System.Drawing.Size(1100, 529);
            this.rptV.TabIndex = 0;
            // 
            // p_geraRptReciboCacheTableAdapter
            // 
            this.p_geraRptReciboCacheTableAdapter.ClearBeforeFill = true;
            // 
            // frmReciboCache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 529);
            this.Controls.Add(this.rptV);
            this.Name = "frmReciboCache";
            this.Text = "frmReciboCache";
            this.Load += new System.EventHandler(this.frmReciboCache_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRptReciboCacheBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptV;
        private System.Windows.Forms.BindingSource p_geraRptReciboCacheBindingSource;
        private dbAgenciaDataSet dbAgenciaDataSet;
        private dbAgenciaDataSetTableAdapters.p_geraRptReciboCacheTableAdapter p_geraRptReciboCacheTableAdapter;


    }
}