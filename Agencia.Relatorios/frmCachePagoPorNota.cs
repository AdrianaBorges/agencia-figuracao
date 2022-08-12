using System;
using System.Windows.Forms;

namespace Agencia.Relatorios
{
    public partial class frmCachePagoPorNota : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }

        public frmCachePagoPorNota()
        {
            InitializeComponent();
        }

        private void frmCachePorNota_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Cursor = Cursors.WaitCursor;

                CarregaRelatorio(0);
                rpt.RefreshReport();

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaRelatorio(int idnota)
        {
            try
            {
                p_geraRptCachePagoPorNotaTableAdapter.Fill(dbAgenciaDataSet.p_geraRptCachePagoPorNota, idnota);
                rpt.RefreshReport();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregaRelatorio(Convert.ToInt32(cmbNotaFiscal.SelectedValue));
        }
    }
}
