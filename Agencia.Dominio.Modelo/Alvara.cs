using System;
using System.Globalization;

namespace Agencia.Dominio.Modelo
{
    public class Alvara
    {
        public int IdAlvara { get; set; }
        public int IdPrograma { get; set; }
        public DateTime DataEmissao { get; set; }
        public string NumProcesso { get; set; }
        public string Observacao { get; set; }
        public int IdUsuario { get; set; }

    }
}
