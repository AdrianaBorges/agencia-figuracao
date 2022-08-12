using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using System.Collections.Generic;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeAcesso
    {
        private int Idformulario = 2;
        private AcessoDao _dao;

        public RepositorioDeAcesso()
        {
            _dao = new AcessoDao();
        }

        public DataTable ObterListaDeUsuarios(int idusuario)
        {
            try
            {
                using (var db = new DB(true))
                {
                    return db.GetDataTable(new P_ListaUsuario() {});
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Erro : " + ex.Message);
            }
        }


        /// <summary>
        /// Verifica se o usuário possui acesso liberado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true ou false</returns>
        public bool UsuarioComAcessoLiberado(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.ExistsValue("SELECT idpessoa from pessoa where acesso = 1 and idpessoa = " + id + "");
                
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                return false;
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

       
        public bool UsuarioPossuiSenhaCadastrada(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.ExistsValue("SELECT senha from login where idpessoa = " + id + "");
                
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                return false;
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        /// <summary>
        /// Verifica se o usuário tem acesso ao módulo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="operacao"></param>
        /// <param name="tela"></param>
        /// <returns></returns>
        public bool AcessoPermitidoAoUsuario(int idusuario, int id, string operacao, string tela)
        {
            try
            {
                _dao.OpenConnection();

                string permissao = _dao.GetValue("select ca.idpermissao from colaborador co, cargo ca where co.idcargo = ca.idcargo and co.idpessoa = " + id + "");
                string pontos = _dao.GetValue("select pontos from permissao where operacao like " + operacao + " and tela like " + tela + "");

                if (Convert.ToInt32(permissao) <= Convert.ToInt32(pontos))
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                return false;
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        /// <summary>
        /// Verifica se a senha informada pelo usuário é valida
        /// </summary>
        /// <param name="id"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public bool SenhaValida(int idusuario, int id, string senha)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.ExistsValue("SELECT senha from login where idpessoa = " + id + " and senha = '" + senha + "'");
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                return false;
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        static public class Retorna
        {
            static public int TipoUsuario(int idusuario, int id, string senha)
            {
                var _dao = new AcessoDao();
                try
                {
                    _dao.OpenConnection();
                    var adm = _dao.GetValue("SELECT administrador from login where idpessoa = " + id + " and senha = '" + senha + "'");
                    return Convert.ToInt32(adm);

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

            /// <summary>
            /// Registra login de Usuário
            /// </summary>
            /// <param name="colaborador"></param>
            /// <returns>true ou false</returns>
            public bool RegistraLoginDeUsuario(int idusuario, Acesso acesso)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Insert(acesso);
                
                return true;
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                return false;
            }
            finally
            {
                _dao.CloseConnection();
            }

        }
    }
}
