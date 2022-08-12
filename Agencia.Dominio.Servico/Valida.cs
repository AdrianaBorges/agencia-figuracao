using System;
using System.Text.RegularExpressions;
using Agencia.Dominio.Modelo;

namespace Agencia.Dominio.Servico
{
    static public class Valida
    {
  
        #region Libera registro de senha de usuário

        /// <summary>
        /// Verifica se a senha informada pelo usuário é válida
        /// </summary>
        /// <returns>true ou false</returns>
        static public string SenhaDeUsuario(int id, string senha)
        {
            if (id == 0)
            {
                return "Informe Usuário e Senha para registro";
            }
            else
            {
                if (senha.ToString().Length < 6)
                {
                    return "Senha inferior a seis digitos!";
                }
            }
            
            return "";
        }
        
        #endregion

        #region Método de Validação de email

        /// <summary>
        /// Confirma a validade de um email
        /// </summary>
        /// <param name="enderecoEmail">Email a ser validado</param>
        /// <returns>Retorna True se o email for valido</returns>
        static public bool EnderecoEmail(string enderecoEmail)
        {
            try
            {
                //define a expressão regulara para validar o email
                string texto_Validar = enderecoEmail;
                Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão
                if (expressaoRegex.IsMatch(texto_Validar))
                {
                    // o email é valido
                    return true;
                }
                else
                {
                    // o email é inválido
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Valida Data de Nascimento
        /// <summary>
        /// Valida data de nascimento menor que a data atual
        /// </summary>

        static public string dataNascimento(DateTime nascimento, DateTime cadastro)
        {
            //Data de nascimento inferior a data de cadastro
            if (nascimento < cadastro)  //Verifica se o intervalo é de pelo menos 180 dias
            {
                var date = cadastro - nascimento;
                var totalDias = date.Days;

                return totalDias <= 180 ? "Data de Nascimento inferior a 6(seis) meses." : "";
            }

            //Data de nascimento igual a data de cadastro
            if (nascimento == cadastro)
            {
                return "A data de Nascimento não pode ser igual a data de Cadastro.";
            }

            //Data de nascimento maior do que a data de cadastro
            return nascimento > cadastro ? "A data de Nascimento não pode ser superior a data de Cadastro." : "";
        }

        #endregion

        static public class Preenchimento
        {
            #region Programa
            static public void Programa(Produto p)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(p.Data))) { strMensagem = strMensagem + "Data de Cadastro, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(p.Descricao))) { strMensagem = strMensagem + "Descrição, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(p.Status))) { strMensagem = strMensagem + "Status (Ativo ou Inativo), "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }
            #endregion

            #region Colaborador
            static public void Colaborador(Colaborador c)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(c.Cadastro))) { strMensagem = strMensagem + "Data de Cadastro, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(c.Nome ))) { strMensagem = strMensagem + "Nome do Colaborador, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(c.Nascimento))) { strMensagem = strMensagem + "Data de Nascimento, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(c.Sexo))) { strMensagem = strMensagem + "Sexo, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(c.IdCargo))) { strMensagem = strMensagem + "Cargo, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(c.Status))) { strMensagem = strMensagem + "Status (Ativo ou Inativo), "; }

                    if (c.IdCargo == 0) { strMensagem = strMensagem + "Cargo, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Figurante
            static public void Figurante(Figurante f)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(f.Cadastro))) { strMensagem = strMensagem + "Data de Cadastro, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(f.Nome))) { strMensagem = strMensagem + "Nome do Figurante, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(f.Nascimento))) { strMensagem = strMensagem + "Data de Nascimento, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(f.Sexo))) { strMensagem = strMensagem + "Sexo, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(f.Status))) { strMensagem = strMensagem + "Status (Ativo ou Inativo), "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Dado Bancario
            static public void Veiculo(Veiculo v)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(v.IdMarca ))) { strMensagem = strMensagem + "Marca de Veículo, "; }
                    if (v.IdMarca == 0) { strMensagem = strMensagem + "Marca de Veículo, "; }

                    if (String.IsNullOrEmpty(Convert.ToString(v.IdModelo))) { strMensagem = strMensagem + "Modelo de Veículo, "; }
                    if (v.IdModelo == 0) { strMensagem = strMensagem + "Modelo de Veículo, "; }

                    if (String.IsNullOrEmpty(Convert.ToString(v.Ano))) { strMensagem = strMensagem + "Ano do Veículo, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Dado Bancario
            static public void DadoBancario(DadoBancario db)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(db.Status))) { strMensagem = strMensagem + "Status (Ativa ou Inativa), "; }
                    if (String.IsNullOrEmpty(Convert.ToString(db.IdBanco))) { strMensagem = strMensagem + "Banco, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(db.Tipo))) { strMensagem = strMensagem + "Tipo de Conta (Corrente ou Poupança), "; }
                    if (String.IsNullOrEmpty(Convert.ToString(db.Agencia))) { strMensagem = strMensagem + "Agencia, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(db.NumeroConta))) { strMensagem = strMensagem + "Número da Conta, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(db.Titular))) { strMensagem = strMensagem + "Títular da Conta, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Dado Remuneração
            static public void DadoRemuneracao(DadoRemuneracao dr)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(dr.IdRemuneracao))) { strMensagem = strMensagem + "Tipo de Remuneração, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(dr.Valor))) { strMensagem = strMensagem + "Valor da Remuneração, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Dado Produto\Programa
            static public void DadoProduto(DadoProduto dr)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(dr.IdPrograma))) { strMensagem = strMensagem + "Programa, "; }
                    if (dr.IdPrograma == 0) { strMensagem = strMensagem + "Programa, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Pedido de Gravação
            static public void Pedido(Pedido p)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(p.DataCadastro))) { strMensagem = strMensagem + "Data de Cadastro, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(p.DataPedido))) { strMensagem = strMensagem + "Data de Gravação, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(p.NumPedido))) { strMensagem = strMensagem + "Número do Pedido, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(p.IdEmpresa))) { strMensagem = strMensagem + "Empresa, "; }

                    if (String.IsNullOrEmpty(Convert.ToString(p.Hora))) { strMensagem = strMensagem + "Horário, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(p.HoraInicio))) { strMensagem = strMensagem + "Horário Inicial, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(p.HoraFim))) { strMensagem = strMensagem + "Horário Final, "; }
                    if (p.IdFirma == 0) { strMensagem = strMensagem + "Firma, "; }

                    if (p.IdEmpresa == 0) { strMensagem = strMensagem + "Empresa, "; }
                    if (p.IdPrograma == 0) { strMensagem = strMensagem + "Produto-Programa, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Carta Fatura
            static public void CartaFatura(CartaFatura cf)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(cf.NumCarta))) { strMensagem = strMensagem + "Número da Carta Fatura, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(cf.DataEmissao))) { strMensagem = strMensagem + "Data de Emissão, "; }
                    if (cf.IdFirma == 0) { strMensagem = strMensagem + "Firma, "; }

                    if (cf.IdPrograma == 0) { strMensagem = strMensagem + "Produto-Programa, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Alvará
            static public void Alvara(Alvara al)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(al.NumProcesso))) { strMensagem = strMensagem + "Número do Alvará, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(al.DataEmissao))) { strMensagem = strMensagem + "Data de Emissão, "; }

                    if (al.IdPrograma == 0) { strMensagem = strMensagem + "Produto-Programa, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Nota Fiscal
            static public void NotaFiscal(NotaFiscal nf)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(nf.NumeroNota))) { strMensagem = strMensagem + "Número da Nota Fiscal, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(nf.DataEmissao))) { strMensagem = strMensagem + "Data de Emissão, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(nf.CodVerificador))) { strMensagem = strMensagem + "Código Verificador, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(nf.Descricao))) { strMensagem = strMensagem + "Descrição da Nota Fiscal, "; }

                    if (nf.IdFirma == 0) { strMensagem = strMensagem + "Firma, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Contas a Pagar
            static public void ContasAPagar(ContasAPagar cap)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(cap.Descricao))) { strMensagem = strMensagem + "Descrição, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(cap.DtVencimento))) { strMensagem = strMensagem + "Data de Vencimento, "; }

                    if (cap.IdCusto == 0) { strMensagem = strMensagem + "Centro de Custo, "; }
                    if (cap.IdPessoa == 0) { strMensagem = strMensagem + "Prestador-de-Serviço, "; }
                    if (cap.Valor == "0") { strMensagem = strMensagem + "Valor, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Folha de Pagamento
            static public void Folha(Folha f)
            {
                var strMensagem = "";

                try
                {
                    if (String.IsNullOrEmpty(Convert.ToString(f.DataGeracao))) { strMensagem = strMensagem + "Data de Geração, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(f.MesReferencia))) { strMensagem = strMensagem + "Mês de Referência, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(f.DataDe))) { strMensagem = strMensagem + "Data De, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(f.DataAte))) { strMensagem = strMensagem + "Data Até, "; }
                    if (String.IsNullOrEmpty(Convert.ToString(f.Descricao))) { strMensagem = strMensagem + "Descrição, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion


            #region Item Pedido de Gravação
            static public void ItemPedido(ItemPedido ip)
            {
                var strMensagem = "";

                try
                {
                    if (ip.IdTipo == 0) { strMensagem = strMensagem + "Tipo de Figuração, "; }
                    if (ip.Qtd == 0) { strMensagem = strMensagem + "Quantidade de Figurantes, "; }
                    if (ip.Valor == "0") { strMensagem = strMensagem + "Valor do Cache, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Equipe Pedido de Gravação
            static public void EquipePedido(EquipePedido ep)
            {
                var strMensagem = "";

                try
                {
                    if (ep.IdPedido == 0) { strMensagem = strMensagem + "Pedido de Gravação, "; }
                    if (ep.IdPessoa == 0) { strMensagem = strMensagem + "Colaborador, "; }
                    if (ep.IdCargo == 0) { strMensagem = strMensagem + "Função Exercida, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

            #region Figurantes para Pedido de Gravação
            static public void FiguracaoPedido(PedidoFigurante fp)
            {
                var strMensagem = "";

                try
                {
                    if (fp.IdPedido == 0) { strMensagem = strMensagem + "Pedido de Gravação, "; }
                    if (fp.IdPessoa == 0) { strMensagem = strMensagem + "Figurante, "; }
                    if (fp.IdTipo == 0) { strMensagem = strMensagem + "Tipo-Figuração, "; }

                    if (String.IsNullOrEmpty(Convert.ToString(fp.VlrBruto))) { strMensagem = strMensagem + "Valor do Cache, "; }

                    if (strMensagem != string.Empty)
                    {
                        throw new Exception(strMensagem.Substring(0, (strMensagem.Length - 2)));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("O(s) campo(s) abaixo são de preenchimento obrigatório:") + ex.Message);
                }
            }

            #endregion

        }
    }

}
