using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeRemuneracoes
    {
        private const int Idformulario = 2;

        RemuneracaoDao _dao;

        public RepositorioDeRemuneracoes()
        {
            _dao = new RemuneracaoDao();
        }

        public DataTable ObterListaDeRemuneracoes(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaRemuneracao());

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
