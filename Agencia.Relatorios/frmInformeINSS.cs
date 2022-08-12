using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;

namespace Agencia.Relatorios
{
    public partial class frmInformeINSS : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }
        private ListViewColumnSorter lvwColumnSorter;

        public frmInformeINSS()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.lstRecibo.ListViewItemSorter = lvwColumnSorter;

            WindowsForm.RegisterFocusEvents(Controls);

        }

        private void frmInformeINSS_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Cursor = Cursors.WaitCursor;
                RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);

                ListaFigurantes(lstRecibo, "-", 0, null, null, qtdPorNota);

                cboNmeFirma.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Erro: ") +
                Environment.NewLine + string.Format(ex.Message),
                string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;

            }
        }

        private void ListaFigurantes(ListView lst, string nome, int idpessoa, Nullable<DateTime> de, Nullable<DateTime> ate, ToolStripLabel lab)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                lst.Columns.Clear();

                lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nome-Figurante", 35 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Cpf", 12 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Pis", 12 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Data-Pgto", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nº Recibo", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Vlr-Bruto", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Vlr-Desconto", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Vlr-Líquido", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                //var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                //var hd2 = lst.Columns.Add("Data-Pgto", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                //var hd3 = lst.Columns.Add("Nº Recibo", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                //var hd4 = lst.Columns.Add("Vlr-Líquido", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                //var hd5 = lst.Columns.Add("11%", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                //var hd6 = lst.Columns.Add("20%", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                //var hd7 = lst.Columns.Add("Vlr-Recolher", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
    
                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeRecibos(ICodigoUsuario, nome, idpessoa, de, ate, IdFirma));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Figurante(s).") + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SelecionaTodosOsItens(ListView lst)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                foreach (ListViewItem list in lst.Items)
                {
                    list.Checked = true;

                }

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
        private void LimpaTabelaTemporaria()
        {
            var repositorioDeFigurantePedido = new RepositorioDeFigurantesPedidos();
            try
            {
                repositorioDeFigurantePedido.DeletaReciboTemp(ICodigoUsuario);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void LimpaTabelaTemporaria(int idfirma)
        {
            var repositorioDeFigurantePedido = new RepositorioDeFigurantesPedidos();
            try
            {
                repositorioDeFigurantePedido.DeleteReciboTemp();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void RegistraItem(int idfirma, int idpessoa, string recibo)
        {
            var repositorioDeFigurantePedido = new RepositorioDeFigurantesPedidos();
            try
            {
                repositorioDeFigurantePedido.InsereReciboTemp(ICodigoUsuario, idfirma, idpessoa, recibo);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void CarregaTabelaTemporaria(ListView lst)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                LimpaTabelaTemporaria(IdFirma);

                if (ItemSelecionado(lst))
                {
                    foreach (ListViewItem list in lst.Items)
                    {
                        if (list.Checked) //Convert.ToInt32(list.SubItems[0].Text)
                        {
                            RegistraItem(IdFirma, Convert.ToInt32(list.SubItems[0].Text), Convert.ToString(list.SubItems[5].Text));
                        }
                    }
                }
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

        private bool ItemSelecionado(ListView lst)
        {
            Cursor = Cursors.WaitCursor;

            foreach (ListViewItem list in lstRecibo.Items)
            {
                if (list.Checked) //Convert.ToInt32(list.SubItems[0].Text)
                {
                    return true;
                }
            }

            Cursor = Cursors.Default;

            return false;
        }

        private void toolImprimir_Click(object sender, System.EventArgs e)
        {
            try
            {
                CarregaTabelaTemporaria(lstRecibo);
                ExibeRelatorio();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
            
        }

        private void ExibeRelatorio()
        {
            try
            {
                Form formulario = new frmRecolheInss();
                frmRecolheInss.IdFirma = IdFirma;
                frmRecolheInss.De = Convert.ToDateTime(txtDe.Text);
                frmRecolheInss.Ate = Convert.ToDateTime(txtAte.Text); 

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void tstNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int idmatricula = 0;

                if (tstMatricula.Text != string.Empty) { idmatricula = Convert.ToInt32(tstMatricula.Text); }
                ListaFigurantes(lstRecibo, tstNome.Text, idmatricula, null, null, qtdPorNota);

            }
        }

        private void toolAtualizar_Click(object sender, System.EventArgs e)
        {
            ExecutaConsulta();
        }

        private void tstMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { ExecutaConsulta(); }
        }

        private void ExecutaConsulta()
        {
            try
            {
                int idmatricula = 0;

                if (tstMatricula.Text != string.Empty) { idmatricula = Convert.ToInt32(tstMatricula.Text); }
                ListaFigurantes(lstRecibo, tstNome.Text, idmatricula, Convert.ToDateTime(txtDe.Text), Convert.ToDateTime(txtAte.Text), qtdPorNota);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Erro: ") +
                Environment.NewLine + string.Format(ex.Message),
                string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void cboNmeFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNmeFirma.Selected)
            {
                IdFirma = Convert.ToInt32(RepositorioDeFirmas.Retorna.IdFirma(cboNmeFirma.Text));
            }

        }

        private void chkSelecionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelecionar.Checked) {
                SelecionaTodosOsItens(lstRecibo);

            }
        }
    }
}
