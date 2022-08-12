using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Agencia.Relatorios
{
    public partial class frmBeneficioPessoa : Form
    {
        public frmBeneficioPessoa()
        {
            InitializeComponent();
        }

        private void frmBeneficioPessoa_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Cursor = Cursors.WaitCursor;

                p_geraRptBeneficioPessoaTableAdapter.Fill(dbAgenciaDataSet.p_geraRptBeneficioPessoa);
                rpt.RefreshReport();

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmBeneficioPessoa_Load_1(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
