using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_CarregaListaTipoFiguracao : IStoredProcedureContext
    {
        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_carregaTipoFiguracao"; }
        }
    }


    public class TipoFiguracaoDao : BaseDao<TipoFiguracao>
    {
        protected override string GetDeleteCommand(TipoFiguracao entidade)
        {
            return string.Format("Delete From tipofiguracao Where idtipo = {0}", entidade.IdTipo);
        }

        protected override string GetExistsCommand(TipoFiguracao entidade)
        {
            return string.Format("select idtipo from tipofiguracao where idtipo = {0}", entidade.IdTipo);
        }

        protected override string GetInsertCommand(TipoFiguracao entidade)
        {
            return string.Format("insert into tipofiguracao (idtipo) values ('{0}')",
                                  entidade.IdTipo);
        }

        protected override string GetSelectCommand(string id)
        {
            return "SELECT idtipo, descricao FROM programtipofiguracaoa Where idtipo = '" + id + "'";
        }

        protected override string GetSelectCommand()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new NotImplementedException();
        }

        protected override string GetUpdateCommand(TipoFiguracao entidade)
        {
            throw new NotImplementedException();
        }

        protected override TipoFiguracao Hydrate(SqlDataReader reader)
        {
            return new TipoFiguracao()
            {
                IdTipo = Convert.ToInt32(reader[0].ToString()),
                Descricao = reader[1].ToString()
            };
        }
    }
}
