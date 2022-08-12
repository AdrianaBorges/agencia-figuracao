using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using System.Collections.Generic;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeDadosBancarios
    {
        private const int Idformulario = 2;
        private DadoBancarioDao _dao;

        public RepositorioDeDadosBancarios()
        {
            _dao = new DadoBancarioDao();
        }

        public DataTable ObterListaDeDadoBancario(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaDadoBancario() { IdPessoa = id });

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

        public DadoBancario ObterDadoBancarioPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.Get(new P_ListaDadoBancarioPorId() { IdDadoBancario = id });

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

        public DadoBancario ObterDadoBancario(int idusuario, int idpessoa)
        {
            try
            {
                _dao.OpenConnection();

                var result = _dao.ExistsValue("Select coalesce(id,0) From DadoBancario where idpessoa = " + idpessoa + " and status = 1");
                if (result)
                {
                    var id = _dao.GetValue("Select coalesce(id,0) From DadoBancario where idpessoa = " + idpessoa + " and status = 1");
                    if (Convert.ToInt32(id) != 0)
                    {
                        return _dao.Get(new P_ListaDadoBancarioPorId() { IdDadoBancario = Convert.ToInt32(id) });
                    }
                }
                return null; 

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

        /// <summary>
        /// Insere DadoBancario quando o mesmo não existir para o colaborador
        /// </summary>
        /// <param name="dado"></param>
        public void Insere(DadoBancario dado)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Insert(dado);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(dado.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        public void Altera(DadoBancario dado)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Update(dado);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(dado.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Exclui(DadoBancario dado)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Delete(dado);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(dado.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public static class Retorna
        {
            public static string IdDadoBancario(DadoBancario dado)
            {
                var _dao = new DadoBancarioDao();
                try
                {
                    _dao.OpenConnection();
                    var result =
                        _dao.GetValue(
                            "Select REPLICATE('0', 5 - LEN(id)) + RTrim(id) as iddadobancario From DadoBancario where idpessoa = " +
                            dado.IdPessoa + " and idbanco = " + dado.IdBanco + " and tipo = '" + dado.Tipo +
                            "' and agencia = '" + dado.Agencia + "' and numconta = '" + dado.NumeroConta + "'");

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

            public static bool IdDadoBancario(int idpessoa)
            {
                var _dao = new DadoBancarioDao();
                try
                {
                    _dao.OpenConnection();
                    var result = _dao.ExistsValue("Select coalesce(id,0) From DadoBancario where idpessoa = " + idpessoa + " and status = 1");

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
