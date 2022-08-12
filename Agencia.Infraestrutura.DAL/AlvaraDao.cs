using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_CarregaListaAlvara : IStoredProcedureContext
    {
        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_carregaGridAlvara"; }
        }
    }

    public class P_ListaPessoaPorAlvara : IStoredProcedureContext
    {
        public int IdAlvara { get; set; }
        public int IdDisponivel { get; set; }
        public string SDado { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idalvara", IdAlvara);
            command.Parameters.Add("@iddisponivel", IdDisponivel);
            command.Parameters.Add("@dado", SDado);
        }

        public string NAME
        {
            get { return "p_carregaGridFiguranteAlvara"; }
        }
    }

    public class P_ListaProcessoPorProduto : IStoredProcedureContext
    {
        public int IdPrograma { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idprograma", IdPrograma);
        }

        public string NAME
        {
            get { return "p_listaProcessoPorProduto"; }
        }
    }
    public class P_RecuperaAlvara : IStoredProcedureContext
    {
        public int IdAlvara { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idalvara", IdAlvara);
        }

        public string NAME
        {
            get { return "P_RecuperaAlvara"; }
        }
    }

    public class AlvaraDao : BaseDao<Alvara>
    {
        protected override string GetDeleteCommand(Alvara entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Alvara entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Dominio.Modelo.Alvara entidade)
        {
            return string.Format("insert into Alvara (numprocesso, dtemissao, idprograma, observacao) values ('{0}', '{1}', {2}, '{3}')",
                               entidade.NumProcesso, entidade.DataEmissao.ToString("MM/dd/yyyy HH:mm:ss"), entidade.IdPrograma, entidade.Observacao);

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

        protected override string GetUpdateCommand(Alvara entidade)
        {
            return string.Format("Update Alvara set numprocesso = '{0}', dtemissao = '{1}', idprograma = {2}, observacao = '{3}' Where idalvara = {4}",
                                  entidade.NumProcesso, entidade.DataEmissao.ToString("MM/dd/yyyy HH:mm:ss"), entidade.IdPrograma, entidade.Observacao, entidade.IdAlvara);
        }

        protected override Alvara Hydrate(SqlDataReader reader)
        {
            return new Alvara()
            {
                IdAlvara = Convert.ToInt32(reader[0].ToString()),
                DataEmissao = Convert.ToDateTime(reader[1].ToString()),
                NumProcesso = reader[2].ToString(),
                IdPrograma = Convert.ToInt32(reader[3].ToString()),
                Observacao = reader[4].ToString()
            };
        }
    }
}
