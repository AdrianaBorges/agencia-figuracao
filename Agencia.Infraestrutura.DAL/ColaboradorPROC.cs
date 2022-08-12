using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Data.Base;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaUsuario : IStoredProcedureContext
    {
        public int Status { get; set; }

        public string NOME_PROCEDURE
        {
            get { return "p_ListaColaborador"; }
        }
    }

    public class ColaboradorPROC : DBStoredProcedure
    {
        protected override void AddParameters(IStoredProcedureContext context, SqlCommand command)
        {
            if (new P_ListaUsuario().NOME_PROCEDURE == context.NOME_PROCEDURE)
            {
                var contexto = (P_ListaUsuario)context;
                command.Parameters.Add("@Status", contexto.Status);
            }
        }
    }

}
