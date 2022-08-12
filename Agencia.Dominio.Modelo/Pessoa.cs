using System;

namespace Agencia.Dominio.Modelo
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public int IdFirma { get; set; }
        public int IdTipoPessoa { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
        public DateTime Cadastro { get; set; }
        public string Status { get; set; }
        public int IdBairro { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Rg { get; set; }
        public string Expedicao { get; set; }
        public string Pis { get; set; }
        public string Ctps { get; set; }
        public string Serie { get; set; }
        public string CartReservista { get; set; }
        public string Fixo { get; set; }
        public string Celular { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }

        public int IdCidade { get; set; }
        public int IdEstado {get; set; }
        public int IdUsuario { get; set; }

        public DateTime DataAlvara { get; set; }
        public string NumProcesso { get; set; }
        public int Menor { get; set; }

        public Pessoa()
        {
            //Construtor padrão - vazio
        }
    }
}
