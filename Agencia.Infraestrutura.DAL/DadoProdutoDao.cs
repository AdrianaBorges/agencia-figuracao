using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaDadoProduto : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }

        public string NAME
        {
            get { return "p_listaDadoProdutoPorId"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
        }
    }

    public class DadoProdutoDao : BaseDao<DadoProduto>
    {
        protected override string GetDeleteCommand(DadoProduto entidade)
        {
            return string.Format("Delete From DadoPrograma Where id = {0}", entidade.IdDadoProduto);

        }

        protected override string GetExistsCommand(DadoProduto entidade)
        {
            return string.Format("select id from dadoprograma where id = {0} and idprograma = {1} and idpessoa = {2}", 
                entidade.IdDadoProduto, entidade.IdPrograma, entidade.IdPessoa);
        }

        protected override string GetInsertCommand(DadoProduto entidade)
        {
            return string.Format("insert into DadoPrograma (idprograma, idpessoa, dtregistro) values ({0}, {1}, '{2}')",
                                 entidade.IdPrograma, entidade.IdPessoa, entidade.DataRegistro.ToString("MM/dd/yyyy HH:mm:ss"));
        }

        public DadoProduto ObterPeloId(int id)
        {
            return GetBySql("select dp.id, p.descricao, dp.idprograma From DadoPrograma dp Inner Join Programa p on p.idprograma = dp.idprograma Where dp.id = " + id + "");
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

        protected override string GetUpdateCommand(DadoProduto entidade)
        {
            throw new NotImplementedException();
        }

        protected override DadoProduto Hydrate(SqlDataReader reader)
        {
            return new DadoProduto()
            {
                IdDadoProduto = Convert.ToInt32(reader[0].ToString()),
                Descricao = reader[1].ToString(),
                IdPrograma = Convert.ToInt32(reader[2].ToString())

            };
        }
    }
}
