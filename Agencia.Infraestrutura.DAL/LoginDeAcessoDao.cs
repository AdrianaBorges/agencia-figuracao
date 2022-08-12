using Agencia.Dominio.Modelo;
using Data.Base;

namespace Agencia.Infraestrutura.DAL
{
    public class LoginDeAcessoDao : BaseDao<Pessoa>
    {
        protected override string GetDeleteCommand(Pessoa entidade)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetExistsCommand(Pessoa entidade)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetInsertCommand(Pessoa entidade)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetSelectCommand(string id)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetSelectCommand()
        {
            throw new System.NotImplementedException();
        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetUpdateCommand(Pessoa entidade)
        {
            throw new System.NotImplementedException();
        }

        protected override Pessoa Hydrate(System.Data.SqlClient.SqlDataReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}
