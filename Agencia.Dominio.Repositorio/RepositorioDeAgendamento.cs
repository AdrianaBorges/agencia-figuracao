using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using System.Collections.Generic;
using Data.Base;
namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeAgendamento
    {
        private const int Idformulario = 25;
        private AgendamentoDao _dao;

        public RepositorioDeAgendamento()
        {
            _dao = new AgendamentoDao();
        }

        public DataTable ObterListaDeAgendamentos()
        {
            try
            {
                using (var db = new DB(true))
                {
                    //return db.GetDataTable("SELECT replicate('0',6 - Len(idagendamento)) + Rtrim(idagendamento) as idagendamento, CONVERT(VARCHAR(10),dtregistro,105) AS dtregistro, controle, descricao, CONVERT(VARCHAR(10),dtpgto,105) AS dtpgto, 0,0, observacao FROM agendamento order by idagendamento desc");
					return db.GetDataTable ("SELECT replicate('0',6 - Len(A.idagendamento)) + Rtrim(A.idagendamento) as idagendamento, CONVERT(VARCHAR(10),A.dtregistro,105) AS dtregistro, A.controle, A.descricao, CONVERT(VARCHAR(10),A.dtpgto,105) AS dtpgto, COUNT(pf.idpessoa) as total,SUM(PF.vlrliquido) as vlrtotal, A.observacao FROM agendamento A inner join ItemAgendamento IA ON IA.idagendamento = A.idagendamento INNER JOIN PedidoFigurante PF ON PF.id = IA.id GROUP BY A.idagendamento, A.dtregistro, A.CONTROLE,A.descricao, A.dtpgto, A.observacao order by A.idagendamento desc");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Agendamento ObtemAgendamentoPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();

                var result = _dao.Get(Convert.ToString(id)); 
                return result;
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObterListaDeFigurantesAgendados(int idusuario, int idagendamento)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaItemAgendamento() { IdAgendamento = idagendamento });

                return result;
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

        public DataTable ObterListaParaLocacao(int idusuario, int idagendamento)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaItemAgendamento() { IdAgendamento = idagendamento });

                return result;
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



    }
}
