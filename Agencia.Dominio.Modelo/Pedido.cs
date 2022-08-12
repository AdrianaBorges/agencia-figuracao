using System;

namespace Agencia.Dominio.Modelo
{
    public class Pedido : CartaFatura 
    {
        public int IdPedido { get; set; }
        public int IdFirma { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataPedido { get; set; }
        public string Status { get; set; }
        public int Extra { get; set; }
        public string NumPedido { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPrograma { get; set; }
        public int IdCartaFatura { get; set; }
        public string Hora { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public string Cena { get; set; }
        public string Capitulo { get; set; }
        public string Observacao { get; set; }
        public string DescPrograma { get; set; }
        public int QtdFigurante { get; set; }
        public decimal ValorPedido { get; set; }
        public decimal TotalPrevisto { get; set; }
        public decimal TotalPedido { get; set; }
        public decimal TotalPago { get; set; }
        public decimal TotalPendente { get; set; }
        public int IdUsuario { get; set; }
        public string Roteiro { get; set; }

    }
}
