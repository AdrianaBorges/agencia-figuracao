using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agencia.Infraestrutura.DAL;
using System.Data;
using Agencia.Dominio.Modelo;


namespace Agencia.Repositorio
{
    public class RepositorioDeLogErro
    {
        LogErroDAO _dao;

        public RepositorioDeLogErro()
        {
            _dao = new LogErroDAO();
        }


        public void RegistraLogErro(LogErro logerro )
        {
            //_dao.OpenConnection();
            _dao.Insert(logerro);
            //_dao.CloseConnection();

        }

    }
}
