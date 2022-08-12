using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeCartasFaturas
    {
        private const int Idformulario = 9;
        CartaFaturaDao _dao;

        public RepositorioDeCartasFaturas()
        {
            _dao = new CartaFaturaDao();
        }

        public DataTable ObterListaDeCartasFaturas(int idusuario, string numcarta, int idfirma)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaCartaFatura() { NumeroFatura = numcarta, IdFirma = idfirma });
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

        public DataTable ObterListaDeCartasFaturasParaNotaFiscal(int idusuario, int idfirma, int idnota)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaFaturaParaNotaFiscal() { IdFirma = idfirma, IdNota = idnota });
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

        public CartaFatura ObterCartaFaturaPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.Get(new P_RecuperaCartaFatura() { IdCartaFatura = id });

                return result;
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

        public void InserePedido(int idusuario, int idcartafatura, int idpedido)
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(string.Format("Update Pedido set idcartafatura = {0} where idpedido = {1}", idcartafatura, idpedido));
 
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar o Pedido para a Carta Fatura. " + ex.Message);
            }
        }

        public void ExcluiPedido(int idusuario, int idpedido)
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(string.Format("Update Pedido set idcartafatura = 0 where idpedido = {0}", idpedido));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar o Pedido para a Carta Fatura. " + ex.Message);
            }
        }


        public void Insere(CartaFatura carta)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Insert(carta);
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(carta.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar a Carta Fatura. " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Altera(CartaFatura carta)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Update(carta);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(carta.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível alterar a Carta Fatura." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Exclui(CartaFatura carta)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Delete(carta);
                _dao.Execute(string.Format("Update Pedido set idcartafatura = 0 where idcartafatura = {0}", carta.IdCartaFatura));

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(carta.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível excluir a Carta Fatura informada." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public bool CartaFaturaExiste(int numcarta, int idprograma)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.ExistsValue(string.Format("Select idcartafatura From CartaFatura Where numcarta = {0} and idprograma = {1}", numcarta, idprograma));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public bool CartaFaturaExiste(int idcartafatura)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.ExistsValue(string.Format("Select idcartafatura From CartaFatura Where idcartafatura = {0}", idcartafatura));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        static public class Retorna
        {
            static public string IdCartaFatura(int numcarta, int idprograma)
            {
                var _dao = new PedidoDao();
                try
                {
                    _dao.OpenConnection();
                    return _dao.GetValue("Select REPLICATE('0', 5 - LEN(idcartafatura)) + RTrim(idcartafatura) as idcartafatura From CartaFatura where numcarta = " + numcarta + " and idprograma = " + idprograma + "");
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
