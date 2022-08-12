using System;
using Agencia.Dominio.Modelo;
using NUnit.Framework;
using Agencia.Infraestrutura.DAL;
using System.Data;

namespace Agencia.Dominio.Repositorio.Test
{
    [TestFixture]
    public class DadoRepositorioDeDadosBancarios
    {
        private DadoBancarioDao _dadoBancarioDao;
        private RepositorioDeDadosBancarios _repositorioDeDadoBancario;
        private RepositorioDeColaboradores _repositorioDeColaborador;

        [SetUp]
        public void SetUp()
        {
            _dadoBancarioDao = new DadoBancarioDao();
            _repositorioDeDadoBancario = new RepositorioDeDadosBancarios();
            _repositorioDeColaborador = new RepositorioDeColaboradores();

            ExcluiDadoBancario();
        }

        private void ExcluiDadoBancario()
        {
            _dadoBancarioDao.OpenConnection();
            _dadoBancarioDao.Execute("delete from DadoBancario");
            _dadoBancarioDao.CloseConnection();
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ObtemListaDeDadoBancarioAtravesDeProcedure()
        {
            //Cria registro na tabela
            var dadoBancario = new DadoBancario
                                   {
                                       IdPessoa = 25,
                                       Status = "1",
                                       IdBanco = 1,
                                       Tipo = "C",
                                       Agencia = "0093",
                                       NumeroConta = "04739-7",
                                       Titular = "ADRIANA BORGES"
                                   };

            _dadoBancarioDao.OpenConnection();
            _dadoBancarioDao.Insert(dadoBancario);

            //Recupera valor
            var dataTable = _repositorioDeDadoBancario.ObterListaDeDadoBancario(32, dadoBancario.IdPessoa);

            _dadoBancarioDao.CloseConnection();

            if (dataTable == null) Assert.Fail();
            if (dataTable.Rows.Count == 0) Assert.Fail();

            foreach (DataRow row in dataTable.Rows)
            {
                Assert.AreEqual("01- ATIVO", row.ItemArray[1].ToString());
                Assert.AreEqual("CORRENTE", row.ItemArray[3].ToString());
                Assert.AreEqual("0093", row.ItemArray[4].ToString());
                Assert.AreEqual("04739-7", row.ItemArray[5].ToString());
                Assert.AreEqual("ADRIANA BORGES", row.ItemArray[6].ToString());

            }
        }

//        [Test]
//        public void InsereDadoBancarioParaPessoa()
//        {
//            //Cria registro na tabela
//            var dadoBancario = new DadoBancario
//                                {
//                                    IdPessoa = 25,
//                                    Status = "1",
//                                    IdBanco = 1,
//                                    Tipo = "C",
//                                    Agencia = "0093",
//                                    NumeroConta = "04739-7",
//                                    Titular = "ADRIANA BORGES"
//                                };
//
//            _dadoBancarioDao.OpenConnection();
//            _repositorioDeDadoBancario.Insere(dadoBancario);
//            _dadoBancarioDao.CloseConnection();
//
//            var exist =  _repositorioDeDadoBancario.DadoBancarioExiste(dadoBancario);
//
//            Assert.AreEqual(exist, true);
//        }

        [Test]
        public void AlteraDadoBancarioParaPessoa()
        {
            //Cria registro na tabela
            var dadoBancario = new DadoBancario
            {
                IdPessoa = 25,
                Status = "1",
                IdBanco = 1,
                Tipo = "C",
                Agencia = "0093",
                NumeroConta = "04739-7",
                Titular = "ADRIANA BORGES"
            };

            _dadoBancarioDao.OpenConnection();
            _repositorioDeDadoBancario.Insere(dadoBancario);

            var id = RepositorioDeDadosBancarios.Retorna.IdDadoBancario(dadoBancario);
            
            //Recupera dado bancario
            var dadoBancarioRecuperado = _dadoBancarioDao.ObterPeloId(Convert.ToInt32(id));

            //Altera dado bancario registrado
            dadoBancarioRecuperado.Agencia = "0094";
            dadoBancarioRecuperado.NumeroConta = "04598-2";

            _repositorioDeDadoBancario.Altera(dadoBancarioRecuperado);

            var result = _dadoBancarioDao.Exists(dadoBancarioRecuperado);

            _dadoBancarioDao.CloseConnection();

            Assert.AreEqual(result, true);
        }

        [Test]
        public void ExcluiDadoBancarioDePessoa()
        {
            //Cria registro na tabela
            var dadoBancario = new DadoBancario
            {
                IdPessoa = 25,
                Status = "1",
                IdBanco = 1,
                Tipo = "C",
                Agencia = "0093",
                NumeroConta = "04739-7",
                Titular = "ADRIANA BORGES"
            };

            _dadoBancarioDao.OpenConnection();
            _repositorioDeDadoBancario.Insere(dadoBancario);

            var id = RepositorioDeDadosBancarios.Retorna.IdDadoBancario(dadoBancario);
            
            //Recupera dado bancario
            var dadoBancarioRecuperado = _dadoBancarioDao.ObterPeloId(Convert.ToInt32(id));

            _repositorioDeDadoBancario.Exclui(dadoBancarioRecuperado);

            var result = _dadoBancarioDao.Exists(dadoBancarioRecuperado);

            _dadoBancarioDao.CloseConnection();

            Assert.AreEqual(result, false);
        }

    }
}
