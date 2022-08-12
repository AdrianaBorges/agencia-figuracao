using System;

namespace Agencia.Dominio.Modelo
{
    public class Folha
    {
        public int IdUsuario { get; set; }
        public int IdFolha { get; set; }
        public DateTime DataGeracao { get; set; }
        public string Status { get; set; }
        public string MesReferencia { get; set; }
        public DateTime DataDe { get; set; }
        public DateTime DataAte { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataLiberacao { get; set; }
    }
}
