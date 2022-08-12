using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeFigurantesPedidos
    {
        private const int Idformulario = 2;
        private FiguracaoPedidoDao _dao;

        public RepositorioDeFigurantesPedidos()
        {
            _dao = new FiguracaoPedidoDao();
        }

        public string ObterValorInss(int idusuario, int idpessoa, DateTime gravacao, int idtipo, string cache)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetValue(new P_RetornaValorInss() { IdPessoa = idpessoa, DataGravacao = gravacao, IdTipo = idtipo, ValorCache = cache });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }


        public DataTable ObterListaDeFiguracaoPedido(int idusuario, int idpedido)
        {
            try
            {
                using (var db = new DB (true))
                {
                    return db.GetDataTable(new P_ListaPedidoFigurante() { IdPedido = idpedido });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterDadosRecibo(int idusuario, int idpessoa, string nrrb)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_RecuperaDadosRecibo() { IdPessoa = idpessoa, Nrrb = nrrb });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterListaDeReciboProvisorio(int idusuario, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaReciboProvisorio() { IdPessoa = idpessoa });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterListaDeFigurante(int idusuario, int idfirma, string nome, string idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaPesquisaFigurantePendente() { IdFirma = idfirma, Nome = nome, IdPessoa = idpessoa });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterFigurantePorFirma(int idusuario, int idfirma, string nome, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaFigurantePorFirma() { IdFirma = idfirma, Nome = nome, IdPessoa = idpessoa });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterReciboFigurantePorFirma(int idusuario, int idfirma, string nome, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaReciboDeFigurantePorFirma() { IdFirma = idfirma, Nome = nome, IdPessoa = idpessoa });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }


        public DataTable ObterPosicaoDeCache(int idusuario, int idfirma, string nome, string idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaPosicaoCache() { IdFirma = idfirma, Nome = nome, IdPessoa = idpessoa });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterListaDeRecibos(int idusuario, int idnota, string nome, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaReciboFigurante() { IdNota = idnota, IdPessoa = idpessoa, Nome = nome });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterListaDeReciboPorFirma(int idusuario, int idfirma, string nome, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaReciboDeFigurantePorFirma() { IdFirma = idfirma, IdPessoa = idpessoa, Nome = nome });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }
        public DataTable ObterListaDeRecibos(int idusuario, string nome, int idpessoa, Nullable<DateTime> de, Nullable<DateTime> ate, int idfirma)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaReciboInformeINSS() { IdPessoa = idpessoa, Nome = nome, De = de, Ate = ate, IdFirma = idfirma });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterListaDeFigurantePorNota(int idusuario, int idnota, string nome)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaFigurantePorNota() { IdNota = idnota, Nome = nome });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterListaDeRecibosCache(int idusuario, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaRecibosCache() { IdPessoa = idpessoa });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterListaDeCachePendente(int idusuario, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaCachePendente() { IdPessoa = idpessoa });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterListaDeCachePendenteSemRecibo(int idusuario, int idpessoa, int idfirma)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaCachePendenteSemRecibo() { IdPessoa = idpessoa, IdFirma = idfirma });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterListaDeCachePago(int idusuario, int idpessoa, decimal recibo)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaCachePago() { IdPessoa = idpessoa, Recibo = recibo });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public DataTable ObterValorTotalDeCachePendente(int idusuario, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaValorTotalCachePendente() { IdPessoa = idpessoa });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }


        public DataTable ObterValorTotalDeCachePago(int idusuario, int idpessoa, decimal recibo)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaValorTotalCachePago() { IdPessoa = idpessoa, Recibo = recibo });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public PedidoFigurante ObterFiguracaoPedido(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.Get(new P_RecuperaPedidoFigurante() { IdFigPedido = id });
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

        public void RegistraBaixa(int idusuario, int idpessoa, int idfigpedido, DateTime databaixa, decimal recibo)
        {
            try
            {
                _dao.OpenConnection();

                _dao.Execute(new P_RegistraBaixaCache() { IdPessoa = idpessoa, IdFigPedido = idfigpedido, DataBaixa = databaixa, Recibo = recibo });
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

        public void RegistraBaixaPorReciboProvisorio(int idusuario, int idpessoa, DateTime databaixa, decimal recibo)
        {
            try
            {
                _dao.OpenConnection();

                _dao.Execute(new P_RegistraBaixaCachePorRecibo() { IdPessoa = idpessoa, DataBaixa = databaixa, Recibo = recibo });
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

        public void GeraNumeroRecibo(int idusuario, int idpessoa, decimal recibo, DateTime data)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Execute(string.Format("Insert Into tmpRecibo (idpessoa, data, recibo) Values ({0}, '{1}', {2})", idpessoa, data.ToString("yyyy/MM/dd"), recibo));

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

        public void ReciboProvisorio(int idusuario, int idpessoa, int idfigpedido, decimal recibo, int idpedido)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Execute(string.Format("Insert Into tmpPgto (recibo, idpessoa, idregistro, idpedido) Values ({0}, {1}, {2}, {3})", recibo, idpessoa, idfigpedido, idpedido));

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

        public void ExcluiReciboProvisorio(int idusuario, decimal recibo, int idpessoa)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Execute(string.Format("Delete from tmpRecibo where recibo = {0} and idpessoa = {1}", recibo, idpessoa));
                _dao.Execute(string.Format("Delete from tmpPgto where recibo = {0} and idpessoa = {1}", recibo, idpessoa));

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

        public void Insere(PedidoFigurante fp)
        {
            try
            {
                if (!FiguracaoPedidoExiste(fp.IdPedido, fp.IdPessoa, fp.IdTipo))
                {
                    _dao.OpenConnection();
                    _dao.Insert(fp);
                }
                else
                {
                    throw new Exception(string.Format("Figurante já constã para o Pedido informado."));
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(fp.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar o Figurante para o Pedido Gravação solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Altera(PedidoFigurante fp)
        {
            try
            {
                if (FiguracaoPedidoExiste(fp.IdFigPedido))
                {
                    _dao.OpenConnection();
                    _dao.Update(fp);
                }
                else
                {
                    throw new Exception(string.Format("Figurante não constã para o Pedido informado."));
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(fp.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível alterar o Figurante para o Pedido Gravação solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Exclui(PedidoFigurante fp)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Delete(fp);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(fp.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível excluir o Figurante do Pedido de Gravação informado." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public bool FiguracaoPedidoExiste(int idpedido, int idpessoa, int idtipo)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.ExistsValue(string.Format("Select id From PedidoFigurante Where idpedido = {0} and idpessoa = {1} and idtipo = {2}", idpedido, idpessoa, idtipo));
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro : " + ex.Message);
            }
        }

        public void InsereReciboTemp(int idusuario, int idfirma, int idpessoa, string nrrb)
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(string.Format("Insert into tmpRecGrupo (idfirma, idpessoa, nrrb) Values ({0}, {1}, {2})", idfirma, idpessoa, nrrb));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar Recibo temporário. " + ex.Message);
            }
        }

        public void DeleteReciboTemp()
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(string.Format("DELETE FROM tmpRecGrupo"));

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível registrar Recibo temporário. " + ex.Message);
            }
        }
        public void RegistraEnvioDeRecibo(int idusuario, int idpessoa, string nrrb, string email)
        {
            try
            {
                using (var db = new DB(true))
                {
                    var data = DateTime.Now;
                    db.Execute(string.Format("Insert into reciboenviado (dtenvio, idpessoa, nrrb, email) Values ('{0}', {1}, '{2}', '{3}')", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), idpessoa, nrrb, email));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar Recibo temporário. " + ex.Message);
            }
        }

        public void DeletaReciboTemp(int idusuario)
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(string.Format("delete from tmpRecGrupo"));
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível limpar a tabela de Recibo temporário. " + ex.Message);
            }
        }

        public bool FiguracaoPedidoExiste(int id)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.ExistsValue(string.Format("Select id From PedidoFigurante Where id = {0}", id));
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro : " + ex.Message);
            }
        }

        public string TotalDeFiguracaoSolicitados(int idpedido)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetValue(string.Format("select coalesce(sum(qtd),0) from pedqtdfigurante Where idpedido = {0}", idpedido));
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro : " + ex.Message);
            }
        }

        /// <summary>
        /// verifica se o figurante já foi registrado no pedido para o tipo de figuração informado
        /// </summary>
        /// <param name="idtipo"></param>
        /// <param name="idpedido"></param>
        /// <param name="idpessoa"></param>
        /// <returns></returns>
        public bool FiguranteCadastradoNoPedidoTipoFiguracao(int idtipo, int idpedido, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.ExistsValue(string.Format("Select id From PedidoFigurante Where idtipo = {0} and idpedido = {1} and idpessoa = {2}", idtipo, idpedido, idpessoa));
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro : " + ex.Message);
            }
        }

        static public class Executa
        {
            static public void ReciboManual()
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        db.Execute(new P_GeracaoManualRecibo() { });
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro : " + ex.Message);
                }
            }

        }

        static public class Retorna
        {
            static public string IdFiguracaoPedido(PedidoFigurante fp)
            {
                var _dao = new PedidoDao();
                try
                {
                    _dao.OpenConnection();
                    return _dao.GetValue("Select REPLICATE('0', 5 - LEN(id)) + RTrim(id) as id From PedidoFigurante where idpedido = " + fp.IdPedido + " and idpessoa = " + fp.IdPessoa + " and idtipo = " + fp.IdTipo + "");

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

            static public decimal ValorInss(int idusuario, int idpessoa, DateTime gravacao, int idtipo, string cache)
            {
                var _dao = new FiguracaoPedidoDao();

                try
                {
                    using (var db = new DB(true))
                    {
                        var valor = db.GetValue(new P_RetornaValorInss() { IdPessoa = idpessoa, DataGravacao = gravacao, IdTipo = idtipo, ValorCache = cache });


                        return Convert.ToDecimal(db.GetValue(new P_RetornaValorInss() { IdPessoa = idpessoa, DataGravacao = gravacao, IdTipo = idtipo, ValorCache = cache }));
                    }
                }
                catch (Exception ex)
                {
                    RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                    throw new Exception("Erro : " + ex.Message);
                }
               
            }
        }
    }
}
