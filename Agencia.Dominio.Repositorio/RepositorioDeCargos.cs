using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeCargos
    {
        private const int Idformulario = 2;
        private CargoDao _dao;

        public RepositorioDeCargos()
        {
            _dao = new CargoDao();
        }

        public DataTable ObterListaDeCargo(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_Lista_Cargos());

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
