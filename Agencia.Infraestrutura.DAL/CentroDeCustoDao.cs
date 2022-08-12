using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_CarregaListaCentroDeCusto : IStoredProcedureContext
    {
        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_CarregaListaCentroDeCusto"; }
        }
    }

    public class CentroDeCustoDao : BaseDao<CentroDeCusto>
    {

        protected override string GetDeleteCommand(CentroDeCusto entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(CentroDeCusto entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(CentroDeCusto entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommand(string id)
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommand()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new NotImplementedException();
        }

        protected override string GetUpdateCommand(CentroDeCusto entidade)
        {
            throw new NotImplementedException();
        }

        protected override CentroDeCusto Hydrate(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
