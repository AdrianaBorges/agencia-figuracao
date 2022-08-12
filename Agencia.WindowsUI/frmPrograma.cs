using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmPrograma : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }
        private ListViewColumnSorter lvwColumnSorter;

        RepositorioDeProdutos _repositorioDeProduto;
        ProdutoDao _dao;

        public frmPrograma()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();

            lstProdutos.ListViewItemSorter = lvwColumnSorter;

            WindowsForm.RegisterFocusEvents(Controls);
        }

        private void FrmProgramaLoad(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                CarregaListViewProduto(lstProdutos, TxtConsulta.Text);

                panel1.Enabled = false;
                cmbStatus.Focus();
                cadastrarPrograma.Enabled = false;
                alterarProduto.Enabled = false;
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

        private void CarregaListViewProduto(ListView lst, string dado)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Data-Cadastro", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd3 = lst.Columns.Add("Produto-Programa", 40 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd4 = lst.Columns.Add("Status", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd5 = lst.Columns.Add("Comissão", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd6 = lst.Columns.Add("Qtd-Pedido(s)", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd7 = lst.Columns.Add("Última-Gravação", 15 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeProdutos().ObterListaDeProdutos(ICodigoUsuario, dado));
                lblQtd.Text = lst.Items.Count.ToString();
                lblQtd.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Produto(s) cadastrados.") + ex.Message);
            }
        }

        private void CarregaListViewPedidoPorProduto(ListView lst,int id)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Pedido", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Data-Pedido", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd3 = lst.Columns.Add("Qtd-Comum", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd4 = lst.Columns.Add("Vlr-Comum", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd5 = lst.Columns.Add("Qtd-Especial", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd6 = lst.Columns.Add("Vlr-Especial", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd7 = lst.Columns.Add("Qtd-Veiculo", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd8 = lst.Columns.Add("Vlr-Veiculo", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd9 = lst.Columns.Add("Qtd-Menor", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd10 = lst.Columns.Add("Vlr-Menor", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd11 = lst.Columns.Add("Qtd-Total", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd12 = lst.Columns.Add("Vlr-Total", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeProdutos().ObterListaDePedidosPorProduto(ICodigoUsuario, id));
                lblQtdPedido.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Produto(s) cadastrados.") + ex.Message);
            }
        }

        private void CarregaInterface(int id)
        {
            var repositorioDeProduto = new RepositorioDeProdutos();
            try
            {
                var result = repositorioDeProduto.ObterProdutoPorId(ICodigoUsuario, id);
                tooNomeProduto.Text = txtDescricao.Text;

                txtCodigo.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdPrograma));
                mtbCadastro.Text = Convert.ToString(result.Data.ToShortDateString());
                cmbStatus.Text = result.Status;
                txtDescricao.Text = result.Descricao;
                txtObservacao.Text = result.Observacao;

                tabDiversos.SelectedTab = tabProduto;
                panel1.Enabled = true;
                alterarProduto.Enabled = true;

                tooNomeProduto.Text = result.Descricao;
                CarregaListViewPedidoPorProduto(lstPedidos, result.IdPrograma);

                mtbCadastro.Focus();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar a Interface de Produto(s).")  + ex.Message);
            }
        }

        private void CarregaObjeto(Produto produto)
        {
            try
            {
                produto.IdPrograma = txtCodigo.Text != string.Empty ? Convert.ToInt32(txtCodigo.Text) : 0;
                produto.Data = Convert.ToDateTime(mtbCadastro.Text);
                produto.Status = cmbStatus.Text != string.Empty ? Convert.ToString(cmbStatus.Text.Substring(0, 2)) : "";
                produto.Descricao = txtDescricao.Text;
                produto.Observacao = txtObservacao.Text;

                Valida.Preenchimento.Programa(produto);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Produto. " + ex.Message);
            }
        }

        private void Registra(Produto produto)
        {
            var repositorioDeProduto = new RepositorioDeProdutos();
            try
            {
                repositorioDeProduto.InsereProduto(produto);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível registrar o Produto solicitado");
            }
        }

        private void Altera(Produto produto)
        {
            var repositorioDeProduto = new RepositorioDeProdutos();
            try
            {
                repositorioDeProduto.AlteraProduto(produto);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível alterar o Produto solicitado");
            }
        }

        private void Exclui(Produto produto)
        {
            var repositorioDeProduto = new RepositorioDeProdutos();
            try
            {
                repositorioDeProduto.ExclusaoLogica(produto);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir o Produto solicitado");
            }
        }

        private void CadastraProduto()
        {
            var produto = new Produto();
            try
            {
                CarregaObjeto(produto);
                Entidade.Existe.Produto(produto);
                Registra(produto);

                MessageBox.Show(string.Format("Programa registrado com sucesso."), string.Format("Registro de Produto"),MessageBoxButtons.OK , MessageBoxIcon.Information  );
                txtCodigo.Text = RepositorioDeProdutos.Retorna.IdPrograma(produto.Descricao); 
                CarregaListViewProduto(lstProdutos, "");

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraProduto()
        {
            var produto = new Produto();
            try
            {
                CarregaObjeto(produto);
                Altera(produto);

                MessageBox.Show(string.Format("Programa alterado com sucesso."), string.Format("Alteração de Produto"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregaListViewProduto(lstProdutos, "");

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiProduto()
        {
            var produto = new Produto();
            try
            {
                CarregaObjeto(produto);
                Exclui(produto);

                MessageBox.Show(string.Format("Programa excluido com sucesso."), string.Format("Alteração de Produto"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregaListViewProduto(lstProdutos, "");
                Funcoes.LimpaCamposFormulario(Controls);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }
        private void lstProdutos_Click(object sender, EventArgs e)
        {
            ExibeProdutoSelecionado(lstProdutos);
        }

        private void ExibeProdutoSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    CarregaInterface(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void NovoRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                Funcoes.LimpaCamposFormulario(Controls);

                panel1.Enabled = true;
                mtbCadastro.Text = Convert.ToString(DateTime.Now);
                cmbStatus.Focus();
                cadastrarPrograma.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void CadastrarPrograma_Click(object sender, EventArgs e)
        {
            try
            {
                CadastraProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void AlterarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                AlteraProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void toolAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ExecutaConsulta();

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

        private void ExcluirProduto_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluiProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void lstProdutos_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.lstProdutos.Sort();
        }

        private void TxtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { ExecutaConsulta(); }

        }

        private void ExecutaConsulta()
        {
            CarregaListViewProduto(lstProdutos, TxtConsulta.Text);

        }
    }
}
