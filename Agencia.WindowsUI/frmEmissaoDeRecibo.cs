using System;
using System.Windows.Forms;
using Agencia.Dominio.Servico;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Relatorios;

namespace Agencia.WindowsUI
{
    public partial class frmEmissaoDeRecibo : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }

        private int IdFigurante;

        public frmEmissaoDeRecibo()
        {
            InitializeComponent();
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

                ListaFigurantes(lstPosicao, -1, tstNome.Text, qtdPosicao);

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

        private static void ListaFigurantes(ListView lst, int idfirma, string nome, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();
                var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Nome-Figurante", 40 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd3 = lst.Columns.Add("CPF", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd4 = lst.Columns.Add("PIS", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd5 = lst.Columns.Add("RG", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeFigurante(ICodigoUsuario, idfirma, nome));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Figurante(s).") + ex.Message);
            }
        }

        private static void ListaCachePendente(ListView lst, int idpessoa, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Nº Pedido", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd3 = lst.Columns.Add("Dt.Gravação", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd4 = lst.Columns.Add("Programa-Produto", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd5 = lst.Columns.Add("Tipo-Cache", 20 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd6 = lst.Columns.Add("Bruto", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd7 = lst.Columns.Add("Inss", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd9 = lst.Columns.Add("Líquido", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd10 = lst.Columns.Add("Status-Pagamento", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

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
        }

        private static void ListaReciboParaBaixa(ListView lst, int idpessoa, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Data-Registro", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd3 = lst.Columns.Add("Nº Recibo", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd4 = lst.Columns.Add("Valor", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd5 = lst.Columns.Add("Nome-Figurante", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeCachePago(ICodigoUsuario, idpessoa));
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
                ListaCachePendente(lst, id, qtdCachePendente);
                ListaCachePago(lstPago, 0, 0, qtdCachePago);

                ExibeValoresPendentes(lst, mtbVlrBruto, mtbVlrInss, mtbVlrLiquido);
                //MontaListaRecibos(lstRecibo, id);
                txt.Text = nome;
                tabDiversos.SelectedTab = tabFigurante;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface do Figurante.") + ex.Message);
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

        private void ExibeListaCachePago(ListView lst, decimal recibo, int id, ToolStripLabel lab)
        {
            try
            {
                ListaCachePago(lst, id, recibo, lab);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
