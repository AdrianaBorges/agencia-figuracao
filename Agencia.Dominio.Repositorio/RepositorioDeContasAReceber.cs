using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeContasAReceber
    {
        private const int Idformulario = 2;
        NotaFiscalDao _dao;

        public RepositorioDeContasAReceber()
        {
            _dao = new NotaFiscalDao();
        }

        public DataTable ObterListaDeContasAReceber(int idusuario, int idfirma, int status, DateTime de, DateTime ate, int numnota)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaNotasAReceber() { IdFirma = idfirma, Status = status, De = de, Ate = ate, NumNota = numnota });

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
