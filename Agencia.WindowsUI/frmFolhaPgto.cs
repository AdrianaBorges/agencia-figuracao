using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmFolhaPgto : Form
    {
        public static int ICodigoUsuario { get; set; }

        public frmFolhaPgto()
        {
            InitializeComponent();
            WindowsForm.RegisterFocusEvents(Controls);

        }

        private void frmFolhaPgto_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);
                
                pnlLiberaPgto.Visible = false;
                cmdLiberaPgto.Enabled = false;

                ListaFolhaPgto(lstFolha, qtdFolha);

                tooTipSelecionado.Enabled = false;
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

        private void ListaFolhaPgto(ListView lst, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Data-Geração", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Mês-Referência", 12 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Período", 20 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Descrição", 40 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Status", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFolhas().ObterListaDeFolhas(ICodigoUsuario));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Folha(s) cadastrada(s).") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de Interface

        private void CarregaInterfaceDeFolha(int id)
        {
            var repositorioDeFolha = new RepositorioDeFolhas();
            try
            {
                var result = repositorioDeFolha.ObterFolhaPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));

                txtCodigo.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdFolha));
                dtpGeracao.Text = Convert.ToString(result.DataGeracao);
                cmbMesRef.Text = result.MesReferencia;
                dtpDataDe.Value = result.DataDe;
                dtpDataAte.Value = result.DataAte;
                txtDescricao.Text = result.Descricao;
                txtObservacao.Text = result.Observacao;

                //if (result.DataLiberacao != null) dtpLiberaPgto.Value = (DateTime)result.DataLiberacao; pnlLiberaPgto.Visible = true;
                //cmdLiberaPgto.Enabled = false;

                tabDiversos.SelectedTab = tabFolha;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface do Colaborador.") + ex.Message);
            }
        }

        private void ExibeFolhaSelecionada(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (!lst.SelectedItems[0].Selected) return;
                pnlFolha.Enabled = true;

                CarregaInterfaceDeFolha(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Carregamento de Objeto

        private void CarregaObjetoFolha(Folha f)
        {
            try
            {
                f.IdFolha = txtCodigo.Text != string.Empty ? Convert.ToInt32(txtCodigo.Text) : 0;
                f.DataGeracao = Convert.ToDateTime(dtpGeracao.Text);
                f.MesReferencia = Convert.ToString(Mes.Retorna.MesNumero(cmbMesRef.Text));
                f.DataDe = Convert.ToDateTime(dtpDataDe.Text);
                f.DataAte = Convert.ToDateTime(dtpDataAte.Text);
                f.Descricao = txtDescricao.Text;
                f.Observacao = txtObservacao.Text;

                f.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.Folha(f);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Nota Fiscal. " + ex.Message);
            }
        }

        #endregion

        #region Limpa Interface

        private void LimpaCamposFolha()
        {
            txtCodigo.Text = string.Empty;
            dtpGeracao.Text = Convert.ToString(DateTime.Now);
            cmbMesRef.Text = string.Empty;
            dtpDataDe.Text = Convert.ToString(DateTime.Now);
            dtpDataAte.Text = Convert.ToString(DateTime.Now);
            txtDescricao.Text = string.Empty;
            txtObservacao.Text = string.Empty;

        }

        #endregion

        #region Persiste Folha de Pagamento

        private void CadastraFolha()
        {
            var folha = new Folha();
            var repositorioDeFolha = new RepositorioDeFolhas();

            try
            {
                CarregaObjetoFolha(folha);
                Entidade.Existe.Folha(folha);
                repositorioDeFolha.Insere(folha);

                MessageBox.Show(string.Format("Folha de Pagamento registrada com sucesso."), string.Format("Registro de Folha de Pagamento"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Text = RepositorioDeFolhas.Retorna.IdFolha(folha.DataGeracao, Convert.ToInt32(folha.MesReferencia), folha.DataDe, folha.DataAte);
                ListaFolhaPgto(lstFolha, qtdFolha);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ProcessaDadosFolha(int idusuario, int idfolha)
        {
            var repositorioDeFolha = new RepositorioDeFolhas();

            try
            {
                repositorioDeFolha.ProcessaDadosFolha(idusuario, idfolha);

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível Processar os Dados da Folha - Erro : " + ex.Message);
            }
        }


        private void AlteraFolha()
        {
            var folha = new Folha();
            var repositorioDeFolha = new RepositorioDeFolhas();

            try
            {
                CarregaObjetoFolha(folha);
                repositorioDeFolha.Altera(folha);

                MessageBox.Show(string.Format("Folha de Pagamento alterada com sucesso."), string.Format("Alteração de Folha de Pagamento"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaFolhaPgto(lstFolha, qtdFolha);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiFolha()
        {
            var folha = new Folha();
            var repositorioDeFolha = new RepositorioDeFolhas();

            try
            {
                CarregaObjetoFolha(folha);
                repositorioDeFolha.Exclui(folha);

                MessageBox.Show(string.Format("Folha de Pagamento excluída com sucesso."), string.Format("Exclusão de Folha de Pagamento"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaFolhaPgto(lstFolha, qtdFolha);
                Funcoes.LimpaCamposFormulario(Controls);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void LiberaFolhaParaPgto(DateTime data)
        {
            var folha = new Folha();
            var repositorioDeFolha = new RepositorioDeFolhas();

            try
            {
                CarregaObjetoFolha(folha);
                Entidade.Pendente.Folha(folha);
                repositorioDeFolha.LiberaParaPgto(folha.IdUsuario, folha.IdFolha, data);

                MessageBox.Show(string.Format("Folha liberada para pagamento com sucesso."), string.Format("Liberação de Folha para Pagamento"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaFolhaPgto(lstFolha, qtdFolha);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        #endregion


        private string DescricaoFolha(string mes)
        {
            return "FOLHA DE PGTO. REF. " + mes + "/" + DateTime.Now.Year;
        }

        private void cmbMesRef_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            txtDescricao.Text = cmbMesRef.Text != string.Empty ? DescricaoFolha(cmbMesRef.Text) : "";

            dtpDataDe.Value = Convert.ToDateTime(Mes.Retorna.PrimeiroDia(Mes.Retorna.MesNumero(cmbMesRef.Text)));
            dtpDataAte.Value = Convert.ToDateTime(Mes.Retorna.ULtimoDia(Mes.Retorna.MesNumero(cmbMesRef.Text)));
        }

        private void lstFolha_Click(object sender, System.EventArgs e)
        {
            try
            {
                ExibeFolhaSelecionada(lstFolha);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void novaFolha_Click(object sender, System.EventArgs e)
        {
            try
            {
                pnlFolha.Enabled = true;

                LimpaCamposFolha();
                dtpGeracao.Text = Convert.ToString(DateTime.Now);
                cmbMesRef.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void CadastrarFolha_Click(object sender, System.EventArgs e)
        {
            try
            {
                CadastraFolha();
                ProcessaDadosFolha(ICodigoUsuario, Convert.ToInt32(txtCodigo.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void AlterarFolha_Click(object sender, System.EventArgs e)
        {
            try
            {
                AlteraFolha();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void ExcluirFolha_Click(object sender, System.EventArgs e)
        {
            try
            {
                ExcluiFolha();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void liberaPagamento_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma a liberação da Folha " + txtDescricao.Text + " para Pagamento?", "Atenção...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    pnlLiberaPgto.Visible = true;
                    cmdLiberaPgto.Enabled = true;
                }
                else
                {
                    pnlLiberaPgto.Visible = false;
                    cmdLiberaPgto.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void cmdLiberaPgto_Click(object sender, System.EventArgs e)
        {
            try
            {
                LiberaFolhaParaPgto(Convert.ToDateTime(dtpLiberaPgto.Value));
                cmdLiberaPgto.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void toolAtualizar_Click(object sender, EventArgs e)
        {

        }

        private void lstFolha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
