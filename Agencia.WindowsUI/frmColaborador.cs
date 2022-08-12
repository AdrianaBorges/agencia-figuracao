using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmColaborador : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }
        private ListViewColumnSorter lvwColumnSorter;

        RepositorioDeColaboradores _repositorioDeColaborador;
        ColaboradorDao _dao;

        public frmColaborador()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();

            lstColaborador.ListViewItemSorter = lvwColumnSorter;

            WindowsForm.RegisterFocusEvents(Controls);
        }

        private void frmColaborador_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                pnlColaborador.Enabled = false;
                pnlDadoBancario.Enabled = false;
                pnlRemuneracao.Enabled = false;
                pnlPrograma.Enabled = false;

                tsCmbStatus.Text = string.Format("01- ATIVO");
                ListaColaboradores(lstColaborador, TxtConsulta.Text, Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2)));

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

        private void MontaComboCargo(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeCargos().ObterListaDeCargo(ICodigoUsuario));
                cmb.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Cargo(s) cadastrados.") + ex.Message);
            }
        }

        private void MontaComboBanco(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeBancos().ObterListaDeBancos(ICodigoUsuario));
                cmb.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Banco(s) cadastrados.") + ex.Message);
            }
        }

        private void MontaComboBairro(ComboBox cmb, int idcidade)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb,
                                                    idcidade == 0
                                                        ? new RepositorioDeBairros().ObterListaDeBairros(ICodigoUsuario)
                                                        : new RepositorioDeBairros().ObterListaDeBairrosPorCidade(
                                                            ICodigoUsuario, idcidade));

                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Bairro(s) cadastrados.") + ex.Message);
            }
        }

        private void MontaComboCidade(ComboBox cmb, int idestado)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb,
                                                    idestado == 0
                                                        ? new RepositorioDeCidades().ObterListaDeCidades(ICodigoUsuario)
                                                        : new RepositorioDeCidades().ObterListaDeCidadesPorEstado(
                                                            ICodigoUsuario, idestado));

                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Cidade(s) cadastrados.") + ex.Message);
            }
        }

        private void MontaComboEstado(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeEstados().ObterListaDeEstados(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Estado(s) cadastrados.") + ex.Message);
            }
        }

        private void MontaComboRemuneracao(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeRemuneracoes().ObterListaDeRemuneracoes(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Remunerações(s) cadastrados.") + ex.Message);
            }
        }

        private void MontaComboPrograma(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeProdutos().ObterListaDeProdutoDisponivelParaColaborador(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Programa(s) disponiveis para o colaborador.") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de ListView

        private void ListaColaboradores(ListView lst, string dado, int status)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Matricula", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Data-Cadastro", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                var hd3 = lst.Columns.Add("Nome-Colaborador", 40 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd4 = lst.Columns.Add("Cargo", 25 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd5 = lst.Columns.Add("Telefone(s)", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeColaboradores().ObterListaDeColaboradores(ICodigoUsuario, dado, status));
                lblQtd.Text = lst.Items.Count.ToString();
                lblQtd.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Colaborador(es) cadastrados.") + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;

            }

        }

        private void ListaDadoBancarioDeColaborador(ListView lst, int id)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Status", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd3 = lst.Columns.Add("Nome-Banco", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd4 = lst.Columns.Add("Tipo-Conta", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd5 = lst.Columns.Add("Agência", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd6 = lst.Columns.Add("Número-Conta", 12 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd7 = lst.Columns.Add("Títular-Conta", 33 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeDadosBancarios().ObterListaDeDadoBancario(ICodigoUsuario, id));
                QtdDadoBanco.Text = lst.Items.Count.ToString();
                QtdDadoBanco.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Dados Bancários(s) cadastrado(s) para o colaborador.") + ex.Message);
            }
        }

        private void ListaRemuneracaoDeColaborador(ListView lst, int id)
        {
            try
            {
                lst.Columns.Clear();

                var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd2 = lst.Columns.Add("Descrição-Remuneração", 40 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                var hd3 = lst.Columns.Add("Valor", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeDadosRemuneracoes().ObterListaDeDadoRemuneracao(ICodigoUsuario, id));
                QtdRemuneracao.Text = lst.Items.Count.ToString();
                QtdRemuneracao.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Remunerações para o colaborador.") + ex.Message);
            }
        }

        private void ListaProdutoParaColaborador(ListView lst, int id)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nome-Programa", 45 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeDadosProdutos().ObterListaDeDadoProduto(ICodigoUsuario, id));
                QtdPrograma.Text = lst.Items.Count.ToString();
                QtdPrograma.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Programa(s) para o colaborador.") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de Interface

        private void CarregaInterfaceDeColaborador(int id)
        {
            var repositorioDeColaborador = new RepositorioDeColaboradores();
            try
            {
                var result = repositorioDeColaborador.ObterPessoaPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));

                txtCodigo.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdPessoa));
                mtbAdmissao.Text = Convert.ToString(result.Cadastro);
                txtNome.Text = result.Nome;
                mtbNascimento.Text = Convert.ToString(result.Nascimento);
                cmbSexo.Text = result.Sexo == "F" ? "FEMININO" : "MASCULINO";
                new WindowsForm().SelectById(cmbCargo, Convert.ToString(result.IdCargo));
                cmbStatus.Text = result.Status == "1" ? "ATIVO" : "INATIVO";

                mtbDemissao.Text = Convert.ToString(result.Desligamento); 
                txtLogradouro.Text = result.Logradouro;
                txtComplemento.Text = result.Complemento;
                mtbCep.Text = result.Cep;

                if (result.IdEstado != 0) { new WindowsForm().SelectById(cmbEstado, Convert.ToString(result.IdEstado)); }
                if (result.IdCidade != 0) { new WindowsForm().SelectById(cmbCidade, Convert.ToString(result.IdCidade)); }
                if (result.IdBairro != 0) { new WindowsForm().SelectById(cmbBairro, Convert.ToString(result.IdBairro)); }

                mtbTelefone.Text = result.Fixo;
                mtbCelular.Text = result.Celular;
                mtbContato.Text = result.Contato;
                txtEmail.Text = result.Email;
                mtbCPF.Text = result.Cpf;
                mtbRG.Text = result.Rg;
                cmbExpedicao.Text = result.Expedicao;
                mtbPis.Text = result.Pis;
                txtCtps.Text = result.Ctps;
                txtSerie.Text = result.Serie;
                mtbCnpj.Text = result.Cnpj;
                txtCartReservista.Text = result.CartReservista;

                tabDiversos.SelectedTab = tabColaborador;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface do Colaborador.") + ex.Message);
            }
        }


        private void CarregaInterfaceDeDadoBancario(int id)
        {
            var repositorioDeDadoBancario = new RepositorioDeDadosBancarios();
            try
            {
                var result = repositorioDeDadoBancario.ObterDadoBancarioPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException("Dados não localizados");

                txtCodBanco.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdDadoBancario));
                cmbStaBanco.Text = result.Status;
                cmbBanco.Text = result.NomeBanco;
                cmbTipConta.Text = result.Tipo;
                txtAgencia.Text = result.Agencia;
                txtNumConta.Text = result.NumeroConta;
                txtTitular.Text = result.Titular;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface de Dado(s) Bancario(s).") + ex.Message);
            }
        }

        private void CarregaInterfaceDeDadoRemuneracao(int id)
        {
            var repositorioDeDadoRemuneracao = new RepositorioDeDadosRemuneracoes();
            try
            {
                var result = repositorioDeDadoRemuneracao.ObterDadoRemuneracaoPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException("Dados não localizados");

                txtCodRemun.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdDadoRemuneracao));
                new WindowsForm().SelectById(cmbRemuneracao ,Convert.ToString(result.IdRemuneracao));
                mtbRemuneracao.Text = Convert.ToString(result.Valor); 

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface de Dado(s) Bancario(s).") + ex.Message);
            }
        }

        private void CarregaInterfaceDeDadoProduto(int id)
        {
            var repositorioDeDadoProduto = new RepositorioDeDadosProdutos();
            try
            {
                var result = repositorioDeDadoProduto.ObterDadoProdutoPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException("Dados não localizados");

                txtCodPrograma.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdDadoProduto));
                new WindowsForm().SelectById(cmbPrograma, Convert.ToString(result.IdPrograma));

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface de Dado(s) Programa(s).") + ex.Message);
            }
        }

        private void ExibeColaboradorSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlColaborador.Enabled = true;
                    MontaComboCargo(cmbCargo);
                    MontaComboEstado(cmbEstado);
                    MontaComboCidade(cmbCidade, 0);
                    MontaComboBairro(cmbBairro, 0);

                    CarregaInterfaceDeColaborador(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                    ListaDadoBancarioDeColaborador(lstDadoBancario, Convert.ToInt32(txtCodigo.Text));
                    ListaRemuneracaoDeColaborador(lstRemuneracao, Convert.ToInt32(txtCodigo.Text));
                    ListaProdutoParaColaborador(lstPrograma, Convert.ToInt32(txtCodigo.Text));

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void ExibeDadoBancarioSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlDadoBancario.Enabled = true;
                    MontaComboBanco(cmbBanco);

                    CarregaInterfaceDeDadoBancario(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ExibeDadoRemuneracaoSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlRemuneracao.Enabled = true;
                    MontaComboRemuneracao(cmbRemuneracao);

                    CarregaInterfaceDeDadoRemuneracao(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void ExibeDadoProdutoSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (lst.SelectedItems[0].Selected)
                {
                    pnlPrograma.Enabled = true;
                    MontaComboPrograma(cmbPrograma);

                    CarregaInterfaceDeDadoProduto(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

        #region Carregamento de Objeto

        private void CarregaObjetoColaborador(Colaborador c)
        {
            try
            {
                c.IdFirma = IdFirma;
                c.IdPessoa = txtCodigo.Text != string.Empty ? Convert.ToInt32(txtCodigo.Text) : 0;
                c.Cadastro = Convert.ToDateTime(mtbAdmissao.Text);
                c.Nome = txtNome.Text;
                c.Nascimento = Convert.ToDateTime(mtbNascimento.Text);
                c.Sexo = cmbSexo.Text == "FEMININO" ? "F" : "M";
                c.IdCargo = Convert.ToInt32(cmbCargo.SelectedValue);
                c.Status = cmbStatus.Text == "ATIVO" ? "1" : "0";
                //if (mtbDemissao.Text != string.Empty) { c.Desligamento = Convert.ToDateTime(mtbDemissao.Text); }
                c.Logradouro = txtLogradouro.Text;
                c.Complemento = txtComplemento.Text;
                c.Cep = mtbCep.Text.Replace("-", "");
                c.IdEstado = Convert.ToInt32(cmbEstado.SelectedValue);
                c.IdCidade = Convert.ToInt32(cmbCidade.SelectedValue);
                c.IdBairro = Convert.ToInt32(cmbBairro.SelectedValue);
                c.Fixo = mtbTelefone.Text;
                c.Celular = mtbCelular.Text;
                c.Contato = mtbContato.Text;
                c.Email = txtEmail.Text;
                c.Cpf = mtbCPF.Text;
                c.Rg = mtbRG.Text;
                c.Expedicao = cmbExpedicao.Text;
                c.Pis = mtbPis.Text;
                c.Ctps = txtCtps.Text;
                c.Serie = txtSerie.Text;
                c.Cnpj = mtbCnpj.Text;
                c.CartReservista = txtCartReservista.Text;

                c.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.Colaborador(c);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Colaborador. " + ex.Message);
            }
        }

        private void CarregaObjetoDadoBancario(DadoBancario db)
        {
            try
            {
                db.IdPessoa = Convert.ToInt32(txtCodigo.Text);
                db.IdDadoBancario = txtCodBanco.Text != string.Empty ? Convert.ToInt32(txtCodBanco.Text) : 0;
                db.Status = cmbStaBanco.Text == "ATIVO" ? "1" : "0";
                db.IdBanco = Convert.ToInt32(cmbBanco.SelectedValue);
                db.Tipo = cmbTipConta.Text == "CORRENTE" ? "C" : "P";
                db.Agencia = txtAgencia.Text;
                db.NumeroConta = txtNumConta.Text;
                db.Titular = txtTitular.Text;

                db.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.DadoBancario(db);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Dado Bancario. " + ex.Message);
            }
        }

        private void CarregaObjetoDadoRemuneracao(DadoRemuneracao db)
        {
            try
            {
                db.IdPessoa = Convert.ToInt32(txtCodigo.Text);
                db.IdDadoRemuneracao = txtCodRemun.Text != string.Empty ? Convert.ToInt32(txtCodRemun.Text) : 0;
                db.IdRemuneracao = Convert.ToInt32(cmbRemuneracao.SelectedValue);
                db.Valor = Convert.ToDecimal(mtbRemuneracao.Text);

                db.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.DadoRemuneracao(db);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Dado Remuneração. " + ex.Message);
            }
        }

        private void CarregaObjetoDadoProduto(DadoProduto dp)
        {
            try
            {
                dp.IdPessoa = Convert.ToInt32(txtCodigo.Text);
                dp.IdDadoProduto = txtCodPrograma.Text != string.Empty ? Convert.ToInt32(txtCodPrograma.Text) : 0;
                dp.IdPrograma = Convert.ToInt32(cmbPrograma.SelectedValue);
                dp.DataRegistro = DateTime.Now; 
                dp.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.DadoProduto(dp);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Dado Produto-Programa. " + ex.Message);
            }
        }

        #endregion

        #region Persiste Colaborador

        private void CadastraColaborador()
        {
            var colaborador = new Colaborador();
            var repositorioDeColaborador = new RepositorioDeColaboradores();

            try
            {
                CarregaObjetoColaborador(colaborador);
                repositorioDeColaborador.Insere(colaborador);

                MessageBox.Show(string.Format("Colaborador registrado com sucesso."), string.Format("Registro de Colaborador"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Text = RepositorioDeColaboradores.Retorna.IdColaborador(colaborador.Nome);
                ListaColaboradores(lstColaborador, "", Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2)));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }
       
        private void AlteraColaborador()
        {
            var colaborador = new Colaborador();
            var repositorioDeColaborador = new RepositorioDeColaboradores();

            try
            {
                CarregaObjetoColaborador(colaborador);
                repositorioDeColaborador.Altera(colaborador);

                MessageBox.Show(string.Format("Colaborador alterado com sucesso."), string.Format("Alteração de Colaborador"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaColaboradores(lstColaborador, "", Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2)));

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiColaborador()
        {
            var colaborador = new Colaborador();
            var repositorioDeColaborador = new RepositorioDeColaboradores();

            try
            {
                CarregaObjetoColaborador(colaborador);
                repositorioDeColaborador.ExclusaoLogica(colaborador);

                MessageBox.Show(string.Format("Colaborador excluido com sucesso."), string.Format("Exclusão de Colaborador"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaColaboradores(lstColaborador, "", Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2)));
                Funcoes.LimpaCamposFormulario(Controls);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }


        #endregion

        #region Persiste Dado Bancario

        private void CadastraDadoBancario()
        {
            var dadobancario = new DadoBancario();
            var repositorioDeDadoBancario = new RepositorioDeDadosBancarios();
            try
            {
                CarregaObjetoDadoBancario(dadobancario);
                repositorioDeDadoBancario.Insere(dadobancario);

                MessageBox.Show(string.Format("Dado Bancario registrado com sucesso."), string.Format("Registro de Dado Bancario"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodBanco.Text = RepositorioDeDadosBancarios.Retorna.IdDadoBancario(dadobancario);
                ListaDadoBancarioDeColaborador(lstDadoBancario, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposDadoBancario();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraDadoBancario()
        {
            var dadobancario = new DadoBancario();
            var repositorioDeDadoBancario = new RepositorioDeDadosBancarios();

            try
            {
                CarregaObjetoDadoBancario(dadobancario);
                repositorioDeDadoBancario.Altera(dadobancario);

                MessageBox.Show(string.Format("Dado Bancario alterado com sucesso."), string.Format("Alteração de Dado Bancario"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaDadoBancarioDeColaborador(lstDadoBancario, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposDadoBancario();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiDadoBancario()
        {
            var dadobancario = new DadoBancario();
            var repositorioDeDadoBancario = new RepositorioDeDadosBancarios();

            try
            {
                CarregaObjetoDadoBancario(dadobancario);
                repositorioDeDadoBancario.Exclui(dadobancario);

                MessageBox.Show(string.Format("Dado Bancario excluido com sucesso."), string.Format("Exclusão de Dado Bancario"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaDadoBancarioDeColaborador(lstDadoBancario, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposDadoBancario();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }


        #endregion

        #region Persiste Dado Remuneracao

        private void CadastraDadoRemuneracao()
        {
            var dadoremuneracao = new DadoRemuneracao();
            var repositorioDeDadoRemuneracao = new RepositorioDeDadosRemuneracoes();
            try
            {
                CarregaObjetoDadoRemuneracao(dadoremuneracao);
                repositorioDeDadoRemuneracao.Insere(dadoremuneracao);

                MessageBox.Show(string.Format("Dado Remuneração registrado com sucesso."), string.Format("Registro de Dado Remuneração"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodRemun.Text = RepositorioDeDadosRemuneracoes.Retorna.IdDadoRemuneracao(dadoremuneracao);
                ListaRemuneracaoDeColaborador(lstRemuneracao, Convert.ToInt32(txtCodigo.Text));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraDadoRemuneracao()
        {
            var dadoremuneracao = new DadoRemuneracao();
            var repositorioDeDadoRemuneracao = new RepositorioDeDadosRemuneracoes();

            try
            {
                CarregaObjetoDadoRemuneracao(dadoremuneracao);
                repositorioDeDadoRemuneracao.Altera(dadoremuneracao);

                MessageBox.Show(string.Format("Dado Remuneração alterado com sucesso."), string.Format("Alteração de Dado Remuneração"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaRemuneracaoDeColaborador(lstRemuneracao, Convert.ToInt32(txtCodigo.Text));

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiDadoRemuneracao()
        {
            var dadoremuneracao = new DadoRemuneracao();
            var repositorioDeDadoRemuneracao = new RepositorioDeDadosRemuneracoes();

            try
            {
                CarregaObjetoDadoRemuneracao(dadoremuneracao);
                repositorioDeDadoRemuneracao.Exclui(dadoremuneracao);

                MessageBox.Show(string.Format("Dado Remuneração excluido com sucesso."), string.Format("Exclusão de Dado Remuneração"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaRemuneracaoDeColaborador(lstRemuneracao, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposDadoRemuneracao();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        #endregion

        #region Persiste Dado Produto\Programa

        private void CadastraDadoProduto()
        {
            var dadoProduto = new DadoProduto();
            var repositorioDeDadoProduto = new RepositorioDeDadosProdutos();
            try
            {
                CarregaObjetoDadoProduto(dadoProduto);
                repositorioDeDadoProduto.Insere(dadoProduto);

                MessageBox.Show(string.Format("Dado Produto-Programa registrado com sucesso."), string.Format("Registro de Dado Produto-Programa"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodPrograma.Text = String.Format("{0:00000}", RepositorioDeDadosProdutos.Retorna.IdDadoProduto(dadoProduto));
                ListaProdutoParaColaborador(lstPrograma, Convert.ToInt32(txtCodigo.Text));

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiDadoProduto()
        {
            var dadoProduto = new DadoProduto();
            var repositorioDeDadoProduto = new RepositorioDeDadosProdutos();

            try
            {
                CarregaObjetoDadoProduto(dadoProduto);
                repositorioDeDadoProduto.Exclui(dadoProduto);

                MessageBox.Show(string.Format("Dado Produto-Programa excluido com sucesso."), string.Format("Exclusão de Dado Produto-Programa"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaProdutoParaColaborador(lstPrograma, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposDadoProduto();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        #endregion

        #region Limpa Interface

        private void LimpaCamposColaborador()
        {
            txtCodigo.Text = string.Empty;
            mtbAdmissao.Text = string.Empty;
            txtNome.Text = string.Empty;
            mtbNascimento.Text = string.Empty;
            cmbSexo.Text = string.Empty;
            cmbCargo.Text = string.Empty;
            cmbStatus.Text = string.Empty;
            mtbDemissao.Text = string.Empty;
            txtLogradouro.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            mtbCep.Text = string.Empty;
            cmbEstado.Text = string.Empty;
            cmbCidade.Text = string.Empty;
            cmbBairro.Text = string.Empty;
            mtbTelefone.Text = string.Empty;
            mtbCelular.Text = string.Empty;
            mtbContato.Text = string.Empty;
            txtEmail.Text = string.Empty;
            mtbCPF.Text = string.Empty;
            mtbRG.Text = string.Empty;
            cmbExpedicao.Text = string.Empty;
            mtbPis.Text = string.Empty;
            txtCtps.Text = string.Empty;
            txtSerie.Text = string.Empty;
            mtbCnpj.Text = string.Empty;
            txtCartReservista.Text = string.Empty;
            chkClt.Checked = false;
            chkComissao.Checked = false;

        }

        private void LimpaCamposDadoBancario()
        {
            cmbBanco.SelectedValue = 0;
            txtCodBanco.Text = string.Empty;
            cmbStaBanco.Text = "ATIVO";
            cmbTipConta.Text = string.Empty;
            txtAgencia.Text = string.Empty;
            txtNumConta.Text = string.Empty;
            txtTitular.Text = string.Empty;
            chkTitular.Checked = false;

        }

        private void LimpaCamposDadoRemuneracao()
        {
            txtCodRemun.Text = string.Empty;
            cmbRemuneracao.Text = string.Empty;
            mtbRemuneracao.Text = string.Empty;

        }

        private void LimpaCamposDadoProduto()
        {
            txtCodPrograma.Text = string.Empty;
            cmbPrograma.Text = string.Empty;

        }

        #endregion

        private void lstColaborador_Click(object sender, EventArgs e)
        {
            try
            {
                ExibeColaboradorSelecionado(lstColaborador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void ExcluirColaborador_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluiColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void toolAtualizar_Click(object sender, EventArgs e)
        {
            ListaColaboradores(lstColaborador, "", Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2)));

        }

        private void AlterarColaborador_Click(object sender, EventArgs e)
        {
            try
            {
                AlteraColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void CadastrarColaborador_Click(object sender, EventArgs e)
        {
            try
            {
                CadastraColaborador();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void cmbEstado_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbEstado.SelectedValue != "0")
            {
                MontaComboCidade(cmbCidade, Convert.ToInt32(cmbEstado.SelectedValue));

            }
        }

        private void novoDadoBancario_Click(object sender, EventArgs e)
        {
            try
            {
                LimpaCamposDadoBancario();
                MontaComboBanco(cmbBanco);
                pnlDadoBancario.Enabled = true;
                cmbStaBanco.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void cmbCidade_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(cmbCidade.SelectedValue))) return;
                MontaComboBairro(cmbBairro, Convert.ToInt32(cmbCidade.SelectedValue));
        }

        private void cmbEstado_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(cmbEstado.SelectedValue))) return;
            MontaComboCidade(cmbCidade, Convert.ToInt32(cmbEstado.SelectedValue));
        }

        private void novoColaborador_Click(object sender, EventArgs e)
        {
            try
            {
                pnlColaborador.Enabled = true;

                MontaComboCargo(cmbCargo);
                MontaComboEstado(cmbEstado);
                MontaComboCidade(cmbCidade, -1);
                MontaComboBairro(cmbBairro, -1);

                LimpaCamposColaborador();
                mtbAdmissao.Text = Convert.ToString(DateTime.Now);
                cmbStatus.Text = "ATIVO";
                txtNome.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void lstDadoBancario_Click(object sender, EventArgs e)
        {
            try
            {
                ExibeDadoBancarioSelecionado(lstDadoBancario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void chkTitular_CheckedChanged(object sender, EventArgs e)
        {
            txtTitular.Text = chkTitular.Checked ? txtNome.Text : string.Empty;
        }

        private void registraDadoBancario_Click(object sender, EventArgs e)
        {
            try
            {
                CadastraDadoBancario();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void alterarDadoBancario_Click(object sender, EventArgs e)
        {
            try
            {
                AlteraDadoBancario();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void excluirDadoBancario_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluiDadoBancario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void novaRemuneracao_Click(object sender, EventArgs e)
        {
            try
            {
                pnlRemuneracao.Enabled = true;
                cmbRemuneracao.Focus();

                MontaComboRemuneracao(cmbRemuneracao);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void lstRemuneracao_Click(object sender, EventArgs e)
        {
            try
            {
                ExibeDadoRemuneracaoSelecionado(lstRemuneracao);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void registraRemuneracao_Click(object sender, EventArgs e)
        {
            try
            {
                CadastraDadoRemuneracao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void alteraRemuneracao_Click(object sender, EventArgs e)
        {
            try
            {
                AlteraDadoRemuneracao();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void excluiRemuneracao_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluiDadoBancario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void novoPrograma_Click(object sender, EventArgs e)
        {
            try
            {
                pnlPrograma.Enabled = true;
                cmbPrograma.Focus();

                MontaComboPrograma(cmbPrograma);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void registraPrograma_Click(object sender, EventArgs e)
        {
            try
            {
                CadastraDadoProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void excluiPrograma_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluiDadoProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void lstPrograma_Click(object sender, EventArgs e)
        {
            try
            {
                ExibeDadoProdutoSelecionado(lstPrograma);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void cmbCidade_SelectedValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(cmbCidade.SelectedValue))) return;
            MontaComboBairro(cmbBairro, Convert.ToInt32(cmbCidade.SelectedValue));

        }

        private void cmbEstado_SelectedValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(cmbEstado.SelectedValue))) return;
            MontaComboCidade(cmbCidade, Convert.ToInt32(cmbEstado.SelectedValue));

        }

        private void lstColaborador_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.lstColaborador.Sort();
        }

        private void TxtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { ListaColaboradores(lstColaborador, "", Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2))); }

        }

        private void tsCmbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { ListaColaboradores(lstColaborador, "", Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2))); }

        }
    }
}
