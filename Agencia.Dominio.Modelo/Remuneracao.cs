using System;

namespace Agencia.Dominio.Modelo
{
    public class Remuneracao : Colaborador
    {
        public int IdRemuneracao { get; set; }
        public string NmeRemuneracao { get; set; }
        public int IdRemuneracaoExtra { get; set; }

    }
}
