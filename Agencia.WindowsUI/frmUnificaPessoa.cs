using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;

namespace Agencia.WindowsUI
{
    public partial class frmUnificaPessoa : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IFiguranteManter { get; set; }

        public frmUnificaPessoa()
        {
            InitializeComponent();
            WindowsForm.RegisterFocusEvents(Controls);
        }

        private void frmUnificaPessoa_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                ListaFigurante(lstCorreto, qtdCorreto, "-1", 0);
                ListaFigurante(lstErrado, qtdErrado, "-1", 0);

                TxtConsultaC.Focus();

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

        #region Carregamento de ListView

        private void ListaFigurante(ListView lst, ToolStripLabel lab, string dado, int idpessoa)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Matricula", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nome-Figurante", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Dt-Nascimento", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Cpf", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Pis", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Telefone(s)", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantes().ObterListaDeFigurantesParaUnificar(ICodigoUsuario, dado, idpessoa));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Figurante(s) cadastrado(s).") + ex.Message);
            }
        }

        #endregion

        private void SelecionaNomeDefinitivo(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (!lst.SelectedItems[0].Selected) return;

                IFiguranteManter = Convert.ToInt32(lst.FocusedItem.SubItems[0].Text);
                TxtDefinitivo.Text = lst.FocusedItem.SubItems[1].Text;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void toolAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ListaFigurante(lstCorreto, qtdCorreto, TxtConsultaC.Text, 0);

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

        private void UnificaRegistros(int idcerto, ListView lst)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var repositorioDeFigurante = new RepositorioDeFigurantes();

                foreach (ListViewItem list in lst.Items)
                {
                    if (list.Checked)
                    {
                        repositorioDeFigurante.UnificaFigurante(ICodigoUsuario, idcerto, Convert.ToInt32(list.SubItems[0].Text));
                    }
                }

                MessageBox.Show(string.Format("Registros unificados com sucesso."), string.Format("Unificação de Registros"), MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void lstCorreto_Click(object sender, EventArgs e)
        {
            SelecionaNomeDefinitivo(lstCorreto);
        }

        private void tooAtualizaE_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ListaFigurante(lstErrado, qtdErrado, TxtConsultaE.Text, IFiguranteManter);

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

        private void tooUnificar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                UnificaRegistros(IFiguranteManter, lstErrado);

                Funcoes.LimpaCamposFormulario(Controls);

                ListaFigurante(lstCorreto, qtdCorreto, "-1", 0);
                ListaFigurante(lstErrado, qtdErrado, "-1", 0);

                TxtConsultaC.Focus();

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

        private void lstCorreto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
