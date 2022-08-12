using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;

namespace Agencia.WindowsUI
{
    public partial class frmLogin : Form
    {
        public int ICodigoUsuario = 32;
        public string UsuarioLogado = string.Empty; 
        public int IdFirma;

        public frmLogin()
        {
            InitializeComponent();
            WindowsForm.RegisterFocusEvents(Controls);

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);
                MontaComboUsuario(cmbUsuario);

                //Senha inserida apenas para teste
                cmbUsuario.Text = "MARIA MIRACI DOS SANTOS SA";
                TxtSenha.Text = "731516";

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

        private void MontaComboUsuario(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeAcesso().ObterListaDeUsuarios(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Usuários(s) cadastrados.") + ex.Message);
            }
        }

        private void cmbFirma_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (!this.cmbFirma.DroppedDown) { this.cmbFirma.DroppedDown = true; }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            ValidaUsuario(Convert.ToInt32(cmbUsuario.SelectedValue), TxtSenha.Text);
        }

        private void ValidaUsuario(int id, string senha)
        {
            var rep = new RepositorioDeAcesso();
            try
            {
                if (!rep.SenhaValida(ICodigoUsuario, id, senha))
                {
                    MessageBox.Show(string.Format("Senha invalida!"), string.Format("Atenção..."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtSenha.Text = string.Empty;
                    TxtSenha.Focus();
                }
                else
                {
                    Form formulario = new frmPrincipal();
                    formulario.Text = "Módulo de Consulta de Posição de Pagamento de Cache";
                    Geral.UsuarioLogado = string.Format("Usuário logado: " + cmbUsuario.Text);
                    Geral.IdUsuario = id;
                    Geral.AppVersao = lblVersao.Text;

                    if (RepositorioDeAcesso.Retorna.TipoUsuario(ICodigoUsuario, id, senha) == 1)
                    {
                        Geral.Administrador = true;
                    }

                    DialogResult = DialogResult.OK;

                    //formulario.Show();
                    //Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void TxtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtSenha.TextLength >= 6) { this.BtnEntrar.Enabled = true; }

        }
    }
}
