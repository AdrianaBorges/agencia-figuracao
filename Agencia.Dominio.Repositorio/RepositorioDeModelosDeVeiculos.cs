using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using System.Collections.Generic;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeModelosDeVeiculos
    {
        private const int Idformulario = 4;
        private ModeloDao _dao;

        public RepositorioDeModelosDeVeiculos()
        {
            _dao = new ModeloDao();
        }

        public DataTable ObterListaDeModelos(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaModelo() { });

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

        public DataTable ObterListaDeModelosPorMarca(int idusuario, int idmarca)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaModeloPorMarca() { IdMarca = idmarca });

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

    }
}
