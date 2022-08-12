using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaRemuneracao : IStoredProcedureContext
    {
        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_listaRemuneracao"; }
        }
    }
    
    public class RemuneracaoDao : BaseDao<Remuneracao>
    {
        protected override string GetDeleteCommand(Remuneracao entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Remuneracao entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Remuneracao entidade)
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

        protected override string GetUpdateCommand(Remuneracao entidade)
        {
            throw new NotImplementedException();
        }

        protected override Remuneracao Hydrate(SqlDataReader reader)
        {
            return new Remuneracao()
            {
                IdRemuneracao = Convert.ToInt32(reader[0].ToString()),
                NmeRemuneracao = reader[1].ToString(),
                IdRemuneracaoExtra = Convert.ToInt32(reader[2].ToString())

            };
        }
    }
}
