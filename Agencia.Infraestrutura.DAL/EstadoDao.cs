using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaTodosEstados : IStoredProcedureContext
    {
        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_listaEstados"; }
        }
    }

    public class EstadoDao : BaseDao<Estado>
    {

        protected override string GetDeleteCommand(Estado entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Estado entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Estado entidade)
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

        protected override string GetUpdateCommand(Estado entidade)
        {
            throw new NotImplementedException();
        }

        protected override Estado Hydrate(SqlDataReader reader)
        {
            return new Estado()
            {
                IdEstado = Convert.ToInt32(reader[0].ToString()),
                NmeEstado = reader[1].ToString(),
                Uf = reader[2].ToString()

            };
        }
    }
}
