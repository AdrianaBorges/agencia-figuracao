using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using System.Collections.Generic;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeProdutos
    {
        private const int Idformulario = 8;
        private ProdutoDao _dao;

        public RepositorioDeProdutos()
        {
            _dao = new ProdutoDao();
        }

        public DataTable ObterListaDeProdutos(int idusuario, string dado)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_Carrega_Grid_Produto() { Descricao = dado });
        
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public DataTable ObterListaDeProdutos(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_Carrega_Combo_Produto());

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public DataTable ObterListaDeProdutosComAlvara(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_Carrega_Combo_Produto_ComAlvara());

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }



        public DataTable ObterListaDePedidosPorProduto(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_Lista_Pedido_Por_Produto() { Id = id });
                
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        public DataTable ObterListaDeProdutoDisponivelParaColaborador(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable("Select p.idprograma, p.descricao From Programa p order by p.descricao");

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }


        /// <summary>
        /// Retorna Produto pelo Id
        /// </summary>
        /// <param name="idusuario"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Produto ObterProdutoPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.ObterPeloId(id); 
                
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);

            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        /// <summary>
        /// Insere produto quando o mesmo não existir na base de dados
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>string vazia quando operação efetuada com sucesso</returns>
        public void InsereProduto(Produto produto)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Insert(produto);
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(produto.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        /// <summary>
        /// Altera produto quando o mesmo constar na base de dados
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>string vazia quando operação efetuada com sucesso</returns>
        public void AlteraProduto(Produto produto)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Update(produto);
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(produto.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        /// <summary>
        /// Deleta o produto quando não existirem pedidos ou colaboradores ligados a ele
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>string vazia quando operação efetuada com sucesso</returns>
        public void ExclusaoLogica(Produto produto)
        {
            try
            {
                if (ProdutoLigadoAPedido(produto.IdPrograma))
                {
                    throw new Exception(string.Format("Existem Pedidos para o Produto informado. Produto não pode ser excluído."));
                }

                if (ProdutoLigadoAPessoa(produto.IdPrograma))
                {
                    throw new Exception(string.Format("Existem Colaboradores atuando no Produto informado. Produto não pode ser excluído."));
                }

                _dao.OpenConnection();
                _dao.Execute(string.Format ("Update Programa set status = 0 where idprograma = {0}", produto.IdPrograma)); 
                
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(produto.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        static public partial class Retorna
        {
            static public string IdPrograma(string parametro)
            {
                var _dao = new ProdutoDao();
                try
                {
                    _dao.OpenConnection();
                    var result = _dao.GetValue("Select REPLICATE('0', 5 - LEN(idprograma)) + RTrim(idprograma) as idprograma From Programa where descricao = '" + parametro + "'"); 
                
                    return result;
                }
                catch (Exception ex)
                {
                    RegistraLogErro.LogAplicacao(32, Idformulario, "Erro : " + ex.Message);
                    throw new Exception("Erro : " + ex.Message);
                }
                finally
                {
                    _dao.CloseConnection();
                }

            }
        }

        /// <summary>
        /// Verifica se existem colaboradores atuando para o produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ProdutoLigadoAPessoa(int id)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.ExistsValue(string.Format("Select idpessoa From ProgramaColaborador Where idprograma = {0}", id));

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);

            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        /// <summary>
        /// Verifica se existem pedidos para o produto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ProdutoLigadoAPedido(int id)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.ExistsValue(string.Format("select top 1 idpedido from pedido where idprograma = {0}", id));

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);

            }
            finally
            {
                _dao.CloseConnection();
            }

        }

    }
}
