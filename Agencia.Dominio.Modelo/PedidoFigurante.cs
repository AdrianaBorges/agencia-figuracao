using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agencia.Dominio.Modelo
{
    public class PedidoFigurante
    {
        public int IdFigPedido { get; set; }
        public int IdPedido { get; set; }
        public int IdTipo { get; set; }
        public int IdPessoa { get; set; }
        public string NmePessoa { get; set; }
        public int IdCusto { get; set; }
        public string DescTipo { get; set; }
        public string VlrBruto { get; set; }
        public string VlrInss { get; set; }
        public string VlrLiquido { get; set; }
        public int IdUsuario { get; set; }

    }
}
