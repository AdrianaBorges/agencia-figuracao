using System;
using System.Net.Configuration;

namespace Agencia.Dominio.Modelo
{
    public class Figurante : Pessoa
    {
        public string Acesso { get; set; }
        public string Pasta { get; set; }

        /// <summary>
        /// 1-Brasileiro(a)
        /// 2-Estrangeiro(a)
        /// </summary>
        public string Nacionalidade { get; set; }

        /// <summary>
        /// 1-Solteiro(a)
        /// 2-Casado(a)
        /// 3-Separado(a)
        /// 4-Divorciado(a)
        /// 5-Viuvo(a)
        /// </summary>
        public string EstadoCivil { get; set; }
        public string NomeArtistico { get; set; }
        public string Mae { get; set; }
        public string Pai { get; set; }
        public string Profissao { get; set; }
        public string RegistroArtistico { get; set; }
        public int AtuaComoFigurante { get; set; }
        public int AtuaComoAtor { get; set; }
        public int AtuaComoModelo { get; set; }
        public string Altura { get; set; }
        public string IdadeAparente { get; set; }
        public string Peso { get; set; }
        public string TipoEtnico { get; set; }
        public string Manequim { get; set; }
        public string Calcado { get; set; }
        public string Busto { get; set; }
        public string Quadril { get; set; }
        public string Cintura { get; set; }
        public string SemelhancaComCelebridade { get; set; }
        public string CorOlhos { get; set; }
        public string Cabelo { get; set; }
        public string CorCabelo { get; set; }
        public string TipoCabelo { get; set; }
        public string CorPele { get; set; }
        public int UsaAparelho { get; set; }
        public string Responsavel { get; set; }
        public string CpfResp { get; set; }
        public string CertNascimento { get; set; }
        public string Livro { get; set; }

        ///Identifica o tipo de Pessoa como Figurante
        public static int IdTipoFigurante()
        {
            return 2;
        }

        ///Identifica o tipo de carregamento do form - Figurante
        public static int IdTipoFormulario()
        {
            return 4;
        }

        public static string DataNascimentoValida(DateTime nascimento, DateTime cadastro)
        {
            //Data de nascimento inferior a data de cadastro
            if (nascimento >= cadastro)
                return nascimento == cadastro ? "A data de Nascimento não pode ser igual ou superior a data de Cadastro." : "";
            //Verifica se o intervalo é de pelo menos 360 dias
            var date = cadastro - nascimento;
            var totalDias = date.Days;

            return totalDias <= 360 ? "Data de Nascimento inferior a 1(um) ano." : "";

        }

    }
}
