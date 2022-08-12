using System;
using Agencia.Dominio.Modelo;
using NUnit.Framework;
using Agencia.Infraestrutura.DAL;
using System.Data;

namespace Agencia.Dominio.Repositorio.Test
{
    [TestFixture]
    public class DadoRepositorioDeProduto
    {
        private ProdutoDao _produtoDao;
        private RepositorioDeProdutos _repositorioDeProduto;
        
        [SetUp]
        public void SetUp()
        {
            _produtoDao = new ProdutoDao();
            _repositorioDeProduto = new RepositorioDeProdutos();

            ExcluiProduto();
            ExcluiPedido();
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

        private void ExcluiPedido()
        {
            _produtoDao.OpenConnection();
            _produtoDao.Execute("delete from pedido");
            _produtoDao.CloseConnection();
        }


      //  [Test]
      //  public void ExistePedidoParaOProduto()
      //  {
      //      var produto = new Produto { Data = DateTime.Now, Descricao = "NOVO PROGRAMA", Observacao = "OBS DE TESTE", Status = "1" };

//            _produtoDao.OpenConnection();
 //           _produtoDao.Insert(produto);
   //         //Recupera produto 
     //       var produtoRecuperado = _produtoDao.ObterPelaDescricao("NOVO PROGRAMA");
      //      //Registra pedido para o produto
       //     _produtoDao.Execute(string.Format("insert into pedido (numpedido, idprograma) values ('{0}', {1})", "TESTEREGISTRO", produtoRecuperado.IdPrograma));
//
  //          var result = _repositorioDeProduto.ProdutoExiste(produtoRecuperado.Descricao);
   //         
    //        _produtoDao.CloseConnection();
        //
          //  Assert.IsTrue(result); 
        //}

        //[Test]
        //public void ProdutoNaoPodeSerExcluidoQuandoLigadoAColaborador()
        //{
        //    var produto = new Produto { Data = DateTime.Now, Descricao = "NOVO PROGRAMA", Observacao = "OBS DE TESTE", Status = "1" };

        //    _produtoDao.OpenConnection();
        //    _produtoDao.Insert(produto);
        //    //Recupera produto
        //    var produtoRecuperado = _produtoDao.ObterPelaDescricao("NOVO PROGRAMA");
            
        //    //Registra colaborador para o produto
        //    _produtoDao.Execute(string .Format ("Insert into programacolaborador (idprograma, idpessoa, dtregistro) values ({0}, {1}, '{2}')", produtoRecuperado.IdPrograma, 32, DateTime .Now.ToString("MM/dd/yyyy HH:mm:ss")));
            
        //    //Chamada ao método de exclusão
        //    var result = _repositorioDeProduto.ExclusaoLogica(produtoRecuperado);

        //    _produtoDao.CloseConnection();

        //    Assert.IsNotNullOrEmpty(result);

        //}

        //[Test]
        //public void ProdutoNaoPodeSerExcluidoQuandoLigadoAPedido()
        //{
        //    var produto = new Produto { Data = DateTime.Now, Descricao = "NOVO PROGRAMA", Observacao = "OBS DE TESTE", Status = "1" };

        //    _produtoDao.OpenConnection();
        //    _produtoDao.Insert(produto);
        //    //Recupera produto
        //    var produtoRecuperado = _produtoDao.ObterPelaDescricao("NOVO PROGRAMA");

        //    //Registra colaborador para o produto
        //    _produtoDao.Execute(string.Format("Insert into programacolaborador (idprograma, idpessoa, dtregistro) values ({0}, {1}, '{2}')", produtoRecuperado.IdPrograma, 32, DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")));
            
        //    //Registra pedido para o produto
        //    _produtoDao.Execute(string.Format("insert into pedido (numpedido, idprograma) values ('{0}', {1})", "TESTE", produtoRecuperado.IdPrograma));

        //    //Chamada ao método de exclusão
        //    var result = _repositorioDeProduto.ExclusaoLogica(32, produtoRecuperado);

        //    _produtoDao.CloseConnection();

        //    Assert.IsNotNullOrEmpty(result);

        //}

    }
}
