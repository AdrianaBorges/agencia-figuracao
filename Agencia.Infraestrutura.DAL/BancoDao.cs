using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaTodosBancos : IStoredProcedureContext
    {
        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_listaBanco"; }
        }
    }

    public class BancoDao : BaseDao<Banco>
    {
        protected override string GetDeleteCommand(Banco entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Banco entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Banco entidade)
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

        protected override string GetUpdateCommand(Banco entidade)
        {
            throw new NotImplementedException();
        }

        protected override Banco Hydrate(SqlDataReader reader)
        {
            return new Banco()
            {
                IdBanco = Convert.ToInt32(reader[0].ToString()),
                NmeBanco = reader[1].ToString()
            };
        }
    }
}
