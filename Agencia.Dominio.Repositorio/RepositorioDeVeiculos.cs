using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using System.Collections.Generic;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeVeiculos
    {
        private const int Idformulario = 4;
        private VeiculoDao _dao;

        public RepositorioDeVeiculos()
        {
            _dao = new VeiculoDao();
        }

        public Veiculo ObterVeiculoPorId(int idusuario, int idveiculo)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.Get(new P_RecuperaVeiculoPorId() { IdVeiculo = idveiculo });

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

        public DataTable ObterListaDeVeiculosPorId(int idusuario, int idpessoa)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaVeiculoPorId() { IdPessoa = idpessoa });

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

        public void Insere(Veiculo dado)
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

        public void Altera(Veiculo dado)
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

        public void Exclui(Veiculo dado)
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
            public static string IdVeiculo(Veiculo dado)
            {
                try
                {
                    using (var db = new DB(true))
                    {

                        return db.GetValue(
                            "Select REPLICATE('0', 5 - LEN(idveiculo)) + RTrim(idveiculo) as id From Veiculo where idpessoa = " +
                            dado.IdPessoa + " and idmarca = " + dado.IdMarca + " and idmodelo = " + dado.IdModelo + " and ano = '" + dado.Ano + "'");
                    }
                }
                catch (Exception ex)
                {
                    RegistraLogErro.LogAplicacao(32, Idformulario, "Erro : " + ex.Message);
                    throw new Exception("Erro : " + ex.Message);
                }
            }
        }

    }
}
