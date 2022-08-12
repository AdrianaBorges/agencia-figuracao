using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeBancos
    {
        private const int Idformulario = 2;
        BancoDao _dao;

        public RepositorioDeBancos()
        {
            _dao = new BancoDao();
        }

        public DataTable ObterListaDeBancos(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaTodosBancos());

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
