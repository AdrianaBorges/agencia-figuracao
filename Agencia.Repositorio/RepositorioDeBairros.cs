using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agencia.Infraestrutura.DAL;
using System.Data;

namespace Agencia.Repositorio
{
    public class RepositorioDeBairros
    {
        BairroPROC _daoP;
        BairroDAO _dao;

        public RepositorioDeBairros()
        {
            _dao = new BairroDAO();
            _daoP = new BairroPROC();

        }

        public DataTable ObterListaDeBairros()
        {
            _daoP.OpenConnection();
            var result = _daoP.GetDataTableFromProcedure(new P_ListaTodosBairros());
            _daoP.CloseConnection();
            return result;
        }
        
    }
}
