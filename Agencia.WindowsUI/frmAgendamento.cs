using System;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmAgendamento : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }
        private ListViewColumnSorter lvwColumnSorter;

        public frmAgendamento()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();

            lstAgendamento.ListViewItemSorter = lvwColumnSorter;
            WindowsForm.RegisterFocusEvents(Controls);

        }

        private void frmAgendamento_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                ListaAgendamentos(lstAgendamento);

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

        private void ListaAgendamentos(ListView lst)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                lst.Columns.Clear();
                lst.Columns.Add("Código", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Data-Registro", 12 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Controle", 15 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Descrição", 35 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Data-Agendamento", 13 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Nº Figurante(s)", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Vlr-Total", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Observação", 35 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeAgendamento().ObterListaDeAgendamentos());
                qtd.Text = lst.Items.Count.ToString();
                qtd.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar os Agendamentos") + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ListaFiguranteAgendamento(ListView lst, int idagendamento)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                lst.Columns.Clear();
                lst.Columns.Add("Id", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nome-Figurante", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nº Pedido", 15 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Data-Gravação", 13 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Produto-Programa", 35 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Vlr-Cache", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeAgendamento().ObterListaDeFigurantesAgendados(ICodigoUsuario, idagendamento));
                qtdFig.Text = lst.Items.Count.ToString();
                qtdFig.Text = string.Format("{0}  registro(s) localizado(s)", lst.Items.Count);
				//vlrTotal.Text = Convert.ToString(CalculaValorAPagar(lstSelecionados));

                vlrTotal.Text = string.Format("{0}  total à pagar", CalculaValorAPagar(lstSelecionados));

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar os Figurantes Agendamentos") + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private double CalculaValorAPagar(ListView lst) 
        {
            try
            {
                Cursor = Cursors.WaitCursor;

				double valor = 0;

                foreach (ListViewItem list in lst.Items)
                {
					valor += Convert.ToDouble(list.SubItems[5].Text);
                }

                Cursor = Cursors.Default;

				return valor;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }

        }

        private void ListaLocacaoFigurante(ListView lst, int idagendamento)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                lst.Columns.Clear();
                lst.Columns.Add("Id", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nome-Figurante", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nº Pedido", 15 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Data-Gravação", 13 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Produto-Programa", 35 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Vlr-Cache", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeAgendamento().ObterListaParaLocacao(ICodigoUsuario, idagendamento));
                //qtdFig.Text = lst.Items.Count.ToString();
                //qtdFig.Text = string.Format("{0}  registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar os Figurantes disponíveis para Agendamentos") + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void lstAgendamento_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                ExibeAgendamento(lstAgendamento);
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

        private void ExibeAgendamento(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (!lst.SelectedItems[0].Selected) return;

                CarregaInterfaceDeAgendamento(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                ListaFiguranteAgendamento(lstSelecionados, Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CarregaInterfaceDeAgendamento(int id)
        {
            var repositorioDeAgendamento = new RepositorioDeAgendamento();
            try
            {
                var result = repositorioDeAgendamento.ObtemAgendamentoPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));

                txtCodigo.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdAgendamento));
                txtDataEmissao.Text = Convert.ToString(result.DataRegistro);
                txtControle.Text = Convert.ToString(result.Controle);
                txtDescricao.Text = Convert.ToString(result.Descricao);
                dtpRecebimento.Text = Convert.ToString(result.DataPgto);
                txtObservacao.Text = result.Observacao;

                txtNumeroControle.Text = Convert.ToString(result.Controle);

                tabDiversos.SelectedTab = tabDetalheAgendamento;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar a Interface do Figurante.") + ex.Message);
            }
        }

    }
}
