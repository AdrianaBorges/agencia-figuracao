using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Relatorios;

namespace Agencia.WindowsUI
{
    public partial class frmPrincipal : Form
    {
        public int ICodigoUsuario = 0;
        public int IdFirma;

        public frmPrincipal()
        {
            InitializeComponent();
            WindowsForm.RegisterFocusEvents(Controls);

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
            try
            {
                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                menuPrincipal.Enabled = true;
                tsUsuarioLogado.Text = string.Empty;
                
                //MontaComboFirma(cmbFirma);
               // MontaComboUsuario(cmbUsuario);

                tsUsuarioLogado.Text = Geral.UsuarioLogado;
                ICodigoUsuario = Geral.IdUsuario;
                lblVersao.Text = Geral.AppVersao;
                lblDataAtual.Text = Convert.ToString(DateTime.Now);
                HabilitaAcesso();

                Cursor = Cursors.Default;
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

        private void HabilitaAcesso()
        {
            bool status = false;
            if (Geral.Administrador) { status = true; }

            //Menu Cadastro
            produtoToolStripMenuItem.Enabled            = status;   //Programa
            colaboradorToolStripMenuItem.Enabled        = status;   //Colaborador
            figuranteToolStripMenuItem.Enabled          = true;     //Figurante
            centroDeCustoToolStripMenuItem.Enabled      = status;   //Centro de custo
            folhaDePagamentoToolStripMenuItem.Enabled   = status;   //Folha de pagamento
            alvaráToolStripMenuItem.Enabled             = status;   //Registro de Alvará

            //Menu Consultas
            cacheToolStripMenuItem.Enabled              = true;   //Posição de Cache
            beneficiosToolStripMenuItem.Enabled         = status;   //Beneficios

            //Lançamento
            contasÀPagarToolStripMenuItem.Enabled       = status;   //Contas à pagar
            contasÀReceberToolStripMenuItem.Enabled     = status;   //Contas à Receber
            pedidoDeGravaçãoToolStripMenuItem.Enabled   = status;   //Pedido de gravação 

            //Emissão
            cartaFaturaToolStripMenuItem.Enabled        = status;   //Carta fatura
            notaFiscalToolStripMenuItem.Enabled         = status;   //Nota Fiscal
            reciboProvisórioToolStripMenuItem.Enabled   = status;   //Recibo provisório

            //Relatório
            pagoporPeríodoToolStripMenuItem.Enabled     = status;   //Posição de cache por período
            porNotaFiscalToolStripMenuItem1.Enabled = status;       //Por nota
            consolidadoToolStripMenuItem.Enabled = status;          //Consolidado
            listagemParaRecolhimentoDeInssToolStripMenuItem.Enabled = status;//Recolhimento de INSS
            resumoDeNotaFiscalToolStripMenuItem.Enabled = status;   //Resumo de nota fiscal
            registroDeAlvaráToolStripMenuItem.Enabled = status;     //Registro de Alvará
            informeDeRecolhimentoDeINSSToolStripMenuItem.Enabled = status;//Informe de recolhimento de INSS

            //Utilitário
            ajusteDeDuplicidadeToolStripMenuItem.Enabled = status; //Ajuste de Duplicidade
            envioDeReciboPorEmailToolStripMenuItem.Enabled = true; //Envio de recibo por e-mail

            //somente cadastro do figurante ,consulta pagamento e enviar email
        }

        #region Montagem de Combos
        private void MontaComboFirma(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeFirmas().ObterListaDeFirmas(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Firma(s) cadastradas.") + ex.Message);
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

        #endregion

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //private void CboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbFirma.SelectedIndex <= 0 && cmbUsuario.SelectedIndex <= 0) return;
        //    ValidaAcesso(Convert.ToInt32(cmbUsuario.SelectedValue));

        //}

        //private void BtnRegistrar_Click(object sender, EventArgs e)
        //{
        //    RegistraLoginUsuario(Convert.ToInt32(cmbUsuario.SelectedValue), TxtSenha.Text);

        //}

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

        //private void VerificaFirmaSelecionada()
        //{
        //    try
        //    {
        //        this.tooFirma.Text = cmbFirma.Text;
        //        IdFirma = Convert.ToInt32(cmbFirma.SelectedValue);
        //        boxUsuario.Enabled = true;

        //        cmbUsuario.Focus();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(string.Format("Não foi possível verificar a Firma selecionada.") + ex.Message);
        //    }
        //}

        //private void cmbFirma_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbFirma.SelectedIndex <= 0) return;
        //    VerificaFirmaSelecionada();
        //}

       

        private void CarregaModuloProduto(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmPrograma)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmPrograma();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Produto-Programa";
                frmPrograma.IdFirma = idfirma;
                frmPrograma.ICodigoUsuario = idusuario;
                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Produto-Programa(s).") + ex.Message);
            }
        }

        private void CarregaModulo(Form formulario, int idfirma, int idusuario, string texto)
        {
            //try
            //{

            //    foreach (var frm in this.MdiChildren)
            //    {
            //        if (!(frm is formulario)) continue;
            //        frm.WindowState = FormWindowState.Maximized;
            //        frm.Activate();
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void CarregaModuloCartaFatura(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmCartaFatura)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmCartaFatura();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Emissão de Carta Fatura";
                frmCartaFatura.IdFirma = idfirma;
                frmCartaFatura.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Carta Fatura.") + ex.Message);
            }
        }

        private void CarregaModuloColaborador(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmColaborador)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmColaborador();
                
                formulario.MdiParent = this;
                formulario.Text = "Módulo de Emissão de Carta Fatura";
                frmColaborador.IdFirma = idfirma;
                frmColaborador.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Colaborador(es).") + ex.Message);
            }
        }

