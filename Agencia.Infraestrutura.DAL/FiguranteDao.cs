using System;
using System.Data.SqlClient;
using Data.Base;
using Agencia.Dominio.Modelo;

namespace Agencia.Infraestrutura.DAL
{
    public class P_RegistraFigurante : IStoredProcedureContext
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
        public string Expedicao { get; set; }
        public string Pis { get; set; }
        public string TelFixo { get; set; }
        public string TelCelular { get; set; }
        public string TelContato { get; set; }
        public string Email { get; set; }
        public string NmeArtistico { get; set; }
        public string Nacionalidade { get; set; }
        public string Acesso { get; set; }
        public string Pasta { get; set; }
        public string Mae { get; set; }
        public string Pai { get; set; }
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
        public string RegistroAtor { get; set; }
        public int Figurante { get; set; }
        public int Ator { get; set; }
        public int Modelo { get; set; }
        public string Altura { get; set; }
        public string IdadeAparente { get; set; }
        public string Peso { get; set; }
        public string TipoEtnico { get; set; }
        public string Manequim { get; set; }
        public string Calcado { get; set; }
        public string Busto { get; set; }
        public string Quadril { get; set; }
        public string Cintura { get; set; }
        public string Celebridade { get; set; }
        public string CorOlhos { get; set; }
        public string Cabelo { get; set; }
        public string CorCabelo { get; set; }
        public string TipoCabelo { get; set; }
        public string CorPele { get; set; }
        public int AparelhoDental { get; set; }
        public string Ctps { get; set; }

        public int IdUsuario { get; set; }

        public string Responsavel { get; set; }
        public string CpfResp { get; set; }
        public string CertNascimento { get; set; }
        public string Livro { get; set; }
        public string Cnpj { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@operacao", Operacao);
            command.Parameters.Add("@idfirma", IdFirma);
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
            command.Parameters.Add("@expedicao", Expedicao);
            command.Parameters.Add("@pis", Pis);
            command.Parameters.Add("@fixo", TelFixo);
            command.Parameters.Add("@celular", TelCelular);
            command.Parameters.Add("@contato", TelContato);
            command.Parameters.Add("@email", Email);
            command.Parameters.Add("@nmeartistico", NmeArtistico);
            command.Parameters.Add("@nacionalidade", Nacionalidade);
            command.Parameters.Add("@acesso", Acesso);
            command.Parameters.Add("@pasta", Pasta);
            command.Parameters.Add("@mae", Mae);
            command.Parameters.Add("@pai", Pai);
            command.Parameters.Add("@estadocivil", EstadoCivil);
            command.Parameters.Add("@profissao", Profissao);
            command.Parameters.Add("@registroator", RegistroAtor );
            command.Parameters.Add("@figurante", Figurante);
            command.Parameters.Add("@ator", Ator);
            command.Parameters.Add("@modelo", Modelo);
            command.Parameters.Add("@altura", Altura);
            command.Parameters.Add("@idadeap", IdadeAparente);
            command.Parameters.Add("@peso", Peso);
            command.Parameters.Add("@tipoetnico", TipoEtnico);
            command.Parameters.Add("@manequim", Manequim );
            command.Parameters.Add("@calcado", Calcado);
            command.Parameters.Add("@busto", Busto);
            command.Parameters.Add("@quadril", Quadril );
            command.Parameters.Add("@cintura", Cintura );
            command.Parameters.Add("@celebridade", Celebridade );
            command.Parameters.Add("@corolhos", CorOlhos);
            command.Parameters.Add("@cabelo", Cabelo);
            command.Parameters.Add("@corcabelo", CorCabelo);
            command.Parameters.Add("@tipocabelo", TipoCabelo );
            command.Parameters.Add("@corpele", CorPele);
            command.Parameters.Add("@apdental", AparelhoDental);
            command.Parameters.Add("@ctps", Ctps);
            command.Parameters.Add("@widcolaborador ", IdUsuario);
            command.Parameters.Add("@responsavel ", Responsavel);
            command.Parameters.Add("@cpfresp ", CpfResp);
            command.Parameters.Add("@certnascimento ", CertNascimento);
            command.Parameters.Add("@livro ", Livro);

        }

