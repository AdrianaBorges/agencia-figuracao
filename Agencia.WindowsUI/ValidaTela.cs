using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.WindowsUI
{
    static public class ValidaTela
    {

        #region Valida o preenchimento da tela de Programas
        static public string Programa(Produto produto)
        {
            var strMensagem = string.Format ("O(s) campo(s) abaixo são de preenchimento obrigatório:") + Environment.NewLine;

            int iContador = 0;

            if (String.IsNullOrEmpty(Convert.ToString(produto.Data))) { strMensagem = strMensagem + "Data de Cadastro, "; iContador++; }

            if (String.IsNullOrEmpty(Convert.ToString(produto.Descricao))) { strMensagem = strMensagem + "Descrição, "; iContador++; }

            if (iContador <= 0) { strMensagem = string.Empty; return ""; } else { return strMensagem; }

        }
        #endregion

    }
}
