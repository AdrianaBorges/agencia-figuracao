using System;
using System.Windows.Forms;
using Agencia.Dominio.Servico;
using Agencia.Infraestrutura.DAL;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Relatorios;

namespace Agencia.WindowsUI
{
    public partial class frmReciboProvisorio : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }

        private int IdFigurante;
        private ListViewColumnSorter lvwColumnSorter;

        public frmReciboProvisorio()
        {
            InitializeComponent();
           
            lvwColumnSorter = new ListViewColumnSorter();
            this.lstRecibos.ListViewItemSorter = lvwColumnSorter;
            WindowsForm.RegisterFocusEvents(Controls);
           
        }

        private void frmEmissaoDeRecibo_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                IdFirma = IdFirma;
                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                ListaFigurantes(lstPosicao, -1, "-", tstMatricula.Text, qtdPosicao);
                ListaReciboParaBaixa(lstRecibos, 0, qtdCacheRecibos);
                RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;

                MessageBox.Show(string.Format("Erro: ") +
                Environment.NewLine + string.Format(ex.Message),
                string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        #region Carregamento de ListView

        private void ListaFigurantes(ListView lst, int idfirma, string nome, string idpessoa, ToolStripLabel lab)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                lst.Columns.Clear();
                lst.Columns.Add("Código", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nome-Figurante", 40 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("CPF", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("PIS", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("RG", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Data-Último-Pgto", 15 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeFigurante(ICodigoUsuario, idfirma, nome, idpessoa));
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
        //27/07
        private void ListaFigurantePorFirma(ListView lst, int idfirma, string nome, int idpessoa, ToolStripLabel lab)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                lst.Columns.Clear();
                lst.Columns.Add("Código", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nome-Figurante", 40 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("CPF", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("PIS", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("RG", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Data-Último-Pgto", 15 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterFigurantePorFirma(ICodigoUsuario, idfirma, nome, idpessoa));
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

        private static void ListaCachePendente(ListView lst, int idpessoa, int idfirma, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Código", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nº Pedido", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Dt.Gravação", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Programa-Produto", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Tipo-Cache", 20 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Bruto", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Inss", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Líquido", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Status-Pagamento", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeCachePendenteSemRecibo(ICodigoUsuario, idpessoa, idfirma));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Cache(s) Pendente(s).") + ex.Message);
            }
        }

        private static void ListaReciboParaBaixa(ListView lst, int idpessoa, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("", 3 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Data-Registro", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Nº Recibo", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Valor", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Nome-Figurante", 35 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeReciboProvisorio(ICodigoUsuario, idpessoa));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Cache(s) Pago(s).") + ex.Message);
            }
        }

        #endregion

        private void lstPosicao_Click(object sender, EventArgs e)
        {
            try
            {
                ExibeListaDeCache(lstPosicao, lstCachePendente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        #region Carregamento de Interface

        private void ExibeListaDeCache(ListView lst, ListView lstDestino)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    CarregaInterfaceDeFigurante(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text), lstDestino, Convert.ToString(lst.FocusedItem.SubItems[1].Text), txtPessoa);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CarregaInterfaceDeFigurante(int id, ListView lst, string nome, ToolStripTextBox txt)
        {
            try
            {
                IdFigurante = id;
                ListaCachePendente(lst, id, IdFirma, qtdCachePendente);

                ExibeValoresPendentes(lst, mtbVlrBruto, mtbVlrInss, mtbVlrLiquido);
                ListaReciboParaBaixa(lstRecibos, id, qtdCacheRecibos);

                HabilitaBotoes(true);

                txt.Text = nome;
                tabDiversos.SelectedTab = tabFigurante;

                toolEmiteRecibo.Enabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar a Interface do Figurante.") + ex.Message);
            }
        }

        private void ExibeValoresPendentes(ListView lst, ToolStripTextBox bruto, ToolStripTextBox inss, ToolStripTextBox liquido)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                decimal vlrBruto = 0;
                decimal vlrInss = 0;
                decimal vlrLiquido = 0;

                foreach (ListViewItem list in lst.Items)
                {
                    vlrBruto = vlrBruto + Convert.ToDecimal(list.SubItems[5].Text);
                    vlrInss = vlrInss + Convert.ToDecimal(list.SubItems[6].Text);
                    vlrLiquido = vlrLiquido + Convert.ToDecimal(list.SubItems[7].Text);

                }

                bruto.Text = Convert.ToString(vlrBruto);
                inss.Text = Convert.ToString(vlrInss);
                liquido.Text = Convert.ToString(vlrLiquido);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                Cursor = Cursors.Default;

            }
        }

        #endregion

        private void toolAtualizar_Click(object sender, EventArgs e)
        {
            ListaFigurantes(lstPosicao, IdFirma, tstNome.Text, tstMatricula.Text, qtdPosicao);
        }

        private void GeraReciboProvisorio(DateTime dtbaixa, ListView lst)
        {
            Cursor = Cursors.WaitCursor;

            var repositorioDePedidoFigurante = new RepositorioDeFigurantesPedidos();
            var repositorioDePedidos = new RepositorioDePedidos();

            try
            {
                var recibo = Recibo.Numero(dtbaixa);
                repositorioDePedidoFigurante.GeraNumeroRecibo(ICodigoUsuario, IdFigurante, Convert.ToDecimal(recibo), dtbaixa);

                foreach (ListViewItem list in lst.Items)
                {
                    if (list.Checked)
                    {
                        int idpedido = Convert.ToInt32(repositorioDePedidos.ObterIdPedido(ICodigoUsuario, list.SubItems[1].Text, IdFigurante));
                        repositorioDePedidoFigurante.ReciboProvisorio(ICodigoUsuario, IdFigurante, Convert.ToInt32(list.SubItems[0].Text), Convert.ToDecimal(recibo), idpedido);
                    }
                }

                MessageBox.Show(string.Format("Recibo Provisório Nº " + recibo + ", gerado com sucesso."), string.Format("Emissão de Recibo Provisório"), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void toolEmiteRecibo_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdFigurante > 0)
                {
                    GeraReciboProvisorio(DateTime.Now, lstCachePendente);
                    AtualizaTela();
                    toolEmiteRecibo.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void AtualizaTela()
        {
            ListaCachePendente(lstCachePendente, IdFigurante, IdFirma, qtdCachePendente);

            ExibeValoresPendentes(lstCachePendente, mtbVlrBruto, mtbVlrInss, mtbVlrLiquido);
            ListaReciboParaBaixa(lstRecibos, IdFigurante, qtdCacheRecibos);

        }

        private void ExclusaoDeReciboProvisorio(ListView lst)
        {
            var repositorioDePedidoFigurante = new RepositorioDeFigurantesPedidos();
            Cursor = Cursors.WaitCursor;

            try
            {
                foreach (ListViewItem list in lst.Items)
                {
                    if (list.Checked)
                    {
                        repositorioDePedidoFigurante.ExcluiReciboProvisorio(ICodigoUsuario, Convert.ToDecimal(list.SubItems[2].Text), Convert.ToInt32(list.SubItems[4].Text.Substring(0,7)));
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

        private void HabilitaBotoes(bool estado)
        {
            btnImprimir.Enabled = estado;
            btnBaixar.Enabled = estado;
            btnExcluir.Enabled = estado;

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                ExclusaoDeReciboProvisorio(lstRecibos);
                AtualizaTela();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExibeRelatorio(int idpessoa, decimal nrrb, int status)
        {
            try
            {
                Form formulario = new frmRecibo();
                frmRecibo.IdPessoa = idpessoa;
                frmRecibo.NumeroRecibo = nrrb;
                frmRecibo.Status = status;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ImprimeReciboProvisorio(lstRecibos); 
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ImprimeReciboProvisorio(ListView lst)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                foreach (ListViewItem list in lst.Items)
                {
                    if (list.Checked)
                    {
                        ExibeRelatorio(Convert.ToInt32(list.SubItems[4].Text.Substring(0,7)), Convert.ToDecimal(list.SubItems[2].Text), 0);
                    }
                }

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void RegistraBaixa()
        {
            try
            {
                if (dtBaixa.Text == string.Empty)
                {
                    throw new Exception("Informe a data da baixa");
                }
                else
                {
                    BaixaCache(Convert.ToDateTime(dtBaixa.Text), lstRecibos);
                    AtualizaTela();

                    MessageBox.Show(string.Format("Baixa de Cache registrada com sucesso."), string.Format("Registro de Baixa de Cache"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BaixaCache(DateTime dtbaixa, ListView lst)
        {
            var repositorioDePedidoFigurante = new RepositorioDeFigurantesPedidos();

            try
            {
                Cursor = Cursors.WaitCursor;
                //var recibo = Recibo.Numero(dtbaixa);
                var recibo = "";
                
                foreach (ListViewItem list in lst.Items)
                {
                    if (!list.Checked) continue;

                    recibo = list.SubItems[2].Text;
                    IdFigurante = Convert.ToInt32(list.SubItems[4].Text.Substring(0,7));
                    //var Id = Convert.ToInt32(list.SubItems[2].Text.Substring(0, 6));

                    //Entidade.Existe.ItemReciboProvisorio(IdFigurante, Convert.ToInt32(Id));
                    repositorioDePedidoFigurante.RegistraBaixaPorReciboProvisorio(ICodigoUsuario, IdFigurante, dtbaixa, Convert.ToDecimal(recibo));
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


        private void btnBaixar_Click(object sender, EventArgs e)
        {
            try
            {
                var datavalida = Funcoes.DataDeBaixaValida(Convert.ToDateTime(dtBaixa.Text));
                if (datavalida) { throw new Exception("A data da baixa não pode ser superior a data Atual"); }

                RegistraBaixa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void lstCachePendente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tstNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            tstMatricula.Text = string.Empty;
            if (e.KeyChar == 13) { ListaFigurantes(lstPosicao, IdFirma, tstNome.Text, tstMatricula.Text, qtdPosicao); }
        }

        private void tstMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            tstNome.Text = string.Empty;
            if (e.KeyChar == 13) { ListaFigurantes(lstPosicao, IdFirma, tstNome.Text, tstMatricula.Text, qtdPosicao); }
        }

        private void lstRecibos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.lstRecibos.Sort();
        }

        private void cboNmeFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNmeFirma.Selected)
            {
                IdFirma = Convert.ToInt32(RepositorioDeFirmas.Retorna.IdFirma(cboNmeFirma.Text));
                ListaFigurantePorFirma(lstPosicao, IdFirma, tstNome.Text, 0, qtdPosicao);

            }

        }
    }
}
