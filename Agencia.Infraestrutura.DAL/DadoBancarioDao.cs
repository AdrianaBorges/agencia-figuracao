using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaDadoBancario : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }

        public string NAME
        {
            get { return "p_ListaDadoBancario"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
        }
    }

    public class P_ListaDadoBancarioPorId : IStoredProcedureContext
    {
        public int IdDadoBancario { get; set; }

        public string NAME
        {
            get { return "p_RecuperaDadoBancarioPorId"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@id", IdDadoBancario);
        }
    }


    public class DadoBancarioDao : BaseDao<DadoBancario>
    {
        protected override string GetDeleteCommand(DadoBancario entidade)
        {
            return string.Format("Delete From DadoBancario Where id = {0}", entidade.IdDadoBancario);
        }

        protected override string GetExistsCommand(DadoBancario dado)
        {
            return string.Format("select id from dadobancario where id = {0} and tipo = '{1}' and agencia = '{2}'", dado.IdDadoBancario, dado.Tipo, dado.Agencia);
        }

        protected override string GetInsertCommand(DadoBancario entidade)
        {
            return string.Format("insert into DadoBancario (idpessoa, status, idbanco, tipo, agencia, numconta, titular) values ({0}, {1}, {2}, '{3}', '{4}', '{5}', '{6}')",
                                 entidade.IdPessoa, entidade.Status, entidade.IdBanco, entidade.Tipo, entidade.Agencia, entidade.NumeroConta, entidade.Titular);
        }

        public DadoBancario ObterPeloId(int id)
        {
            return GetBySql("select db.id, "  +
				            "case db.status when 1 then '01- ATIVO' when 0 then '00- INATIVO' end as status, " +
				            "bc.numero + '-' + bc.nmebanco as nmebanco, " +
				            "db.tipo, db.agencia, db.numconta, db.titular, db.idpessoa " + 
			                "from dadobancario db " +
			                "inner join banco bc on bc.idbanco=db.idbanco " +
			                "where db.id = " + id + "");
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

        protected override string GetUpdateCommand(DadoBancario entidade)
        {
            return string.Format("Update DadoBancario set status = '{0}', idbanco = {1}, tipo = '{2}', agencia = '{3}', numconta = '{4}' Where id = {5}",
                Convert.ToInt32(entidade.Status), entidade .IdBanco , entidade.Tipo, entidade.Agencia, entidade.NumeroConta, entidade.IdDadoBancario );
        }

        protected override DadoBancario Hydrate(SqlDataReader reader)
        {
            return new DadoBancario()
            {
                IdDadoBancario = Convert.ToInt32(reader[0].ToString()),
                Status = reader[1].ToString(),
                IdBanco = Convert.ToInt32(reader[2].ToString()),
                NomeBanco = reader[3].ToString(),
                Tipo = reader[4].ToString(),
                Agencia = reader[5].ToString(),
                NumeroConta = reader[6].ToString(),
                Titular = reader[7].ToString(),
                IdPessoa = Convert.ToInt32(reader[8].ToString()),

            };

        }
    }
}
