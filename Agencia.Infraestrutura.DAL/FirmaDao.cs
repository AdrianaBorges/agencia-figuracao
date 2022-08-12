using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class FirmaDao : BaseDao<Firma>
    {
        protected override string GetDeleteCommand(Firma entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Firma entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Firma entidade)
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

        protected override string GetUpdateCommand(Firma entidade)
        {
            throw new NotImplementedException();
        }

        protected override Firma Hydrate(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
