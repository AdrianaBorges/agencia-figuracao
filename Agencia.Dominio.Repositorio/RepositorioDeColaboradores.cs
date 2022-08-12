using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeColaboradores
    {
        private const int Idformulario = 2;
        private ColaboradorDao _dao;

        public RepositorioDeColaboradores()
        {
            _dao = new ColaboradorDao();
        }

        public DataTable ObterListaDeUsuarios(int idusuario, string dado)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaUsuario() { Descricao = dado });

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        public DataTable ObterListaDeColaboradores(int idusuario, string dado, int status)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaColaborador () { Nome = dado, Status = status });

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        public DataTable ObterListaDeColaboradoresPorProduto(int idusuario, int produto, int pedido)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaColaboradorPorProduto() { Produto = produto, Pedido = pedido });

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        public Colaborador ObterPessoaPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.Get(new P_RecuperaColaboradorPorId() { IdPessoa = id }); 
                
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Insere(Colaborador colaborador)
        {
            try
            {
                if (!ColaboradorExiste(colaborador.Nome, colaborador.IdTipoPessoa))
                {
                    _dao.OpenConnection();

                    _dao.Execute(new P_RegistraColaborador() 
                                     {
                                         Operacao = "INSERT",
                                         IdFirma = colaborador.IdFirma,
                                         IdPessoa = colaborador.IdPessoa,
                                         IdTipoPessoa = colaborador.IdTipoPessoa ,
                                         Nome = colaborador.Nome ,
                                         Sexo = colaborador.Sexo,
                                         DataNascimento = colaborador.Nascimento,
                                         DataCadastro = colaborador.Cadastro,
                                         Status = colaborador.Status,
                                         IdBairro = colaborador.IdBairro,
                                         Logradouro = colaborador.Logradouro,
                                         Complemento = colaborador.Complemento, 
                                         Cep = colaborador.Cep,
                                         Cpf = colaborador.Cpf,
                                         Rg = colaborador.Rg,
                                         Cnpj = colaborador.Cnpj,
                                         Expedicao = colaborador.Expedicao,
                                         Pis = colaborador.Pis,
                                         Ctps = colaborador.Ctps,
                                         Serie = colaborador.Serie,
                                         CarteiraReservista = colaborador.CartReservista,
                                         TelFixo = colaborador.Fixo,
                                         TelCelular = colaborador.Celular,
                                         TelContato = colaborador.Contato,
                                         Email = colaborador.Email,
                                         IdCargo = colaborador.IdCargo,
                                         DataDesligamento = colaborador.Desligamento,
                                         Clt = colaborador.Clt,
                                         Comissao = colaborador.Comissao,
                                         IdUsuario = colaborador.IdUsuario
                                     });

                }
                else
                {
                    throw new Exception(string.Format("Colaborador informado já constã na base de dados."));
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(colaborador.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar o Colaborador solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Altera(Colaborador colaborador)
        {
            try
            {
                if (ColaboradorExiste(colaborador.IdPessoa))
                {
                    _dao.OpenConnection();

                    _dao.Execute(new P_RegistraColaborador() 
                                     {
                                         Operacao = "UPDATE",
                                         IdFirma = colaborador.IdFirma,
                                         IdPessoa = colaborador.IdPessoa,
                                         IdTipoPessoa = colaborador.IdTipoPessoa,
                                         Nome = colaborador.Nome,
                                         Sexo = colaborador.Sexo,
                                         DataNascimento = colaborador.Nascimento,
                                         DataCadastro = colaborador.Cadastro,
                                         Status = colaborador.Status,
                                         IdBairro = colaborador.IdBairro,
                                         Logradouro = colaborador.Logradouro,
                                         Complemento = colaborador.Complemento,
                                         Cep = colaborador.Cep,
                                         Cpf = colaborador.Cpf,
                                         Rg = colaborador.Rg,
                                         Cnpj = colaborador.Cnpj,
                                         Expedicao = colaborador.Expedicao,
                                         Pis = colaborador.Pis,
                                         Ctps = colaborador.Ctps,
                                         Serie = colaborador.Serie,
                                         CarteiraReservista = colaborador.CartReservista,
                                         TelFixo = colaborador.Fixo,
                                         TelCelular = colaborador.Celular,
                                         TelContato = colaborador.Contato,
                                         Email = colaborador.Email,
                                         IdCargo = colaborador.IdCargo,
                                         DataDesligamento = colaborador.Desligamento,
                                         Clt = colaborador.Clt,
                                         Comissao = colaborador.Comissao,
                                         IdUsuario = colaborador.IdUsuario
                                     });
                }
                else
                {
                    throw new Exception(string.Format("Colaborador informado não constã na base de dados."));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(colaborador.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível alterar o Colaborador solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        public void ExclusaoLogica(Colaborador colaborador)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Execute(string.Format("Update Pessoa set status = 0 where idpessoa = {0}", colaborador.IdPessoa));
                
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(colaborador.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível excluir o Colaborador solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        //verificar quais parametros necessários para saber se a pessoa existe
        public bool ColaboradorExiste(string nome, Int32 idtipopessoa)
        {
            _dao.OpenConnection();
            //var result = _dao.ExistsValue(string.Format("select p.idpessoa from pessoa p inner join colaborador c on c.idpessoa where p.nmepessoa = '{0}'", parametro));
            var result = _dao.ExistsValue(string.Format("Select idpessoa from Pessoa Where nmepessoa = '{0}' and idtipopessoa = {1}", nome, idtipopessoa));
            _dao.CloseConnection();

            return result;

        }

        //verificar quais parametros necessários para saber se a pessoa existe
        public bool ColaboradorExiste(int id)
        {
            _dao.OpenConnection();
            var result = _dao.ExistsValue(string.Format("select idpessoa from pessoa where idpessoa = {0}", id));
            _dao.CloseConnection();

            return result;

        }

        static public class Retorna
        {
            static public string IdColaborador(string parametro)
            {
                var _dao = new ColaboradorDao();
                try
                {
                    _dao.OpenConnection();
                    var result = _dao.GetValue("Select REPLICATE('0', 5 - LEN(idpessoa)) + RTrim(idpessoa) as idpessoa From Pessoa where nmepessoa = '" + parametro + "'");
            
                    return result;
                }
                catch (Exception ex)
                {
                    RegistraLogErro.LogAplicacao(32, Idformulario, "Erro : " + ex.Message);
                    throw new Exception("Erro : " + ex.Message);
                }
                finally
                {
                    _dao.CloseConnection();
                }

            }
        }

    }
}
