using System;
using System.Windows.Forms;
using Agencia.Dominio.Servico;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Relatorios;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmPosicaoCache : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }
        private ListViewColumnSorter lvwColumnSorter;

        private int IdFigurante;

        public frmPosicaoCache()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();

            lstPosicao.ListViewItemSorter = lvwColumnSorter;
            lstCachePendente.ListViewItemSorter = lvwColumnSorter;
            lstPago.ListViewItemSorter = lvwColumnSorter;

            WindowsForm.RegisterFocusEvents(Controls);
        }

        private void frmPosicaoCache_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                IdFirma = IdFirma;
                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                MontaComboNotaFiscal(cmbNotaFiscal, IdFirma);

                ListaFigurantes(lstPosicao, -1, "-", tstMatricula.Text, qtdPosicao);
                tstNome.Focus();

                Cursor = Cursors.Default;
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
        #region Montagem de Listas
     
        private void MontaListaRecibos(ListBox lst, int idpessoa)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeRecibosCache(ICodigoUsuario, idpessoa));
                lst.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Recibo(s) de cache pago.") + ex.Message);
            }
        }
       
        #endregion

        #region Carregamento de ListView

        private void ListaFigurantes(ListView lst, int idfirma, string nome, string idpessoa,ToolStripLabel lab)
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

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterPosicaoDeCache(ICodigoUsuario, idfirma, nome, idpessoa));
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

        private void ListaFigurantesPorNota(ListView lst, int idnota, string nome, ToolStripLabel lab)
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

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeFigurantePorNota(ICodigoUsuario, idnota, nome));
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

        private void ListaCachePendente(ListView lst, int idpessoa, ToolStripLabel lab)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                lst.Columns.Clear();

                lst.Columns.Add("Código", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nº Pedido", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Dt.Gravação", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Programa-Produto", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Tipo-Cache", 20 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Bruto", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Inss", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Líquido", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Status", 20 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeCachePendente(ICodigoUsuario, idpessoa));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Cache(s) Pendente(s).") + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private static void ExibeValorTotalCachePendente(ListView lst, int idpessoa)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("", 20 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterValorTotalDeCachePendente(ICodigoUsuario, idpessoa));

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o Valor Total Pendente.") + ex.Message);
            }
        }

        private static void ListaCachePago(ListView lst, int idpessoa, decimal recibo, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nº Pedido", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Dt.Gravação", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Programa-Produto", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Tipo-Cache", 20 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Bruto", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Inss", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Líquido", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeCachePago(ICodigoUsuario, idpessoa, recibo));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Cache(s) Pago(s).") + ex.Message);
            }
        }

        private static void ExibeValorTotalCachePago(ListView lst, int idpessoa, decimal recibo)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("", 20 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterValorTotalDeCachePago(ICodigoUsuario, idpessoa, recibo));

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o Valor Total Pago.") + ex.Message);
            }
        }

        #endregion

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
                ListaCachePendente(lst, id, qtdCachePendente);
                ExibeValorTotalCachePendente(lstVlrCachePendente, IdFigurante);

                ListaCachePago(lstPago, 0, 0, qtdCachePago);
                ExibeValorTotalCachePago(lstVlrPago, 0, 0);

                MontaListaRecibos(lstRecibo, id);
                txt.Text = nome;
                tabDiversos.SelectedTab = tabFigurante;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar a Interface do Figurante.") + ex.Message);
            }
        }

        private void ExibeListaCachePago(ListView lst, decimal recibo, int id, ToolStripLabel lab)
        {
            try
            {
                ListaCachePago(lst, id, recibo, lab);
                ExibeValorTotalCachePago(lstVlrPago, id, recibo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        #endregion

        private void toolAtualizar_Click(object sender, System.EventArgs e)
        {
            ListaFigurantes(lstPosicao, IdFirma, tstNome.Text, tstMatricula.Text, qtdPosicao);

        }

        private void lstPosicao_Click(object sender, System.EventArgs e)
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

        private void lstRecibo_Click(object sender, System.EventArgs e)
        {
            try
            {
                ExibeListaCachePago(lstPago, Convert.ToDecimal(lstRecibo.Text.Substring( 0, 14)), IdFigurante, qtdCachePago);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void tsImprimeRecibo_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (lstRecibo.Text != "") { ExibeRelatorio(IdFigurante, Convert.ToDecimal(lstRecibo.Text.Substring(0, 14)), 1); }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    BaixaCache(Convert.ToDateTime(dtBaixa.Text), lstCachePendente);

                    ListaCachePendente(lstCachePendente, IdFigurante, qtdCachePendente);
                    ExibeValorTotalCachePendente(lstVlrCachePendente, IdFigurante);

                    ListaCachePago(lstPago, 0, 0, qtdCachePago);
                    ExibeValorTotalCachePago(lstVlrPago, 0, 0);

                    MontaListaRecibos(lstRecibo, IdFigurante);

                    MessageBox.Show(string.Format("Baixa de Cache registrada com sucesso."), string.Format("Registro de Baixa de Cache"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool PossuiReciboProvisorio(ListView lst)
        {
            foreach (ListViewItem list in lst.Items)
            {
                if (!list.Checked) continue;
                if (list.SubItems[8].Text != string.Empty) return false;

            }

            return true;
        }

        private void BaixaCache(DateTime dtbaixa, ListView lst)
        {
            var repositorioDePedidoFigurante = new RepositorioDeFigurantesPedidos();

            try
            {
                Cursor = Cursors.WaitCursor;
                var recibo = Recibo.Numero(dtbaixa);

                foreach (ListViewItem list in lst.Items)
                {
                    if (!list.Checked) continue;
                    Entidade.Existe.ItemReciboProvisorio(IdFigurante, Convert.ToInt32(list.SubItems[0].Text));
                    repositorioDePedidoFigurante.RegistraBaixa(ICodigoUsuario, IdFigurante, Convert.ToInt32(list.SubItems[0].Text), dtbaixa, Convert.ToDecimal(recibo));
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }

        }
       
        private void toolbaixaCache_Click(object sender, EventArgs e)
        {
            try
            {
                if (PossuiReciboProvisorio(lstCachePendente))
                {
                    var datavalida = Funcoes.DataDeBaixaValida(Convert.ToDateTime(dtBaixa.Text));
                    if (datavalida) { throw new Exception("A data da baixa não pode ser superior a data Atual"); }

                    RegistraBaixa();
                }
                else
                {
                    var msg = "";
                    msg = "O figurante " + txtPessoa + ", possui" + "\n" + "Recibo(s) provisório(s) para o(s) pedido(s) selecionado(s). " + "\n";
                    msg += "\n" + "O usuário poderá proceder de acordo com as opções abaixo: " + "\n";
                    msg += "\n" + "* Efetuar a baixa através do recibo já criado, acessando o módulo Emissão/Recibo Provisório";
                    msg += "\n" + "* Ou excluir o recibo e através do módulo Posição Cache, efetuar a baixa.";
 
                    MessageBox.Show(msg + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                ListaFigurantesPorNota(lstPosicao, Convert.ToInt32(cmbNotaFiscal.SelectedValue), tstNome.Text, qtdPorNota);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void tstMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            tstNome.Text = string.Empty;
            if (e.KeyChar == 13) { ListaFigurantes(lstPosicao, IdFirma, tstNome.Text, tstMatricula.Text, qtdPosicao); }

        }

        private void tstNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            tstMatricula.Text = string.Empty;
            if (e.KeyChar == 13) { ListaFigurantes(lstPosicao, IdFirma, tstNome.Text, tstMatricula.Text, qtdPosicao); }

        }

        private void cmbNotaFiscal_SelectedValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cmbNotaFiscal.SelectedValue == null) { return; }

            //    ListaFigurantesPorNota(lstPosicao, Convert.ToInt32(cmbNotaFiscal.SelectedValue), tstNome.Text, qtdPorNota);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            //}

        }

        private void cmbNotaFiscal_Click(object sender, EventArgs e)
        {
            tstMatricula.Text = string.Empty;
            tstNome.Text = string.Empty;
        }

        private void lstPago_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.lstPago.Sort();
        }

        private void lstCachePendente_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.lstCachePendente.Sort();
        }

        private void lstPosicao_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.lstPosicao.Sort();
        }

        private void toolGeraReciboManual_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int i = 0;
                for (i = 1; i <= 499; i++)
                {
                    RepositorioDeFigurantesPedidos.Executa.ReciboManual();
                }

                MessageBox.Show(i + ", recibos gerados com sucesso.", "Geração Manual de Recibos Antigos...", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //// Instancio o form2 (que é o ProgressBar)
                //frmProgressBar form = new frmProgressBar();

                //// Utilizo o método show para abrir o form
                //form.Show();

                //// Esta é a quantidade de vezes em que o UpdateBar será atualizado
                //int X = 10;



                ///* Configuro o valor máximo da barra. Neste caso é X, mas se eu tivesse 10 laços poderia colocar o
                //*tamanho máximo como X*10. Também poderia atualizar a cada função. Para isso poderia inserir o
                //*método AtualizaBarra antes de executar qualquer função, e então a barra aumentaria um pouco a cada  
                //*função
                //*/
                //form.MaximumBar(X);

                //// Faço o laço para atualizar a barra
                //for (int i = 0; i < X; i++)
                //{
                //    // Método que atualiza a barra e o texto da barra
                //    form.AtualizaBarra("Atualizando barra...");
                //    // Insiro algum código que desejo e vou mostrando o status da atualização
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;

            }
        }
        
    }
}
