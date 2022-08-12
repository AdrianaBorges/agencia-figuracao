using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;

namespace Agencia.Dominio.Repositorio
{
    static public class RegistraLogErro
    {
        static public void LogAplicacao(int idpessoa, int idform, string descricao)
        {
            RepositorioDeLogErro rep = new RepositorioDeLogErro();
            LogErro l = new LogErro();

            l.IdForm = idform;
            l.Descricao = descricao;
            rep.RegistraLogErro(l);
        }
    }

    public class RepositorioDeLogErro
    {
        private const int IDFORMULARIO = 2;

        LogErroDao _dao;

        public RepositorioDeLogErro()
        {
            _dao = new LogErroDao();
        }

        public void RegistraLogErro(LogErro logerro)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Execute(string.Format("Insert Into logerro (IdForm, Data, Descricao) Values ({0}, '{1}', '{2}')", logerro.IdForm, DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), logerro.Descricao));

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

        public void RegistraLogAplicacao(int idform, DateTime data, string descricao)
        {
            var rep = new RepositorioDeLogErro();
            var l = new LogErro {IdForm = idform, Data = data.Date, Descricao = descricao};

            rep.RegistraLogErro(l);
        }
    }
}
