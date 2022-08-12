using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_RegistraPedido : IStoredProcedureContext
    {
        public string Operacao { get; set; }
        public int IdFirma { get; set; }
        public int IdPedido { get; set; }
        public int Extra { get; set; }
        public DateTime DtCadastro { get; set; }
        public string NumPedido { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPrograma { get; set; }
        public DateTime DtPedido { get; set; }
        public string Hora { get; set; }
        public string HoraIni { get; set; }
        public string HoraFim  { get; set; }
        public string Cena { get; set; }
        public string Capitulo { get; set; }
        public string Observacao { get; set; }
        public string Roteiro { get; set; }
        public int IdUsuario { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@operacao", Operacao);
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@idpedido", IdPedido);
            command.Parameters.Add("@extra", Extra);
            command.Parameters.Add("@dtcadastro", DtCadastro);
            command.Parameters.Add("@numpedido", NumPedido);
            command.Parameters.Add("@idempresa", IdEmpresa);
            command.Parameters.Add("@idprograma", IdPrograma);
            command.Parameters.Add("@dtpedido", DtPedido);
            command.Parameters.Add("@hora", Hora);
            command.Parameters.Add("@horaini", HoraIni);
            command.Parameters.Add("@horafim", HoraFim);
            command.Parameters.Add("@cena", Cena);
            command.Parameters.Add("@capitulo", Capitulo);
            command.Parameters.Add("@observacao", Observacao);
            command.Parameters.Add("@roteiro", Roteiro);
            command.Parameters.Add("@widcolaborador ", IdUsuario);
        }

        public string NAME
        {
            get { return "p_RegistraPedido"; }
        }
    }

    public class P_ListaPedidos : IStoredProcedureContext
    {
        public string NumeroPedido { get; set; }
        public int IdProduto { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@numpedido", NumeroPedido);
            command.Parameters.Add("@idproduto", IdProduto);
        }

        public string NAME
        {
            get { return "p_listaPedidos"; }
        }
    }

    public class P_RecuperaPedidoPorId : IStoredProcedureContext
    {
        public int IdPedido { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpedido", IdPedido);
        }

        public string NAME
        {
            get { return "p_RecuperaPedidoPorId"; }
        }
    }

    public class P_ListaPedidoPorFatura : IStoredProcedureContext
    {
        public int IdCartaFatura { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idcartafatura", IdCartaFatura);
        }

        public string NAME
        {
            get { return "p_listaPedidoPorFatura"; }
        }
    }

    public class P_ListaPedidoDisponivel : IStoredProcedureContext
    {
        public int IdCartaFatura { get; set; }
        public DateTime De { get; set; }
        public DateTime Ate { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idcartafatura", IdCartaFatura);
            command.Parameters.Add("@de", De);
            command.Parameters.Add("@ate", Ate);
        }

        public string NAME
        {
            get { return "p_listaPedidoDisponivel"; }
        }
    }

    public class PedidoDao : BaseDao<Pedido>
    {
        protected override string GetDeleteCommand(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Pedido entidade)
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

        protected override string GetUpdateCommand(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        protected override Pedido Hydrate(SqlDataReader reader)
        {
            return new Pedido()
            {
                IdPedido = Convert.ToInt32(reader[0].ToString()),
                NumPedido = reader[1].ToString(),
                DataPedido = Convert.ToDateTime(reader[2].ToString()),
                DescPrograma = reader[3].ToString(),
                Extra = Convert.ToInt32(reader[4].ToString()),
                IdEmpresa = Convert.ToInt32(reader[5].ToString()),
                DataCadastro = Convert.ToDateTime(reader[6].ToString()),
                IdPrograma = Convert.ToInt32(reader[7].ToString()),
                Cena = reader[8].ToString(),
                Capitulo = reader[9].ToString(),
                Hora = reader[10].ToString(),
                HoraInicio = reader[11].ToString(),
                HoraFim = reader[12].ToString(),
                Observacao = reader[13].ToString(),
                Roteiro = reader[14].ToString(),
                TotalPedido = Convert.ToDecimal(reader[15].ToString()),
                TotalPago = Convert.ToDecimal(reader[16].ToString()),
                TotalPendente = Convert.ToDecimal(reader[17].ToString()),
                TotalPrevisto = Convert.ToDecimal(reader[18].ToString()),
                IdFirma = Convert.ToInt32(reader[19].ToString())
            };
        }
    }
}
