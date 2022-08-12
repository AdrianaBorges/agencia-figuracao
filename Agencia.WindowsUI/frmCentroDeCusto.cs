using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmCentroDeCusto : Form
    {
        public static int ICodigoUsuario { get; set; }

        private RepositorioDeCentroDeCustos _repositorioDeCentroDeCustos;
        private CentroDeCustoDao _dao;

        public frmCentroDeCusto()
        {
            InitializeComponent();
            WindowsForm.RegisterFocusEvents(Controls);

        }

        private void frmCentroDeCusto_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                pnlCentroDeCustos.Enabled = false;
                ListaCentroDeCustos(lstCentroDeCusto, qtdCentroDeCusto);

                tooTipSelecionado.Enabled = false;
                tooTipFiltraPedido.Enabled = false;
                tooTipRegistraPedido.Enabled = false;

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

        private void ListaCentroDeCustos(ListView lst, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Descrição", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd3 = lst.Columns.Add("Base", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd4 = lst.Columns.Add("Central-De-Custo", 15 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd5 = lst.Columns.Add("Observação", 40 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeCentroDeCustos().ObterListaDeCentroDeCustos(ICodigoUsuario));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Centro(s) de Custo(s) cadastrado(s).") + ex.Message);
            }
        }

        #endregion

    }
}
