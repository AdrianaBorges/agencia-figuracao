using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Infraestrutura.DAL
{
    /// <summary>
    /// Verifica se a entidade passada existe
    /// </summary>
    static public class Entidade
    {
        static public class Existe
        {
            static public void Folha(Folha f)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("Select idfolha From Folha Where de = '{0}' and ate = '{1}' and mesref = {2} ", f.DataDe.ToString("MM/dd/yyyy"), f.DataAte.ToString("MM/dd/yyyy"), f.MesReferencia));

                        if (result)
                        {
                            throw new Exception(string.Format("Folha de Pagamento nº " + f.Descricao + ", já constã na base de dados."));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            static public void NotaFiscal(NotaFiscal nf)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("Select idnota From NotaFiscal Where numnota = {0} and idfirma = {1} and codverificacao = '{2}'", nf.NumeroNota, nf.IdFirma, nf.CodVerificador));

                        if (result)
                        {
                            throw new Exception(string.Format("Nota Fiscal nº " + nf.NumeroNota + ", já constã na base de dados."));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            static public void CartaFatura(CartaFatura cf)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("Select idcartafatura From CartaFatura Where numcarta = {0} and idprograma = {1}", cf.NumCarta, cf.IdPrograma));
                    
                        if(result) 
                        {
                            throw new Exception(string.Format("Carta Fatura nº " + cf.NumCarta + ", já constã na base de dados."));

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            static public void Alvara(Alvara al)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("Select idalvara From Alvara Where numprocesso = {0}", al.NumProcesso));

                        if (result)
                        {
                            throw new Exception(string.Format("Alvara nº " + al.NumProcesso + ", já constã na base de dados."));

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            static public void ContaAPagar(ContasAPagar cap)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("Select idcontaapagar From ContasAPagar Where idcusto = {0} and idpessoa = {1} and vencimento = '{2}' and valor = '{3}'", cap.IdCusto, cap.IdPessoa, cap.DtVencimento, cap.Valor));

                        if (result)
                        {
                            throw new Exception(string.Format("Conta A Pagar " + cap.Descricao + ", já constã na base de dados."));

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

            static public void PedidoDeGravacao(Pedido p)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("Select idpedido From Pedido Where numpedido = '{0}' and idprograma = {1} and extra = {2}", p.NumPedido, p.IdPrograma, p.Extra));

                        if (result)
                        {
                            throw new Exception(string.Format("Pedido de Gravação nº " + p.NumPedido + ", já constã na base de dados."));

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            static public void Veiculo(Veiculo v)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("select idveiculo from Veiculo where idpessoa = {0} and idmarca = {1} and idmodelo = {2} and ano = {3} ",
                                                                   v.IdPessoa, v.IdMarca, v.IdModelo, v.Ano));
                        if (result)
                        {
                            throw new Exception(string.Format("Veículo " + v.DescMarca  + ", já constã na base de dados."));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            static public void Produto(Produto p)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("Select descricao from Programa Where descricao = '{0}'", p.Descricao));
                        if (result)
                        {
                            throw new Exception(string.Format("Programa-Produto " + p.Descricao + ", já constã na base de dados."));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

            static public void ItemPedido(ItemPedido ip)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("Select id From pedqtdfigurante Where idtipo = {0} and idpedido = {1}", ip.IdTipo, ip.IdPedido));
                        if (result)
                        {
                            throw new Exception(string.Format("Item " + ip.DescTipo + ", já constã na base de dados."));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            static public void DadoBancario(DadoBancario d)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("select id from dadobancario where idpessoa = {0} and tipo = '{1}' and agencia = '{2}' and numconta = '{3}'",
                                                                   d.IdPessoa, d.Tipo, d.Agencia, d.NumeroConta));
                        if (result)
                        {
                            throw new Exception(string.Format("Dado Bancário " + d.NomeBanco + ", já constã na base de dados."));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            static public void Pessoa(Pessoa p)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        if (db.ExistsValue(string.Format("select idpessoa from pessoa where nmepessoa = '{0}'", p.Nome))) { throw new Exception(string.Format("O nome " + p.Nome + ", já constã na base de dados.")); }

                        if (p.Cpf != string.Empty) { if (db.ExistsValue(string.Format("select idpessoa from pessoa where cpf = '{0}'", p.Cpf))) { throw new Exception(string.Format("O CPF nº " + p.Cpf + ", já constã na base de dados.")); } }
                        if (p.Rg != string.Empty) { if (db.ExistsValue(string.Format("select idpessoa from pessoa where rg = '{0}'", p.Rg))) { throw new Exception(string.Format("O RG nº " + p.Rg + ", já constã na base de dados.")); } }
                        if (p.Pis != string.Empty) { if (db.ExistsValue(string.Format("select idpessoa from pessoa where pis = '{0}'", p.Pis))) { throw new Exception(string.Format("O PIS nº " + p.Pis + ", já constã na base de dados.")); } }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            static public void ItemReciboProvisorio(int idpessoa, int idfigpedido)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("Select recibo From tmpPgto Where idpessoa = {0} and idregistro = {1}",
                                                                   idpessoa, idfigpedido));
                        if (result)
                        {
                            throw new Exception(string.Format("Existe Recibo provisório pendente de baixa para o registro nº " + idfigpedido));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

        static public class Pendente
        {
            static public void NotaFiscal(NotaFiscal nf)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result =  db.ExistsValue(string.Format("Select idnota From NotaFiscal Where numnota = {0} and status = 0", nf.NumeroNota));

                        if (!result)
                        {
                            throw new Exception(string.Format("Nota Fiscal nº " + nf.NumeroNota + ", já constã quitada na base de dados."));
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            static public void Folha(Folha f)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("Select idfolha From Folha Where idfolha = {0} and dtliberacao is null", f.IdFolha));

                        if (!result)
                        {
                            throw new Exception(string.Format("Folha de Pagamento " + f.Descricao + ", já constã liberada para pagamento."));
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        static public class Possui
        {
            static public void CartaFatura(NotaFiscal nf)
            {
                try
                {
                    using (var db = new DB(true))
                    {
                        var result = db.ExistsValue(string.Format("Select idcartafatura From CartaFatura Where idnota = {0}", nf.IdNotaFiscal));

                        if (!result)
                        {
                            throw new Exception(string.Format("Nota Fiscal nº " + nf.NumeroNota + ", não possui Carta-Fatura registrada."));
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


    }
}
