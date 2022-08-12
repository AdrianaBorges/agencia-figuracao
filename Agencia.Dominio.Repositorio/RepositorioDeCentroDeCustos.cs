using System;
using Agencia.Infraestrutura.DAL;
using System.Data;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeCentroDeCustos
    {
        private const int Idformulario = 3;
        private CentroDeCustoDao _dao;

        public RepositorioDeCentroDeCustos()
        {
            _dao = new CentroDeCustoDao();
        }

        public DataTable ObterListaDeCentroDeCustos(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_CarregaListaCentroDeCusto() { });

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
