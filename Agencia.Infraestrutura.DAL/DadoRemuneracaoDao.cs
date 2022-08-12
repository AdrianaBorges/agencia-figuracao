using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{

    public class P_ListaDadoRemuneracao : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }

        public string NAME
        {
            get { return "p_ListaDadoRemuneracao"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
        }
    }

    public class P_ListaDadoRemuneracaoPorId : IStoredProcedureContext
    {
        public int IdDadoRemuneracao { get; set; }

        public string NAME
        {
            get { return "p_RecuperaDadoRemuneracaoPorId"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@id", IdDadoRemuneracao);
        }
    }

    public class DadoRemuneracaoDao : BaseDao<DadoRemuneracao>
    {
        protected override string GetDeleteCommand(DadoRemuneracao entidade)
        {
            return string.Format("Delete From dadoremuneracao Where id = {0}", entidade.IdDadoRemuneracao);
        }

        protected override string GetExistsCommand(DadoRemuneracao entidade)
        {
            return string.Format("select id from dadoremuneracao where idpessoa = {0} and idremuneracao = {1}", entidade.IdPessoa, entidade.IdRemuneracao);
        }

        protected override string GetInsertCommand(DadoRemuneracao entidade)
        {
            return string.Format("insert into DadoRemuneracao (idpessoa, idremuneracao, valor) values ({0}, {1}, '{2}')",
                     entidade.IdPessoa, entidade.IdRemuneracao, entidade.Valor);
        }

        public DadoRemuneracao Obter(DadoRemuneracao entidade)
        {
            return GetBySql("SELECT id, idpessoa, idremuneracao, valor FROM dadoremuneracao Where idpessoa = " + entidade.IdPessoa + "" + " and idremuneracao = " + entidade.IdRemuneracao + "" + " and valor = '" + entidade.Valor + "'");
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

        protected override string GetUpdateCommand(DadoRemuneracao entidade)
        {
            return string.Format("Update DadoRemuneracao set valor = '{0}' Where id = {1}", 
                                entidade.Valor, entidade.IdDadoRemuneracao);
        }

        protected override DadoRemuneracao Hydrate(SqlDataReader reader)
        {
            return new DadoRemuneracao()
            {
                IdDadoRemuneracao = Convert.ToInt32(reader[0].ToString()),
                IdRemuneracao = Convert.ToInt32(reader[1].ToString()),
                NmeRemuneracao = reader[2].ToString(),
                Valor = Convert.ToDecimal(reader[3].ToString())
            };
        }
    }
}
