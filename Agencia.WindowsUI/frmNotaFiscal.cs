using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmNotaFiscal : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }

        public frmNotaFiscal()
        {
            InitializeComponent();
            WindowsForm.RegisterFocusEvents(Controls);

        }

        private void frmNotaFiscal_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                pnlNota.Enabled = false;
                pnlDataPagto.Visible = false;
                //ListaNotaFiscal(lstNotaFiscal, 0, IdFirma);
                RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);
                RepositorioDeFirmas.MontaCombo.Firma(cboFirma, ICodigoUsuario);

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

        private void ListaNotaFiscal(ListView lst, int numnota, int idfirma)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Código", 6 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nota-Fiscal", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Data-Emissão", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Cod-Verificação", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Descrição", 27 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Bruto", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Cofins", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("CSLL", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("IRPJ", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("PIS", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("ISS", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                lst.Columns.Add("Líquido", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeNotasFiscais().ObterListaDeNotasFiscais(ICodigoUsuario, numnota, idfirma));
                qtdNota.Text = lst.Items.Count.ToString();
                qtdNota.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Carta(s) cadastrada(s).") + ex.Message);
            }
        }

        private void ListaFaturaParaNotaFiscal(ListView lst, int idfirma, int idnota, ToolStripItem lab)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Carta-Fatura", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd3 = lst.Columns.Add("Data-Emissão", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd4 = lst.Columns.Add("Produto-Programa", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd5 = lst.Columns.Add("Total-Faturado", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);
                var hd6 = lst.Columns.Add("Total-Realizado", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeCartasFaturas().ObterListaDeCartasFaturasParaNotaFiscal(ICodigoUsuario, idfirma, idnota));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Carta(s) Fatura(s) disponíveis para a Nota Fiscal.") + ex.Message);
            }
        }

        private void ListaFaturaDisponivelParaNotaFiscal(ListView lst, int idfirma, int idnota, ToolStripItem lab)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Código", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Carta-Fatura", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Data-Emissão", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Produto-Programa", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Total-Faturado", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Total-Realizado", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeCartasFaturas().ObterListaDeCartasFaturasParaNotaFiscal(ICodigoUsuario, idfirma, idnota));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Carta(s) Fatura(s) disponíveis para a Nota Fiscal.") + ex.Message);
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
                    pnlNota.Enabled = true;
                    //MontaComboProduto(cmbPrograma);
                    RepositorioDeFirmas.MontaCombo.Firma(cboFirma, ICodigoUsuario);

                    CarregaInterfaceDeNotaFiscal(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                    ListaFaturaParaNotaFiscal(lstFaturaGravada, IdFirma, Convert.ToInt32(lst.FocusedItem.SubItems[0].Text), qtdFaturaSelecionada);
                    ListaFaturaDisponivelParaNotaFiscal(lstFaturaDisponivel, IdFirma, 0, qtdFaturaDisponivel);

                    tooTipSelecionado.Enabled = true;
                    tooTipRegistraPedido.Enabled = true;
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
                if (result.IdFirma != 0) { new WindowsForm().SelectById(cboFirma, Convert.ToString(result.IdFirma)); }

                tabDiversos.SelectedTab = tabNotaFiscal;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface da Nota Fiscal.") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de Objeto

        private void CarregaObjetoNotaFiscal(NotaFiscal nf)
        {
            try
            {
                nf.IdContratante = 1;
                nf.IdNotaFiscal = txtCodigo.Text != string.Empty ? Convert.ToInt32(txtCodigo.Text) : 0;
                nf.NumeroNota = txtNotaFiscal.Text;
                nf.DataEmissao = Convert.ToDateTime(dtpEmissao.Text);
                nf.CodVerificador = txtCodVerificacao.Text;
                nf.Descricao = txtDescricao.Text;
                nf.Observacao = txtObservacao.Text;
                nf.IdFirma = Convert.ToInt32(cboFirma.SelectedValue);

                nf.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.NotaFiscal(nf);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Nota Fiscal. " + ex.Message);
            }
        }

        #endregion

        #region Persiste Nota Fiscal

        private void CadastraNotaFiscal()
        {
            var notafiscal = new NotaFiscal();
            var repositorioDeNotaFiscal = new RepositorioDeNotasFiscais();

            try
            {
                CarregaObjetoNotaFiscal(notafiscal);
                Entidade.Existe.NotaFiscal(notafiscal);
                repositorioDeNotaFiscal.Insere(notafiscal);

                MessageBox.Show(string.Format("Nota Fiscal registrada com sucesso."), string.Format("Registro de Nota Fiscal"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Text = RepositorioDeNotasFiscais.Retorna.IdNotaFiscal(Convert.ToInt32(notafiscal.NumeroNota), notafiscal.IdFirma);
                ListaNotaFiscal(lstNotaFiscal, 0, notafiscal.IdFirma);

                ListaFaturaParaNotaFiscal(lstFaturaGravada, notafiscal.IdFirma, Convert.ToInt32(txtCodigo.Text), qtdFaturaSelecionada);
                ListaFaturaDisponivelParaNotaFiscal(lstFaturaDisponivel, notafiscal.IdFirma, 0, qtdFaturaDisponivel);

                tooTipSelecionado.Enabled = true;
                tooTipRegistraPedido.Enabled = true;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraNotaFiscal()
        {
            var notafiscal = new NotaFiscal();
            var repositorioDeNotaFiscal = new RepositorioDeNotasFiscais();

            try
            {
                CarregaObjetoNotaFiscal(notafiscal);
                repositorioDeNotaFiscal.Altera(notafiscal);

                MessageBox.Show(string.Format("Nota Fiscal alterada com sucesso."), string.Format("Alteração de Nota Fiscal"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaNotaFiscal(lstNotaFiscal, 0, IdFirma);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
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
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiNotaFiscal()
        {
            var notafiscal = new NotaFiscal();
            var repositorioDeNotaFiscal = new RepositorioDeNotasFiscais();

            try
            {
                CarregaObjetoNotaFiscal(notafiscal);
                repositorioDeNotaFiscal.Exclui(notafiscal);

                MessageBox.Show(string.Format("Nota Fiscal excluida com sucesso."), string.Format("Exclusão de Nota Fiscal"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaNotaFiscal(lstNotaFiscal, 0, IdFirma);
                Funcoes.LimpaCamposFormulario(Controls);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        #endregion

        #region Persiste Carta Fatura Para Nota Fiscal

        private void CadastraFaturaParaNotaFiscal(ListView lst, int idnota)
        {
            var repositorioDeNotaFiscal = new RepositorioDeNotasFiscais();
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    repositorioDeNotaFiscal.InsereFatura(ICodigoUsuario, idnota, Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));

                    MessageBox.Show(string.Format("Carta Fatura registrada para a Nota Fiscal com sucesso."), string.Format("Registro de Carta Fatura"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListaFaturaParaNotaFiscal(lstFaturaGravada, IdFirma, Convert.ToInt32(lst.FocusedItem.SubItems[0].Text), qtdFaturaSelecionada);
                    ListaFaturaDisponivelParaNotaFiscal(lstFaturaDisponivel, IdFirma, 0, qtdFaturaDisponivel);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiFatura(int idcartafatura, int idnota)
        {
            var repositorioDeNotaFiscal = new RepositorioDeNotasFiscais();
            try
            {
                repositorioDeNotaFiscal.ExcluiFatura(ICodigoUsuario, idnota);

                MessageBox.Show(string.Format("Carta Fatura excluida da Nota Fiscal com sucesso."), string.Format("Exclusão de Carta Fatura"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaFaturaParaNotaFiscal(lstFaturaGravada, IdFirma, idnota, qtdFaturaSelecionada);
                ListaFaturaDisponivelParaNotaFiscal(lstFaturaDisponivel, IdFirma, 0, qtdFaturaDisponivel);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void GravaFatura(int idnota, int idcartafatura)
        {
            var repositorioDeNotaFiscal = new RepositorioDeNotasFiscais();
            try
            {
                repositorioDeNotaFiscal.InsereFatura(ICodigoUsuario, idnota, idcartafatura);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }
        #endregion


        private void lstNotaFiscal_Click(object sender, System.EventArgs e)
        {
            try
            {
                ExibeNotaFiscalSelecionada(lstNotaFiscal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }
        #region Limpa Interface

        private void LimpaCamposNotaFiscal()
        {
            txtCodigo.Text = string.Empty;
            txtNotaFiscal.Text = string.Empty;
            dtpEmissao.Text = Convert.ToString(DateTime.Now);
            txtCodVerificacao.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtObservacao.Text = string.Empty;

            mtbVlrBruto.Text = Convert.ToString("0,0");
            mtbVlrLiquido.Text = Convert.ToString("0,0");
            mtbVlrCofins.Text = Convert.ToString("0,0");
            mtbVlrCsll.Text = Convert.ToString("0,0");
            mtbVlrIrpj.Text = Convert.ToString("0,0");
            mtbVlrPis.Text = Convert.ToString("0,0");
            mtbVlrIss.Text = Convert.ToString("0,0");

        }

        #endregion

        private void novaFatura_Click(object sender, System.EventArgs e)
        {
            try
            {
                pnlNota.Enabled = true;

                LimpaCamposNotaFiscal();
                dtpEmissao.Text = Convert.ToString(DateTime.Now);
                txtNotaFiscal.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void CadastrarNotaFiscal_Click(object sender, System.EventArgs e)
        {
            try
            {
                CadastraNotaFiscal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void AlterarNotaFiscal_Click(object sender, System.EventArgs e)
        {
            try
            {
                LiberaNotaParaPagamento();
                AlteraNotaFiscal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void ExcluiNota_Click(object sender, System.EventArgs e)
        {
            try
            {
                LiberaNotaParaPagamento();
                ExcluiNotaFiscal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void excluiFaturaNotaFisca_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (lstFaturaGravada.SelectedItems.Count != 0)
            //    {
            //        if (MessageBox.Show("Confirma a exclusão da Carta Fatura " + lstFaturaGravada.FocusedItem.SubItems[1].Text + " - " + lstFaturaGravada.FocusedItem.SubItems[3].Text + " da Nota Fiscal ?", "Atenção...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            //        {
            //            if (lstFaturaGravada.SelectedItems[0].Selected)
            //            {
            //                ExcluiFatura(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(lstFaturaGravada.FocusedItem.SubItems[0].Text));
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            //}

        }

        private void tooRegistraFatura_Click(object sender, System.EventArgs e)
        {
            
        }

        private void AcionaGravacaoDaFaturaParaNotaFiscal(ListView lst)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                foreach (ListViewItem list in lst.Items)
                {
                    if (list.Checked)
                    {
                        GravaFatura(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(list.SubItems[0].Text));
                    }
                }

                Cursor = Cursors.Default;

                MessageBox.Show(string.Format("Carta(s) Fatura(s) registrada(s) para Nota Fiscal com sucesso."), string.Format("Registro de Nota Fiscal"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaFaturaParaNotaFiscal(lstFaturaGravada, IdFirma, Convert.ToInt32(txtCodigo.Text), qtdFaturaSelecionada);
                ListaFaturaDisponivelParaNotaFiscal(lstFaturaDisponivel, IdFirma, 0, qtdFaturaDisponivel);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                Cursor = Cursors.Default;

            }
        }

        private void toolAtualizar_Click(object sender, EventArgs e)
        {
            IdFirma = Convert.ToInt32(RepositorioDeFirmas.Retorna.IdFirma(cboNmeFirma.Text));
            ListaNotaFiscal(lstNotaFiscal, 0, IdFirma);
        }

        private void btnRegistraCarta_Click(object sender, EventArgs e)
        {
            try
            {
                AcionaGravacaoDaFaturaParaNotaFiscal(lstFaturaDisponivel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void btnExcluiCartaFatura_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstFaturaGravada.SelectedItems.Count != 0)
                {
                    if (MessageBox.Show("Confirma a exclusão da Carta Fatura " + lstFaturaGravada.FocusedItem.SubItems[1].Text + " - " + lstFaturaGravada.FocusedItem.SubItems[3].Text + " da Nota Fiscal ?", "Atenção...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (lstFaturaGravada.SelectedItems[0].Selected)
                        {
                            ExcluiFatura(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(lstFaturaGravada.FocusedItem.SubItems[0].Text));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void cboFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNmeFirma.Selected)
            {
                IdFirma = Convert.ToInt32(RepositorioDeFirmas.Retorna.IdFirma(cboFirma.Text));

            }

        }
    }
}
