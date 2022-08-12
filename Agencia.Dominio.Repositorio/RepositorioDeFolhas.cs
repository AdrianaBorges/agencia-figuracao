using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeFolhas
    {
        private const int Idformulario = 7; 
        readonly FolhaDao _dao;

        public RepositorioDeFolhas()
        {
            _dao = new FolhaDao();
        }

        public DataTable ObterListaDeFolhas(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaFolhaPgto() { });

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

        public Folha ObterFolhaPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.Get(new P_RecuperaFolhaPorId() { IdFolha = id });

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

        public void ProcessaDadosFolha(int idusuario, int idfolha)
        {
            try
            {
                _dao.OpenConnection();

                _dao.Execute(new P_ProcessaDadosFolha() { IdFolha = idfolha });

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

        public void Insere(Folha folha)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Insert(folha);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(folha.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar a Folha de Pagamento solicitada. " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void LiberaParaPgto(int idusuario, int idfolha, DateTime data)
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(string.Format("Update Folha Set dtliberacao = '{1}' Where idfolha = {0}", idfolha, data.ToString("MM/dd/yyyy HH:mm:ss")));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar a liberação da Folha para Pagamento." + ex.Message);
            }
        }

        public void Altera(Folha folha)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Update(folha);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(folha.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível alterar a Folha de Pagamento solicitada." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        public void Exclui(Folha folha)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Delete(folha);
                
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(folha.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível excluir a Folha de Pagamento informada. " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        static public class Retorna
        {
            static public string IdFolha(DateTime dtgeracao, int mesref, DateTime dtde, DateTime dtate)
            {
                var _dao = new FolhaDao();
                try
                {
                    _dao.OpenConnection();

                    return _dao.GetValue("Select dbo.FormataCodigo(idfolha, 'M') as idfolha From Folha where dtgeracao  = '" + dtgeracao.ToString("MM/dd/yyyy") + "' and mesref = " + mesref + " and de = '" + dtde.ToString("MM/dd/yyyy") + "' and ate = '" + dtate.ToString("MM/dd/yyyy") + "'");
                
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