        public string NAME
        {
            get { return "p_RegistraPessoaFigurante"; }
        }
    }

    public class P_RecuperaFigurantePorId : IStoredProcedureContext
    {
        public int IdPessoa { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpessoa", IdPessoa);
        }

        public string NAME
        {
            get { return "p_RecuperaFigurantePorId"; }
        }
    }

    public class P_UnificaFigurante : IStoredProcedureContext
    {
        public int IdPessoaC { get; set; }
        public int IdPessoaE { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idcerto", IdPessoaC);
            command.Parameters.Add("@iderrado", IdPessoaE);

        }

        public string NAME
        {
            get { return "p_UnificaFigurante"; }
        }
    }

    public class P_ListaFiguranteDisponivelParaPedido : IStoredProcedureContext
    {
        public int IdPedido { get; set; }
        public int IdTipoConsulta { get; set; }
        public string Dado { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@idpedido", IdPedido);
            command.Parameters.Add("@dado", Dado);
            command.Parameters.Add("@tipoconsulta", IdTipoConsulta);

        }

        public string NAME
        {
            get { return "p_listaFiguranteDisponivelParaPedido"; }
        }
    }

    public class P_ListaFigurantes : IStoredProcedureContext
    {
        public int Status { get; set; }
        public string Nome { get; set; }
        public int IdPessoa { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@dado", Nome);
            command.Parameters.Add("@status", Status);
            command.Parameters.Add("@idpessoa", IdPessoa);
        }

        public string NAME
        {
            get { return "p_listaFigurante"; }
        }
    }

    public class P_ListaFiguranteParaUnificar : IStoredProcedureContext
    {
        public string Nome { get; set; }
        public int IdPessoa { get; set; }

        public void AddParameters(SqlCommand command)
        {
            command.Parameters.Add("@dado", Nome);
            command.Parameters.Add("@idpessoa", IdPessoa);
        }

        public string NAME
        {
            get { return "p_listaFiguranteParaUnificar"; }
        }
    }

    public class FiguranteDao : BaseDao<Figurante>
    {
        protected override string GetDeleteCommand(Figurante entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetExistsCommand(Figurante entidade)
        {
            throw new NotImplementedException();
        }

        protected override string GetInsertCommand(Figurante entidade)
        {
            throw new NotImplementedException();
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

        protected override string GetUpdateCommand(Figurante entidade)
        {
            throw new NotImplementedException();
        }

        protected override Figurante Hydrate(SqlDataReader reader)
        {
            return new Figurante()
            {
                IdPessoa = Convert.ToInt32(reader[0].ToString()),
                Nome = reader[1].ToString(),
                Nascimento = Convert.ToDateTime(reader[2].ToString()),
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
                Cpf = reader[14].ToString(),
                Rg = reader[15].ToString(),
                Expedicao = reader[16].ToString(),
                Pis = reader[17].ToString(),
                IdCidade = Convert.ToInt32(reader[18].ToString()),
                IdEstado = Convert.ToInt32(reader[19].ToString()),
                Acesso = reader[20].ToString(),
                Pasta = reader[21].ToString(),
                Nacionalidade = reader[22].ToString(),
                EstadoCivil = reader[23].ToString(),
                NomeArtistico = reader[24].ToString(),
                Mae = reader[25].ToString(),
                Pai = reader[26].ToString(),
                Profissao = reader[27].ToString(),
                RegistroArtistico = reader[28].ToString(),
                AtuaComoFigurante = Convert.ToInt32(reader[29].ToString()),
                AtuaComoAtor = Convert.ToInt32(reader[30].ToString()),
                AtuaComoModelo = Convert.ToInt32(reader[31].ToString()),
                Altura = reader[32].ToString(),
                IdadeAparente = reader[33].ToString(),
                Peso = reader[34].ToString(),
                TipoEtnico = reader[35].ToString(),
                Manequim = reader[36].ToString(),
                Calcado = reader[37].ToString(),
                Busto = reader[38].ToString(),
                Quadril = reader[39].ToString(),
                Cintura = reader[40].ToString(),
                SemelhancaComCelebridade = reader[41].ToString(),
                CorOlhos = reader[42].ToString(),
                Cabelo = reader[43].ToString(),
                CorCabelo = reader[44].ToString(),
                TipoCabelo = reader[45].ToString(),
                CorPele = reader[46].ToString(),
                UsaAparelho = Convert.ToInt32(reader[47].ToString()),
                IdFirma  = Convert.ToInt32(reader[48].ToString()),
                NumProcesso = reader[49].ToString(),
                Menor = Convert.ToInt32(reader[50].ToString()),
                Responsavel = reader[51].ToString(),
                CpfResp = reader[52].ToString(),
                CertNascimento = reader[53].ToString(),
                Livro = reader[54].ToString()

            };
        }
    }
}
