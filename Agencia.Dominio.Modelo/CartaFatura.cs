using System;

namespace Agencia.Dominio.Modelo
{
    public class CartaFatura : NotaFiscal 
    {
        public int IdCartaFatura { get; set; }
        public int IdFirma { get; set;  }
        public int NumCarta { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataRecebimento { get; set; }
        public int IdPrograma { get; set; }
        public string Observacao { get; set; }

        public int IdUsuario { get; set; }

    }
}
