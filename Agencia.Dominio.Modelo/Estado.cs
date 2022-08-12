using System;

namespace Agencia.Dominio.Modelo
{
    public class Estado : Pessoa
    {
        public int IdEstado { get; set; }
        public string NmeEstado { get; set; }
        public string Uf { get; set; }

    }
}
