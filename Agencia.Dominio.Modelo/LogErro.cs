using System;

namespace Agencia.Dominio.Modelo
{
    public class LogErro
    {
        public string IdLogErro { get; set; }
        public int IdPessoa { get; set; }
        public int IdForm { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }

    }
}
