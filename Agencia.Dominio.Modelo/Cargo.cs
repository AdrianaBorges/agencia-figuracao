using System;

namespace Agencia.Dominio.Modelo
{
    public class Cargo : Colaborador 
    {
        public int IdCargo { get; set; }
        public string Descricao { get; set; }
        public int IdPermissao { get; set; }
    }
}
