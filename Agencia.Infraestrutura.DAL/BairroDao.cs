using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaTodosBairros : IStoredProcedureContext
    {
        public string Id { get; set; }

        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_listaBairro"; }
        }
    }

    public class P_ListaBairrosPorCidade : IStoredProcedureContext
    {
        public int IdCidade { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idcidade", IdCidade);
        }

        public string NAME
        {
            get { return "p_listaBairroPorCidade"; }
        }
    }

    public class BairroDao : BaseDao<Bairro>
    {
        
        protected override string GetDeleteCommand(Bairro entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Bairro entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Bairro entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommand(string id)
        {
            return "SELECT Select b.idbairro, c.idcidade, e.idestado, b.nmebairro From Bairro b Inner Join Cidade c on c.idcidade = b.idcidade Inner Join Estado e on e.idestado = c.idestado Where b.idbairro = '" + id + "'";
        }

        public Bairro ObterPeloSQL(string parametro)
        {
            return GetBySql("Select b.idbairro, c.idcidade, e.idestado, b.nmebairro From Bairro b Inner Join Cidade c on c.idcidade = b.idcidade Inner Join Estado e on e.idestado = c.idestado Where b.nmebairro = '" + parametro + "'");
        }

        protected override string GetSelectCommand()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new NotImplementedException();
        }

        protected override string GetUpdateCommand(Bairro entidade)
        {
            throw new NotImplementedException();
        }

        protected override Bairro Hydrate(SqlDataReader reader)
        {
            return new Bairro()
            {
                IdBairro = Convert.ToInt32(reader[0].ToString()),
                IdCidade = Convert.ToInt32(reader[1].ToString()),
                IdEstado = Convert.ToInt32(reader[2].ToString()),
                NmeBairro = reader[3].ToString()
            };
        }
       
    }
}
