using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agencia.Dominio.Modelo
{
    public class EquipePedido
    {
        public int IdEquipe { get; set; }
        public int IdPedido { get; set; }
        public int IdPessoa { get; set; }
        public string NmePessoa { get; set; }
        public int IdCargo { get; set; }
        public string DescCargo { get; set; }
        public int IdUsuario { get; set; }

    }
}
