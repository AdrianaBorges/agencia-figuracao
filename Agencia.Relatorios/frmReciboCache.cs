using System;
using System.Windows.Forms;

namespace Agencia.Relatorios
{
    public partial class frmReciboCache : Form
    {
        public static int IdPessoa { get; set; }
        public static decimal NumeroRecibo { get; set; }
        public static int Status { get; set; }

        public frmReciboCache()
        {
            InitializeComponent();
        }

        private void frmReciboCache_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Cursor = Cursors.WaitCursor;

                CarregaRecibo(IdPessoa, NumeroRecibo, Status);
                
                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregaRecibo(int idpessoa, decimal nrrb, int status)
        {
            try
            {
                p_geraRptReciboCacheTableAdapter.Fill(dbAgenciaDataSet.p_geraRptReciboCache, idpessoa, nrrb, status);
                rptV.RefreshReport();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

    }
}
