using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeContasAPagar
    {
        private const int Idformulario = 2;
        ContasAPagarDao _dao;

        public RepositorioDeContasAPagar()
        {
            _dao = new ContasAPagarDao();
        }

        public DataTable ObterListaDeContasAPagar(int idusuario, int idfirma, DateTime de, DateTime ate, int idcusto)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaContasAPagar() { IdFirma = idfirma, De = de, Ate = ate, IdCusto = idcusto });

                return result;
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public DataTable ObterListaDeContasPagas(int idusuario, int idfirma, DateTime de, DateTime ate, int idcusto)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaContasPagas() { IdFirma = idfirma, De = de, Ate = ate, IdCusto = idcusto });

                return result;
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public ContasAPagar ObterContaAPagarPorId(int idusuario, int idtipo, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.Get(new P_RecuperaContaAPagar() { IdTipo = idtipo, IdContaAPagar = id });

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);

            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        public void Insere(ContasAPagar conta)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Insert(conta);
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(conta.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar a Conta à Pagar. " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Altera(ContasAPagar conta)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Update(conta);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(conta.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível alterar a Conta à Pagar." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Exclui(ContasAPagar conta)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Delete(conta);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(conta.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível excluir a Conta à Pagar informada." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        static public class Retorna
        {
            static public string IdContaAPagar(int idcusto, int idpessoa, DateTime vencimento, string descricao)
            {
                var _dao = new PedidoDao();
                try
                {
                    _dao.OpenConnection();
                    return _dao.GetValue("Select REPLICATE('0', 5 - LEN(idcontaapagar)) + RTrim(idcontaapagar) as idcontaapagar From ContasAPagar where idcusto = " + idcusto + " and idpessoa = " + idpessoa + " and vencimento = '" + vencimento.ToString("MM/dd/yyyy HH:mm:ss") + "' and descricao = '" + descricao + "'");
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
