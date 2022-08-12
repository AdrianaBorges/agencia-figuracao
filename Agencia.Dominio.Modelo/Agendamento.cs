using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agencia.Dominio.Modelo
{
    public class Agendamento
    {
        public int IdAgendamento { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Controle { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPgto { get; set; }
        public string Observacao { get; set; }

    }
}
