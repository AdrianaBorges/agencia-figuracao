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
    public partial class frmContasAReceber : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }

        public frmContasAReceber()
        {
            InitializeComponent();
            WindowsForm.RegisterFocusEvents(Controls);

        }

        private void frmContasAReceber_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                tcmbStatus.Text = "0- PENDENTE";

                pnlCentroDeCustos.Enabled = false;
                ListaContasAReceber(lstContasAReceber, IdFirma, Convert.ToInt32(tcmbStatus.Text.Substring(0,1)), DateTime.Now, DateTime.Now, 0, qtdContasAReceber);

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

        private void ListaContasAReceber(ListView lst, int idfirma, int status, DateTime de, DateTime ate, int numnota, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Nota-Fiscal", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd3 = lst.Columns.Add("Data-Emissão", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd4 = lst.Columns.Add("Data-Pagto", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd5 = lst.Columns.Add("Cod-Verificação", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd6 = lst.Columns.Add("Descrição", 27 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd7 = lst.Columns.Add("Bruto", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd8 = lst.Columns.Add("Cofins", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd9 = lst.Columns.Add("CSLL", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd10 = lst.Columns.Add("IRPJ", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd11 = lst.Columns.Add("PIS", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd12 = lst.Columns.Add("ISS", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd13 = lst.Columns.Add("Líquido", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeContasAReceber().ObterListaDeContasAReceber(ICodigoUsuario, idfirma, status, de, ate, numnota));
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

        private void ExibeNotaFiscalSelecionada(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlCentroDeCustos.Enabled = true;

                    CarregaInterfaceDeNotaFiscal(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CarregaInterfaceDeNotaFiscal(int id)
        {
            var repositorioDeNotaFiscal = new RepositorioDeNotasFiscais();
            try
            {
                var result = repositorioDeNotaFiscal.ObterNotaFiscalPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));

                txtCodigo.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdNotaFiscal));
                txtNotaFiscal.Text = result.NumeroNota;
                dtpEmissao.Text = Convert.ToString(result.DataEmissao);

                if (!String.IsNullOrEmpty(Convert.ToString(result.DataPagamento)))
                {
                    pnlDataPagto.Visible = true;
                    dtpPagamento.Text = Convert.ToString(result.DataPagamento);
                    pnlDataPagto.Enabled = false;
                }
                else
                {
                    pnlDataPagto.Visible = false;
                    dtpPagamento.Text = string.Empty;
                }

                txtCodVerificacao.Text = result.CodVerificador;
                txtDescricao.Text = result.Descricao;
                mtbVlrBruto.Text = Convert.ToString(result.ValorBruto);
                mtbVlrLiquido.Text = Convert.ToString(result.ValorLiquido);
                mtbVlrCofins.Text = Convert.ToString(result.ValorCofins);
                mtbVlrCsll.Text = Convert.ToString(result.ValorCsll);
                mtbVlrIrpj.Text = Convert.ToString(result.ValorIrpj);
                mtbVlrPis.Text = Convert.ToString(result.ValorPis);
                mtbVlrIss.Text = Convert.ToString(result.ValorIss);
                txtObservacao.Text = result.Observacao;

                tabDiversos.SelectedTab = tabContasAReceber;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface da Nota Fiscal.") + ex.Message);
            }
        }

        #endregion

        private void toolAtualizar_Click(object sender, System.EventArgs e)
        {
            ListaContasAReceber(lstContasAReceber, IdFirma, Convert.ToInt32(tcmbStatus.Text.Substring(0, 1)), DateTime.Now, DateTime.Now, 0, qtdContasAReceber);

        }

        private void lstContasAReceber_Click(object sender, System.EventArgs e)
        {
            try
            {
                ExibeNotaFiscalSelecionada(lstContasAReceber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void registraPagamentoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                LiberaNotaParaPagamento();

                pnlDataPagto.Visible = true;
                btnRegistraPgto.Enabled = true;
                dtpPagamento.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void LiberaNotaParaPagamento()
        {
            var notafiscal = new NotaFiscal();
            var repositorioDeNotaFiscal = new RepositorioDeNotasFiscais();

            try
            {
                CarregaObjetoNotaFiscal(notafiscal);
                Entidade.Pendente.NotaFiscal(notafiscal);
                Entidade.Possui.CartaFatura(notafiscal);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        #region Carregamento de Objeto

        private void CarregaObjetoNotaFiscal(NotaFiscal nf)
        {
            try
            {
                nf.IdFirma = IdFirma;
                nf.IdNotaFiscal = txtCodigo.Text != string.Empty ? Convert.ToInt32(txtCodigo.Text) : 0;
                nf.NumeroNota = txtNotaFiscal.Text;
                nf.DataEmissao = Convert.ToDateTime(dtpEmissao.Text);
                nf.CodVerificador = txtCodVerificacao.Text;
                nf.Descricao = txtDescricao.Text;
                nf.Observacao = txtObservacao.Text;

                nf.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.NotaFiscal(nf);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Nota Fiscal. " + ex.Message);
            }
        }

        #endregion

        private void btnRegistraPgto_Click(object sender, System.EventArgs e)
        {
            try
            {
                RegistroDePagamento(Convert.ToDateTime(dtpPagamento.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void RegistroDePagamento(DateTime dtpagamento)
        {
            var notafiscal = new NotaFiscal();
            var repositorioDeNotaFiscal = new RepositorioDeNotasFiscais();

            try
            {
                CarregaObjetoNotaFiscal(notafiscal);

                if (MessageBox.Show("Confirma o registro de pagamento para Nota da Fiscal " + notafiscal.NumeroNota + " ?", "Atenção...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(dtpagamento)))
                    {
                        repositorioDeNotaFiscal.RegistraPagamento(notafiscal.IdUsuario, notafiscal.IdNotaFiscal, dtpagamento);

                        MessageBox.Show(string.Format("Pagamento registrado para a Nota Fiscal com sucesso."), string.Format("Registro de Pgto de Nota Fiscal"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListaContasAReceber(lstContasAReceber, IdFirma, Convert.ToInt32(tcmbStatus.Text.Substring(0, 1)), DateTime.Now, DateTime.Now, 0, qtdContasAReceber);
                        pnlDataPagto.Enabled = false;

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void tcmbStatus_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            toolAtualizar_Click();
        }

        private void toolAtualizar_Click()
        {
            ListaContasAReceber(lstContasAReceber, IdFirma, Convert.ToInt32(tcmbStatus.Text.Substring(0, 1)), DateTime.Now, DateTime.Now, 0, qtdContasAReceber);
        }

    }
}
