using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agencia.Dominio.Modelo
{
    public class DadoProduto : Pessoa 
    {
        public int IdDadoProduto { get; set; }
        public DateTime DataRegistro { get; set; }
        public int IdPrograma { get; set; }
        public string Descricao { get; set; }
    }
}
