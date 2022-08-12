using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;

namespace Agencia.Relatorios
{
    public partial class frmResumoNF : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }
        public static int IdNotaFiscal { get; set; }

        public frmResumoNF()
        {
            InitializeComponent();
            //p_carregaTmpNotaFiscal executar a procedure
        }

        private void frmResumoNF_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                WindowState = FormWindowState.Maximized;
                RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);
                 
                //p_geraRptResumoNotaTableAdapter.Fill(this.dbAgenciaDataSet.p_geraRptResumoNota, 0);
                //rpt.RefreshReport();

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                this.rpt.RefreshReport();

            }
        }


        private void CarregaRelatorio(int idusuario, int idnota, int idfirma)
        {
            var repositorioDeNotasFiscais = new RepositorioDeNotasFiscais();

            try
            {
                Cursor = Cursors.WaitCursor;
                p_geraRptResumoNotaTableAdapter.Fill(this.dbAgenciaDataSet.p_geraRptResumoNota, 0);
                rpt.RefreshReport();

                repositorioDeNotasFiscais.LimpaTabelaTemporaria(idusuario);
                repositorioDeNotasFiscais.CarregaTabelaTemporaria(idusuario, idnota, idfirma);

                p_geraRptResumoNotaTableAdapter.Fill(this.dbAgenciaDataSet.p_geraRptResumoNota, idnota);
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

        private void btnFiltrar_Click_2(object sender, System.EventArgs e)
        {
            //CarregaRelatorio(ICodigoUsuario, IdFirma);

        }

        private void cboNmeFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNmeFirma.Selected)
            {
                p_geraRptResumoNotaTableAdapter.Fill(this.dbAgenciaDataSet.p_geraRptResumoNota, 0);
                rpt.RefreshReport();

                IdFirma = Convert.ToInt32(RepositorioDeFirmas.Retorna.IdFirma(cboNmeFirma.Text));
                RepositorioDeNotasFiscais.MontaCombo.NotaFiscal(cmbNotaFiscal, ICodigoUsuario, IdFirma);

            }
        }

        private void btnFiltraRegistro_Click(object sender, EventArgs e)
        {
            CarregaRelatorio(ICodigoUsuario, IdNotaFiscal, IdFirma);

        }

        private void cmbNotaFiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IdFirma != 0)
            {
                IdNotaFiscal = Convert.ToInt32(RepositorioDeNotasFiscais.Retorna.IdNotaFiscal(Convert.ToInt32(cmbNotaFiscal.Text), IdFirma));
            }
        }

        private void cmbNotaFiscal_Click(object sender, EventArgs e)
        {

        }
    }
}
