using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaNotasFiscais : IStoredProcedureContext
    {
        public int IdFirma { get; set; }
        public int NumNota { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@numnota", NumNota);

        }

        public string NAME
        {
            get { return "p_listaNotaFiscalPorFirma"; }
        }
    }

    public class P_RecuperaNotaFiscal : IStoredProcedureContext
    {
        public int IdNota { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idnota", IdNota);

        }

        public string NAME
        {
            get { return "p_RecuperaNotaFiscal"; }
        }
    }

    public class p_carregaTmpNotaFiscal : IStoredProcedureContext
    {
        public int IdNota { get; set; }
        public int IdFirma { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idnotafiscal", IdNota);
            command.Parameters.Add("@idfirma", IdFirma);

        }

        public string NAME
        {
            get { return "p_carregaTmpNotaFiscal"; }
        }
    }


    public class P_ListaNotasAReceber : IStoredProcedureContext
    {
        public int IdFirma { get; set; }
        public int Status { get; set; }
        public DateTime De { get; set; }
        public DateTime Ate { get; set; }
        public int NumNota { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@status", Status);
            command.Parameters.Add("@de", De);
            command.Parameters.Add("@ate", Ate);
            command.Parameters.Add("@numnota", NumNota);
        }

        public string NAME
        {
            get { return "p_listaContasAReceber"; }
        }
    }

    public class NotaFiscalDao : BaseDao<NotaFiscal>
    {
        protected override string GetDeleteCommand(NotaFiscal entidade)
        {
            return string.Format("Delete From NotaFiscal Where idnotafiscal = {0}", entidade.IdNotaFiscal);
        }

        protected override string GetExistsCommand(NotaFiscal entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(NotaFiscal entidade)
        {
            return string.Format("insert into NotaFiscal (idfirma, idcontratante, numnota, dtemissao, codverificacao, descricao, observacao, status) values ({0}, {1},'{2}','{3}','{4}','{5}','{6}',{7})",
                                  entidade.IdFirma, entidade.IdContratante, entidade.NumeroNota, entidade.DataEmissao.ToString("MM/dd/yyyy HH:mm:ss"), entidade.CodVerificador, entidade.Descricao, entidade.Observacao, 0);
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

        protected override string GetUpdateCommand(NotaFiscal entidade)
        {
            return string.Format("update NotaFiscal set numnota = '{1}', codverificacao = '{2}', descricao = '{3}', observacao = '{4}' WHERE (idnota = {0})",  entidade.IdNotaFiscal, entidade.NumeroNota, entidade.CodVerificador, entidade.Descricao, entidade.Observacao);
        }

        protected override NotaFiscal Hydrate(SqlDataReader reader)
        {
            return new NotaFiscal()
            {
                IdNotaFiscal = Convert.ToInt32(reader[0].ToString()),
                NumeroNota = reader[1].ToString(),
                DataEmissao = Convert.ToDateTime(reader[2].ToString()),
                DataPagamento = reader[3].ToString(),
                CodVerificador = reader[4].ToString(),
                Descricao = reader[5].ToString(),
                ValorBruto = Convert.ToDecimal(reader[6].ToString()),
                ValorCofins = Convert.ToDecimal(reader[7].ToString()),
                ValorCsll = Convert.ToDecimal(reader[8].ToString()),
                ValorIrpj = Convert.ToDecimal(reader[9].ToString()),
                ValorPis = Convert.ToDecimal(reader[10].ToString()),
                ValorIss = Convert.ToDecimal(reader[11].ToString()),
                ValorLiquido = Convert.ToDecimal(reader[12].ToString()),
                Observacao = reader[13].ToString(),
                Status = Convert.ToInt32(reader[14].ToString())
               
            };
        }
    }
}
