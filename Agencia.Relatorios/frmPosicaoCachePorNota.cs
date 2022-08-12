using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace Agencia.Relatorios
{
    public partial class frmPosicaoCachePorNota : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdNotaFiscal { get; set; }
        public static int IdFirma { get; set; }

        public frmPosicaoCachePorNota()
        {
            InitializeComponent();
        }

        private void frmCachePorNota_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Cursor = Cursors.WaitCursor;

                //MontaComboNotaFiscal(cmbNotaFiscal, IdFirma);
                RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);  

                CarregaRelatorios(0);

                rptPago.RefreshReport();
                rptPendente.RefreshReport();
                rptAgrupadoPorBanco.RefreshReport();
                rpt.RefreshReport();
                rptTotal.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;

            }
            this.rptTotal.RefreshReport();
        }

        private void CarregaRelatorios(int idnota)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                p_geraRptCachePagoPorNotaTableAdapter.Fill(dbAgenciaDataSet.p_geraRptCachePagoPorNota, idnota);
                p_geraRptCachePendentePorNotaTableAdapter.Fill(dbAgenciaDataSet.p_geraRptCachePendentePorNota, idnota);
                p_geraRptCachePendentePorNotaTableAdapter.Fill(dbAgenciaDataSet.p_geraRptCachePendentePorNota, idnota);
                p_geraRptPendenteTotalTableAdapter.Fill(dbAgenciaDataSet.p_geraRptPendenteTotal, IdFirma);

                rptPago.RefreshReport();
                rptPendente.RefreshReport();
                rptAgrupadoPorBanco.RefreshReport();
                rpt.RefreshReport();
                rptTotal.RefreshReport();
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

        private void GeraPdf(int idnota)
        {
            try
            {
                //p_geraRptCachePagoPorNotaTableAdapter.Fill(dbAgenciaDataSet.p_geraRptCachePagoPorNota, idnota);
                //p_geraRptCachePendentePorNotaTableAdapter.Fill(dbAgenciaDataSet.p_geraRptCachePendentePorNota, idnota);

                rptPago.RefreshReport();
                rptPendente.RefreshReport();


                rptPago.LocalReport.Refresh();

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = rptPago.LocalReport.Render("Pdf", null, out mimeType, out encoding, out extension,out streamids, out warnings);

                FileStream fs = new FileStream(@"c:\output\output.pdf",FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();


            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        #region Montagem de Combos

        private void MontaComboNotaFiscal(ComboBox cmb, int idnota)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeNotasFiscais().ObterListaDeNotas(ICodigoUsuario, idnota));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Nota(s) cadastradas.") + ex.Message);
            }
        }

        #endregion


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cmbNotaFiscal.Selected || cmbNotaFiscal.Text != "")
            {
                IdNotaFiscal = Convert.ToInt32(RepositorioDeNotasFiscais.Retorna.IdNotaFiscal(Convert.ToInt32(cmbNotaFiscal.Text), IdFirma));
                CarregaRelatorios(IdNotaFiscal);

            }
        }

        private void cboNmeFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNmeFirma.Selected)
            {
                IdFirma = Convert.ToInt32(RepositorioDeFirmas.Retorna.IdFirma(cboNmeFirma.Text));
                RepositorioDeNotasFiscais.MontaCombo.NotaFiscal(cmbNotaFiscal, ICodigoUsuario, IdFirma);
            }
        }
    }
}
