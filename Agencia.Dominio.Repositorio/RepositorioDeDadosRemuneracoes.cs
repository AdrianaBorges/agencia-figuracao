using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using System.Collections.Generic;
using Data.Base;
namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeDadosRemuneracoes
    {
        private const int Idformulario = 2;
        private DadoRemuneracaoDao _dao;

        public RepositorioDeDadosRemuneracoes()
        {
            _dao = new DadoRemuneracaoDao();
        }

        public DataTable ObterListaDeDadoRemuneracao(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaDadoRemuneracao() { IdPessoa = id });

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

        public DadoRemuneracao ObterDadoRemuneracaoPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.Get(new P_ListaDadoRemuneracaoPorId() { IdDadoRemuneracao = id });

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

        public void Insere(DadoRemuneracao dado)
        {
            try
            {
                if (!DadoRemuneracaoExiste(dado))
                {
                    _dao.OpenConnection();
                    _dao.Insert(dado);
                }
                else
                {
                    throw new Exception(string.Format("Dado Remuneracao informado já constã para Colaborador."));
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

        public void Altera(DadoRemuneracao dado)
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

        public void Exclui(DadoRemuneracao dado)
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

        public bool DadoRemuneracaoExiste(DadoRemuneracao dado)
        {
            try
            {
                _dao.OpenConnection();
                var result =
                    _dao.ExistsValue(
                        string.Format(
                            "select id from dadoremuneracao where idpessoa = {0} and idremuneracao = {1}",
                            dado.IdPessoa, dado.IdRemuneracao));

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
            public static string IdDadoRemuneracao(DadoRemuneracao dado)
            {
                var _dao = new DadoRemuneracaoDao();
                try
                {
                    _dao.OpenConnection();
                    var result =
                        _dao.GetValue(
                            "Select REPLICATE('0', 5 - LEN(id)) + RTrim(id) as id From DadoRemuneracao where idpessoa = " +
                            dado.IdPessoa + " and idremuneracao = " + dado.IdRemuneracao + "'");

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
