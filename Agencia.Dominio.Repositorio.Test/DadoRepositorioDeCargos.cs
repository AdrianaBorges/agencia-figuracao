using System;
using Agencia.Dominio.Modelo;
using NUnit.Framework;
using Agencia.Infraestrutura.DAL;
using System.Data;

namespace Agencia.Dominio.Repositorio.Test
{
    [TestFixture]
    public class DadoRepositorioDeCargos
    {
        private CargoDao _cargoDao;
        private RepositorioDeCargos _repositorioDeCargos;

        [SetUp]
        public void SetUp()
        {
            _cargoDao = new CargoDao();
            _repositorioDeCargos = new RepositorioDeCargos();

            ExcluiCargo();

        }

        [TearDown]
        public void TearDown()
        {

        }

        private void ExcluiCargo()
        {
            _cargoDao.OpenConnection();
            _cargoDao.Execute("delete from cargo");
            _cargoDao.CloseConnection();
        }

        [Test]
        public void ObtemListaDeCargoAtravesDeProcedure()
        {
            var _repositorioDeCargos = new RepositorioDeCargos();

            //Cria registro na tabela 
            var cargo = new Cargo {IdCargo = 15, Descricao = "TESTEDEINCLUSÃO", IdPermissao = 3};

            _cargoDao.OpenConnection();
            _cargoDao.Insert(cargo);

            //Recupera valor
            var dataTable = _repositorioDeCargos.ObterListaDeCargo(32);  

            _cargoDao.CloseConnection();

            if (dataTable == null) Assert.Fail();
            if (dataTable.Rows.Count == 0) Assert.Fail();

            foreach (DataRow row in dataTable.Rows)
            {
                Assert.AreEqual(15, Convert.ToInt32(row.ItemArray[0].ToString()));
                Assert.AreEqual("TESTEDEINCLUSÃO", row.ItemArray[1].ToString());
                Assert.AreEqual(3, Convert.ToInt32(row.ItemArray[2].ToString()));

            }

        }

    }
}
