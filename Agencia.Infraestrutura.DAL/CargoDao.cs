using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_Lista_Cargos : IStoredProcedureContext
    {
        public void AddParameters(SqlCommand command)
        {
            return;
        }

        public string NAME
        {
            get { return "p_listaCargo"; }
        }
    }

    public class CargoDao : BaseDao<Cargo>
    {
        protected override string GetDeleteCommand(Cargo entidade)
        {
            return string.Format("Delete From Cargo Where idcargo = {0}", entidade.IdCargo);
        }

        protected override string GetExistsCommand(Cargo entidade)
        {
            return string.Format("Select idcargo, descricao, idpermissao From Cargo where idcargo = {0}",entidade.IdCargo);
        }

        protected override string GetInsertCommand(Cargo entidade)
        {
            return string.Format("Insert into cargo (idcargo, descricao, idpermissao) values ({0}, '{1}', {2})",
                                 entidade.IdCargo, entidade.Descricao, entidade.IdPermissao);
        }

        protected override string GetSelectCommand(string id)
        {
            return string.Format("Select idcargo, descricao, idpermissao from cargo where idcargo = " + id + "");
        }

        protected override string GetSelectCommand()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new NotImplementedException();
        }

        protected override string GetUpdateCommand(Cargo entidade)
        {
            throw new NotImplementedException();
        }

        public Cargo ObterPorDescricao (string parametro)
        {
            return GetBySql("SELECT idcargo, descricao, idpermissao FROM cargo Where descricao = '" + parametro + "'");
        }

        public Cargo ObterPorId (int id)
        {
            return GetBySql("SELECT idcargo, descricao, idpermissao FROM cargo Where idcargo = " + id + "");
        }

        protected override Cargo Hydrate(System.Data.SqlClient.SqlDataReader reader)
        {
            return new Cargo()
            {
                IdCargo = Convert.ToInt32(reader[0].ToString()),
                Descricao = reader[1].ToString(),
                IdPermissao = Convert.ToInt32(reader[2].ToString())
            };
        }
    }
}
