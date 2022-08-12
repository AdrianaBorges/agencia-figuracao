using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Dominio.Repositorio
{

    public class PrestadorDeServicoDao : BaseDao<PrestadorDeServico> 
    {
        public PrestadorDeServico ObterPeloSQL()
        {
            return GetBySql("Select idpessoa, nmepessoa From Pessoa Where idtipopessoa = 3 Order by nmepessoa");
        }

        protected override string GetDeleteCommand(PrestadorDeServico entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(PrestadorDeServico entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(PrestadorDeServico entidade)
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

        protected override string GetUpdateCommand(PrestadorDeServico entidade)
        {
            throw new NotImplementedException();
        }

        protected override PrestadorDeServico Hydrate(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
