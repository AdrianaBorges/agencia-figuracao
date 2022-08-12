using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agencia.Dominio.Modelo
{
    public class DadoBancario : Pessoa
    {
        public int IdDadoBancario { get; set; }
        public int IdPessoa { get; set; }
        public string Status { get; set; }
        public int IdBanco { get; set; }
        public string NomeBanco { get; set; }
        public string Tipo { get; set; }
        public string Agencia { get; set; }
        public string NumeroConta { get; set; }
        public string Titular { get; set; }

    }
}
