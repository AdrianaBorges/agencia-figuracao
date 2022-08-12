using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agencia.Dominio.Modelo
{
    public class Veiculo : Modelo
    {
        //public int IdPessoa { get; set; }
        public int IdVeiculo { get; set; }
        public string Ano { get; set; }
        //public string Marca { get; set; }
        //public string Modelo { get; set; }

        //public Modelo Modelo;
        //public Marca Marca;

    }

    public class Modelo : Marca
    {
        public int IdModelo { get; set; }
        public string DescModelo { get; set; }

    }
    public class Marca : Figurante 
    {
        public int IdMarca { get; set; }
        public string DescMarca { get; set; }
    }

    
}
