using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using System.Collections.Generic;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeMarcasDeVeiculos
    {
        private const int Idformulario = 4;
        private MarcaDao _dao;

        public RepositorioDeMarcasDeVeiculos()
        {
            _dao = new MarcaDao();
        }

        public DataTable ObterListaDeMarcasDeVeiculos(int idusuario)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaMarcaVeiculo() { });

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
