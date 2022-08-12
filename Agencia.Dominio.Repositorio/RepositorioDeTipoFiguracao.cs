using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeTipoFiguracao
    {
        private const int Idformulario = 16;
        TipoFiguracaoDao _dao;

        public RepositorioDeTipoFiguracao()
        {
            _dao = new TipoFiguracaoDao();
        }

        public DataTable ObterListaTipoFiguracao(int idusuario)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_CarregaListaTipoFiguracao() { });
                }

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            

        }


    }

    
}
