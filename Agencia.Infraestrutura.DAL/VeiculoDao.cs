using System;
using System.Data.SqlClient;
using Agencia.Dominio.Modelo;
using Data.Base;

namespace Agencia.Infraestrutura.DAL
{
    public class P_ListaVeiculoPorId : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }

        public string NAME
        {
            get { return "p_ListaVeiculoPorId"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
        }
    }

    public class P_RecuperaVeiculoPorId : IStoredProcedureContext
    {
        public int IdVeiculo { get; set; }

        public string NAME
        {
            get { return "p_RecuperaVeiculoPorId"; }
        }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idveiculo", IdVeiculo);
        }
    }

    public class VeiculoDao : BaseDao<Veiculo> 
    {
        protected override string GetDeleteCommand(Veiculo entidade)
        {
            return string.Format("Delete From Veiculo Where idveiculo = {0}", entidade.IdVeiculo);
        }

        protected override string GetExistsCommand(Veiculo entidade)
        {
            return string.Format("select idveiculo from veiculo where idpessoa = {0} and idmarca = {1} and idmodelo = {2} and ano = '{3}'",
                                  entidade.IdPessoa, entidade.IdMarca, entidade.IdModelo, entidade.Ano );
        }

        protected override string GetInsertCommand(Veiculo entidade)
        {
            return string.Format("insert into Veiculo (idpessoa, idmarca, idmodelo,  ano) values ({0}, {1}, {2}, '{3}')",
                                 entidade.IdPessoa, entidade.IdMarca, entidade.IdModelo, entidade.Ano);
        }

        public Veiculo ObterPeloId(int id)
        {
            return GetBySql("select idveiculo, idpessoa, idmarca, idmodelo, ano From veiculo where idveiculo = " + id + "");
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

        protected override string GetUpdateCommand(Veiculo entidade)
        {
            return string.Format("update veiculo set ano = '{0}' Where (idveiculo = {1})", entidade.Ano, entidade .IdVeiculo);

        }

        protected override Veiculo Hydrate(System.Data.SqlClient.SqlDataReader reader)
        {
            return new Veiculo()
            {
                IdVeiculo = Convert.ToInt32(reader[0].ToString()),
                DescMarca = reader[1].ToString(),
                DescModelo = reader[2].ToString(),
                Ano = reader[3].ToString(),
                IdMarca = Convert.ToInt32(reader[4].ToString()),
                IdModelo = Convert.ToInt32(reader[5].ToString()),

            };
        }
    }
}
