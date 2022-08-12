using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using System.Collections.Generic;
using Data.Base;
using System.Windows.Forms;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeFirmas
    {
        private const int Idformulario = 8;
        private FirmaDao _dao;

        public RepositorioDeFirmas()
        {
            _dao = new FirmaDao();
        }

        public DataTable ObterListaDeFirmas(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable("Select idfirma, descricao From Firma Order by descricao");

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

        static public class Retorna
        {
            static public string NomeFirma(int idfirma)
            {
                var _dao = new FirmaDao();
                try
                {
                    _dao.OpenConnection();
                    return _dao.GetValue("Select razao From Firma where idfirma  = " + idfirma + "");

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

            static public string IdFirma(string nmefirma)
            {
                var _dao = new FirmaDao();
                try
                {
                    _dao.OpenConnection();
                    return _dao.GetValue("Select idfirma From Firma where descricao = '" + nmefirma + "'");

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
            static public void Firma(ToolStripComboBox cmb, int idusuario)
            {
                try
                {
                    new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeFirmas().ObterListaDeFirmas(idusuario));
                    cmb.ComboBox.SelectedValue = 0;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Não foi possível listar a(s) Firma(s) cadastradas.") + ex.Message);
                }
            }

            static public void Firma(ComboBox cmb, int idusuario)
            {
                try
                {
                    new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeFirmas().ObterListaDeFirmas(idusuario));
                    cmb.SelectedValue = 0;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Não foi possível listar a(s) Firma(s) cadastradas.") + ex.Message);
                }
            }
        }

    }
}
