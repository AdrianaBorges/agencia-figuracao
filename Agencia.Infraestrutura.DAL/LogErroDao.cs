using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;
using System.Data;

namespace Agencia.Infraestrutura.DAL
{
    public class LogErroDao : BaseDao<LogErro>
    {
        protected override string GetDeleteCommand(LogErro entidade)
        {
            return string.Format("Delete from logerro where idlogerro = '{0}'", entidade.IdLogErro);
        }

        protected override string GetExistsCommand(LogErro entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(LogErro entidade)
        {
            return string.Format("insert into logerro (IdPessoa, IdForm, Data, Descricao) values ({0}, {1},'{2}','{3}')",
                                 entidade.IdPessoa, entidade.IdForm, entidade.Data.Date, entidade.Descricao);
        }

        protected override string GetSelectCommand(string id)
        {
            return "select IdLogErro, IdPessoa, IdForm, Data, Descricao From LogErro Where IdForm = '" + id + "'";
        }

        protected override string GetSelectCommand()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new NotImplementedException();
        }

        protected override string GetUpdateCommand(LogErro entidade)
        {
            return string.Format("Update LogErro set IdPessoa = {1}, IdForm = {2}, Data = {3}, Descricao = '{4}' Where IdLogErro = '{0}'",
                                   entidade.IdLogErro, entidade.IdForm, entidade.Data, entidade.Descricao);
        }

        protected override LogErro Hydrate(SqlDataReader reader)
        {
            return new LogErro()
            {
                IdLogErro = reader[0].ToString(),
                IdPessoa = int.Parse(reader[1].ToString()),
                IdForm = int.Parse(reader[2].ToString()),
                Data = Convert.ToDateTime(reader[3].ToString()),
                Descricao = reader[4].ToString()
            };
        }

    }
}
