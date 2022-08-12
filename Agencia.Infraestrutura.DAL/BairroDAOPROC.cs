using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Data.Base;

namespace Agencia.Infraestrutura.DAL
{

    public class P_ListaTodosBairros : IStoredProcedureContext
    {
        public string Id { get; set; }

        public string NOME_PROCEDURE
        {
            get { return "p_ListaBairro"; }
        }
    }

    public class BairroDAOPROC : DBStoredProcedure
    {
        protected override void AddParameters(IStoredProcedureContext context, SqlCommand command)
        {
            if (new P_ListaTodosBairros().NOME_PROCEDURE == context.NOME_PROCEDURE)
            {
                return;
            }

            //if (new P_Teste_Contexto().NOME_PROCEDURE == context.NOME_PROCEDURE)
            //{
            //    var contexto = (P_Teste_Contexto)context;
            //    command.Parameters.Add("@Id", contexto.Id);
            //}
        }

    }
}
