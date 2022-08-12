using System;

namespace Agencia.Dominio.Modelo
{
    public class CentroDeCusto : CentralDeCusto
    {
        public int IdCusto { get; set; }
        public string DescCentroDeCusto { get; set; }
        public string Observacao { get; set; }

    }
}
