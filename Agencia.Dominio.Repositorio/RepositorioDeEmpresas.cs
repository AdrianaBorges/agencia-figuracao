using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{

    public class RepositorioDeEmpresas
    {
        private const int Idformulario = 2;
        EmpresaDao _dao;

        public RepositorioDeEmpresas()
        {
            _dao = new EmpresaDao();
        }

        public DataTable ObterListaDeEmpresas(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaTodasEmpresas());

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
