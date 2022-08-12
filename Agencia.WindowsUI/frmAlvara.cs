using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmAlvara : Form
    {
        public static int ICodigoUsuario { get; set; }

        private RepositorioDeAlvara _repositorioDeAlvara;
        private AlvaraDao _dao;

        public frmAlvara()
        {
            InitializeComponent();
            WindowsForm.RegisterFocusEvents(Controls);

        }

        private void frmAlvara_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                pnlAlvara.Enabled = false;
                ListaAlvaras(lstAlvara, qtdAlvara);

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

        private void ListaAlvaras(ListView lst, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Dt-Emissão", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd3 = lst.Columns.Add("Número-Processo", 20 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd4 = lst.Columns.Add("Produto-Programa", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeAlvara().ObterListaDeAlvaras(ICodigoUsuario));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Alvará(s) cadastrado(s).") + ex.Message);
            }
        }

        private void ListaPessoaAlvara(ListView lst, int idalvara, int iddisponivel, ToolStripLabel lab, string dado)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Nome-Figurante", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd3 = lst.Columns.Add("Nascimento", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd4 = lst.Columns.Add("Idade", 4 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd5 = lst.Columns.Add("CPF", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd6 = lst.Columns.Add("Certidão", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd7 = lst.Columns.Add("Livro", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd8 = lst.Columns.Add("Nome-Responsável", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd9 = lst.Columns.Add("CPF-Responsável", 12 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeAlvara().ObterListaDePessoasPorAlvara(ICodigoUsuario, idalvara, iddisponivel, dado));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Figurantes(s).") + ex.Message);
            }
        }


        #endregion

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

        private void LimpaCamposAlvara()
        {
            txtCodigo.Text = string.Empty;
            txtNumProcesso.Text = string.Empty;
            cmbPrograma.SelectedValue = 0;
            txtObservacao.Text = string.Empty;

        }

        private void novoAlvara_Click(object sender, EventArgs e)
        {
            try
            {
                pnlAlvara.Enabled = true;

                MontaComboProduto(cmbPrograma);

                LimpaCamposAlvara();
                dtpEmissao.Text = Convert.ToString(DateTime.Now);
                txtNumProcesso.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void ExibeAlvaraSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlAlvara.Enabled = true;
                    MontaComboProduto(cmbPrograma);

                    CarregaInterfaceDeAlvara(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                    ListaPessoaAlvara(lstPessoaRegistrada, Convert.ToInt32(txtCodigo.Text), 0, qtdPessoaRegistrada, string.Empty);
                    ListaPessoaAlvara(lstPessoaDisponivel, Convert.ToInt32(txtCodigo.Text), 1, qtdPessoaDisponivel, string.Empty);

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

        private void CarregaInterfaceDeAlvara(int id)
        {
            var repositorioDeAlvara = new RepositorioDeAlvara();
            try
            {
                var result = repositorioDeAlvara.ObterAlvaraPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));

                txtCodigo.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdAlvara));
                dtpEmissao.Text = Convert.ToString(result.DataEmissao);
                txtNumProcesso.Text = Convert.ToString(result.NumProcesso);
                new WindowsForm().SelectById(cmbPrograma, Convert.ToString(result.IdPrograma));
                txtObservacao.Text = result.Observacao;
                txtProcessoReferencia.Text = Convert.ToString(result.NumProcesso);

                tabDiversos.SelectedTab = tabAlvara;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface da Alvara.") + ex.Message);
            }
        }

        #region Persiste Alvará

        //private void CadastraAlvara()
        //{
        //    var alvara = new Alvara();
        //    var repositorioDeAlvara = new RepositorioDeAlvara();

        //    try
        //    {
        //        CarregaObjetoAlvara(alvara);
        //        Entidade.Existe.Alvara(alvara);
        //        repositorioDeAlvara.Insere(alvara);

        //        MessageBox.Show(string.Format("Alvará registrado com sucesso."), string.Format("Registro de Alvará"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtCodigo.Text = RepositorioDeAlvara.Retorna.IdAlvara(fatura.NumCarta, fatura.IdPrograma);
        //        ListaCartaFatura(lstCartaFatura, "0", IdFirma);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Erro : " + ex.Message);
        //    }
        //}

        //private void AlteraCartaFatura()
        //{
        //    var fatura = new CartaFatura();
        //    var repositorioDeFatura = new RepositorioDeCartasFaturas();

        //    try
        //    {
        //        CarregaObjetoCartaFatura(fatura);
        //        repositorioDeFatura.Altera(fatura);

        //        MessageBox.Show(string.Format("Carta Fatura alterada com sucesso."), string.Format("Alteração de Carta Fatura"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        ListaCartaFatura(lstCartaFatura, "0", IdFirma);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Erro : " + ex.Message);
        //    }
        //}

        //private void ExcluiCartaFatura()
        //{
        //    var fatura = new CartaFatura();
        //    var repositorioDeFatura = new RepositorioDeCartasFaturas();

        //    try
        //    {
        //        CarregaObjetoCartaFatura(fatura);
        //        repositorioDeFatura.Exclui(fatura);

        //        MessageBox.Show(string.Format("Carta Fatura excluida com sucesso."), string.Format("Exclusão de Carta Fatura"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        ListaCartaFatura(lstCartaFatura, "0", IdFirma);
        //        Funcoes.LimpaCamposFormulario(Controls);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Erro : " + ex.Message);
        //    }
        //}

        #endregion

        private void CarregaObjetoAlvara(Alvara al)
        {
            try
            {
                al.IdAlvara = txtCodigo.Text != string.Empty ? Convert.ToInt32(txtCodigo.Text) : 0;
                al.NumProcesso = txtNumProcesso.Text;
                al.DataEmissao = Convert.ToDateTime(dtpEmissao.Text);
                al.IdPrograma = Convert.ToInt32(cmbPrograma.SelectedValue);
                al.Observacao = txtObservacao.Text;

                al.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.Alvara(al);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Alvará. " + ex.Message);
            }
        }

        private void lstAlvara_Click(object sender, EventArgs e)
        {
            try
            {
                ExibeAlvaraSelecionado(lstAlvara);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void ExcluiPessoa(int idalvara, int idpessoa)
        {
            var repositorioDeAlvara = new RepositorioDeAlvara();
            try
            {
                repositorioDeAlvara.ExcluiPessoa(ICodigoUsuario, idalvara, idpessoa);

                MessageBox.Show(string.Format("Figurante excluido do Alvará com sucesso."), string.Format("Exclusão de Figurante"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaPessoaAlvara(lstPessoaRegistrada, Convert.ToInt32(txtCodigo.Text), 0, qtdPessoaRegistrada, string.Empty);
                ListaPessoaAlvara(lstPessoaDisponivel, Convert.ToInt32(txtCodigo.Text), 1, qtdPessoaDisponivel, string.Empty);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void excluiPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstPessoaRegistrada.SelectedItems.Count != 0)
                {
                    if (MessageBox.Show("Confirma a exclusão do Figurante " + lstPessoaRegistrada.FocusedItem.SubItems[1].Text + " - " + lstPessoaRegistrada.FocusedItem.SubItems[3].Text + " do Alvará?", "Atenção...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (lstPessoaRegistrada.SelectedItems[0].Selected)
                        {
                            ExcluiPessoa(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(lstPessoaRegistrada.FocusedItem.SubItems[0].Text));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void tooFiltrarPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                ListaPessoaAlvara(lstPessoaDisponivel, 0, 1, qtdPessoaDisponivel, tooNomePessoa.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private bool FiguranteSelecionado(ListView lst)
        {
            foreach (ListViewItem list in lst.Items)
            {
                if (list.Checked)
                {
                    return true;
                }
            }

            return false;
        }

        private void RegistraPessoaParaAlvara(ListView lst)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                foreach (ListViewItem list in lst.Items)
                {
                    if (list.Checked)
                    {
                        GravaPessoa(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(list.SubItems[0].Text));
                    }
                }

                Cursor = Cursors.Default;

                MessageBox.Show(string.Format("Pessoa(s) registrada(s) para o Alvará com sucesso."), string.Format("Registro de Alvará"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaPessoaAlvara(lstPessoaRegistrada, Convert.ToInt32(txtCodigo.Text), 0, qtdPessoaRegistrada, string.Empty);
                ListaPessoaAlvara(lstPessoaDisponivel, Convert.ToInt32(txtCodigo.Text), 1, qtdPessoaDisponivel, string.Empty);

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

        private void GravaPessoa(int idalvara, int idpessoa)
        {
            var repositorioDeAlvara = new RepositorioDeAlvara();
            try
            {
                repositorioDeAlvara.InserePessoa(ICodigoUsuario, idalvara, idpessoa);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }
        private void tooRegistraPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FiguranteSelecionado(lstPessoaDisponivel)) return;
                RegistraPessoaParaAlvara(lstPessoaDisponivel);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void lstAlvara_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
