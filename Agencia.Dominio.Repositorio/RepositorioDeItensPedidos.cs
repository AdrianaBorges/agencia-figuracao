using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeItensPedidos
    {
        private const int Idformulario = 2;
        ItemPedidoDao _dao;

        public RepositorioDeItensPedidos()
        {
            _dao = new ItemPedidoDao();
        }

        public DataTable ObterListaItensPedidos(int idusuario, int idpedido)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaItemPedido() { IdPedido = idpedido });
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

        public DataTable ObterListaDeTiposDeFiguracao(int idusuario, int idpedido)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaTipoFiguracao() { IdPedido = idpedido });
                }

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterValoresItensPedido(int idusuario, int idpedido)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_RetornaValorPedido() { IdPedido = idpedido });
                }

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public ItemPedido ObterItemPedidoPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.Get(new P_RecuperaItemPedidoPorId() { IdItem = id });

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }

            finally
            {
                _dao.CloseConnection();
            }
        }

        public string ObtemValorItemPedido(int idusuario, int idpedido, int idtipo)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetValue("SELECT valor From pedqtdfigurante Where idpedido = " + idpedido + " and idtipo = " + idtipo + "");
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void Insere(ItemPedido item)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Insert(item);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(item.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar o Item para o Pedido Gravação solicitado. " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Altera(ItemPedido item)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Update(item);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(item.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível alterar o Item para o Pedido Gravação solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Exclui(ItemPedido item)
        {
            try
            {
                _dao.OpenConnection();

                if (!ExisteFiguracaoParaItem(item.IdPedido, item.IdTipo))
                {
                    _dao.Delete(item);

                }
                else
                {
                    throw new Exception(string.Format("Existe(m) Figurante(s) para o Item de Pedido Informado! "));
                }

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(item.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível excluir o Item de Pedido de Gravação informado. " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public bool ExisteFiguracaoParaItem(int idpedido, int idtipo)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.ExistsValue(string.Format("Select id From PedidoFigurante Where idtipo = {0} and idpedido = {1}", idtipo, idpedido));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }
               
        static public class Retorna
        {
            static public string IdItemPedido(int idtipo, string valor)
            {
                var _dao = new PedidoDao();
                try
                {
                    _dao.OpenConnection();
                    return _dao.GetValue("Select REPLICATE('0', 5 - LEN(id)) + RTrim(id) as iditem From pedqtdfigurante where idtipo = " + idtipo + " and valor = '" + valor + "'");

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

    }
}
