using System;
using System.Drawing;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmPedidoDeGravacao : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }
        private ListViewColumnSorter lvwColumnSorter;

        private RepositorioDePedidos _repositorioDePedido;
        private PedidoDao _dao;
        private bool carregaListaTipoFiguracao = false;

        public frmPedidoDeGravacao()
        {
            InitializeComponent();
            
            lvwColumnSorter = new ListViewColumnSorter();
            
            lstPedido.ListViewItemSorter = lvwColumnSorter;
            lstFigurante.ListViewItemSorter = lvwColumnSorter;
            txtPedidoReferencia.Text = string.Empty;

            WindowsForm.RegisterFocusEvents(Controls);

        }

        private void frmPedidoDeGravacao_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                pnlPedido.Enabled = false;
                pnlItens.Enabled = false;
                pnlEquipe.Enabled = false;
                pnlFigurante.Enabled = false;

                ListaPedidos(lstPedido, TxtConsulta.Text, 0);
                
                tooTipItem.Enabled = false;
                tooTipEquipe.Enabled = false;
                tooFiguracao.Enabled = false;

                TxtConsulta.Focus();

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

        private void MontaComboTipoFiguracao(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeTipoFiguracao().ObterListaTipoFiguracao(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Tipo(s) de Figuração cadastrados.") + ex.Message);
            }
        }

        private void MontaComboProduto(ToolStripComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeProdutos().ObterListaDeProdutos(ICodigoUsuario));
                cmb.ComboBox.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Produto(s) cadastrados.") + ex.Message);
            }
        }

        private void MontaComboEmpresa(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeEmpresas().ObterListaDeEmpresas(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
               throw new Exception(string.Format("Não foi possível listar o(s) Empresa(s) cadastrados.") + ex.Message);
            }
        }

        private void MontaComboColaborador(ComboBox cmb, int produto, int pedido)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeColaboradores().ObterListaDeColaboradoresPorProduto(ICodigoUsuario, produto, pedido));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
               throw new Exception(string.Format("Não foi possível listar o(s) Empresa(s) cadastrados.") + ex.Message);
            }
        }

        private void MontaComboTipoDeFigurante(ComboBox cmb, int pedido)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeItensPedidos().ObterListaDeTiposDeFiguracao(ICodigoUsuario, pedido));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Tipo(s) de Figuração cadastrados.") + ex.Message);
            }
        }

        private void MontaComboFigurante(ComboBox cmb, int pedido, int tipoconsulta, string dado)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeFigurantes().ObterListaDeFigurantesDisponivelParaPedido(ICodigoUsuario, pedido, tipoconsulta, dado));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Figurantes(s) cadastrados.") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de ListView

        private void ListaPedidos(ListView lst, string dado, int idproduto)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Numero-Pedido", 12 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Data-Gravação", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Produto-Programa", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Extra", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Qtd-Figurante(s)", 12 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Valor-Pedido", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Nome-Firma", 35 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDePedidos().ObterListaDePedidos(ICodigoUsuario, dado, idproduto ));
                qtdPedido.Text = lst.Items.Count.ToString();
                qtdPedido.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Pedido(s) cadastrados.") + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ListaItenPedido(ListView lst, int idpedido)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Tipo-de-Figuração", 25 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Quantidade", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Valor-Cache", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeItensPedidos().ObterListaItensPedidos(ICodigoUsuario, idpedido));
                qtdItens.Text = lst.Items.Count.ToString();
                qtdItens.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

                ListaValoresItenPedido(lstTotalPedido, idpedido);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Itens de Pedido cadastrados.") + ex.Message);
            }
        }

        private void ListaValoresItenPedido(ListView lst, int idpedido)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Nº-Figurante(s)", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd2 = lst.Columns.Add("Valor-Realizado", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd3 = lst.Columns.Add("Valor-Cache", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeItensPedidos().ObterValoresItensPedido(ICodigoUsuario, idpedido));

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Valores ref. aos Itens de Pedido cadastrados.") + ex.Message);
            }
        }

        private void ListaEquipePedido(ListView lst, int idpedido)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Nome-Colaborador", 38 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd3 = lst.Columns.Add("Função-Exercida", 15 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeEquipesPedidos().ObterListaDeEquipePedido(ICodigoUsuario, idpedido));
                qtdEquipe.Text = lst.Items.Count.ToString();
                qtdEquipe.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Equipe de Produção para o Pedido de Gravação.") + ex.Message);
            }
        }

        private void ListaPedidoFigurante(ListView lst, int idpedido)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Nome-Figurante", 40 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd3 = lst.Columns.Add("Tipo-de-Figuração", 25 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd4 = lst.Columns.Add("Vlr-Líquido", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd5 = lst.Columns.Add("Vlr-INSS", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd6 = lst.Columns.Add("Vlr-Bruto", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeFiguracaoPedido(ICodigoUsuario, idpedido));
                qtdFigurante.Text = lst.Items.Count.ToString();
                qtdFigurante.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Equipe de Produção para o Pedido de Gravação.") + ex.Message);
            }

        }
        #endregion

        #region Carregamento de Interface

        private void ExibePedidoSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlPedido.Enabled = true;

                    MontaComboProduto(cmbPrograma);
                    MontaComboProduto(tooCmbProduto);
                    MontaComboEmpresa(cmbEmpresa);
                    MontaComboTipoDeFigurante(cmbTipoFigurante, Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                    MontaComboTipoFiguracao(cmbTipoFiguracao);
                    RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);

                    CarregaInterfaceDePedido(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                    
                    ListaItenPedido(lstItens, Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                    ListaEquipePedido(lstEquipe, Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                    ListaPedidoFigurante(lstFigurante, Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                    
                    MonitoraInclusaoDeFigurante(lstFigurante, Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                    tooTipItem.Enabled = true;
                    tooTipEquipe.Enabled = true;
                    tooFiguracao.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CarregaInterfaceDePedido(int id)
        {
            var repositorioDePedido = new RepositorioDePedidos();
            try
            {
                var result = repositorioDePedido.ObterPedidoPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));

                txtCodigo.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdPedido));
                new WindowsForm().SelectById(cmbEmpresa , Convert.ToString (result.IdEmpresa));
                mtbCadastro.Text = Convert.ToString(result.DataCadastro);
                chkExtra.Checked = result.Extra == 1 ? true : false;
                txtNumPedido.Text = result.NumPedido;
                mtbGravacao.Text = Convert.ToString(result.DataPedido);

                if (result.IdFirma != 0) { new WindowsForm().SelectById(cboNmeFirma, Convert.ToString(result.IdFirma)); }

                new WindowsForm().SelectById(cmbPrograma, Convert.ToString (result.IdPrograma));
                txtCena.Text = result.Cena;
                txtCapitulo.Text = result.Capitulo;
                mtbHorario.Text = result.Hora;
                mtbInicio.Text = result.HoraInicio;
                mtbTermino.Text = result.HoraFim;

                if (result.Roteiro != string.Empty) { txtRoteiro.Text = result.Roteiro; }

                txtPedidoReferencia.Text = result.NumPedido;
               // tooTotalPrevisto.Text = Convert.ToString(result.TotalPrevisto);
               // tooTotalPedido.Text = Convert.ToString(result.TotalPedido);
               // tooTotalPago.Text = Convert.ToString (result.TotalPago);

                tabDiversos.SelectedTab = tabPedidoGravacao;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface do Pedido de Gravação.") + ex.Message);
            }
        }

        private void ExibeItemPedidoSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlItens.Enabled = true;

                    CarregaInterfaceDeItemPedido(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CarregaInterfaceDeItemPedido(int id)
        {
            var repositorioDeItemPedido = new RepositorioDeItensPedidos();
            try
            {
                var result = repositorioDeItemPedido.ObterItemPedidoPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));

                txtCodItem.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdItem));
                cmbTipoFiguracao.Text = result.DescTipo;
                txtQtdItem.Text = Convert.ToString(result.Qtd);
                txtValorCache.Text = Convert.ToString(result.Valor);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface do(s) Itens do Pedido de Gravação.") + ex.Message);
            }
        }

        private void ExibeEquipePedidoSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlEquipe.Enabled = true;
                    CarregaInterfaceDeEquipePedido(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CarregaInterfaceDeEquipePedido(int id)
        {
            var repositorioDeEquipePedido = new RepositorioDeEquipesPedidos();
            try
            {
                var result = repositorioDeEquipePedido.ObterEquipePedidoPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));

                txtCodEquipe.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdEquipe));
                cmbColaborador.Text = result.NmePessoa;
                cmbFuncao.Text = result.DescCargo;
                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface da Equipe de Produção.") + ex.Message);
            }
        }

        private void ExibePedidoFiguranteSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlFigurante.Enabled = true;
                    CarregaInterfaceDePedidoFigurante(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                    
                    HabilitaCadastroFiguracao(false);
                    HabilitaAlterarEExcluirFiguracao(true);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CarregaInterfaceDePedidoFigurante(int id)
        {
            var repositorioDePedidoFigurante = new RepositorioDeFigurantesPedidos();
            try
            {
                var result = repositorioDePedidoFigurante.ObterFiguracaoPedido(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));

                txtCodFigurante.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdFigPedido));
                cmbFigurante.Text = result.NmePessoa;
                cmbFigurante.SelectedValue = result.IdPessoa;
                new WindowsForm().SelectById(cmbTipoFigurante, Convert.ToString(result.IdTipo));
                txtVlrCache.Text = result.VlrBruto;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar a Interface do Figurante.") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de Objeto

        private void CarregaObjetoPedido(Pedido p)
        {
            try
            {
                p.IdPedido = txtCodigo.Text != string.Empty ? Convert.ToInt32(txtCodigo.Text) : 0;
                p.DataCadastro = Convert.ToDateTime(mtbCadastro.Text);
                p.DataPedido = Convert.ToDateTime(mtbGravacao.Text);
                p.Extra = chkExtra.Checked ? 1 : 0;
                p.NumPedido = txtNumPedido.Text.Trim();
                p.IdEmpresa = Convert.ToInt32(cmbEmpresa.SelectedValue);
                p.IdFirma = Convert.ToInt32(cboNmeFirma.SelectedValue);
                p.IdPrograma = Convert.ToInt32(cmbPrograma.SelectedValue);
                p.Status = "0";
                p.IdCartaFatura = 0;
                p.Hora = mtbHorario.Text;
                p.HoraInicio = mtbInicio.Text;
                p.HoraFim = mtbTermino.Text;
                p.Cena = txtCena.Text;
                p.Capitulo = txtCapitulo.Text;
                p.Roteiro = txtRoteiro.Text;
                p.Observacao = txtObservacao.Text;
                                
                p.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.Pedido(p);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Pedido de Gravação. " + ex.Message);
            }
        }

        private void CarregaObjetoItensPedido(ItemPedido ip)
        {
            try
            {
                ip.IdItem = txtCodItem.Text != string.Empty ? Convert.ToInt32(txtCodItem.Text) : 0;
                ip.IdTipo = Convert.ToInt32(cmbTipoFiguracao.SelectedValue);
                ip.Qtd = Convert.ToInt32 (txtQtdItem.Text);
                ip.Valor = Convert.ToString(txtValorCache.Text).Replace (",",".");
                ip.IdPedido = Convert.ToInt32(txtCodigo.Text);

                ip.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.ItemPedido(ip);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Itens Pedido. " + ex.Message);
            }
        }

        private void CarregaObjetoEquipePedido(EquipePedido ep)
        {
            try
            {
                ep.IdEquipe = txtCodEquipe.Text != string.Empty ? Convert.ToInt32(txtCodEquipe.Text) : 0;
                ep.IdPedido = Convert.ToInt32(txtCodigo.Text);
                ep.IdPessoa = Convert.ToInt32(cmbColaborador.SelectedValue);
                ep.IdCargo = Convert.ToInt32(cmbFuncao.Text.Substring(0,2));
                
                ep.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.EquipePedido(ep);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Itens Pedido. " + ex.Message);
            }
        }

        private void CarregaObjetoPedidoFigurante(PedidoFigurante fp)
        {
            try
            {
                var repositorioDePedidoFigurante = new RepositorioDeFigurantesPedidos();
                var repositorioDeFigurante = new RepositorioDeFigurantes();
                var idpessoa = RepositorioDeFigurantes.Retorna.IdFigurante(cmbFigurante.Text);

                fp.IdFigPedido = txtCodFigurante.Text != string.Empty ? Convert.ToInt32(txtCodFigurante.Text) : 0;
                fp.IdPedido = Convert.ToInt32(txtCodigo.Text);
                fp.IdPessoa = Convert.ToInt32(idpessoa);
                fp.IdTipo = Convert.ToInt32(cmbTipoFigurante.SelectedValue);
                fp.VlrBruto = txtVlrCache.Text;

                var inss = RepositorioDeFigurantesPedidos.Retorna.ValorInss(ICodigoUsuario, fp.IdPessoa, Convert.ToDateTime(mtbGravacao.Text), fp.IdTipo, fp.VlrBruto.Replace(",", "."));
                var bruto = txtVlrCache.Text;
                var liquido = Convert.ToDecimal(bruto) - Convert.ToDecimal(inss);

                fp.VlrInss = Convert.ToString(inss);
                fp.VlrLiquido = Convert.ToString(liquido);

                fp.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.FiguracaoPedido(fp);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Itens Pedido. " + ex.Message);
            }
        }

        #endregion

        #region Persiste Pedido de Gravação

        private void CadastraPedido()
        {
            var pedido = new Pedido();
            var repositorioDePedido = new RepositorioDePedidos();

            try
            {
                CarregaObjetoPedido(pedido);
                Entidade.Existe.PedidoDeGravacao(pedido);
                repositorioDePedido.Insere(pedido);

                MessageBox.Show(string.Format("Pedido de Gravação registrado com sucesso."), string.Format("Registro de Pedido de Gravação"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Text = RepositorioDePedidos.Retorna.IdPedido(pedido.NumPedido);

                ListaItenPedido(lstItens, Convert.ToInt32(txtCodigo.Text));
                ListaEquipePedido(lstEquipe, Convert.ToInt32(txtCodigo.Text));
                ListaPedidoFigurante(lstFigurante, Convert.ToInt32(txtCodigo.Text));
                MontaComboTipoDeFigurante(cmbTipoFigurante, Convert.ToInt32(txtCodigo.Text));

                tooTipItem.Enabled = true;
                tooTipEquipe.Enabled = true;
                tooFiguracao.Enabled = true;

                ListaPedidos(lstPedido, "", 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraPedido()
        {
            var pedido = new Pedido();
            var repositorioDePedido = new RepositorioDePedidos();

            try
            {
                CarregaObjetoPedido(pedido);
                repositorioDePedido.Altera(pedido);

                MessageBox.Show(string.Format("Pedido de Gravação alterado com sucesso."), string.Format("Alteração de Pedido de Gravação"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaPedidos(lstPedido, "", 0);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiPedido()
        {
            var pedido = new Pedido();
            var repositorioDePedido = new RepositorioDePedidos();

            try
            {
                CarregaObjetoPedido(pedido);
                repositorioDePedido.ExclusaoLogica(pedido);

                MessageBox.Show(string.Format("Pedido de Gravação excluido com sucesso."), string.Format("Exclusão de Pedido de Gravação"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaPedidos(lstPedido, "", 0);
                Funcoes.LimpaCamposFormulario(Controls);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }


        #endregion

        #region Persiste ItemPedido

        private void CadastraItemPedido()
        {
            var itempedido = new ItemPedido();
            var repositorioDeItemPedido = new RepositorioDeItensPedidos();

            try
            {
                CarregaObjetoItensPedido(itempedido);
                Entidade.Existe.ItemPedido(itempedido);
                repositorioDeItemPedido.Insere(itempedido);

                //MessageBox.Show(string.Format("Item de Pedido de Gravação registrado com sucesso."), string.Format("Registro de Item de Pedido de Gravação"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodItem.Text = RepositorioDeItensPedidos.Retorna.IdItemPedido(itempedido.IdTipo , Convert.ToString (itempedido.Valor));
                ListaItenPedido(lstItens, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposItensPedido();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraItemPedido()
        {
            var itempedido = new ItemPedido();
            var repositorioDeItemPedido = new RepositorioDeItensPedidos();

            try
            {
                CarregaObjetoItensPedido(itempedido);
                repositorioDeItemPedido.Altera(itempedido);

                MessageBox.Show(string.Format("Item de Pedido de Gravação alterado com sucesso."), string.Format("Alteração de Item de Pedido de Gravação"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaItenPedido(lstItens, Convert.ToInt32(txtCodigo.Text));

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiItemPedido()
        {
            var itempedido = new ItemPedido();
            var repositorioDeItemPedido = new RepositorioDeItensPedidos();

            try
            {
                CarregaObjetoItensPedido(itempedido);
                repositorioDeItemPedido.Exclui(itempedido);

                MessageBox.Show(string.Format("Item de Pedido de Gravação excluído com sucesso."), string.Format("Exclusão de Item de Pedido de Gravação"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaItenPedido(lstItens, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposItensPedido();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }


        #endregion

        #region Persiste Equipe Pedido

        private void CadastraEquipePedido()
        {
            var equipepedido = new EquipePedido();
            var repositorioDeEquipePedido = new RepositorioDeEquipesPedidos();

            try
            {
                CarregaObjetoEquipePedido(equipepedido);
                repositorioDeEquipePedido.Insere(equipepedido);

                //MessageBox.Show(string.Format("Equipe de Produção registrado com sucesso."), string.Format("Registro de Equipe de Produção"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodEquipe.Text = RepositorioDeEquipesPedidos.Retorna.IdEquipe(equipepedido);
                ListaEquipePedido(lstEquipe, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposEquipe();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraEquipePedido()
        {
            var equipepedido = new EquipePedido();
            var repositorioDeEquipePedido = new RepositorioDeEquipesPedidos();

            try
            {
                CarregaObjetoEquipePedido(equipepedido);
                repositorioDeEquipePedido.Altera(equipepedido);

                MessageBox.Show(string.Format("Equipe de Produção alterado com sucesso."), string.Format("Alteração de Equipe de Produção"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaEquipePedido(lstEquipe, Convert.ToInt32(txtCodigo.Text));

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiEquipePedido()
        {
            var equipepedido = new EquipePedido();
            var repositorioDeEquipePedido = new RepositorioDeEquipesPedidos();

            try
            {
                CarregaObjetoEquipePedido(equipepedido);
                repositorioDeEquipePedido.Exclui(equipepedido);

                MessageBox.Show(string.Format("Equipe de Produção excluída com sucesso."), string.Format("Exclusão de Equipe de Produção "), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaEquipePedido(lstEquipe, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposEquipe();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }


        #endregion

        #region Persiste Figurante Pedido

        private void CadastraPedidoFigurante()
        {
            var PedidoFigurante = new PedidoFigurante();
            var repositorioDePedidoFigurante = new RepositorioDeFigurantesPedidos();

            try
            {
                CarregaObjetoPedidoFigurante(PedidoFigurante);
                repositorioDePedidoFigurante.Insere(PedidoFigurante);

                //MessageBox.Show(string.Format("Figurante registrado com sucesso para o Pedido."), string.Format("Registro de Figurante para Pedido"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodFigurante.Text = RepositorioDeFigurantesPedidos.Retorna.IdFiguracaoPedido(PedidoFigurante);
                ListaPedidoFigurante(lstFigurante, Convert.ToInt32(txtCodigo.Text));
                MonitoraInclusaoDeFigurante(lstFigurante, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposFigurante();
                MontaComboFigurante(cmbFigurante, Convert.ToInt32(txtCodigo.Text), 0, "");
                txtFiltrar.Text = string.Empty;
                txtFiltrar.Focus();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraPedidoFigurante()
        {
            var PedidoFigurante = new PedidoFigurante();
            var repositorioDePedidoFigurante = new RepositorioDeFigurantesPedidos();
            
            try
            {
                CarregaObjetoPedidoFigurante(PedidoFigurante);
                repositorioDePedidoFigurante.Altera(PedidoFigurante);

                MessageBox.Show(string.Format("Figurante alterado com sucesso."), string.Format("Alteração de Figurante para Pedido"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaPedidoFigurante(lstEquipe, Convert.ToInt32(txtCodigo.Text));

                HabilitaCadastroFiguracao(true);
                HabilitaAlterarEExcluirFiguracao(false);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiPedidoFigurante()
        {
            var PedidoFigurante = new PedidoFigurante();
            var repositorioDePedidoFigurante = new RepositorioDeFigurantesPedidos();

            try
            {
                CarregaObjetoPedidoFigurante(PedidoFigurante);
                repositorioDePedidoFigurante.Exclui(PedidoFigurante);

                MessageBox.Show(string.Format("Figurante excluída com sucesso do Pedido de Gravação."), string.Format("Exclusão de Figurante para Pedido de Gravação."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaPedidoFigurante(lstFigurante, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposFigurante();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        #endregion

        #region Limpa Interface

        private void LimpaCamposPedido()
        {
            txtCodigo.Text = string.Empty;
            cmbEmpresa.SelectedValue = 0;
            mtbCadastro.Text = string.Empty;
            chkExtra.Checked = false;
            txtNumPedido.Text = string.Empty;
            mtbGravacao.Text = string.Empty;
            cmbPrograma.SelectedValue = 0;
            txtCena.Text = string.Empty;
            txtCapitulo.Text = string.Empty;
            mtbHorario.Text = string.Empty;
            mtbInicio.Text = string.Empty;
            mtbTermino.Text = string.Empty;
            txtObservacao.Text = string.Empty;

        }

        private void LimpaCamposItensPedido()
        {
            txtCodItem.Text = string.Empty;
            cmbTipoFiguracao.Text = string.Empty;
            txtQtdItem.Text = string.Empty;
            txtValorCache.Text = "0";
        }

        private void LimpaCamposEquipe()
        {
            txtCodEquipe.Text = string.Empty;
            cmbColaborador.SelectedValue = 0;
            cmbFuncao.Text = string.Empty;
        }

        private void LimpaCamposFigurante()
        {
            txtCodFigurante.Text = string.Empty;
            cmbFigurante.SelectedValue = 0;
            cmbTipoFigurante.SelectedValue = 0;
            cmbFigurante.Text = string.Empty;
            cmbFigurante.SelectedText = string.Empty;
            txtVlrCache.Text = "0";

        }

        #endregion

        private void toolAtualizar_Click(object sender, EventArgs e)
        {
            ExecutaConsulta();
        }

        private void ExecutaConsulta()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ListaPedidos(lstPedido, TxtConsulta.Text, 0);
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

        private void lstPedido_Click(object sender, EventArgs e)
        {
            try
            {
                ExibePedidoSelecionado(lstPedido);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void novoPedido_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                pnlPedido.Enabled = true;

                ListaItenPedido(lstItens, 0);
                ListaEquipePedido(lstEquipe, 0);
                ListaPedidoFigurante(lstFigurante, 0);

                MonitoraInclusaoDeFigurante(lstFigurante, 0);

                MontaComboEmpresa(cmbEmpresa);
                MontaComboProduto(cmbPrograma);
                RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);

                LimpaCamposPedido();
                mtbCadastro.Text = Convert.ToString(DateTime.Now);
                cmbEmpresa.SelectedValue = 4;
                cmbEmpresa.Text = "TV GLOBO";
                //cmbEmpresa.Focus();
                txtNumPedido.Focus();

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

        private void CadastrarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                CadastraPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void AlterarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                AlteraPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void ExcluiPedidoLogico_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluiPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void lstItens_Click(object sender, EventArgs e)
        {
            try
            {
                ExibeItemPedidoSelecionado(lstItens);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void novoItem_Click(object sender, EventArgs e)
        {
            try
            {
                pnlItens.Enabled = true;
                MontaComboTipoFiguracao(cmbTipoFiguracao);

                LimpaCamposItensPedido();
                cmbTipoFiguracao.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void cadastraItem_Click(object sender, EventArgs e)
        {
            try
            {
                CadastraItemPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void alteraItem_Click(object sender, EventArgs e)
        {
            try
            {
                AlteraItemPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void ExcluiItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluiItemPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void novaEquipe_Click(object sender, EventArgs e)
        {
            try
            {
                pnlEquipe.Enabled = true;

                LimpaCamposEquipe();
                MontaComboColaborador(cmbColaborador, Convert.ToInt32(cmbPrograma.SelectedValue), Convert.ToInt32(txtCodigo.Text));
                cmbColaborador.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void cadastraEquipe_Click(object sender, EventArgs e)
        {
            try
            {
                CadastraEquipePedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void alteraEquipe_Click(object sender, EventArgs e)
        {
            try
            {
                AlteraEquipePedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void excluiEquipe_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluiEquipePedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void lstEquipe_Click(object sender, EventArgs e)
        {
            try
            {
                ExibeEquipePedidoSelecionado(lstEquipe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void novoFigurante_Click(object sender, EventArgs e)
        {
            try
            {
                pnlFigurante.Enabled = true;

                LimpaCamposFigurante();
                MontaComboFigurante(cmbFigurante, Convert.ToInt32(txtCodigo.Text), 0, "");
                MontaComboTipoDeFigurante(cmbTipoFigurante, Convert.ToInt32(txtCodigo.Text));

                HabilitaCadastroFiguracao(true);
                HabilitaAlterarEExcluirFiguracao(false);

                cmbTipoConsulta.Text = "02-Cpf";
                txtFiltrar.Focus();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

      
        private void cmdFiltrar_Click(object sender, EventArgs e)
        {
            FiltraFiguracao();
        }


        private void FiltraFiguracao()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (String.IsNullOrEmpty(Convert.ToString(cmbTipoConsulta.Text)) || (String.IsNullOrEmpty(txtCodigo.Text))) return;
                if (String.IsNullOrEmpty(Convert.ToString(txtFiltrar.Text))) return;

                MontaComboFigurante(cmbFigurante, Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(cmbTipoConsulta.Text.Substring(0, 2)), txtFiltrar.Text);

                if (!this.cmbFigurante.DroppedDown) { this.cmbFigurante.DroppedDown = true; }

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

        private void cmbTipoConsulta_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(cmbTipoConsulta.Text)) || (String.IsNullOrEmpty(txtCodigo.Text))) return;
            txtFiltrar.Focus();

        }

        private void cadastraFigurante_Click(object sender, EventArgs e)
        {
            try
            {
                if (FiguranteJaCadastradoPedidoTipoFiguracao())
                {
                    MessageBox.Show("O Figurante já constã no Pedido para o mesmo Tipo de Figuração", string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
                else
                {
                    CadastraPedidoFigurante();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void MonitoraInclusaoDeFigurante(ListView lst, int idpedido)
        {
            var repositorioDePedidoFigurante = new RepositorioDeFigurantesPedidos();

            int totfig = Convert.ToInt32(repositorioDePedidoFigurante.TotalDeFiguracaoSolicitados(idpedido));
            int totincluso = Convert.ToInt32(lst.Items.Count.ToString());

            if (totincluso == totfig)
            {
                //MessageBox.Show("Inclusão de Figurantes completa.", string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                toolPosicaoQtdFig.Text = "Inclusão de figurantes completa.";
            }
            else
            {
                toolPosicaoQtdFig.Text = totfig - totincluso + " figurante(s) pendente(s) para inclusão no Pedido.";
            }
        
        }

        private bool FiguranteJaCadastradoPedidoTipoFiguracao()
        {
            var idpessoa = RepositorioDeFigurantes.Retorna.IdFigurante(cmbFigurante.Text);
            var repositorioDePedidoFigurante = new RepositorioDeFigurantesPedidos();

            return repositorioDePedidoFigurante.FiguranteCadastradoNoPedidoTipoFiguracao(Convert.ToInt32(cmbTipoFigurante.SelectedValue), Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(idpessoa));
            
        }

        private void alterarFigurante_Click(object sender, EventArgs e)
        {
            try
            {
                AlteraPedidoFigurante();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void excluirFigurante_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluiPedidoFigurante();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void lstFigurante_Click(object sender, EventArgs e)
        {
            try
            {
                ExibePedidoFiguranteSelecionado(lstFigurante);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void HabilitaCadastroFiguracao(bool status)
        {
            cadastraFigurante.Enabled = status;
        }

        private void HabilitaAlterarEExcluirFiguracao(bool status)
        {
            alterarFigurante.Enabled = status;
            excluirFigurante.Enabled = status;
        }

        private void lstPedido_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.lstPedido.Sort();
        }

        private void lstFigurante_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.lstFigurante.Sort();
        }

        private void cmbTipoFigurante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var repositorioDeItensPedidos = new RepositorioDeItensPedidos();
            var result = repositorioDeItensPedidos.ObtemValorItemPedido(ICodigoUsuario, Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(cmbTipoFigurante.SelectedValue));
            txtVlrCache.Text = result;
        }

        private void cmbFigurante_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!this.cmbTipoFigurante.DroppedDown) { this.cmbTipoFigurante.DroppedDown = true; }
        }

        private void TxtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { ExecutaConsulta(); }

        }

        private void txtFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { FiltraFiguracao(); }

        }

        private void cboNmeFirma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
