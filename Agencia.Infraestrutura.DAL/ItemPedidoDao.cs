using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_RetornaValorPedido : IStoredProcedureContext
    {
        public int IdPedido { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpedido", IdPedido);
        }

        public string NAME
        {
            get { return "p_CalculaValorPedido"; }
        }
    }

    public class P_ListaItemPedido : IStoredProcedureContext
    {
        public int IdPedido { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpedido", IdPedido);
        }

        public string NAME
        {
            get { return "p_listaItemPedido"; }
        }
    }

    public class P_ListaTipoFiguracao : IStoredProcedureContext
    {
        public int IdPedido { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpedido", IdPedido);
        }

        public string NAME
        {
            get { return "p_listaTipoFiguracao"; }
        }
    }


    public class P_RecuperaItemPedidoPorId : IStoredProcedureContext
    {
        public int IdItem { get; set; }

        public string NAME
        {
            get { return "p_RecuperaItemPedidoPorId"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@IdItem", IdItem);
        }
    }

    public class ItemPedidoDao : BaseDao<ItemPedido>
    {
        protected override string GetDeleteCommand(ItemPedido entidade)
        {
            return string.Format("Delete From pedqtdfigurante Where id = {0}", entidade.IdItem);
        }

        protected override string GetExistsCommand(ItemPedido entidade)
        {
            return string.Format("select id from pedqtdfigurante where idpedido = {0} and idtipo = {1}", entidade.IdPedido, entidade.IdTipo);
        }

        protected override string GetInsertCommand(ItemPedido entidade)
        {
            return string.Format("insert into pedqtdfigurante (idpedido, idtipo, qtd, valor) values ({0}, {1}, {2}, '{3}')",
                     entidade.IdPedido, entidade.IdTipo, entidade.Qtd, entidade.Valor);
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

        public ItemPedido ObterPeloId(int id)
        {
            return GetBySql("select id, case ip.idtipo when 1 then '01- FIGURAÇÃO COMUM' " 
			              + "when 2 then '02- FIGURAÇÃO ESPECIAL' " 
			              + "when 3 then '03- VEÍCULO CENA' "
			              + "when 4 then '04- MENOR TIPO 1 (0 A 15) ANOS' end as tipo, "
		                  + "replicate('0',3 - len(ip.qtd)) + rtrim(ip.qtd) as qtd, "
		                  + "cast(ip.valor as decimal(18,2)) as vlrcache, ip.idpedido "
                          + "from pedqtdfigurante ip where ip.id = " + id + "");
        }

        protected override string GetUpdateCommand(ItemPedido entidade)
        {
            return string.Format("Update pedqtdfigurante set valor = '{0}', qtd = {1}, idtipo = {2} Where (id = {3})",
                                  entidade.Valor, entidade.Qtd, entidade.IdTipo, entidade.IdItem);
        }

        protected override ItemPedido Hydrate(SqlDataReader reader)
        {
            return new ItemPedido()
            {
                IdItem = Convert.ToInt32(reader[0].ToString()),
                DescTipo = reader[1].ToString(),
                Qtd = Convert.ToInt32(reader[2].ToString()),
                Valor = reader[3].ToString(),
                IdPedido = Convert.ToInt32(reader[4].ToString())

            };
        }
    }
}
