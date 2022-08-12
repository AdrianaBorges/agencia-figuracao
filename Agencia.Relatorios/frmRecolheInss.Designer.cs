namespace Agencia.Relatorios
{
    partial class frmRecolheInss
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecolheInss));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.p_geraRelatorioInssBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbAgenciaDataSet = new Agencia.Relatorios.dbAgenciaDataSet();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.rpt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.p_geraRelatorioInssTableAdapter = new Agencia.Relatorios.dbAgenciaDataSetTableAdapters.p_geraRelatorioInssTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRelatorioInssBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAgenciaDataSet)).BeginInit();
            this.toolMenuColaborador.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_geraRelatorioInssBindingSource
            // 
            this.p_geraRelatorioInssBindingSource.DataMember = "p_geraRelatorioInss";
            this.p_geraRelatorioInssBindingSource.DataSource = this.dbAgenciaDataSet;
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
            this.btnFiltrar});
            this.toolMenuColaborador.Location = new System.Drawing.Point(0, 0);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(873, 25);
            this.toolMenuColaborador.TabIndex = 260;
            this.toolMenuColaborador.Text = "toolStrip3";
            this.toolMenuColaborador.Visible = false;
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
            this.toolStripLabel1.Size = new System.Drawing.Size(226, 22);
            this.toolStripLabel1.Text = "                                                                         ";
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
            // dtpAte
            // 
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(160, 2);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(95, 20);
            this.dtpAte.TabIndex = 263;
            // 
            // dtpDe
            // 
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(60, 2);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(95, 20);
            this.dtpDe.TabIndex = 262;
            // 
            // rpt
            // 
            this.rpt.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dtRecolheInss";
            reportDataSource1.Value = this.p_geraRelatorioInssBindingSource;
            this.rpt.LocalReport.DataSources.Add(reportDataSource1);
            this.rpt.LocalReport.ReportEmbeddedResource = "Agencia.Relatorios.recolheInss.rdlc";
            this.rpt.Location = new System.Drawing.Point(0, 0);
            this.rpt.Name = "rpt";
            this.rpt.Size = new System.Drawing.Size(873, 440);
            this.rpt.TabIndex = 264;
            // 
            // p_geraRelatorioInssTableAdapter
            // 
            this.p_geraRelatorioInssTableAdapter.ClearBeforeFill = true;
            // 
            // frmRecolheInss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 440);
            this.Controls.Add(this.rpt);
            this.Controls.Add(this.dtpAte);
            this.Controls.Add(this.dtpDe);
            this.Controls.Add(this.toolMenuColaborador);
            this.Name = "frmRecolheInss";
            this.Text = "frmRecolhimentoInss";
            this.Load += new System.EventHandler(this.frmRecolhimentoInss_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_geraRelatorioInssBindingSource)).EndInit();
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
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private Microsoft.Reporting.WinForms.ReportViewer rpt;
        private System.Windows.Forms.BindingSource p_geraRelatorioInssBindingSource;
        private dbAgenciaDataSet dbAgenciaDataSet;
        private dbAgenciaDataSetTableAdapters.p_geraRelatorioInssTableAdapter p_geraRelatorioInssTableAdapter;
    }
}