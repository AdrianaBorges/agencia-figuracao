using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_Lista_Produto : IStoredProcedureContext
    {
        public string Descricao { get; set; }

        public string NAME
        {
            get { return "p_listaProduto"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@dado", Descricao);
        }
    }

    public class P_Carrega_Grid_Produto : IStoredProcedureContext
    {
        public string Descricao { get; set; }

        public string NAME
        {
            //get { return "p_CarregaComboProduto"; }
            //get { return "p_CarregaGridProduto"; }


            get { return "p_ListaPrograma"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@dado", Descricao);
        }
    }

    public class P_Carrega_Combo_Produto : IStoredProcedureContext
    {
        public string NAME
        {
            get { return "p_CarregaComboProduto"; }
        }

        public void AddParameters(SqlCommand command)
        {
            return;
        }
    }

    public class P_Carrega_Combo_Produto_ComAlvara : IStoredProcedureContext
    {
        public string NAME
        {
            get { return "p_CarregaComboProdutoComAlvara"; }
        }

        public void AddParameters(SqlCommand command)
        {
            return;
        }
    }


    public class P_Lista_Pedido_Por_Produto : IStoredProcedureContext
    {
        public int Id { get; set; }

        public string NAME
        {
            get { return "p_ListaPedidoPorProduto"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idprograma", Id);
        }
    }

    public class ProdutoDao : BaseDao<Produto> 
    {
        protected override string GetDeleteCommand(Produto entidade)
        {
            return string.Format("Delete From programa Where descricao = '{0}'", entidade.Descricao);
        }

        protected override string GetExistsCommand(Produto entidade)
        {
            return string.Format("Select idprograma, data, descricao, status observacao From programa Where idprograma = {0}", entidade.IdPrograma);
        }

        protected override string GetInsertCommand(Produto entidade)
        {
            return string.Format("insert into Programa (data, descricao, observacao, status) values ('{0}', '{1}', '{2}', '{3}')",
                                  entidade.Data.ToString("MM/dd/yyyy HH:mm:ss"), entidade.Descricao, entidade.Observacao, entidade.Status);

            //return string.Format("insert into Programa (data, descricao, observacao, status) values ('{0}', '{1}', '{2}', '{3}')",
            //          entidade.Data, entidade.Descricao, entidade.Observacao, entidade.Status);
        }

        protected override string GetSelectCommand(string id)
        {
            return "SELECT idprograma, descricao, observacao, status FROM programa Where idprograma = '" + id + "'";
        }

        public Produto ObterPelaDescricao(string parametro)
        {
            return GetBySql("SELECT idprograma, data, descricao, observacao, status FROM programa Where descricao = '" + parametro + "'");
        }

        public Produto ObterPeloId(int id)
        {
            return GetBySql("SELECT idprograma, descricao, observacao, case status when 1 then '01- ATIVO' when 0 then '00- INATIVO' end as status, data FROM programa Where idprograma = " + id + "");
        }

        protected override string GetSelectCommand()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new NotImplementedException();
        }

        protected override string GetUpdateCommand(Produto entidade)
        {
            return string.Format("update programa set descricao = '{0}', status = '{2}', observacao = '{3}' WHERE (idprograma = {1})", entidade.Descricao, entidade.IdPrograma, Convert.ToInt32(entidade.Status), entidade.Observacao);
        }

        protected override Produto Hydrate(SqlDataReader reader)
        {
            return new Produto()
            {
                IdPrograma = Convert.ToInt32(reader[0].ToString()),
                Descricao = reader[1].ToString(),
                Observacao = reader[2].ToString(),
                Status = reader[3].ToString(),
                Data = Convert.ToDateTime(reader[4].ToString())

            };
        }
    }
}
