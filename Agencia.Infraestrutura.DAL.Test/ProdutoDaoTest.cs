using System;
using Agencia.Dominio.Modelo;
using NUnit.Framework;
using System.Text;

namespace Agencia.Infraestrutura.DAL.Test
{
    [TestFixture]
    public class ProdutoDaoTest
    {
        ProdutoDao _produtoDao;
        
        [SetUp]
        public void SetUp()
        {
            _produtoDao = new ProdutoDao();
            ExcluiProduto();
        }

        [TearDown]
        public void TearDown()
        {
            ExcluiProduto();
        }

        private void ExcluiProduto()
        {
            _produtoDao.OpenConnection();
            _produtoDao.Execute("delete from programa");
            _produtoDao.CloseConnection();
        }

        private void InsereProduto()
        {
            var produto = new Produto { Data = DateTime.Now, Descricao = "NOVA INCLUSÃO", Observacao = "OBS DE TESTE" };

            _produtoDao.OpenConnection();
            _produtoDao.Insert(produto);
            _produtoDao.CloseConnection();

        }
        
        [Test]
        public void RegistraNovoProduto()
        {
            var produto = new Produto
            {
                Data = DateTime.Now,
                Descricao = "NOVAINCLUSÃO",
                Observacao = "OBS DE TESTE",
                Status = "1"
            };
            _produtoDao.OpenConnection();
            _produtoDao.Insert(produto);

            var produtoRecuperado = _produtoDao.ObterPelaDescricao("NOVAINCLUSÃO");
            
            _produtoDao.CloseConnection();

            Assert.AreEqual(produtoRecuperado.Descricao, produto.Descricao);
            Assert.AreEqual(produtoRecuperado.Observacao, produto.Observacao);
        }

        [Test]
        public void AlteraProduto()
        {
            var produto = new Produto { Data = DateTime.Now, Descricao = "NOVA INCLUSÃO", Observacao = "OBS DE TESTE", Status = "1" };

            _produtoDao.OpenConnection();
            _produtoDao.Insert(produto);

            //Recupera produto 
            var produtoRecuperado = _produtoDao.ObterPelaDescricao("NOVA INCLUSÃO");

            //Altera produto registrado
            produtoRecuperado.Descricao = "INCLUSÃO ALTERADA";
            
            _produtoDao.Update(produtoRecuperado);

            var result = _produtoDao.Exists(produtoRecuperado);
            _produtoDao.CloseConnection();

            Assert.AreEqual(result, true);
        }
    }
}
