using System.Data.SqlClient;
using Agencia.Dominio.Modelo;
using Data.Base;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaUsuario : IStoredProcedureContext
    {
        public int Status { get; set; }
        public string Descricao { get; set; }

        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_listaUsuario"; }
        }
    }

    public class AcessoDao : BaseDao<Acesso>
    {

        protected override string GetDeleteCommand(Acesso entidade)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetExistsCommand(Acesso entidade)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Registra senha para o usuário
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        protected override string GetInsertCommand(Acesso entidade)
        {
            return string.Format("insert into Login (idpessoa, senha) values ({0},'{1}')",
                                  entidade.IdPessoa, entidade.Senha);

        }

        protected override string GetSelectCommand(string id)
        {
            return "SELECT idpessoa FROM pessoa where acesso = 1 and idpessoa = '" + id + "'";

        }

        protected override string GetSelectCommand()
        {
            throw new System.NotImplementedException();
        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetUpdateCommand(Acesso entidade)
        {
            throw new System.NotImplementedException();
        }

        protected override Acesso Hydrate(System.Data.SqlClient.SqlDataReader reader)
        {
            return new Acesso()
            {
                Senha = reader[0].ToString()
            };
        }
    }
}
