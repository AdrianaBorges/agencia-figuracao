using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_GeracaoManualRecibo : IStoredProcedureContext
    {
        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_geracaoManualRecibo"; }
        }
    }

    public class P_RetornaValorInss : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }
        public DateTime DataGravacao { get; set; }
        public int IdTipo { get; set; }
        public string ValorCache { get; set; }

        public string NAME
        {
            get { return "p_RetornaValorInss"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
            command.Parameters.Add("@gravacao", DataGravacao);
            command.Parameters.Add("@idtipo", IdTipo);
            command.Parameters.Add("@vlrcache", ValorCache);
        }
    }

    public class P_RecuperaPedidoFigurante : IStoredProcedureContext
    {
        public int IdFigPedido { get; set; }

        public string NAME
        {
            get { return "p_RecuperaFigurantePedido"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@id", IdFigPedido);
        }
    }

    public class P_RegistraBaixaCache : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }
        public int IdFigPedido { get; set; }
        public DateTime DataBaixa { get; set; }
        public decimal Recibo { get; set; }

        public string NAME
        {
            get { return "p_BaixaCache"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
            command.Parameters.Add("@idpedidofig", IdFigPedido);
            command.Parameters.Add("@databaixa", DataBaixa);
            command.Parameters.Add("@recibo", Recibo);
        }
    }

    public class P_RegistraBaixaCachePorRecibo : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }
        public DateTime DataBaixa { get; set; }
        public decimal Recibo { get; set; }

        public string NAME
        {
            get { return "p_baixaCachePorRecibo"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
            command.Parameters.Add("@nrrb", Recibo);
            command.Parameters.Add("@databaixa", DataBaixa);

        }
    }
    public class P_ListaPedidoFigurante : IStoredProcedureContext
    {
        public int IdPedido { get; set; }

        public string NAME
        {
            get { return "p_listaFiguracaoPedido"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpedido", IdPedido);
        }
    }

    public class P_RecuperaDadosRecibo : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }
        public string Nrrb { get; set; }

        public string NAME
        {
            get { return "p_recuperaDadosRecibo"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
            command.Parameters.Add("@nrrb", Nrrb);
        }
    }

    public class P_ListaReciboProvisorio : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }

        public string NAME
        {
            get { return "p_listaReciboProvisorio"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
        }
    }

    public class P_ListaPesquisaFigurante : IStoredProcedureContext
    {
        public int IdFirma { get; set; }
        public string Nome { get; set; }
        public string IdPessoa { get; set; }

        public string NAME
        {
            get { return "p_listaPesquisaFigurante"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@nome", Nome);
            command.Parameters.Add("@idpessoa", IdPessoa);

        }
    }

    public class P_ListaPesquisaFigurantePendente : IStoredProcedureContext
    {
        public int IdFirma { get; set; }
        public string Nome { get; set; }
        public string IdPessoa { get; set; }

        public string NAME
        {
            get { return "p_listaPesquisaFigurantePendente"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@nome", Nome);
            command.Parameters.Add("@idpessoa", IdPessoa);

        }
    }

    public class p_listaFigurantePorNota : IStoredProcedureContext
    {
        public int IdFirma { get; set; }
        public int IdStatus { get; set; }

        public string NAME
        {
            get { return "p_listaFigurantePorNota"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@idstatus", IdStatus);

        }
    }
    public class P_ListaPosicaoCache: IStoredProcedureContext
    {
        public int IdFirma { get; set; }
        public string Nome { get; set; }
        public string IdPessoa { get; set; }

        public string NAME
        {
            get { return "p_listaPosicaoCache"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@nome", Nome);
            command.Parameters.Add("@idpessoa", IdPessoa);

        }
    }

    public class P_ListaReciboFigurante : IStoredProcedureContext
    {
        public int IdNota { get; set; }
        public int IdPessoa { get; set; }
        public string Nome { get; set; }

        public string NAME
        {
            get { return "p_listaReciboFigurante"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idnota", IdNota);
            command.Parameters.Add("@idpessoa", IdPessoa);
            command.Parameters.Add("@nome", Nome);

        }
    }

    public class P_ListaReciboDeFigurantePorFirma : IStoredProcedureContext
    {
        public int IdFirma { get; set; }
        public int IdPessoa { get; set; }
        public string Nome { get; set; }

        public string NAME
        {
            get { return "p_listaReciboFigurantePorFirma"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@idpessoa", IdPessoa);
            command.Parameters.Add("@nome", Nome);

        }
    }

    public class P_ListaFigurantePorFirma : IStoredProcedureContext
    {
        public int IdFirma { get; set; }
        public string Nome { get; set; }
        public int IdPessoa { get; set; }

        public string NAME
        {
            get { return "p_listaFigurantePorFirma"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@nome", Nome);
            command.Parameters.Add("@idpessoa", IdPessoa);

        }
    }
    public class P_ListaReciboInformeINSS : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public Nullable<DateTime> De { get; set; }
        public Nullable<DateTime> Ate { get; set; }
        public int IdFirma { get; set; }


        public string NAME
        {
            get { return "p_listaInformeINSS"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
            command.Parameters.Add("@nome", Nome);
            command.Parameters.Add("@de", De);
            command.Parameters.Add("@ate", Ate);
            command.Parameters.Add("@idfirma", IdFirma);

        }
    }

    public class P_ListaFigurantePorNota : IStoredProcedureContext
    {
        public int IdNota { get; set; }
        public string Nome { get; set; }

        public string NAME
        {
            get { return "p_listaConsultaFigurantePorNota"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idnota", IdNota);
            command.Parameters.Add("@nome", Nome);
        }
    }

    public class P_ListaRecibosCache : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }

        public string NAME
        {
            get { return "p_listaReciboCache"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
        }
    }

    public class P_ListaCachePendente : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }
       
        public string NAME
        {
            get { return "p_listaCachePendPgto"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);

        }
    }

    public class P_ListaCachePendenteSemRecibo : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }
        public int IdFirma { get; set; }

        public string NAME
        {
            get { return "p_listaCachePendenteSemRecibo"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
            command.Parameters.Add("@idfirma", IdFirma);

        }
    }

    public class P_ListaCachePago : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }
        public decimal Recibo { get; set; }

        public string NAME
        {
            get { return "p_listaCachePgto"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
            command.Parameters.Add("@recibo", Recibo);

        }
    }

    public class P_ListaValorTotalCachePago : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }
        public decimal Recibo { get; set; }

        public string NAME
        {
            get { return "p_listaValorTotalPgto"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
            command.Parameters.Add("@recibo", Recibo);

        }
    }

    public class P_ListaValorTotalCachePendente : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }

        public string NAME
        {
            get { return "p_listaValorTotalPendente"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
        }
    }

    public class FiguracaoPedidoDao : BaseDao<PedidoFigurante>
    {
        protected override string GetDeleteCommand(PedidoFigurante entidade)
        {
            return string.Format("Delete From PedidoFigurante Where id = {0}", entidade.IdFigPedido);
        }

        protected override string GetExistsCommand(PedidoFigurante entidade)
        {
            return string.Format("Select id, idpessoa, idtipo, idpessoa From PedidoFigurante Where id = {0}", entidade.IdFigPedido);
        }

        protected override string GetInsertCommand(PedidoFigurante entidade)
        {
            return string.Format("insert into PedidoFigurante (idcusto, idpedido, idtipo, idpessoa, vlrbruto, vlrinss, vlrliquido, status) values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                                  12, entidade.IdPedido, entidade.IdTipo, entidade.IdPessoa, entidade.VlrBruto.Replace(",", "."), entidade.VlrInss.Replace(",", "."), entidade.VlrLiquido.Replace(",", "."), 0);
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

        protected override string GetUpdateCommand(PedidoFigurante entidade)
        {
            return string.Format("Update PedidoFigurante set idtipo = {0}, vlrbruto = '{1}', vlrinss = '{2}', vlrliquido = '{3}' Where (id = {4})",
                      entidade.IdTipo, entidade.VlrBruto, entidade.VlrInss, entidade.VlrLiquido, entidade.IdFigPedido);

        }

        protected override PedidoFigurante Hydrate(SqlDataReader reader)
        {
            return new PedidoFigurante()
            {
                IdFigPedido = Convert.ToInt32(reader[0].ToString()),
                NmePessoa = reader[1].ToString(),
                DescTipo = reader[2].ToString(),
                VlrBruto = reader[3].ToString(),
                VlrInss = reader[4].ToString(),
                VlrLiquido = reader[5].ToString(),
                IdPessoa = Convert.ToInt32(reader[6].ToString()),
                IdTipo = Convert.ToInt32(reader[7].ToString())
            };
        }
    }
}
