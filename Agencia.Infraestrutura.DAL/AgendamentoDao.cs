using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaItemAgendamento : IStoredProcedureContext
    {
        public int IdAgendamento { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idagendamento", IdAgendamento);
        }

        public string NAME
        {
            get { return "p_listaItemAgendamento"; }
        }
    }

    public class P_ListaItensParaLocacao : IStoredProcedureContext
    {
        public int IdAgendamento { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idagendamento", IdAgendamento);
        }

        public string NAME
        {
            get { return "p_listaItensParaAgendamento"; }
        }
    }

    public class AgendamentoDao : BaseDao<Agendamento>
    {
        //public Agendamento ObterListaDeAgendamentos(string dado)
        //{
        //    return GetBySql("SELECT REPLICATE('0', 6 - LEN(idagendamento)) + RTrim(idagendamento) as idagendamento, CONVERT(char, dregistro, 105)) AS dregistro, descricao, CONVERT(char, dtpgto, 105)) AS dtpgto, observacao FROM agendamento order by idagendamento desc");
        //}

        protected override string GetDeleteCommand(Agendamento entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Agendamento entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Agendamento entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommand()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommand(string id)
        {
            return "SELECT idagendamento, convert(varchar(10),dtregistro,105) AS dtregistro,CONTROLE,descricao, convert(varchar(10),dtpgto,105) AS dtpgto,observacao FROM Agendamento where idagendamento = '" + id + "'";

        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new NotImplementedException();
        }

        protected override string GetUpdateCommand(Agendamento entidade)
        {
            throw new NotImplementedException();
        }

        protected override Agendamento Hydrate(SqlDataReader reader)
        {
            return new Agendamento()
            {
                IdAgendamento = Convert.ToInt32(reader[0].ToString()),
                DataRegistro = Convert.ToDateTime(reader[1].ToString()),
                Controle = reader[2].ToString(),
                Descricao = reader[3].ToString(),
                DataPgto = Convert.ToDateTime(reader[4].ToString()),
                Observacao = reader[5].ToString()

            };
        }
    }
}
