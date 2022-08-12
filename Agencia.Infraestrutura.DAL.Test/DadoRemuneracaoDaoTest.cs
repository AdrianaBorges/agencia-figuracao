using System;
using Agencia.Dominio.Modelo;
using NUnit.Framework;
using System.Text;
using System.Data.SqlClient;

namespace Agencia.Infraestrutura.DAL.Test
{
    [TestFixture]
    public class DadoRemuneracaoDaoTest
    {
        DadoRemuneracaoDao _dadoRemuneracaoDao;

        [SetUp]
        public void SetUp()
        {
            _dadoRemuneracaoDao = new DadoRemuneracaoDao();

        }

        [TearDown]
        public void TearDown()
        {
            ExcluiDadoRemuneracao();
        }

        private void ExcluiDadoRemuneracao()
        {
            _dadoRemuneracaoDao.OpenConnection();
            _dadoRemuneracaoDao.Execute("Delete from dadoremuneracao where idpessoa = 525 and idremuneracao = 8");
            _dadoRemuneracaoDao.CloseConnection();
            
        }

        [Test]
        public void RegistraNovaRemuneracao()
        {
            //Registra
            var dado = new DadoRemuneracao { IdPessoa = 525, IdRemuneracao = 8, Valor = Convert.ToDecimal("500")};

            _dadoRemuneracaoDao.OpenConnection();
            _dadoRemuneracaoDao.Insert(dado);

            //Recupera
            var exist = _dadoRemuneracaoDao.ExistsValue("Select id From DadoRemuneracao Where idpessoa = 525 and idremuneracao = 8");

            _dadoRemuneracaoDao.CloseConnection();

            //Testa
            Assert.True(exist); 
        }

        [Test]
        public void AlteraDadoRemuneracao()
        {
            //Registra
            var dado = new DadoRemuneracao { IdPessoa = 525, IdRemuneracao = 8, Valor = Convert.ToDecimal("500") };

            _dadoRemuneracaoDao.OpenConnection();
            _dadoRemuneracaoDao.Insert(dado);

            //Recupera
            var dadoRecuperado = _dadoRemuneracaoDao.Obter(dado);

            //Altera
            dadoRecuperado.Valor = Convert.ToDecimal("650");
            _dadoRemuneracaoDao.Update(dadoRecuperado);

            //Recupera dado alterado
            var exist = _dadoRemuneracaoDao.ExistsValue("Select id From DadoRemuneracao Where idpessoa = 525 and idremuneracao = 8 and valor = '650.00'");

            _dadoRemuneracaoDao.CloseConnection();

            //Testa
            Assert.True(exist); 
        }

    }
}
