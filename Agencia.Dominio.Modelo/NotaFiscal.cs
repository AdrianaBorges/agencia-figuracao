using System;


namespace Agencia.Dominio.Modelo
{
    public class NotaFiscal 
    {
        public int IdNotaFiscal { get; set; }
        public int IdFirma { get; set; }
        public string NumeroNota { get; set; }
        public DateTime DataEmissao { get; set; }
        public string CodVerificador { get; set; }
        public string Descricao { get; set; }
        public int IdContratante { get; set; }
        public int IdLancamnto { get; set; }
        public string Observacao { get; set; }
        public DateTime DataLiberacao { get; set; }
        public int Status { get; set; }
        public string DataPagamento { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal ValorCofins { get; set; }
        public decimal ValorCsll { get; set; }
        public decimal ValorIrpj { get; set; }
        public decimal ValorPis { get; set; }
        public decimal ValorIss { get; set; }

        public int IdUsuario { get; set; }

    }
}
