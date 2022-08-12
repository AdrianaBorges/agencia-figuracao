using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDePedidos
    {
        private const int Idformulario = 9;
        PedidoDao _dao;

        public RepositorioDePedidos()
        {
            _dao = new PedidoDao();
        }

        public DataTable ObterListaDePedidos(int idusuario, string numpedido, int idproduto)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaPedidos() { NumeroPedido = numpedido, IdProduto = idproduto });

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

        public DataTable ObterListaDePedidosPorFatura(int idusuario, int idcartafatura)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaPedidoPorFatura() { IdCartaFatura = idcartafatura});

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

        public DataTable ObterListaDePedidosDisponiveis(int idusuario, int idcartafatura, DateTime de, DateTime ate)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaPedidoDisponivel() { IdCartaFatura = idcartafatura, De = de, Ate = ate });

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

        public Pedido ObterPedidoPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.Get(new P_RecuperaPedidoPorId() { IdPedido = id });

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

        public string ObterIdPedido(int idusuario, string numpedido, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetValue("SELECT p.idpedido From Pedido p inner join pedidofigurante pf on pf.idpedido = p.idpedido Where p.numpedido = '" + numpedido + "' and pf.idpessoa = " + idpessoa + "");
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void Insere(Pedido p)
        {
            try
            {
                _dao.OpenConnection();

                _dao.Execute(new P_RegistraPedido()
                {
                    Operacao = "INSERT",
                    IdFirma = p.IdFirma,
                    IdPedido = p.IdPedido,
                    Extra = p.Extra,
                    DtCadastro = p.DataCadastro,
                    NumPedido = p.NumPedido,
                    IdEmpresa = p.IdEmpresa,
                    IdPrograma = p.IdPrograma,
                    DtPedido = p.DataPedido,
                    Hora = p.Hora,
                    HoraIni = p.HoraInicio,
                    HoraFim = p.HoraFim,
                    Cena = p.Cena,
                    Capitulo = p.Capitulo,
                    Observacao = p.Observacao,
                    IdUsuario = p.IdUsuario
                });

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(p.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar o Pedido de Gravação solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Altera(Pedido p)
        {
            try
            {
                if (PedidoExiste(p.IdPedido))
                {
                    _dao.OpenConnection();

                    _dao.Execute(new P_RegistraPedido()
                    {
                        Operacao = "UPDATE",
                        IdFirma = p.IdFirma,
                        IdPedido = p.IdPedido,
                        Extra = p.Extra,
                        DtCadastro = p.DataCadastro,
                        NumPedido = p.NumPedido,
                        IdEmpresa = p.IdEmpresa,
                        IdPrograma = p.IdPrograma,
                        DtPedido = p.DataPedido,
                        Hora = p.Hora,
                        HoraIni = p.HoraInicio,
                        HoraFim = p.HoraFim,
                        Cena = p.Cena,
                        Capitulo = p.Capitulo,
                        Observacao = p.Observacao,
                        IdUsuario = p.IdUsuario
                    });
                }
                else
                {
                    throw new Exception(string.Format("Pedido de Gravação informado não constã na base de dados."));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(p.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível alterar o Pedido de Gravação solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        public void ExclusaoLogica(Pedido p)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Execute(string.Format("Update Pedido set status = 0 where idpedido = {0}", p.IdPedido));

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(p.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível excluir o Pedido de Gravação solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

       

        public bool PedidoExiste(int idpedido)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.ExistsValue(string.Format("Select idpedido From Pedido Where idpedido = {0}", idpedido));
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro : " + ex.Message);
            }
        }

        static public class Retorna
        {
            static public string IdPedido(string numpedido)
            {
                var _dao = new PedidoDao();
                try
                {
                    _dao.OpenConnection();
                    return _dao.GetValue("Select REPLICATE('0', 5 - LEN(idpedido)) + RTrim(idpedido) as idpedido From Pedido where numpedido = '" + numpedido + "'");

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
