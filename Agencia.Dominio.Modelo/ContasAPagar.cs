using System;

namespace Agencia.Dominio.Modelo
{
    public class ContasAPagar : CentroDeCusto
    {
        public int IdUsuario { get; set; }
        public int IdAPagar { get; set; }
        public int IdPessoa { get; set; }
        public string NmePessoa { get; set; }
        public DateTime DtCadastro { get; set; }
        public string Descricao { get; set; }
        public DateTime DtVencimento { get; set; }
        public string Valor { get; set; }
        public new string Observacao { get; set; }
        public int Status { get; set; }
        public string DtPagamento { get; set; }

    }
}

