using System;

namespace Agencia.Dominio.Modelo
{
    public class Colaborador : Pessoa
    {
        public int IdCargo { get; set; }
        public string DescCargo { get; set; }
        public DateTime? Desligamento { get; set; }
        public int Clt { get; set; }
        public int Comissao { get; set; }
        public string Senha { get; set; }

        /// <summary>
        /// Identifica o tipo de carregamento do form -  Colaborador
        /// </summary>
        /// <returns></returns>
        public static int IdTipoFormulario()
        {
            return 2;
        }
    }
}
