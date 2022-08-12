using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using System.Collections.Generic;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeEquipesPedidos
    {
        private const int Idformulario = 2;
        private EquipePedidoDao _dao;

        public RepositorioDeEquipesPedidos()
        {
            _dao = new EquipePedidoDao();
        }

        public DataTable ObterListaDeEquipePedido(int idusuario, int idpedido)
        {
            try
            {
                using (var db = new DB (true))
                {
                    return db.GetDataTable(new P_ListaEquipePedido() { IdPedido = idpedido });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }

        public EquipePedido ObterEquipePedidoPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.Get(new P_RecuperaEquipePedido() { IdEquipe = id });
                
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

        public void Insere(EquipePedido equipe)
        {
            try
            {
                if (!EquipePedidoExiste(equipe))
                {
                    _dao.OpenConnection();
                    _dao.Insert(equipe);

                }
                else
                {
                    throw new Exception(string.Format("Produto informado já constã na base de dados."));
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(equipe.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        
        public void Altera(EquipePedido equipe)
        {
            try
            {
                if (EquipePedidoExiste(equipe))
                {
                    _dao.OpenConnection();
                    _dao.Update(equipe);
                }
                else
                {
                    throw new Exception(string.Format("Produto não localizado na base de dados."));
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(equipe.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        
        public void Exclui(EquipePedido equipe)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Delete(equipe);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(equipe.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        static public partial class Retorna
        {
            static public string IdEquipe(EquipePedido ep)
            {
                var _dao = new EquipePedidoDao();
                try
                {
                    _dao.OpenConnection();
                    var result = _dao.GetValue("Select REPLICATE('0', 5 - LEN(id)) + RTrim(id) as id From PedidoEquipe where idpedido = " + ep.IdPedido + " and idpessoa = " + ep.IdPessoa + " and idcargo = " + ep.IdCargo + "");

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

       
        public bool EquipePedidoExiste(EquipePedido equipe)
        {
            try
            {
                using(var db = new DB (true))
                {
                    return db.ExistsValue(string.Format("Select id from PedidoEquipe Where idpedido = {0} and idpessoa = {1} and idcargo = {2}", equipe.IdPedido, equipe.IdPessoa, equipe.IdCargo));
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);

            }
        }

    }
}
