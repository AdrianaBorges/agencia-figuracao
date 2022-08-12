using System;

namespace Agencia.Dominio.Modelo
{
    public class Bairro : Estado
    {
        public int IdBairro { get; set; }
        public string NmeBairro { get; set; }
        public int IdCidade { get; set; }
        public string NmeCidade { get; set; }
        public int IdEstado { get; set; }
        public string NmeEstado { get; set; }
        public string Uf { get; set; }

    }

}
