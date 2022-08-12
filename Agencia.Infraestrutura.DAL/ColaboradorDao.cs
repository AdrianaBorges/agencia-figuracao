using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;
using System.Data;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.Infraestrutura.DAL
{
    public class P_RegistraColaborador : IStoredProcedureContext
    {
        public string Operacao { get; set; }
        public int IdFirma { get; set; }
        public int IdPessoa { get; set; }
        public int IdTipoPessoa { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Status { get; set; }
        public int IdBairro { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Cnpj { get; set; }
        public string Expedicao { get; set; }
        public string Pis { get; set; }
        public string Ctps { get; set; }
        public string Serie { get; set; }
        public string CarteiraReservista { get; set; }
        public string TelFixo { get; set; }
        public string TelCelular { get; set; }
        public string TelContato { get; set; }
        public string Email { get; set; }
        public int IdCargo { get; set; }
        public DateTime? DataDesligamento { get; set; }
        public int Clt { get; set; }
        public int Comissao { get; set; }
        public int IdUsuario { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@operacao", Operacao);
            command.Parameters.Add("@idfirma", IdPessoa);
            command.Parameters.Add("@idpessoa", IdPessoa);
            command.Parameters.Add("@idtipopessoa", IdTipoPessoa);
            command.Parameters.Add("@nmepessoa", Nome);
            command.Parameters.Add("@sexo", Sexo);
            command.Parameters.Add("@dtnascimento", DataNascimento);
            command.Parameters.Add("@dtcadastro", DataCadastro);
            command.Parameters.Add("@status", Status);
            command.Parameters.Add("@idbairro", IdBairro);
            command.Parameters.Add("@logradouro", Logradouro);
            command.Parameters.Add("@complemento", Complemento);
            command.Parameters.Add("@cep", Cep);
            command.Parameters.Add("@cpf", Cpf);
            command.Parameters.Add("@rg", Rg);
            command.Parameters.Add("@cnpj", Cnpj);
            command.Parameters.Add("@expedicao", Expedicao);
            command.Parameters.Add("@pis", Pis);
            command.Parameters.Add("@ctps", Ctps);
            command.Parameters.Add("@serie", Serie);
            command.Parameters.Add("@cartreservista", CarteiraReservista);
            command.Parameters.Add("@fixo", TelFixo );
            command.Parameters.Add("@celular", TelCelular);
            command.Parameters.Add("@contato", TelContato);
            command.Parameters.Add("@email", Email);
            command.Parameters.Add("@idcargo", IdCargo);
            command.Parameters.Add("@dtdesligamento", DataDesligamento);
            command.Parameters.Add("@clt", Clt);
            command.Parameters.Add("@comissao", Comissao);
            command.Parameters.Add("@widcolaborador ", IdUsuario);
        }

        public string NAME
        {
            get { return "p_RegistraColaborador"; }
        }
    }

    public class P_ListaColaborador : IStoredProcedureContext
    {
        public int Status { get; set; }
        public string Nome { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@dado", Nome);
            command.Parameters.Add("@status", Status);
        }

        public string NAME
        {
            get { return "p_listaColaborador"; }
        }
    }

    public class P_ListaColaboradorPorProduto : IStoredProcedureContext
    {
        public int Produto { get; set; }
        public int Pedido { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idproduto", Produto);
            command.Parameters.Add("@idpedido", Pedido);

        }

        public string NAME
        {
            get { return "p_listaColaboradorProduto"; }
        }
    }

    public class P_RecuperaColaboradorPorId : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
        }

        public string NAME
        {
            get { return "p_RecuperaColaboradorPorId"; }
        }
    }

    public class ColaboradorDao : BaseDao<Colaborador>
    {
        protected override string GetDeleteCommand(Colaborador entidade)
        {
            return string.Format("Delete From colaborador where idpessoa = {0}", entidade.IdPessoa);
        }

        protected override string GetExistsCommand(Colaborador entidade)
        {
            return string.Format("Select idpessoa From colaborador where idpessoa = {0}", entidade.IdPessoa);
        }

        protected override string GetSelectCommand(string id)
        {
            return "Select idpessoa, idcargo, dtdesligamento, clt, comissao From colaborador where  idpessoa = " + id + "";

        }

        /// <summary>
        /// Registra senha para usuário
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        protected override string GetInsertCommand(Colaborador entidade)
        {
            return string.Format("Insert into Colaborador (idpessoa, idcargo, dtdesligamento, clt, comissao) values ({0}, {1}, '{2}', {3}, {4})",
                                  entidade.IdPessoa, entidade.IdCargo , entidade.Clt , entidade.Comissao);
        }

        protected override string GetSelectCommand()
        {
            throw new NotImplementedException();
        }

        protected override string GetSelectCommandWithJoin(string foreignKey)
        {
            throw new NotImplementedException();
        }

        protected override string GetUpdateCommand(Colaborador entidade)
        {
            throw new NotImplementedException();
        }

        private DateTime? AceitaDataNull(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return null;
            }
            return Convert.ToDateTime(data);
        }

        protected override Colaborador Hydrate(SqlDataReader reader)
        {
            return new Colaborador()
            {
                IdPessoa = Convert.ToInt32(reader[0].ToString()),
                Nome = reader[1].ToString(),
                Nascimento = Convert.ToDateTime (reader[2].ToString()),
                Sexo = reader[3].ToString(),
                Cadastro = Convert.ToDateTime(reader[4].ToString()),
                Status = reader[5].ToString(),
                Logradouro = reader[6].ToString(),
                Complemento = reader[7].ToString(),
                Cep = reader[8].ToString(),
                IdBairro = Convert.ToInt32(reader[9].ToString()),
                Fixo = reader[10].ToString(),
                Celular = reader[11].ToString(),
                Contato = reader[12].ToString(),
                Email = reader[13].ToString(),
                Cpf= reader[14].ToString(),
                Rg = reader[15].ToString(),
                Expedicao = reader[16].ToString(),
                Pis = reader[17].ToString(),
                Ctps = reader[18].ToString(),
                Serie = reader[19].ToString(),
                CartReservista = reader[20].ToString(),
                IdCargo = Convert.ToInt32(reader[21].ToString()),
                Desligamento = AceitaDataNull(reader[22].ToString()),
                Clt = Convert.ToInt32(reader[23].ToString()),
                Comissao = Convert.ToInt32(reader[24].ToString()),
                IdCidade = Convert.ToInt32(reader[25].ToString()),
                IdEstado = Convert.ToInt32(reader[26].ToString()),
                IdFirma = Convert.ToInt32(reader[27].ToString())
            };
        }
        
    }

}
