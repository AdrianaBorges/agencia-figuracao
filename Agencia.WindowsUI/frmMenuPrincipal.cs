using System;
using System.Drawing;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;

namespace Agencia.WindowsUI
{
    public partial class FrmMenuPrincipal : Form
    {
        public int ICodigoUsuario = 32;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            RegisterFocusEvents(Controls);
            tsUsuarioLogado.Text = string.Empty;
            CboUsuario.Focus();
            HabilitaForm(false);

            CarregaComboUsuario();
        }

        private void CarregaComboUsuario()
        {
            new WindowsForm().LoadFromDataTable(CboUsuario, new RepositorioDeAcesso().ObterListaDeUsuarios(ICodigoUsuario));
            CboUsuario.Text = string.Empty;
        }

        #region Método que muda a cor dos campos
        private void RegisterFocusEvents(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if ((control is TextBox) ||
                  (control is RichTextBox) ||
                  (control is ComboBox) ||
                  (control is MaskedTextBox))
                {
                    control.Enter += new EventHandler(controlFocus_Enter);
                    control.Leave += new EventHandler(controlFocus_Leave);
                }

                RegisterFocusEvents(control.Controls);
            }
        }

        void controlFocus_Leave(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.White;
        }

        void controlFocus_Enter(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.LightGreen;
        }
        #endregion

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void HabilitaForm(bool status)
        {
            lblMens1.Visible = status;
            BtnEntrar.Enabled = status;
            BtnRegistrar.Visible = status;
            //this.arquivosToolStripMenuItem.Enabled = status;
            //this.cadastrosToolStripMenuItem.Enabled = status;
            //this.lançamentosToolStripMenuItem.Enabled = status;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ValidaUsuario(int id, string senha)
        {
            var rep = new RepositorioDeAcesso();

            if (!rep.SenhaValida(ICodigoUsuario, id, senha))
            {
                MessageBox.Show(string.Format("Senha invalida!"), string.Format("Atenção..."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSenha.Text = string.Empty;
                TxtSenha.Focus();
            }
            else
            {
                tsUsuarioLogado.Text = string.Format("Usuário logado: )" + CboUsuario.Text);
                plnLogin.Visible = false;
            }
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            ValidaUsuario(Convert.ToInt32(CboUsuario.SelectedValue), TxtSenha.Text);

        }

        private void TxtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtSenha.TextLength >= 6) { this.BtnEntrar.Enabled = true; }
        }

        private void CboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboUsuario.SelectedIndex != 0)
            {
                ValidaAcesso(Convert.ToInt32(CboUsuario.SelectedValue));
            }
        }

        private void ValidaAcesso(int id)
        {
            var rep = new RepositorioDeAcesso();

            if (!rep.UsuarioPossuiSenhaCadastrada(ICodigoUsuario, id))
            {
                MessageBox.Show(string.Format("Usuário(a) não possui senha cadastrada!") +
                                Environment.NewLine + string.Format("Digite a senha e clique no botão [Registrar Senha]"),
                                string.Format("Atenção..."), MessageBoxButtons.OK, MessageBoxIcon.Error);

                BtnRegistrar.Visible = true;
                BtnEntrar.Enabled = false;
                TxtSenha.Focus();
            }
            else
            {
                if (!rep.UsuarioComAcessoLiberado(ICodigoUsuario, id))
                {
                    MessageBox.Show(string.Format("Seu acesso à aplicação ainda não foi liberado.") + 
                                    Environment.NewLine + string.Format("Entre em contato com a Administração."), 
                                    string.Format("Atenção..."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    BtnRegistrar.Visible = false;
                    BtnEntrar.Enabled = true;
                    TxtSenha.Focus();
                }
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            RegistraLoginUsuario(Convert.ToInt32(CboUsuario.SelectedValue), TxtSenha.Text);

        }

        private void RegistraLoginUsuario(int id, string senha)
        {
            var retorno = Valida.SenhaDeUsuario(id, senha);

            if (retorno == string.Empty) 
            {
                MessageBox.Show(retorno, string.Format("Atenção..."), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var rep = new RepositorioDeAcesso();
                var a = new Acesso {IdPessoa = id, Senha = senha};

                if (!rep.RegistraLoginDeUsuario(ICodigoUsuario, a))
                {
                    MessageBox.Show(string.Format("Não foi possível registrar Login e Senha informado!"), string.Format("Atenção..."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtSenha.Focus();
                }
                else
                {
                    MessageBox.Show(string.Format("Senha registrada com sucesso!"), string.Format("Atenção..."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnEntrar.Enabled = true;
                    BtnEntrar.Focus();

                }
            }
        }

        private void LiberaAcessoAoModulo(int id, string operacao, string modulo)
        {
            //if (p.PermissaodeAcesso(iCodigoUsuario, idCodCargo, "CONSULTA", "PROGRAMA")) { CarregaFormPrograma(); }

            var rep = new RepositorioDeAcesso();

            if (!rep.AcessoPermitidoAoUsuario(ICodigoUsuario, id, operacao, modulo))
            {
                //carrega formulário especifico
            }
            else
            {
                var sMensagem = string.Format("O usuário(a) logado não possui ") + 
                                Environment.NewLine + string.Format("permissão de acesso para ") + operacao + " " + modulo + 
                                Environment.NewLine + Environment.NewLine + string.Format("Consulte a Administração.");
                MessageBox.Show(sMensagem, string .Format("Atenção..."), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }

        //private void CarregaFormulario(new frmFormulario, string texto)
        //{
        //    foreach (Form form in this.MdiChildren)
        //    {
        //        if (form is frmFormulario)
        //        {
        //            form.WindowState = FormWindowState.Maximized;
        //            form.Activate();
        //            return;
        //        }
        //    }

        //    //Abre formulário se o mesmo não estiver aberto
        //    Form formulario = new frmFormulario();

        //    formulario.MdiParent = this;
        //    formulario.Text = texto;
        //    formulario.WindowState = FormWindowState.Maximized;
        //    formulario.Show();

        //}


        //private void CarregaFormPrograma()
        //{
        //    foreach (Form form in this.MdiChildren)
        //    {
        //        if (form is frmPrograma)
        //        {
        //            form.WindowState = FormWindowState.Maximized;
        //            form.Activate();
        //            return;
        //        }
        //    }

        //    //Abre formulário se o mesmo não estiver aberto
        //    Form formulario = new frmPrograma();
        //    textoDoFormulario = "Consulta de Programa(s)";

        //    formulario.MdiParent = this;
        //    formulario.Text = textoDoFormulario;
        //    formulario.WindowState = FormWindowState.Maximized;
        //    formulario.Show();
        //}
    }
}
