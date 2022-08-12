using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using System.Collections.Generic;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeDadosProdutos
    {
        private const int Idformulario = 2;
        private DadoProdutoDao _dao;

        public RepositorioDeDadosProdutos()
        {
            _dao = new DadoProdutoDao();
        }

        public DataTable ObterListaDeDadoProduto(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaDadoProduto() { IdPessoa = id });

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

        public DadoProduto ObterDadoProdutoPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.ObterPeloId(id);

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


        public void Insere(DadoProduto dado)
        {
            try
            {
                if (!DadoProdutoExiste(dado))
                {
                    _dao.OpenConnection();
                    _dao.Insert(dado);
                }
                else
                {
                    throw new Exception(string.Format("Dado Produto informado já constã para Colaborador."));
                }
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

        public void Altera(DadoProduto dado)
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

        public void Exclui(DadoProduto dado)
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

      
        public bool DadoProdutoExiste(DadoProduto dado)
        {

            try
            {
                _dao.OpenConnection();
                var result =
                    _dao.ExistsValue(
                        string.Format(
                            "select id from dadoprograma where idpessoa = {0} and idprograma = {1}",
                            dado.IdPessoa, dado.IdPrograma));

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

        public static class Retorna
        {
            public static string IdDadoProduto(DadoProduto dado)
            {
                var _dao = new DadoProdutoDao();
                try
                {
                    _dao.OpenConnection();
                    var result =
                        _dao.GetValue(
                                    "Select Max(id) as id From DadoPrograma where idpessoa = " +
                                    dado.IdPessoa + " and idprograma = " + dado.IdPrograma);

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
