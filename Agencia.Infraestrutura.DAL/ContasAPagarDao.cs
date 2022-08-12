using System;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaContasAPagar : IStoredProcedureContext
    {
        public int IdFirma { get; set; }
        public DateTime De { get; set; }
        public DateTime Ate { get; set; }
        public int IdCusto { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@de", De);
            command.Parameters.Add("@ate", Ate);
            command.Parameters.Add("@idcusto", IdCusto);
        }

        public string NAME
        {
            get { return "p_listaContasAPagar"; }
        }
    }

    public class P_ListaContasPagas : IStoredProcedureContext
    {
        public int IdFirma { get; set; }
        public DateTime De { get; set; }
        public DateTime Ate { get; set; }
        public int IdCusto { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@de", De);
            command.Parameters.Add("@ate", Ate);
            command.Parameters.Add("@idcusto", IdCusto);
        }

        public string NAME
        {
            get { return "p_listaContasPaga"; }
        }
    }

    public class P_RecuperaContaAPagar : IStoredProcedureContext
    {
        public int IdTipo { get; set; }
        public int IdContaAPagar { get; set; }
        
        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idtipo", IdTipo);
            command.Parameters.Add("@idcontaapagar", IdContaAPagar);

        }

        public string NAME
        {
            get { return "p_RecuperaContaAPagar"; }
        }
    }

    public class ContasAPagarDao : BaseDao<ContasAPagar>
    {

        protected override string GetDeleteCommand(ContasAPagar entidade)
        {
            return string.Format("Delete From ContasAPagar Where idcontaapagar = {0}", entidade.IdAPagar);
        }

        protected override string GetExistsCommand(ContasAPagar entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(ContasAPagar entidade)
        {
            return string.Format("insert into ContasAPagar (idcusto, idpessoa, data, descricao, vencimento, valor, observacao, status) values ({0}, {1}, '{2}', '{3}', '{4}', {5}, '{6}', {7})",
                                 entidade.IdCusto, entidade.IdPessoa, DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), entidade.Descricao, entidade.DtVencimento.ToString("MM/dd/yyyy HH:mm:ss"), entidade.Valor.Replace(",", "."), entidade.Observacao, 0);
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

        protected override string GetUpdateCommand(ContasAPagar entidade)
        {
            throw new NotImplementedException();
        }

        protected override ContasAPagar Hydrate(SqlDataReader reader)
        {
            return new ContasAPagar()
            {
                IdAPagar = Convert.ToInt32(reader[0].ToString()),
                DtVencimento = Convert.ToDateTime(reader[1].ToString()),
                IdCusto = Convert.ToInt32(reader[2].ToString()),
                IdPessoa = Convert.ToInt32(reader[3].ToString()),
                Descricao = reader[4].ToString(),
                Valor = reader[5].ToString(),
                Observacao = reader[6].ToString(),
                DtPagamento = reader[7].ToString()

            };
        }
    }
}
