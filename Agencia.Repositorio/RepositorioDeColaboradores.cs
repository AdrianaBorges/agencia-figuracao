using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agencia.Infraestrutura.DAL;
using System.Data;

namespace Agencia.Repositorio
{
    public class RepositorioDeColaboradores
    {
        ColaboradorPROC _daoP;
        ColaboradorDAO _dao;

        public RepositorioDeColaboradores()
        {
            _daoP = new ColaboradorPROC();
            _dao = new ColaboradorDAO();

        }

        public DataTable ObterListaDeUsuarios()
        {
            _daoP.OpenConnection();
            var result = _daoP.GetDataTableFromProcedure(new P_ListaUsuario());
            _daoP.CloseConnection();
            return result;
        }

        public bool UsuarioComAcessoLiberado(int id)
        {

        }

    }
}
