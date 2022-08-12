using System;
using System.Windows.Forms;
using Agencia.Dominio.Repositorio;

namespace Agencia.Relatorios
{
    public partial class frmCachePago : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }

        public frmCachePago()
        {
            InitializeComponent();
        }

        private void frmCachePago_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Cursor = Cursors.WaitCursor;
                RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);

                p_geraRptCachePagoTableAdapter.Fill(dbAgenciaDataSet.p_geraRptCachePago, IdFirma, dtpDe.Value, dtpAte.Value);
                rpt.RefreshReport();

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaRelatorio(int idfirma, DateTime de, DateTime ate)
        {
            try
            {
                p_geraRptCachePagoTableAdapter.Fill(dbAgenciaDataSet.p_geraRptCachePago, idfirma, de, ate);
                rpt.RefreshReport();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregaRelatorio(IdFirma, dtpDe.Value, dtpAte.Value);

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
