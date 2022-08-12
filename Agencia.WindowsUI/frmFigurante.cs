using System;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    public partial class frmFigurante : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }
        private ListViewColumnSorter lvwColumnSorter;

        private RepositorioDeFigurantes _repositorioDeFigurante;
        private FiguranteDao _dao;

        public frmFigurante()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            lstFigurante.ListViewItemSorter = lvwColumnSorter;

            WindowsForm.RegisterFocusEvents(Controls);
        }

        private void frmFigurante_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;

                Cursor = Cursors.WaitCursor;
                Funcoes.LimpaCamposFormulario(Controls);

                HabilitaOperacoes(false);
                
                tsCmbStatus.Text = string.Format("01- ATIVO");

                ListaFigurantes(lstFigurante, "-1", Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2)), 0);

                TxtConsulta.Focus();
                
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

        #region Montagem de Combos

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

        private void MontaComboMarca(ComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeMarcasDeVeiculos().ObterListaDeMarcasDeVeiculos(ICodigoUsuario));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Marca(s) de Veículo(s) cadastrados.") + ex.Message);
            }
        }

        private void MontaComboModelo(ComboBox cmb, int idmarca)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb,
                                                    idmarca == 0
                                                        ? new RepositorioDeModelosDeVeiculos().ObterListaDeModelos(ICodigoUsuario)
                                                        : new RepositorioDeModelosDeVeiculos().ObterListaDeModelosPorMarca(
                                                            ICodigoUsuario, idmarca));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Modelo(s) de Veículo(s) cadastrados.") + ex.Message);
            }
        }
        #endregion

        #region Carregamento de ListView

        private void ListaFigurantes(ListView lst, string dado, int status, int idpessoa)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Matricula", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Data-Cadastro", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Nome-Figurante", 40 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Ult-Gravação", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Center);
                lst.Columns.Add("Telefone(s)", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Email", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantes().ObterListaDeFigurantes(ICodigoUsuario, dado, status, idpessoa));
                qtdFigurante.Text = lst.Items.Count.ToString();
                qtdFigurante.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Figurante(es) cadastrados.") + ex.Message);
            }

        }

        private void ListaDadoBancarioDeFigurante(ListView lst, int id)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Status", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Nome-Banco", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Tipo-Conta", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Agência", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Número-Conta", 12 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Títular-Conta", 39 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeDadosBancarios().ObterListaDeDadoBancario(ICodigoUsuario, id));
                QtdDadoBanco.Text = lst.Items.Count.ToString();
                QtdDadoBanco.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Dados Bancários(s) cadastrado(s) para o figurante.") + ex.Message);
            }
        }

        private void ListaVeiculoParaFigurante(ListView lst, int id)
        {
            try
            {
                lst.Columns.Clear();

                lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Marca", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Modelo", 30 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);
                lst.Columns.Add("Ano", 10 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeVeiculos().ObterListaDeVeiculosPorId(ICodigoUsuario, id));
                QtdVeiculo.Text = lst.Items.Count.ToString();
                QtdVeiculo.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Veículo(s) cadastrado(s) para o figurante.") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de Interface

        private void ExibeFiguranteSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (!lst.SelectedItems[0].Selected) return;

                HabilitaOperacoes(true);

                MontaComboEstado(cmbEstado);
                MontaComboCidade(cmbCidade, 0);
                MontaComboBairro(cmbBairro, 0);
                MontaComboMarca(CmbMarca);

                CarregaInterfaceDeFigurante(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
                ListaDadoBancarioDeFigurante(lstDadoBancario, Convert.ToInt32(txtCodigo.Text));
                ListaVeiculoParaFigurante(lstVeiculo, Convert.ToInt32(txtCodigo.Text));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        private void ExibeDadosQuandoMenor(int emenor)
        {
            if (emenor == 1) 
            {
                pnlMenor.Visible = true;
            }
            else
            {
                pnlMenor.Visible = false;
            }
        }

        private void CarregaInterfaceDeFigurante(int id)
        {
            var repositorioDeFigurante = new RepositorioDeFigurantes();
            try
            {
                var result = repositorioDeFigurante.ObterPessoaPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException(string.Format("Dados não localizados"));

                txtCodigo.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdPessoa));
                mtbAdmissao.Text = Convert.ToString(result.Cadastro);
                txtNome.Text = result.Nome;
                mtbNascimento.Text = Convert.ToString(result.Nascimento);
                lblIdade.Text = string.Format("{0} ano(s) de idade", Convert.ToString(Funcoes.CalculaIdade(result.Nascimento)));

                ExibeDadosQuandoMenor(result.Menor);

                txtDtAlvara.Text = Convert.ToString(result.DataAlvara);
                txtNumProcesso.Text = result.NumProcesso;

                cmbSexo.Text = result.Sexo == "F" ? "FEMININO" : "MASCULINO";
                cmbStatus.Text = result.Status == "1" ? "ATIVO" : "INATIVO";
                txtAcesso.Text = result.Acesso;
                txtPasta.Text = result.Pasta;
                cmbNacionalidade.Text = Convert.ToString(result.Nacionalidade);
                cmbEstCivil.Text = Convert.ToString(result.EstadoCivil);
                txtNmeArtistico.Text = result.NomeArtistico;
                txtMae.Text = result.Mae;
                txtPai.Text = result.Pai;
                txtLogradouro.Text = result.Logradouro;
                txtComplemento.Text = result.Complemento;
                mtbCep.Text = result.Cep;

                txtResponsavel.Text = result.Responsavel;
                mtbCPFResp.Text = result.CpfResp;
                txtCertNascimento.Text = result.CertNascimento;
                txtLivro.Text = result.Livro;

                if (result.IdEstado != 0) 
                {
                    new WindowsForm().SelectById(cmbEstado, Convert.ToString(result.IdEstado));
                }
                else
                {
                    cmbEstado.SelectedValue = "0";
                }

                if (result.IdCidade != 0)
                {
                    new WindowsForm().SelectById(cmbCidade, Convert.ToString(result.IdCidade));
                }
                else
                {
                    cmbCidade.SelectedValue = "0";
                }

                if (result.IdBairro != 0)
                {
                    new WindowsForm().SelectById(cmbBairro, Convert.ToString(result.IdBairro));
                }
                else
                {
                    cmbBairro.SelectedValue = "0";
                }

                mtbTelefone.Text = result.Fixo;
                mtbCelular.Text = result.Celular;
                mtbContato.Text = result.Contato;
                txtEmail.Text = result.Email;
                mtbCPF.Text = result.Cpf;
                mtbRG.Text = result.Rg;
                mtbPis.Text = result.Pis;
                txtCtps.Text = result.Ctps;
                cmbProfissao.Text = result.Profissao;
                txtRegistroAtor.Text = result.RegistroArtistico;
                chkAtor.Checked = result.AtuaComoAtor == 1 ? true : false;
                chkFigurante.Checked = result.AtuaComoFigurante == 1 ? true : false;
                chkModelo.Checked = result.AtuaComoModelo == 1 ? true : false;
                
                //Biotipo
                txtAltura.Text = result.Altura;
                txtIdadeAparente.Text = result.IdadeAparente;
                txtPeso.Text = result.Peso;
                cmbTipoEtnico.Text = result.TipoEtnico;
                cmbManequim.Text = result.Manequim;
                cmbCalcado.Text = result.Calcado;
                txtBusto.Text = result.Busto;
                txtQuadril.Text = result.Quadril;
                txtCintura.Text = result.Cintura;
                txtSemelhanca.Text = result.SemelhancaComCelebridade;
                cmbCorOlhos.Text = result.CorOlhos;
                cmbCabelos.Text = result.Cabelo;
                cmbCorCabelo.Text = result.CorCabelo;
                cmbTipoCabelo.Text = result.TipoCabelo;
                cmbCorPele.Text = result.CorPele;
                chkUsaAparelho.Checked = result.UsaAparelho == 1 ? true : false;

                tabDiversos.SelectedTab = tabFigurante;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível carregar a Interface do Figurante.") + ex.Message);
            }
        }

        private void ExibeDadoBancarioSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (!lst.SelectedItems[0].Selected) return;
                pnlDadoBancario.Enabled = true;
                MontaComboBanco(cmbBanco);

                CarregaInterfaceDeDadoBancario(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                new WindowsForm().SelectById(cmbBanco, Convert.ToString(result.IdBanco));
                //cmbBanco.Text = result.NomeBanco;
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

        private void ExibeVeiculoSelecionado(ListView lst)
        {
            try
            {
                if (lst.SelectedItems.Count == 0) return;
                if (!lst.SelectedItems[0].Selected) return;
                pnlVeiculo.Enabled = true;
                MontaComboMarca(CmbMarca);
                MontaComboModelo(CmbModelo, 0);
 
                CarregaInterfaceDeVeiculo(Convert.ToInt32(lst.FocusedItem.SubItems[0].Text));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CarregaInterfaceDeVeiculo(int id)
        {
            var repositorioDeVeiculo = new RepositorioDeVeiculos();
            try
            {
                var result = repositorioDeVeiculo.ObterVeiculoPorId(ICodigoUsuario, id);
                if (result == null) throw new ArgumentNullException("Dados não localizados");

                TxtCodVeiculo.Text = String.Format("{0:00000}", Convert.ToInt32(result.IdVeiculo));
                new WindowsForm().SelectById(CmbMarca, Convert.ToString(result.IdMarca));
                new WindowsForm().SelectById(CmbModelo, Convert.ToString(result.IdModelo));
                CmbAno.Text = result.Ano;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi carregar a Interface de Veículo(s).") + ex.Message);
            }
        }

        #endregion

        #region Carregamento de Objeto

        private void CarregaObjetoFigurante(Figurante f)
        {
            try
            {
                f.IdFirma = IdFirma;
                f.IdPessoa = txtCodigo.Text != string.Empty ? Convert.ToInt32(txtCodigo.Text) : 0;
                f.Cadastro = Convert.ToDateTime(mtbAdmissao.Text);
                f.Status = cmbStatus.Text == "ATIVO" ? "1" : "0";
                f.Nome = txtNome.Text;
                f.Sexo = cmbSexo.Text == "FEMININO" ? "F" : "M";
                f.Nascimento = Convert.ToDateTime(mtbNascimento.Text);
                f.Acesso = txtAcesso.Text;
                f.Pasta = txtPasta.Text;

                switch (cmbNacionalidade.Text)
                {
                    case "BRASILEIRO(A)":
                        f.Nacionalidade = "1";
                        break;
                    case "ESTRANGEIRO(A)":
                        f.Nacionalidade = "2";
                        break;
                }
                
                switch (cmbEstCivil.Text)
                {
                    case "SOLTEIRO(A)":
                        f.EstadoCivil = "1";
                        break;
                    case "CASADO(A)":
                        f.EstadoCivil = "2";
                        break;
                    case "SEPARADO(A)":
                        f.EstadoCivil = "3";
                        break;
                    case "DIVORCIADO(A)":
                        f.EstadoCivil = "4";
                        break;
                    case "VIUVO(A)":
                        f.EstadoCivil = "5";
                        break;
                }
                
                f.NomeArtistico = txtNmeArtistico.Text;
                f.Mae = txtMae.Text;
                f.Pai = txtPai.Text;
                f.Logradouro = txtLogradouro.Text;
                f.Complemento = txtComplemento.Text;
                f.Cep = mtbCep.Text.Replace("-", "");
                f.IdEstado = Convert.ToInt32(cmbEstado.SelectedValue);
                f.IdCidade = Convert.ToInt32(cmbCidade.SelectedValue);
                f.IdBairro = Convert.ToInt32(cmbBairro.SelectedValue);
                f.Fixo = mtbTelefone.Text;
                f.Celular = mtbCelular.Text;
                f.Contato = mtbContato.Text;
                f.Email = txtEmail.Text;
                f.Cpf = mtbCPF.Text;
                f.Rg = mtbRG.Text;
                f.Pis = mtbPis.Text;
                f.Ctps = txtCtps.Text;
                f.Profissao = cmbProfissao.Text;
                f.RegistroArtistico = txtRegistroAtor.Text;
                f.AtuaComoFigurante = chkFigurante.Checked ? 1 : 0;
                f.AtuaComoAtor = chkAtor.Checked ? 1 : 0;
                f.AtuaComoModelo = chkModelo.Checked ? 1 : 0;
                f.Altura = txtAltura.Text;
                f.IdadeAparente = txtIdadeAparente.Text;
                f.TipoEtnico = cmbTipoEtnico.Text;
                f.Manequim = cmbManequim.Text;
                f.Calcado = cmbCalcado.Text;
                f.Busto = txtBusto.Text;
                f.Quadril = txtQuadril.Text;
                f.Cintura = txtCintura.Text;
                f.SemelhancaComCelebridade = txtSemelhanca.Text;
                f.CorOlhos = cmbCorOlhos.Text;
                f.Cabelo = cmbCabelos.Text;
                f.CorCabelo = cmbCorCabelo.Text;
                f.TipoCabelo = cmbTipoCabelo.Text;
                f.CorPele = cmbCorPele.Text;
                f.UsaAparelho = chkUsaAparelho.Checked ? 1 : 0;
                f.IdUsuario = ICodigoUsuario;
                f.Responsavel = txtResponsavel.Text;
                f.CpfResp = mtbCPFResp.Text;
                f.CertNascimento = txtCertNascimento.Text;
                f.Livro = txtLivro.Text;

                Valida.Preenchimento.Figurante(f);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Figurante. " + ex.Message);
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

        private void CarregaObjetoVeiculo(Veiculo v)
        {
            try
            {
                v.IdPessoa = Convert.ToInt32(txtCodigo.Text);
                v.IdVeiculo = TxtCodVeiculo.Text != string.Empty ? Convert.ToInt32(TxtCodVeiculo.Text) : 0;
                v.IdMarca = Convert.ToInt32(CmbMarca.SelectedValue);
                v.IdModelo = Convert.ToInt32(CmbModelo.SelectedValue);
                v.Ano = CmbAno.Text;

                v.IdUsuario = ICodigoUsuario;

                Valida.Preenchimento.Veiculo(v);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o objeto Veículo. " + ex.Message);
            }
        }
        #endregion

        #region Persiste Figurante

        private void CadastraFigurante()
        {
            var figurante = new Figurante();
            var repositorioDeFigurante = new RepositorioDeFigurantes();

            try
            {
                if (!ValidaDataDeNascimento(Convert.ToDateTime(mtbNascimento.Text), Convert.ToDateTime(mtbAdmissao.Text))) return;
                if (!ValidaEmail(txtEmail.Text)) return;

                CarregaObjetoFigurante(figurante);
                Entidade.Existe.Pessoa(figurante);
                repositorioDeFigurante.Insere(figurante);

                MessageBox.Show(string.Format("Figurante registrado com sucesso."), string.Format("Registro de Figurante"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Text = RepositorioDeFigurantes.Retorna.IdFigurante(figurante.Nome);
                ListaFigurantes(lstFigurante, "-1", Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2)), 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraFigurante()
        {
            var figurante = new Figurante();
            var repositorioDeFigurante = new RepositorioDeFigurantes();

            try
            {
                CarregaObjetoFigurante(figurante);
                repositorioDeFigurante.Altera(figurante);

                MessageBox.Show(string.Format("Figurante alterado com sucesso."), string.Format("Alteração de Figurante"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (TxtConsulta.Text.Trim() != string.Empty || txtMatricula.Text.Trim() != string.Empty)
                {
                    int idmatricula = 0;
                    if (txtMatricula.Text.Trim() != string.Empty) { idmatricula = Convert.ToInt32(txtMatricula.Text); }

                    ListaFigurantes(lstFigurante, TxtConsulta.Text, Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2)), idmatricula);
                }
                else
                {
                    ListaFigurantes(lstFigurante, "-1", Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2)), 0);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluirFigurante()
        {
            var figurante = new Figurante();
            var repositorioDeFigurante = new RepositorioDeFigurantes();

            try
            {
                CarregaObjetoFigurante(figurante);
                repositorioDeFigurante.ExclusaoLogica(figurante);

                MessageBox.Show(string.Format("Figurante excluido com sucesso."), string.Format("Alteração de Figurante"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaFigurantes(lstFigurante, TxtConsulta.Text, Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2)), 0);
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
                Entidade.Existe.DadoBancario(dadobancario);
                repositorioDeDadoBancario.Insere(dadobancario);

                MessageBox.Show(string.Format("Dado Bancario registrado com sucesso."), string.Format("Registro de Dado Bancario"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodBanco.Text = RepositorioDeDadosBancarios.Retorna.IdDadoBancario(dadobancario);
                ListaDadoBancarioDeFigurante(lstDadoBancario, Convert.ToInt32(txtCodigo.Text));
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
                ListaDadoBancarioDeFigurante(lstDadoBancario, Convert.ToInt32(txtCodigo.Text));
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
                ListaDadoBancarioDeFigurante(lstDadoBancario, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposDadoBancario();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }


        #endregion

        #region Persiste Veículo

        private void CadastraVeiculo()
        {
            var veiculo = new Veiculo();
            var repositorioDeVeiculo = new RepositorioDeVeiculos();

            try
            {
                CarregaObjetoVeiculo(veiculo);
                Entidade.Existe.Veiculo(veiculo);
                repositorioDeVeiculo.Insere(veiculo);

                MessageBox.Show(string.Format("Veículo registrado com sucesso."), string.Format("Registro de Veículo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCodVeiculo.Text = RepositorioDeVeiculos.Retorna.IdVeiculo(veiculo);
                ListaVeiculoParaFigurante(lstVeiculo, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposVeiculo();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void AlteraVeiculo()
        {
            var veiculo = new Veiculo();
            var repositorioDeVeiculo = new RepositorioDeVeiculos();

            try
            {
                CarregaObjetoVeiculo(veiculo);
                repositorioDeVeiculo.Altera(veiculo);

                MessageBox.Show(string.Format("Veículo alterado com sucesso."), string.Format("Alteração de Veículo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaVeiculoParaFigurante(lstVeiculo, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposVeiculo();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void ExcluiVeiculo()
        {
            var veiculo = new Veiculo();
            var repositorioDeVeiculo = new RepositorioDeVeiculos();

            try
            {
                CarregaObjetoVeiculo(veiculo);
                repositorioDeVeiculo.Exclui(veiculo);

                MessageBox.Show(string.Format("Veículo excluido com sucesso."), string.Format("Exclusão de Veículo"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaVeiculoParaFigurante(lstVeiculo, Convert.ToInt32(txtCodigo.Text));
                LimpaCamposVeiculo();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }


        #endregion

        #region Limpa Interface

        private void LimpaCamposFigurante()
        {
            txtCodigo.Text = string.Empty;
            mtbAdmissao.Text = string.Empty;
            cmbStatus.Text = string.Empty;
            txtNome.Text = string.Empty;
            cmbSexo.Text = string.Empty;
            mtbNascimento.Text = string.Empty;
            lblIdade.Text = string.Empty;
            txtAcesso.Text = string.Empty;
            txtPasta.Text = string.Empty;
            cmbNacionalidade.Text = string.Empty;
            cmbEstCivil.Text = string.Empty;
            txtNmeArtistico.Text = string.Empty;
            txtMae.Text = string.Empty;
            txtPai.Text = string.Empty;
            txtLogradouro.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            mtbCep.Text = string.Empty;
            cmbEstado.SelectedValue = 0;
            cmbCidade.SelectedValue = 0;
            cmbBairro.SelectedValue = 0;
            mtbTelefone.Text = string.Empty;
            mtbCelular.Text = string.Empty;
            mtbContato.Text = string.Empty;
            txtEmail.Text = string.Empty;
            mtbCPF.Text = string.Empty;
            mtbRG.Text = string.Empty;
            mtbPis.Text = string.Empty;
            txtCtps.Text = string.Empty;
            cmbProfissao.Text = string.Empty;
            txtRegistroAtor.Text = string.Empty;
            chkFigurante.Checked = false;
            chkAtor.Checked = false;
            chkModelo.Checked = false;
            txtAltura.Text = string.Empty;
            txtIdadeAparente.Text = string.Empty;
            txtPeso.Text = string.Empty;
            cmbTipoEtnico.Text = string.Empty;
            cmbManequim.Text = string.Empty;
            cmbCalcado.Text = string.Empty;
            txtBusto.Text = string.Empty;
            txtQuadril.Text = string.Empty;
            txtCintura.Text = string.Empty;
            txtSemelhanca.Text = string.Empty;
            cmbCorOlhos.Text = string.Empty;
            cmbCabelos.Text = string.Empty;
            cmbCorCabelo.Text = string.Empty;
            cmbTipoCabelo.Text = string.Empty;
            cmbCorPele.Text = string.Empty;
            chkUsaAparelho.Checked = false;

        }

        private void LimpaCamposDadoBancario()
        {
            cmbBanco .SelectedValue = 0;
            txtCodBanco.Text = string.Empty;
            cmbStaBanco.Text = string.Empty;
            cmbTipConta.Text = string.Empty;
            txtAgencia.Text = string.Empty;
            txtNumConta.Text = string.Empty;
            txtTitular.Text = string.Empty;
            chkTitular.Checked = false;
        }

        private void LimpaCamposVeiculo()
        {
            TxtCodVeiculo.Text = string.Empty;
            CmbMarca.SelectedValue = 0;
            CmbModelo.SelectedValue = 0;
            CmbAno.Text = string.Empty;
          
        }

        #endregion

        private void novoFigurante_Click(object sender, EventArgs e)
        {
            try
            {
                pnlFigurante.Enabled = true;

                MontaComboEstado(cmbEstado);
                MontaComboCidade(cmbCidade, -1);
                MontaComboBairro(cmbBairro, -1);

                LimpaCamposFigurante();
                HabilitaOperacoes(true);
                mtbAdmissao.Text = Convert.ToString(DateTime.Now);
                cmbStatus.Text = "ATIVO";
                txtNome.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void CadastrarFigurante_Click(object sender, EventArgs e)
        {
            try
            {
                CadastraFigurante();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void AlterarFigurante_Click(object sender, EventArgs e)
        {
            try
            {
                AlteraFigurante();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void ExcluiFigurante_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluirFigurante();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void novoDadoBancario_Click(object sender, EventArgs e)
        {
            try
            {
                LimpaCamposDadoBancario();
                MontaComboBanco(cmbBanco);
                pnlDadoBancario.Enabled = true;
                cmbStaBanco.Text = "ATIVO";
                cmbStaBanco.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
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

        private void novoVeiculo_Click(object sender, EventArgs e)
        {
            try
            {
                pnlVeiculo.Enabled = true;

                MontaComboMarca(CmbMarca);

                LimpaCamposVeiculo();
                CmbMarca.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void lstVeiculo_Click(object sender, EventArgs e)
        {
            try
            {
                ExibeVeiculoSelecionado(lstVeiculo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void CmbMarca_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(CmbMarca.SelectedValue))) return;
            MontaComboModelo(CmbModelo, Convert.ToInt32(CmbMarca.SelectedValue));

        }

        private void lstDadoBancario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void registraVeiculo_Click(object sender, EventArgs e)
        {
            try
            {
                CadastraVeiculo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void alterarVeiculo_Click(object sender, EventArgs e)
        {
            try
            {
                AlteraVeiculo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void excluirVeiculo_Click(object sender, EventArgs e)
        {
            try
            {
                ExcluiVeiculo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }

        private void toolAtualizar_Click(object sender, EventArgs e)
        {
            ExecutaConsulta();
        }

        private void ExecutaConsulta()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int matricula = 0;
                if (txtMatricula.Text != string.Empty) { matricula = Convert.ToInt32(txtMatricula.Text); }
                ListaFigurantes(lstFigurante, TxtConsulta.Text, Convert.ToInt32(tsCmbStatus.Text.Substring(0, 2)), matricula);
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

        private void HabilitaOperacoes(bool estado)
        {
            //Registro geral
            pnlFigurante.Enabled = estado;

            CadastrarFigurante.Enabled = estado;
            AlterarFigurante .Enabled = estado;
            ExcluiFigurante.Enabled = estado;

            //Dado Bancário
            pnlDadoBancario.Enabled = estado;

            novoDadoBancario .Enabled = estado;
            registraDadoBancario .Enabled = estado;
            alterarDadoBancario.Enabled = estado;
            excluirDadoBancario .Enabled = estado;

            //Veículo
            pnlVeiculo.Enabled = estado;

            novoVeiculo.Enabled = estado;
            registraVeiculo.Enabled = estado;
            alterarVeiculo.Enabled = estado;
            excluirVeiculo.Enabled = estado;

        }

        private void mtbNascimento_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidaDataDeNascimento(Convert.ToDateTime(mtbNascimento.Text), Convert.ToDateTime(mtbAdmissao.Text))) return;

        }

        private bool ValidaDataDeNascimento(DateTime dtnascimento, DateTime dtadmissao)
        {
            var valida = Valida.dataNascimento(dtnascimento, dtadmissao);

            if (!String.IsNullOrEmpty(valida))
            {
                MessageBox.Show(valida, "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbNascimento.Focus();
                return false;
            }
            else
            {
                lblIdade.Text = Convert.ToString(Funcoes.CalculaIdade(Convert.ToDateTime(mtbNascimento.Value)));
                txtAcesso.Focus();
                return true;
            }
        }

        private bool ValidaEmail(string email)
        {
            if (!Funcoes.ValidaEmail(email))
            {
                MessageBox.Show("E-mail informado não é valido", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void TxtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtMatricula.Text = string.Empty;
            if (e.KeyChar == 13) { ExecutaConsulta(); }
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            TxtConsulta.Text = string.Empty;
            if (e.KeyChar == 13) { ExecutaConsulta(); }
        }

        private void CmbMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(CmbMarca.SelectedValue))) return;
            MontaComboModelo(CmbModelo, Convert.ToInt32(CmbMarca.SelectedValue));

        }

        private void lstFigurante_ColumnClick(object sender, ColumnClickEventArgs e)
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

            this.lstFigurante.Sort();
        }

        private void cmbEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(cmbEstado.SelectedValue))) return;
            MontaComboCidade(cmbCidade, Convert.ToInt32(cmbEstado.SelectedValue));

            if (!this.cmbCidade.DroppedDown) { this.cmbCidade.DroppedDown = true; }

        }

        private void cmbCidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Convert.ToString(cmbCidade.SelectedValue))) return;
            MontaComboBairro(cmbBairro, Convert.ToInt32(cmbCidade.SelectedValue));

            if (!this.cmbBairro.DroppedDown) { this.cmbBairro.DroppedDown = true; }

        }

        private void lstFigurante_DoubleClick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                ExibeFiguranteSelecionado(lstFigurante);
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
    }
}
