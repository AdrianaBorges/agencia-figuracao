using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmContasAPagar : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }

        public frmContasAPagar()
        {
            InitializeComponent();
            WindowsForm.RegisterFocusEvents(Controls);
        }

        private void frmContasAPagar_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                tcmbStatus.Text = string.Format("0- PENDENTE");

                pnlAPagar.Enabled = false;
                ListaContasAPagar(lstAPagar, IdFirma, DateTime.Now, DateTime.Now, 0, qtdAPagar);

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

        #region Montagem de Combos

        private static void MontaComboCentroDeCusto(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeCentroDeCustos().ObterListaDeCentroDeCustos(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Central de Custo(s) cadastrados.") + ex.Message);
            }
        }

        private static void MontaComboPrestadorDeServicoEFigurante(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDePrestadorDeServico().ObterListaDePrestadorDeServicoEFigurante(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Prestadores de Serviço(s) cadastrados.") + ex.Message);
            }
        }

        private static void MontaComboPrestadorDeServico(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDePrestadorDeServico().ObterListaDePrestadorDeServico(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Prestadores de Serviço(s) cadastrados.") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de ListView

        private static void ListaContasAPagar(ListView lst, int idfirma, DateTime de, DateTime ate, int idcusto, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();
                var hd1 = lst.Columns.Add("Tipo", 4 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd3 = lst.Columns.Add("Vencimento", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd4 = lst.Columns.Add("Centro-De-Custo", 25 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd5 = lst.Columns.Add("Nome", 25 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd6 = lst.Columns.Add("Valor", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd7 = lst.Columns.Add("Observação", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeContasAPagar().ObterListaDeContasAPagar(ICodigoUsuario, idfirma, de, ate, idcusto));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Contas à Receber.") + ex.Message);
            }
        }

        private static void ListaContasAPaga(ListView lst, int idfirma, DateTime de, DateTime ate, int idcusto, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Tipo", 4 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd3 = lst.Columns.Add("Pagamento", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd4 = lst.Columns.Add("Centro-De-Custo", 25 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd5 = lst.Columns.Add("Nome", 25 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd6 = lst.Columns.Add("Valor", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd7 = lst.Columns.Add("Movimento-De-Caixa", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeContasAPagar().ObterListaDeContasPagas(ICodigoUsuario, idfirma, de, ate, idcusto));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Contas à Receber.") + ex.Message);
            }
        }


        #endregion

        #region Carregamento de Interface

        private void ExibeContaAPagarSelecionada(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlAPagar.Enabled = true;

                    MontaComboCentroDeCusto(cmbCentroDeCusto);
                    MontaComboPrestadorDeServicoEFigurante(cmbPrestador);

                    CarregaInterfaceDeContaAPagar(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text), Convert.ToInt32(lst.FocusedItem.SubItems[1].Text));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CarregaInterfaceDeContaAPagar(int idtipo, int id)
        {
            var repositorioDeContasAPagar = new RepositorioDeContasAPagar();
            try
            {
                var result = repositorioDeContasAPagar.ObterContaAPagarPorId(ICodigoUsuario, idtipo, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));

                txtCodigo.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdAPagar));
                new WindowsForm().SelectById(cmbCentroDeCusto, Convert.ToString(result.IdCusto));
                new WindowsForm().SelectById(cmbPrestador, Convert.ToString(result.IdPessoa));
                txtDescricao.Text = result.Descricao;
                txtObservacao.Text = result.Observacao;
                txtValor.Text = Convert.ToString(result.Valor);

                if (result.DtPagamento != "")
                {
                    pnlDataPagto.Visible = true;
                    dtpPagamento.Text = result.DtPagamento;
                }
                else
                {
                    pnlDataPagto.Visible = false;
                }

                tabDiversos.SelectedTab = tabContasAPagar;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface de Contas à Pagar.") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de Objeto

        private void CarregaObjetoContaAPagar(ContasAPagar cap)
        {
            try
            {
                cap.IdAPagar = txtCodigo.Text != string.Empty ? Convert.ToInt32(txtCodigo.Text) : 0;
                cap.IdCusto = Convert.ToInt32(cmbCentroDeCusto.SelectedValue);
                cap.IdPessoa = Convert.ToInt32(cmbPrestador.SelectedValue);
                cap.Descricao = txtDescricao.Text;
                cap.DtVencimento = Convert.ToDateTime(dtpVencimento.Text);
                cap.Valor = txtValor.Text;
                cap.Observacao = txtObservacao.Text;

                cap.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.ContasAPagar(cap);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Contas A Pagar. " + ex.Message);
            }
        }

        #endregion

        #region Persiste Conta A Pagar

        private void CadastraContaAPagar()
        {
            var aPagar = new ContasAPagar();
            var repositorioDeContaAPagar = new RepositorioDeContasAPagar();

            try
            {
                CarregaObjetoContaAPagar(aPagar);
                Entidade.Existe.ContaAPagar(aPagar);
                repositorioDeContaAPagar.Insere(aPagar);

                MessageBox.Show(string.Format("Conta à Pagar registrada com sucesso."), string.Format("Registro de Conta à Pagar"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Text = RepositorioDeContasAPagar.Retorna.IdContaAPagar(aPagar.IdCusto, aPagar.IdPessoa, aPagar.DtVencimento, aPagar.Descricao);
                ListaContasAPagar(lstAPagar, IdFirma, DateTime.Now, DateTime.Now, 0, qtdAPagar);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraContaAPagar()
        {
            var aPagar = new ContasAPagar();
            var repositorioDeContaAPagar = new RepositorioDeContasAPagar();

            try
            {
                CarregaObjetoContaAPagar(aPagar);
                repositorioDeContaAPagar.Altera(aPagar);

                MessageBox.Show(string.Format("Conta à Pagar alterada com sucesso."), string.Format("Alteração de Conta à Pagar"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaContasAPagar(lstAPagar, IdFirma, DateTime.Now, DateTime.Now, 0, qtdAPagar);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluirContaAPagar()
        {
            var aPagar = new ContasAPagar();
            var repositorioDeContaAPagar = new RepositorioDeContasAPagar();

            try
            {
                CarregaObjetoContaAPagar(aPagar);
                repositorioDeContaAPagar.Exclui(aPagar);

                MessageBox.Show(string.Format("Conta à Pagar excluida com sucesso."), string.Format("Exclusão de Conta à Pagar"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaContasAPagar(lstAPagar, IdFirma, DateTime.Now, DateTime.Now, 0, qtdAPagar);
                Funcoes.LimpaCamposFormulario(Controls);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        #endregion

        #region Limpa Interface

        private void LimpaCamposContaAPagar()
        {
            txtCodigo.Text = string.Empty;
            dtpVencimento.Text = Convert.ToString(DateTime.Now);
            cmbCentroDeCusto.SelectedValue = 0;
            cmbPrestador.SelectedValue = 0;
            txtDescricao.Text = string.Empty;
            txtValor.Text = Convert.ToString("0,0");
            txtObservacao.Text = string.Empty;
        }

        #endregion

        private void tcmbStatus_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            toolAtualizar_Click();
        }

        private void toolAtualizar_Click()
        {
            switch (tcmbStatus.Text.Substring(0,1))
            {
                case "0":
                    ListaContasAPagar(lstAPagar, IdFirma, DateTime.Now, DateTime.Now, 0, qtdAPagar);
                    break;
                case "1":
                    ListaContasAPaga(lstAPagar, IdFirma, DateTime.Now, DateTime.Now, 0, qtdAPagar);
                    break;
            }
        }

        private void lstAPagar_Click(object sender, EventArgs e)
        {
            try
            {
                ExibeContaAPagarSelecionada(lstAPagar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void novaContaAPagar_Click(object sender, EventArgs e)
        {
            try
            {
                pnlAPagar.Enabled = true;

                LimpaCamposContaAPagar();
                
                MontaComboCentroDeCusto(cmbCentroDeCusto);
                MontaComboPrestadorDeServico(cmbPrestador);

                dtpVencimento.Text = Convert.ToString(DateTime.Now);
                cmbCentroDeCusto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void CadastrarContaAPagar_Click(object sender, System.EventArgs e)
        {
            try
            {
                CadastraContaAPagar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void AlterarContaAPagar_Click(object sender, System.EventArgs e)
        {
            try
            {
                AlteraContaAPagar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void ExcluiContaAPagar_Click(object sender, System.EventArgs e)
        {
            try
            {
                ExcluirContaAPagar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }
    }
}