        private void CarregaModuloFigurante(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmFigurante)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmFigurante();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Figurante(s)";
                frmFigurante.IdFirma = idfirma;
                frmFigurante.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Figurante(s).") + ex.Message);
            }
        }

        private void CarregaModuloPedidoGravacao(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmPedidoDeGravacao)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmPedidoDeGravacao();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Lançamento de Pedido de Gravação";
                frmPedidoDeGravacao.IdFirma = idfirma;
                frmPedidoDeGravacao.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Pedido de Gravação.") + ex.Message);
            }
        }

        private void CarregaModuloNotaFiscal(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmNotaFiscal)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmNotaFiscal();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Emissão de Nota-Fiscal";
                frmNotaFiscal.IdFirma = idfirma;
                frmNotaFiscal.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Nota-Fiscal.") + ex.Message);
            }
        }

        private void CarregaModuloContasAReceber(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmContasAReceber)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmContasAReceber();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Contas à Receber";
                frmContasAReceber.IdFirma = idfirma;
                frmContasAReceber.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Nota-Fiscal.") + ex.Message);
            }
        }

        private void CarregaModuloCentroDeCusto(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmCentroDeCusto)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmCentroDeCusto();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Centro de Custo";
                //frmCentroDeCusto.IdFirma = idfirma;
                frmCentroDeCusto.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Centro-De-Custo.") + ex.Message);
            }
        }

        private void CarregaModuloPosicaoCache(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmPosicaoCache)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmPosicaoCache();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Consulta de Posição de Pagamento de Cache";
                frmPosicaoCache.IdFirma = idfirma;
                frmPosicaoCache.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Centro-De-Custo.") + ex.Message);
            }
        }

        private void CarregaModuloContasAPagar(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmContasAPagar)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmContasAPagar();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Contas à Pagar";
                frmContasAPagar.IdFirma = idfirma;
                frmContasAPagar.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Contas-à-Pagar.") + ex.Message);
            }
        }

        private void CarregaModuloCachePago(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmCachePago)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmCachePago();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Relatório de Cache Pago";
                frmCachePago.IdFirma = idfirma;
                frmCachePago.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Cache-Pago.") + ex.Message);
            }
        }

        private void CarregaModuloPosicaoDeCachePorNota(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmPosicaoCachePorNota)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmPosicaoCachePorNota();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Posição de Cache Por Nota Fiscal";
                frmPosicaoCachePorNota.IdFirma = idfirma;
                frmPosicaoCachePorNota.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Posição de Cache.") + ex.Message);
            }
        }

        private void CarregaModuloRecolhimentoInss(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmRecolheInss)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmRecolheInss();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Lista para Recolhimento de INSS";
                frmRecolheInss.IdFirma = idfirma;
                frmRecolheInss.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Lista para Recolhimento de INSS.") + ex.Message);
            }
        }

        private void CarregaModuloDeAlvara(int idusuario)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmAlvara)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmAlvara();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Alvará";
                frmAlvara.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Alvará.") + ex.Message);
            }
        }

        private void CarregaModuloDeEnvioDeEmail(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmEnviaEmail)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmEnviaEmail();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Envio de Recibo por Email";
                frmEnviaEmail.ICodigoUsuario = idusuario;
                frmEnviaEmail.IdFirma = idfirma;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Envio de Recibo por Email.") + ex.Message);
            }
        }

        private void CarregaModuloDeResumoNotaFiscal(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmResumoNF)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmResumoNF();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Impressão de Resumo de Nota Fiscal";
                frmResumoNF.ICodigoUsuario = idusuario;
                frmResumoNF.IdFirma = idfirma;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Impressão de Resumo de Nota Fiscal.") + ex.Message);
            }
        }

        private void CarregaModuloDeConsolidado(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmConsolidado)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmConsolidado();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Impressão de Posição de Cache Consolidado";
                frmConsolidado.ICodigoUsuario = idusuario;
                frmConsolidado.IdFirma = idfirma;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Posição de Cache Consolidado.") + ex.Message);
            }
        }

        private void CarregaModuloDeRelatorioDeRegistroAlvara(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmRelatorioDeAlvara)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmRelatorioDeAlvara();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Impressão de Registro de Alvará";
                frmRelatorioDeAlvara.ICodigoUsuario = idusuario;
                frmRelatorioDeAlvara.IdFirma = idfirma;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Impressão de Registro de Alvará.") + ex.Message);
            }
        }

        private void CarregaModuloDeInformeDeInss(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmInformeINSS)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmInformeINSS();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Informe de Recolhimento de INSS";
                frmInformeINSS.ICodigoUsuario = idusuario;
                frmInformeINSS.IdFirma = idfirma;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Informe de Recolhimento de INSS.") + ex.Message);
            }
        }

        private void CarregaModuloDeAgendamento(int idusuario)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmAgendamento)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmAgendamento();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Agendamento de Pagamento";
                frmAgendamento.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Agendamento de Pagamento.") + ex.Message);
            }
        }

        private void CarregaModuloDeAjusteDeDuplicidade(int idusuario)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmUnificaPessoa)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmUnificaPessoa();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Ajuste de Duplicidade de Figurantes";
                frmUnificaPessoa.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Ajuste de Duplicidade de Figurantes.") + ex.Message);
            }
        }

        private void CarregaModuloPosicaoDeReciboProvisorio(int idusuario, int idfirma)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmReciboProvisorio)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmReciboProvisorio();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Emissão de Recibo Provisório";
                frmReciboProvisorio.IdFirma = idfirma;
                frmReciboProvisorio.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Emissão de Recibo Provisório.") + ex.Message);
            }
        }

        private void CarregaModuloFolhaDePagamento(int idusuario)
        {
            try
            {
                foreach (var form in this.MdiChildren)
                {
                    if (!(form is frmFolhaPgto)) continue;
                    form.WindowState = FormWindowState.Maximized;
                    form.Activate();
                    return;
                }

                Form formulario = new frmFolhaPgto();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Folha de Pagamento";
                frmFolhaPgto.ICodigoUsuario = idusuario;

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Folha de Pagamento.") + ex.Message);
            }
        }
        private void CarregaModuloListaDeBeneficios()
        {
            try
            {
                foreach (Form form in this.MdiChildren)
                {
                    if (form is frmBeneficioPessoa)
                    {
                        form.WindowState = FormWindowState.Maximized;
                        form.Activate();
                        return;
                    }
                }

                Form formulario = new frmBeneficioPessoa();

                formulario.MdiParent = this;
                formulario.Text = "Módulo de Lista de Benefícios";

                formulario.Show();

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar o módulo de Lista de Benefícios.") + ex.Message);
            }
        }

        private void CarregamentoDeModulo(string nmeForm)
        {
            try
            {
                string textoForm = string.Empty;
                switch (nmeForm)
                {
                    case "frmBeneficioPessoa":
                        foreach (Form form in this.MdiChildren)
                        {
                            if (form is frmBeneficioPessoa)
                            {
                                form.WindowState = FormWindowState.Maximized;
                                form.Activate();
                                return;
                            }
                        }
                        Form formulario = new frmBeneficioPessoa();
                        formulario.MdiParent = this;
                        formulario.Text = "Módulo de Lista de Benefícios";

                        formulario.Show();

                        break;
                    //case "CASADO(A)":
                    //    f.EstadoCivil = "2";
                    //    break;
                    //case "SEPARADO(A)":
                    //    f.EstadoCivil = "3";
                    //    break;
                    //case "DIVORCIADO(A)":
                    //    f.EstadoCivil = "4";
                    //    break;
                    //case "VIUVO(A)":
                    //    f.EstadoCivil = "5";
                    //    break;
                }


            }
            catch (Exception ex)
            {
                var texto = "Não foi possível carregar o módulo " + "";
                throw new Exception(string.Format(texto) + ex.Message);
            }
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloProduto(ICodigoUsuario, IdFirma);
        }

        private void cartaFaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloCartaFatura(ICodigoUsuario, IdFirma);
        }

        private void colaboradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloColaborador(ICodigoUsuario , IdFirma);
        }

        private void figuranteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloFigurante(ICodigoUsuario, IdFirma);
        }

        private void pedidoDeGravaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloPedidoGravacao(ICodigoUsuario, IdFirma);
        }

        private void notaFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloNotaFiscal(ICodigoUsuario, IdFirma);
        }

        private void contasÀPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloContasAPagar(ICodigoUsuario, IdFirma);
        }

        private void contasÀReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloContasAReceber(ICodigoUsuario, IdFirma);
        }

        private void centroDeCustoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloCentroDeCusto(ICodigoUsuario, IdFirma);
        }

        private void cacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloPosicaoCache(ICodigoUsuario, IdFirma);
        }

        private void pagoporPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloCachePago(ICodigoUsuario, IdFirma);
        }

        private void porNotaFiscalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CarregaModuloPosicaoDeCachePorNota(ICodigoUsuario, IdFirma);
        }

        private void reciboProvisórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloPosicaoDeReciboProvisorio(ICodigoUsuario, IdFirma);
        }

        private void beneficiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloListaDeBeneficios();
        }

        private void folhaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloFolhaDePagamento(ICodigoUsuario);
        }

        private void listagemParaRecolhimentoDeInssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloRecolhimentoInss(ICodigoUsuario, IdFirma);
        }

        private void ajusteDeDuplicidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloDeAjusteDeDuplicidade(ICodigoUsuario);
        }

        private void alvaráToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloDeAlvara(ICodigoUsuario);
        }

        private void envioDeReciboPorEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloDeEnvioDeEmail(ICodigoUsuario, IdFirma);

        }

        private void resumoDeNotaFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloDeResumoNotaFiscal(ICodigoUsuario, IdFirma);
        }

        private void consolidadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloDeConsolidado(ICodigoUsuario, IdFirma);
        }

        private void registroDeAlvaráToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloDeRelatorioDeRegistroAlvara(ICodigoUsuario, IdFirma);
        }

        private void informeDeRecolhimentoDeINSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloDeInformeDeInss(ICodigoUsuario, IdFirma);
        }

        private void agendamentoDePgtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarregaModuloDeAgendamento(ICodigoUsuario);
        }
    }
}
