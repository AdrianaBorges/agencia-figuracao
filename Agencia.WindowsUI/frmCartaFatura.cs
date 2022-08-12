using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmCartaFatura : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }
        private ListViewColumnSorter lvwColumnSorter;
        
        private RepositorioDeCartasFaturas _repositorioDeCartaFatura;
        private CartaFaturaDao _dao;

        public frmCartaFatura()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();

            lstCartaFatura.ListViewItemSorter = lvwColumnSorter;
            lstPedidoGravado.ListViewItemSorter = lvwColumnSorter;
            lstPedidoDisponivel.ListViewItemSorter = lvwColumnSorter;

            txtCartaReferencia.Text = string.Empty;

            WindowsForm.RegisterFocusEvents(Controls);

        }

        private void frmCartaFatura_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                pnlCartaFatura.Enabled = false;
                ListaCartaFatura(lstCartaFatura, "0", IdFirma);

                tooTipSelecionado.Enabled = false;
                tooTipFiltraPedido.Enabled = false;
                tooTipRegistraPedido.Enabled = false;
                TxtConsulta.Focus();

                RepositorioDeFirmas.MontaCombo.Firma(tooCmbFirma, ICodigoUsuario);

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

        #region Montagem de Combos

        private void MontaComboProduto(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeProdutos().ObterListaDeProdutos(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Produto(s) cadastrados.") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de ListView

        private void ListaCartaFatura(ListView lst, string numcarta, int idfirma)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Carta-Fatura", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd3 = lst.Columns.Add("Produto-Programa", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd4 = lst.Columns.Add("Dt-Emissão", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd5 = lst.Columns.Add("Dt-Vencimento", 12 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd6 = lst.Columns.Add("Dt-Recebimento", 12 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd7 = lst.Columns.Add("Total-Cache", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd8 = lst.Columns.Add("Total-Realizado", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd9 = lst.Columns.Add("Nota-Fiscal", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeCartasFaturas().ObterListaDeCartasFaturas(ICodigoUsuario, numcarta, idfirma));
                qtdCarta.Text = lst.Items.Count.ToString();
                qtdCarta.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Carta(s) cadastrada(s).") + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ListaPedidoParaFatura(ListView lst, int idcartafatura, ToolStripLabel lab)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Número-Pedido", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd3 = lst.Columns.Add("Data-Gravação", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd4 = lst.Columns.Add("Produto-Programa", 38 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd5 = lst.Columns.Add("Total-Pedido", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd6 = lst.Columns.Add("Total-Realizado", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDePedidos().ObterListaDePedidosPorFatura(ICodigoUsuario, idcartafatura));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Pedidos(s) cadastrado(s) para a Carta Fatura.") + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ListaPedidoDisponivel(ListView lst, int idcartafatura, ToolStripLabel lab, DateTime de, DateTime ate)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Número-Pedido", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd3 = lst.Columns.Add("Data-Gravação", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd4 = lst.Columns.Add("Produto-Programa", 38 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd5 = lst.Columns.Add("Total-Pedido", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd6 = lst.Columns.Add("Total-Realizado", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDePedidos().ObterListaDePedidosDisponiveis(ICodigoUsuario, idcartafatura, de, ate));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Pedidos(s) cadastrado(s) para a Carta Fatura.") + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }
        #endregion

        #region Carregamento de Interface

        private void ExibeCartaFaturaSelecionada(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlCartaFatura.Enabled = true;
                    MontaComboProduto(cmbPrograma);
                    RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);

                    CarregaInterfaceDeCartaFatura(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                    ListaPedidoParaFatura(lstPedidoGravado, Convert.ToInt32(txtCodigo.Text), qtdPedidoSelecionado);
                    ListaPedidoDisponivel(lstPedidoDisponivel, 0, qtdPedidoDisponivel, Convert.ToDateTime(dtpDe.Value), Convert.ToDateTime(dtpAte.Value));

                    tooTipSelecionado.Enabled = true;
                    tooTipFiltraPedido.Enabled = true;
                    tooTipRegistraPedido.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CarregaInterfaceDeCartaFatura(int id)
        {
            var repositorioDeFatura = new RepositorioDeCartasFaturas();
            try
            {
                var result = repositorioDeFatura.ObterCartaFaturaPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));
                if (result.IdFirma != 0) { new WindowsForm().SelectById(cboNmeFirma, Convert.ToString(result.IdFirma)); }

                txtCodigo.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdCartaFatura));
                dtpEmissao.Text = Convert.ToString(result.DataEmissao);
                txtNumFatura.Text = Convert.ToString (result.NumCarta);
                new WindowsForm().SelectById(cmbPrograma, Convert.ToString(result.IdPrograma));
                txtObservacao.Text = result.Observacao;
                dtpVencimento.Text = Convert.ToString(result.DataVencimento);
                dtpRecebimento.Text = Convert.ToString(result.DataRecebimento);
                txtCartaReferencia.Text = Convert.ToString(result.NumCarta); 

                tabDiversos.SelectedTab = tabCartaFatura;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface da Carta Fatura.") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de Objeto

        private void CarregaObjetoCartaFatura(CartaFatura cf)
        {
            try
            {
                cf.IdFirma = Convert.ToInt32(cboNmeFirma.SelectedValue);
                cf.IdCartaFatura = txtCodigo.Text != string.Empty ? Convert.ToInt32(txtCodigo.Text) : 0;
                cf.NumCarta = Convert.ToInt32(txtNumFatura.Text);
                cf.DataEmissao = Convert.ToDateTime(dtpEmissao.Text);
                cf.IdPrograma = Convert.ToInt32(cmbPrograma.SelectedValue);
                cf.Observacao = txtObservacao.Text;
                cf.DataVencimento = Convert.ToDateTime(dtpVencimento.Text);
                cf.DataRecebimento = Convert.ToDateTime(dtpRecebimento.Text);

                cf.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.CartaFatura(cf);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Carta Fatura. " + ex.Message);
            }
        }

        #endregion

        #region Persiste CartaFatura

        private void CadastraCartaFatura()
        {
            var fatura = new CartaFatura();
            var repositorioDeFatura = new RepositorioDeCartasFaturas();

            try
            {
                CarregaObjetoCartaFatura(fatura);
                Entidade.Existe.CartaFatura(fatura);
                repositorioDeFatura.Insere(fatura);

                MessageBox.Show(string.Format("Carta Fatura registrada com sucesso."), string.Format("Registro de Carta Fatura"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Text = RepositorioDeCartasFaturas.Retorna.IdCartaFatura(fatura.NumCarta, fatura.IdPrograma);
                ListaCartaFatura(lstCartaFatura, "0", IdFirma);

                ListaPedidoParaFatura(lstPedidoGravado, Convert.ToInt32(txtCodigo.Text), qtdPedidoSelecionado);
                ListaPedidoDisponivel(lstPedidoDisponivel, 0, qtdPedidoDisponivel, Convert.ToDateTime(dtpDe.Value), Convert.ToDateTime(dtpAte.Value));

                tooTipSelecionado.Enabled = true;
                tooTipFiltraPedido.Enabled = true;
                tooTipRegistraPedido.Enabled = true;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraCartaFatura()
        {
            var fatura = new CartaFatura();
            var repositorioDeFatura = new RepositorioDeCartasFaturas();

            try
            {
                CarregaObjetoCartaFatura(fatura);
                repositorioDeFatura.Altera(fatura);

                MessageBox.Show(string.Format("Carta Fatura alterada com sucesso."), string.Format("Alteração de Carta Fatura"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaCartaFatura(lstCartaFatura, "0", IdFirma);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiCartaFatura()
        {
            var fatura = new CartaFatura();
            var repositorioDeFatura = new RepositorioDeCartasFaturas();

            try
            {
                CarregaObjetoCartaFatura(fatura);
                repositorioDeFatura.Exclui(fatura);

                MessageBox.Show(string.Format("Carta Fatura excluida com sucesso."), string.Format("Exclusão de Carta Fatura"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaCartaFatura(lstCartaFatura, "0", IdFirma);
                Funcoes.LimpaCamposFormulario(Controls);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        #endregion

        #region Persiste Pedido para Carta Fatura

        private void CadastraPedidoParaFatura(ListView lst, int idcartafatura)
        {
            var repositorioDeFatura = new RepositorioDeCartasFaturas();

            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    repositorioDeFatura.InserePedido(ICodigoUsuario, idcartafatura, Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));

                    MessageBox.Show(string.Format("Pedido registrado para a Carta Fatura com sucesso."), string.Format("Registro de Pedido de Gravação"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListaPedidoParaFatura(lstPedidoGravado, Convert.ToInt32(txtCodigo.Text), qtdPedidoSelecionado);
                    ListaPedidoDisponivel(lstPedidoDisponivel, 0, qtdPedidoDisponivel, Convert.ToDateTime(dtpDe.Text), Convert.ToDateTime(dtpAte.Text));

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiPedido(int idcartafatura, int idpedido)
        {
            var repositorioDeFatura = new RepositorioDeCartasFaturas();
            try
            {
                repositorioDeFatura.ExcluiPedido(ICodigoUsuario, idpedido);

                MessageBox.Show(string.Format("Pedido excluido da Carta Fatura com sucesso."), string.Format("Exclusão de Pedido"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaPedidoParaFatura(lstPedidoGravado, Convert.ToInt32(txtCodigo.Text), qtdPedidoSelecionado);
                ListaPedidoDisponivel(lstPedidoDisponivel, 0, qtdPedidoDisponivel, Convert.ToDateTime(dtpDe.Text), Convert.ToDateTime(dtpAte.Text));

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void GravaPedido(int idcartafatura, int idpedido)
        {
            var repositorioDeFatura = new RepositorioDeCartasFaturas();
            try
            {
                repositorioDeFatura.InserePedido(ICodigoUsuario, idcartafatura, idpedido);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        #endregion

        #region Limpa Interface

        private void LimpaCamposCartaFatura()
        {
            txtCodigo.Text = string.Empty;
            txtNumFatura.Text = string.Empty;
            cmbPrograma.SelectedValue = 0;
            txtObservacao.Text = string.Empty;

        }

        #endregion

        private void lstCartaFatura_Click(object sender, EventArgs e)
        {
            try
            {
                ExibeCartaFaturaSelecionada(lstCartaFatura);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void toolAtualizar_Click(object sender, EventArgs e)
        {
            if (tooCmbFirma.Selected)
            {
                IdFirma = Convert.ToInt32(RepositorioDeFirmas.Retorna.IdFirma(tooCmbFirma.Text));

            }

            ListaCartaFatura(lstCartaFatura, TxtConsulta.Text, IdFirma);

        }

        private void novaFatura_Click(object sender, EventArgs e)
        {
            try
            {
                pnlCartaFatura.Enabled = true;

                MontaComboProduto(cmbPrograma);
                RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);

                LimpaCamposCartaFatura();
                dtpEmissao.Text = Convert.ToString(DateTime.Now);
                txtNumFatura.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void CadastrarFatura_Click(object sender, EventArgs e)
        {
            try
            {
                CadastraCartaFatura();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void AlterarFatura_Click(object sender, EventArgs e)
        {
            try
            {
                AlteraCartaFatura();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void ExcluiFatura_Click(object sender, EventArgs e)
        {
            ExcluiCartaFatura();
        }

        private void excluiPedidoFatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstPedidoGravado.SelectedItems.Count != 0)
                {
                    if (MessageBox.Show("Confirma a exclusão do Pedido " + lstPedidoGravado.FocusedItem.SubItems[1].Text + " - " + lstPedidoGravado.FocusedItem.SubItems[3].Text + " da Carta Fatura?", "Atenção...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (lstPedidoGravado.SelectedItems[0].Selected)
                        {
                            ExcluiPedido(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(lstPedidoGravado.FocusedItem.SubItems[0].Text));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void tooRegistraPedido_Click(object sender, EventArgs e)
        {
            AcionaGravacaoDePedidoParaFatura(lstPedidoDisponivel);

        }

        private void AcionaGravacaoDePedidoParaFatura(ListView lst)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                foreach (ListViewItem list in lst.Items)
                {
                    if (list.Checked)
                    {
                        GravaPedido(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(list.SubItems[0].Text));
                    }
                }
                    
                MessageBox.Show(string.Format("Pedido(s) registrado(s) para Carta Fatura com sucesso."), string.Format("Registro de Pedido"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaPedidoParaFatura(lstPedidoGravado, Convert.ToInt32(txtCodigo.Text), qtdPedidoSelecionado);
                ListaPedidoDisponivel(lstPedidoDisponivel, Convert.ToInt32(txtCodigo.Text), qtdPedidoDisponivel, Convert.ToDateTime(dtpDe.Text), Convert.ToDateTime(dtpAte.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                Cursor = Cursors.Default;

            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void tooFiltrarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                ListaPedidoDisponivel(lstPedidoDisponivel, Convert.ToInt32(txtCodigo.Text), qtdPedidoDisponivel, Convert.ToDateTime(dtpDe.Value), Convert.ToDateTime(dtpAte.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void lstPedidoDisponivel_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.lstPedidoDisponivel.Sort();
        }

        private void lstPedidoGravado_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.lstPedidoGravado.Sort();
        }

        private void lstCartaFatura_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.lstCartaFatura.Sort();
        }

        private void TxtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { ListaCartaFatura(lstCartaFatura, TxtConsulta.Text, IdFirma); }

        }

        private void tooCmbFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tooCmbFirma.Selected)
            {
                IdFirma = Convert.ToInt32(RepositorioDeFirmas.Retorna.IdFirma(tooCmbFirma.Text));
                ListaCartaFatura(lstCartaFatura, "", IdFirma);

            }

        }
    }
}
