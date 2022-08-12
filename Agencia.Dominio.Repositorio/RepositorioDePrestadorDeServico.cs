using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDePrestadorDeServico
    {
        private const int Idformulario = 2;
        private PrestadorDeServicoDao _dao;

        public RepositorioDePrestadorDeServico()
        {
            _dao = new PrestadorDeServicoDao();
        }

        public DataTable ObterListaDePrestadorDeServico(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                return
                    _dao.GetDataTable("Select idpessoa, nmepessoa From Pessoa Where idtipopessoa in (3) Order by nmepessoa");

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

        public DataTable ObterListaDePrestadorDeServicoEFigurante(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                return
                    _dao.GetDataTable("Select idpessoa, nmepessoa From Pessoa Where idtipopessoa in (2,3) Order by nmepessoa");

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
    }
}
