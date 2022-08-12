using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeAlvara
    {
        private const int Idformulario = 11;
        private AlvaraDao _dao;

        public RepositorioDeAlvara()
        {
            _dao =  new AlvaraDao();
        }

        public DataTable ObterListaDeAlvaras(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_CarregaListaAlvara() { });

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

        public DataTable ObterListaDeProcessos(int idusuario, int idprograma)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaProcessoPorProduto() { IdPrograma = idprograma });

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


        public DataTable ObterListaDePessoasPorAlvara(int idusuario, int idalvara, int iddisponivel, string dado)
        {
            try
            {
                _dao.OpenConnection();
                return _dao.GetDataTable(new P_ListaPessoaPorAlvara() { IdAlvara = idalvara, IdDisponivel = iddisponivel, SDado = dado });

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

        public void InserePessoa(int idusuario, int idalvara, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(string.Format("Insert into dadoalvara (idalvara, idpessoa) Values ({0}, {1})", idalvara, idpessoa));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar a Pessoa para o Alvará. " + ex.Message);
            }
        }

        public Alvara ObterAlvaraPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.Get(new P_RecuperaAlvara() { IdAlvara = id });

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

        public void Insere(Alvara alvara)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Insert(alvara);
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(alvara.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar a Carta Fatura. " + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Altera(Alvara alvara)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Update(alvara);

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(alvara.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível alterar o Alvará." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Exclui(Alvara alvara)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Delete(alvara);
                _dao.Execute(string.Format("delete from dadoalvara where idalvara = {0}", alvara.IdAlvara));

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(alvara.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível excluir o Alvará informado." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void ExcluiPessoa(int idusuario, int idalvara, int idpessoa)
        {
            try
            {
                using (var db = new DB(true))
                {
                    db.Execute(string.Format("delete from dadoalvara where idalvara = {0} and idpessoa = {1}", idalvara, idpessoa));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível excluir o Figurante do Alvará. " + ex.Message);
            }
        }

        static public class Retorna
        {
            static public string IdAlvara(string numprocesso)
            {
                var _dao = new AlvaraDao();
                try
                {
                    _dao.OpenConnection();
                    return _dao.GetValue("Select REPLICATE('0', 5 - LEN(idalvara)) + RTrim(idalvara) as idalvara From Alvara where numprocesso = '" + numprocesso + "'");
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
