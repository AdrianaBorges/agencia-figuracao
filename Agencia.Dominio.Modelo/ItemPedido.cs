using System;

namespace Agencia.Dominio.Modelo
{
    public class ItemPedido : Pedido
    {
        public int IdItem { get; set; }
        public int IdTipo { get; set; }
        public string DescTipo { get; set; }
        public int Qtd { get; set; }
        public string Valor { get; set; }

    }
}
