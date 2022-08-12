using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaEquipePedido : IStoredProcedureContext
    {
        public int IdPedido { get; set; }

        public string NAME
        {
            get { return "p_listaEquipePedido"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpedido", IdPedido);
        }
    }

    public class P_RecuperaEquipePedido : IStoredProcedureContext
    {
        public int IdEquipe { get; set; }

        public string NAME
        {
            get { return "p_RecuperaEquipePedidoPorId"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idequipe", IdEquipe);
        }
    }


    public class EquipePedidoDao : BaseDao<EquipePedido>
    {
        protected override string GetDeleteCommand(EquipePedido entidade)
        {
            return string.Format("Delete From PedidoEquipe Where id = {0}", entidade.IdEquipe);
        }

        protected override string GetExistsCommand(EquipePedido entidade)
        {
            return string.Format("Select idpedido, idpessoa, idcargo From PedidoEquipe Where id = {0}", entidade.IdEquipe);
        }

        protected override string GetInsertCommand(EquipePedido entidade)
        {
            return string.Format("insert into PedidoEquipe (idpedido, idpessoa, idcargo) values ({0}, {1}, {2})",
                                  entidade.IdPedido, entidade.IdPessoa, entidade.IdCargo);
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

        protected override string GetUpdateCommand(EquipePedido entidade)
        {
            return string.Format("update from PedidoEquipe set idcargo = {0} WHERE (id = {1})", entidade.IdCargo, entidade.IdEquipe);
        }

        protected override EquipePedido Hydrate(SqlDataReader reader)
        {
            return new EquipePedido()
            {
                IdEquipe = Convert.ToInt32(reader[0].ToString()),
                NmePessoa = reader[1].ToString(),
                DescCargo = reader[2].ToString(),

            };
        }
    }
}
