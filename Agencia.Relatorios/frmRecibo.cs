using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agencia.Relatorios
{
    public partial class frmRecibo : Form
    {
        public static int IdPessoa { get; set; }
        public static decimal NumeroRecibo { get; set; }
        public static int Status { get; set; }

        public frmRecibo()
        {
            InitializeComponent();
        }

        private void frmRecibo_Load(object sender, EventArgs e)
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
