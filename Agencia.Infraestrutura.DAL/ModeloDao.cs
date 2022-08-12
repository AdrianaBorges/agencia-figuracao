using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaModeloPorMarca : IStoredProcedureContext
    {
        public int IdMarca { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idmarca", IdMarca);
        }

        public string NAME
        {
            get { return "p_listaModeloPorId"; }
        }
    }

    public class P_ListaModelo : IStoredProcedureContext
    {
        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_listaModelo"; }
        }
    }

    public class ModeloDao : BaseDao<Modelo>
    {

        protected override string GetDeleteCommand(Modelo entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Modelo entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Modelo entidade)
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

        protected override string GetUpdateCommand(Modelo entidade)
        {
            throw new NotImplementedException();
        }

        protected override Modelo Hydrate(SqlDataReader reader)
        {
            return new Modelo()
            {
                IdModelo = Convert.ToInt32(reader[0].ToString()),
                DescModelo = reader[1].ToString(),
            };
        }
    }
}
