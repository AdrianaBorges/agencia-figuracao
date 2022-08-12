using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agencia.Dominio.Modelo
{
    public class Empresa
    {
        public int IdEmpresa {get; set;}
        public DateTime DtCadastro {get; set;}
        public string Descricao {get; set;}
        public int Observacao {get; set;}
        
    }
}
