using System;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaFolhaPgto : IStoredProcedureContext
    {
        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_listaFolhaPgto"; }
        }
    }

    public class P_RecuperaFolhaPorId : IStoredProcedureContext
    {
        public int IdFolha { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfolha", IdFolha);
        }

        public string NAME
        {
            get { return "p_RecuperaFolhaPorId"; }
        }
    }

    public class P_ProcessaDadosFolha : IStoredProcedureContext
    {
        public int IdFolha { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idfolha", IdFolha);
        }

        public string NAME
        {
            get { return "p_RecuperaFolhaPorId"; }
        }
    }


    public class FolhaDao : BaseDao<Folha>
    {
        protected override string GetDeleteCommand(Folha entidade)
        {
            return string.Format("Delete From Folha Where idfolha = {0}", entidade.IdFolha);
        }

        protected override string GetExistsCommand(Folha entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Folha entidade)
        {
            return string.Format("insert into Folha (dtgeracao, status, mesref, de, ate, descricao, observacao) values ('{0}', {1}, {2}, '{3}', '{4}', '{5}', '{6}')",
                     entidade.DataGeracao.ToString("MM/dd/yyyy HH:mm:ss"), 0, entidade.MesReferencia, entidade.DataDe.ToString("MM/dd/yyyy HH:mm:ss"), entidade.DataAte.ToString("MM/dd/yyyy HH:mm:ss"), entidade.Descricao, entidade.Observacao);
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

        protected override string GetUpdateCommand(Folha entidade)
        {
            return string.Format("Update Folha set dtgeracao = '{1}', mesref = {2}, de = '{3}', ate = '{4}', descricao = '{5}', observacao = '{6}' Where (idfolha = {0})",
                     entidade.IdFolha, entidade.DataGeracao.ToString("MM/dd/yyyy HH:mm:ss"), entidade.MesReferencia, entidade.DataDe.ToString("MM/dd/yyyy HH:mm:ss"), entidade.DataAte.ToString("MM/dd/yyyy HH:mm:ss"), entidade.Descricao, entidade.Observacao);
        }

        protected override Folha Hydrate(SqlDataReader reader)
        {
            return new Folha()
            {
                IdFolha = Convert.ToInt32(reader[0].ToString()),
                DataGeracao = Convert.ToDateTime(reader[1].ToString()),
                Status = reader[2].ToString(),
                MesReferencia = reader[3].ToString(),
                DataDe = Convert.ToDateTime(reader[4].ToString()),
                DataAte = Convert.ToDateTime(reader[5].ToString()),
                Descricao = reader[6].ToString(),
                Observacao = reader[7].ToString(),
                //DataLiberacao = Convert.ToDateTime(reader[8].ToString())

            };
        }
    }
}
