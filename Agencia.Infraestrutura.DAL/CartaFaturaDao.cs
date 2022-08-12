using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;
using System.Data;
using Agencia.Infraestrutura.DAL;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaCartaFatura : IStoredProcedureContext
    {
        public string NumeroFatura { get; set; }
        public int IdFirma { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@numcarta", NumeroFatura);
            command.Parameters.Add("@idfirma", IdFirma);
        }

        public string NAME
        {
            get { return "p_listaCartaFatura"; }
        }
    }

    public class P_RecuperaCartaFatura : IStoredProcedureContext
    {
        public int IdCartaFatura { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idcartafatura", IdCartaFatura);
        }

        public string NAME
        {
            get { return "p_RecuperaCartaFaturaPorId"; }
        }
    }

    public class P_ListaFaturaParaNotaFiscal : IStoredProcedureContext
    {
        public int IdFirma { get; set; }
        public int IdNota { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfirma", IdFirma);
            command.Parameters.Add("@idnota", IdNota);

        }

        public string NAME
        {
            get { return "p_listaCartaFaturaParaNotaFiscal"; }
        }
    }

    public class CartaFaturaDao : BaseDao<CartaFatura>
    {
        protected override string GetDeleteCommand(Dominio.Modelo.CartaFatura entidade)
        {
            return string.Format("Delete From CartaFatura Where idcartafatura = {0}", entidade.IdCartaFatura);
        }

        protected override string GetExistsCommand(Dominio.Modelo.CartaFatura entidade)
        {
            return string.Format("select idcartafatura from CartaFatura where idcartafatura = {0} and idfirma = {1} and numcarta = '{2}'", entidade.IdCartaFatura, entidade.IdFirma , entidade.NumCarta);
        }

        protected override string GetInsertCommand(Dominio.Modelo.CartaFatura entidade)
        {
            return string.Format("insert into CartaFatura (idfirma, numcarta, dtemissao, idprograma, observacao, status, idnota, dtvencimento, dtrecebimento) values ({0}, {1}, '{2}', {3}, '{4}', {5}, {6}, '{7}', '{8}')",
                                 entidade.IdFirma, entidade.NumCarta, entidade.DataEmissao.ToString("MM/dd/yyyy HH:mm:ss"), entidade.IdPrograma, entidade.Observacao, 0, 0, entidade.DataVencimento.ToString("MM/dd/yyyy HH:mm:ss"), entidade.DataRecebimento.ToString("MM/dd/yyyy HH:mm:ss"));
        }

        //DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),

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

        protected override string GetUpdateCommand(Dominio.Modelo.CartaFatura entidade)
        {
            return string.Format("Update CartaFatura set idfirma = {0}, numcarta = {1}, dtemissao = '{2}', idprograma = {3}, observacao = '{4}', dtvencimento = '{5}', dtrecebimento = '{6}' Where idcartafatura = {7}",
                Convert.ToInt32(entidade.IdFirma), entidade.NumCarta, entidade.DataEmissao.ToString("MM/dd/yyyy HH:mm:ss"), entidade.IdPrograma, entidade.Observacao, entidade.DataVencimento.ToString("MM/dd/yyyy HH:mm:ss"), entidade.DataRecebimento.ToString("MM/dd/yyyy HH:mm:ss"), entidade.IdCartaFatura);
        }

        protected override Dominio.Modelo.CartaFatura Hydrate(SqlDataReader reader)
        {
            return new CartaFatura()
            {
                IdCartaFatura = Convert.ToInt32(reader[0].ToString()),
                IdNotaFiscal = Convert.ToInt32(reader[1].ToString()),
                NumCarta = Convert.ToInt32(reader[2].ToString()),
                DataEmissao = Convert.ToDateTime(reader[3].ToString()),
                IdPrograma = Convert.ToInt32(reader[4].ToString()),
                Observacao = reader[5].ToString(),
                IdFirma = Convert.ToInt32(reader[6].ToString()),
                DataVencimento = Convert.ToDateTime(reader[7].ToString()),
                DataRecebimento = Convert.ToDateTime(reader[8].ToString())
            };
        }
    }
}
