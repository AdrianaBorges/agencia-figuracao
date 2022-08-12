using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaCidadesPorEstado : IStoredProcedureContext
    {
        public int IdEstado { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idestado", IdEstado);
        }

        public string NAME
        {
            get { return "p_listaCidadesPorEstado"; }
        }
    }

    public class P_ListaCidades : IStoredProcedureContext
    {

        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_listaCidades"; }
        }
    }

    public class CidadeDao : BaseDao<Cidade> 
    {

        protected override string GetDeleteCommand(Cidade entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Cidade entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Cidade entidade)
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

        protected override string GetUpdateCommand(Cidade entidade)
        {
            throw new NotImplementedException();
        }

        protected override Cidade Hydrate(SqlDataReader reader)
        {
            return new Cidade()
            {
                IdCidade = Convert.ToInt32(reader[0].ToString()),
                NmeCidade = reader[1].ToString()

            };
        }
    }
}
