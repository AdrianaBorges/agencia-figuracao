using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;
using System.Windows.Forms;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeNotasFiscais
    {
        private const int Idformulario = 10;
        NotaFiscalDao _dao;

        public RepositorioDeNotasFiscais()
        {
            _dao = new NotaFiscalDao();
        }

        public DataTable ObterListaDeNotasFiscais(int idusuario, int nota, int idfirma)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaNotasFiscais() { IdFirma = idfirma, NumNota = nota });
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

        public DataTable ObterListaDeNotas(int idusuario, int idfirma)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable("Select idnota, REPLICATE('0', 8 - LEN(numnota)) + RTrim(numnota) as numnota From NotaFiscal Where idfirma = " + idfirma + " order by numnota desc, idnota desc");

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
               
        public NotaFiscal ObterNotaFiscalPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.Get(new P_RecuperaNotaFiscal() { IdNota = id });
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

        public void CarregaTabelaTemporaria(int idusuario, int idnota, int idfirma)
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(new p_carregaTmpNotaFiscal() { IdNota = idnota, IdFirma = idfirma });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível carregar a tabela temporária tmpNotaFiscal. " + ex.Message);
            }

        }

        public void LimpaTabelaTemporaria(int idusuario)
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(string.Format("delete from tmpNotaFiscal"));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível limpar a tabela temporária tmpNotaFiscal. " + ex.Message);
            }
        }

        public void InsereFatura(int idusuario, int idnota, int idcartafatura)
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(string.Format("Update CartaFatura set idnota = {0} where idcartafatura = {1}", idnota, idcartafatura));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar a Carta Fatura para a Nota Fiscal. " + ex.Message);
            }
        }

        public void ExcluiFatura(int idusuario, int idcartafatura)
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(string.Format("Update CartaFatura set idnota = 0 where idcartafatura = {0}", idcartafatura));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar a Carta Fatura para a Nota Fiscal. " + ex.Message);
            }
        }


        public void Insere(NotaFiscal nota)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Insert(nota);
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(nota.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar a Nota Fiscal. " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Altera(NotaFiscal nota)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Update(nota);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(nota.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível alterar a Nota Fiscal." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Exclui(NotaFiscal nota)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Delete(nota);
                _dao.Execute(string.Format("Update CartaFatura set idnota = 0 where idnota = {0}", nota.IdNotaFiscal));

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(nota.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível excluir a Nota Fiscal informada." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void RegistraPagamento(int idusuario, int idnota, DateTime dtpagamento)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Execute(string.Format("Update NotaFiscal set status = 1, dtpagamento = '{0}' where idnota = {1}", dtpagamento.ToString("MM/dd/yyyy HH:mm:ss"), idnota));

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar o pagamento da Nota Fiscal." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }
        static public class Retorna
        {
            static public string IdNotaFiscal(int numnota, int idfirma)
            {
                var _dao = new PedidoDao();
                try
                {
                    _dao.OpenConnection();
                    return _dao.GetValue("Select REPLICATE('0', 5 - LEN(idnota)) + RTrim(idnota) as idnota From NotaFiscal where numnota = " + numnota + " and idfirma = " + idfirma + "");
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

        static public class MontaCombo
        {
            static public void NotaFiscal(ToolStripComboBox cmb, int idusuario, int idfirma)
            {
                try
                {
                    new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeNotasFiscais().ObterListaDeNotas(idusuario, idfirma));
                    //cmb.ComboBox.SelectedValue = 0;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Não foi possível listar a(s) Nota(s) cadastradas.") + ex.Message);
                }
            }
        }

    }
}
