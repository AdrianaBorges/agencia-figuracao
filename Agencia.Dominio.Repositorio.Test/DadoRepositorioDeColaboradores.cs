using System;
using Agencia.Dominio.Modelo;
using NUnit.Framework;
using Agencia.Infraestrutura.DAL;
using System.Data.SqlTypes;

namespace Agencia.Dominio.Repositorio.Test
{
    [TestFixture]
    public class DadoRepositorioDeColaboradores
    {
        private ColaboradorDao _colaboradorDao;
        private RepositorioDeColaboradores _repositorioDeColaborador;

        [SetUp]
        public void SetUp()
        {
            _colaboradorDao = new ColaboradorDao();
            _repositorioDeColaborador = new RepositorioDeColaboradores();

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void InsereNovoColaborador()
        {
            _colaboradorDao.OpenConnection();

            _colaboradorDao.Execute("Delete From pessoa Where idpessoa <> 2");
            _colaboradorDao.Execute("Delete From colaborador Where idpessoa <> 2");

            var colaborador = new Colaborador()
            {
                IdTipoPessoa = 1,
                Nome = "ADRIANA BORGES",
                Sexo = "F",
                Nascimento = Convert.ToDateTime("25/08/1973"),
                Cadastro = Convert.ToDateTime("12/02/2014"),
                Status = "1",
                IdBairro = 1,
                Logradouro = "RUA RAUL BARROSO, 33",
                Complemento = "CASA 1 APT 201",
                Cep = "20710190",
                Cpf = "02547718740",
                Rg = "100656461",
                Cnpj = "",
                Expedicao = "",
                Pis = "",
                Ctps = "",
                Serie = "",
                CartReservista = "",
                Fixo = "",
                Celular = "2194653771",
                Contato = "",
                Email = "fonsecaborges@outlook.com",
                IdCargo = 5,
                Desligamento = null,
                Clt = 0,
                Comissao = 1
            };

            _repositorioDeColaborador.Insere(colaborador);

            var id = RepositorioDeColaboradores.Retorna.IdColaborador(colaborador.Nome);

            //Recupera colaborador
            var colaboradorRecuperado = _repositorioDeColaborador.ObterPessoaPorId(32, Convert.ToInt32(id));

            var exist = _colaboradorDao.Exists(colaboradorRecuperado);

            _colaboradorDao.CloseConnection();

            Assert.AreEqual(exist, true);
        }


        [Test]
        public void AlteraColaborador()
        {
            _colaboradorDao.OpenConnection();

            _colaboradorDao.Execute("Delete From pessoa Where idpessoa <> 2");
            _colaboradorDao.Execute("Delete From colaborador Where idpessoa <> 2");

            var colaborador = new Colaborador()
            {
                IdTipoPessoa = 1,
                Nome = "ADRIANA BORGES",
                Sexo = "F",
                Nascimento = Convert.ToDateTime("25/08/1973"),
                Cadastro = Convert.ToDateTime("12/02/2014"),
                Status = "1",
                IdBairro = 1,
                Logradouro = "RUA RAUL BARROSO, 33",
                Complemento = "CASA 1 APT 201",
                Cep = "20710190",
                Cpf = "02547718740",
                Rg = "100656461",
                Cnpj = "",
                Expedicao = "",
                Pis = "",
                Ctps = "",
                Serie = "",
                CartReservista = "",
                Fixo = "",
                Celular = "2194653771",
                Contato = "",
                Email = "fonsecaborges@outlook.com",
                IdCargo = 5,
                Desligamento = null,
                Clt = 0,
                Comissao = 1
            };

            _repositorioDeColaborador.Insere(colaborador);

            var id = RepositorioDeColaboradores.Retorna.IdColaborador(colaborador.Nome);

            //Recupera colaborador
            var colaboradorRecuperado = _repositorioDeColaborador.ObterPessoaPorId(32, Convert.ToInt32(id));

            //Altera colaborador registrado
            colaboradorRecuperado.Fixo = "2122419214";

            _repositorioDeColaborador.Altera(colaboradorRecuperado);

            var result = _colaboradorDao.Exists(colaboradorRecuperado);

            _colaboradorDao.CloseConnection();

            Assert.AreEqual(result, true);
        }

    }
}
