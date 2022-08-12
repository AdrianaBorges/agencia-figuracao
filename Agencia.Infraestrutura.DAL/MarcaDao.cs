using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaMarcaVeiculo : IStoredProcedureContext
    {
        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_listaMarca"; }
        }
    }

    public class MarcaDao : BaseDao<Marca>
    {
        protected override string GetDeleteCommand(Marca entidade)
        {
            return string.Format("Delete From Marca Where idmarca = {0}", entidade.IdMarca);
        }

        protected override string GetExistsCommand(Marca entidade)
        {
            return string.Format("Select idmarca, descricao Marca Where idmarca = {0}", entidade.IdMarca);
        }

        protected override string GetInsertCommand(Marca entidade)
        {
            return string.Format("insert into Marca (descricao) values ('{0}')", entidade.DescMarca);
        }

        protected override string GetSelectCommand(string id)
        {
            return "SELECT idmarca, descricao FROM Marca idmarca = " + id + "";
        }

        protected override string GetSelectCommand()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new NotImplementedException();
        }

        protected override string GetUpdateCommand(Marca entidade)
        {
            return string.Format("update marca set descricao = '{0}' WHERE (idmarca = {1})", entidade.DescMarca, entidade.IdMarca);
        }

        protected override Marca Hydrate(SqlDataReader reader)
        {
            return new Marca()
            {
                IdMarca = Convert.ToInt32(reader[0].ToString()),
                DescMarca = reader[1].ToString(),
            };
        }
    }
}
