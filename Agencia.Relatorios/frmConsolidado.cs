using System;
using Agencia.Dominio.Repositorio;
using System.Windows.Forms;

namespace Agencia.Relatorios
{
    public partial class frmConsolidado : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }

        public frmConsolidado()
        {
            InitializeComponent();
        }

        private void frmConsolidado_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Cursor = Cursors.WaitCursor;
                tspStatus.Text = "0 - PENDENTE";

                RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);

                this.p_geraRptConsolidadoTableAdapter.Fill(dbAgenciaDataSet.p_geraRptConsolidado, IdFirma, dtpDe.Value, dtpAte.Value, 0);
                rpt.RefreshReport();

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CarregaRelatorio(int idfirma, DateTime de, DateTime ate, int idstatus)
        {
            try
            {
                this.p_geraRptConsolidadoTableAdapter.Fill(dbAgenciaDataSet.p_geraRptConsolidado, IdFirma, dtpDe.Value, dtpAte.Value, idstatus);
                rpt.RefreshReport();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int idstatus = 0;
            if (tspStatus.Text != string.Empty)
            {
                idstatus = Convert.ToInt32(tspStatus.Text.Substring(0, 1));
            }

            CarregaRelatorio(IdFirma, dtpDe.Value, dtpAte.Value, idstatus);

            Cursor = Cursors.Default;

        }

        private void cboNmeFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNmeFirma.Selected)
            {
                IdFirma = Convert.ToInt32(RepositorioDeFirmas.Retorna.IdFirma(cboNmeFirma.Text));
            }

        }
    }
}
