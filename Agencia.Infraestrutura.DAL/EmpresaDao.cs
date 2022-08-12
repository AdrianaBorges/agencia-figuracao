using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaTodasEmpresas : IStoredProcedureContext
    {
        public string Id { get; set; }

        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_listaEmpresa"; }
        }
    }

    public class EmpresaDao : BaseDao<Empresa>
    {
        protected override string GetDeleteCommand(Empresa entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Empresa entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Empresa entidade)
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

        protected override string GetUpdateCommand(Empresa entidade)
        {
            throw new NotImplementedException();
        }

        protected override Empresa Hydrate(SqlDataReader reader)
        {
            return new Empresa()
            {
                IdEmpresa = Convert.ToInt32(reader[0].ToString()),
                Descricao = reader[1].ToString()
            };
        }
    }
}
