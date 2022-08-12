using System;

namespace Agencia.Dominio.Modelo
{
    public class DadoRemuneracao : Colaborador 
    {
        public int IdDadoRemuneracao { get; set; }
        public int IdRemuneracao { get; set; }
        public string NmeRemuneracao { get; set; }
        public Decimal Valor { get; set; }

    }
}
