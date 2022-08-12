using System;
using System.Windows.Forms;

namespace Agencia.Relatorios
{
    public partial class frmRecolheInss : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }
        public static int IdPessoa { get; set; }
        public static DateTime De { get; set; }
        public static DateTime Ate { get; set; }


        public frmRecolheInss()
        {
            InitializeComponent();
        }

        private void frmRecolhimentoInss_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Cursor = Cursors.WaitCursor;

                p_geraRelatorioInssTableAdapter.Fill(dbAgenciaDataSet.p_geraRelatorioInss, IdFirma, De, Ate);
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
            Cursor = Cursors.WaitCursor;

            try
            {
                p_geraRelatorioInssTableAdapter.Fill(dbAgenciaDataSet.p_geraRelatorioInss, idfirma, de, ate);
                rpt.RefreshReport();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnFiltrar_Click(object sender, System.EventArgs e)
        {
            CarregaRelatorio(IdFirma, dtpDe.Value, dtpAte.Value);
        }
    }
}
