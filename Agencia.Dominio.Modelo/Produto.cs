using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agencia.Dominio.Modelo
{
    public class Produto 
    {
        public int IdPrograma { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string Status { get; set; }
        public int IdUsuario { get; set; }
    }
}
