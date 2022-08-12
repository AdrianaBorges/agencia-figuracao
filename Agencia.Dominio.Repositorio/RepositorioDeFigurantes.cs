using System;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using System.Data;
using Data.Base;

namespace Agencia.Dominio.Repositorio
{
    public class RepositorioDeFigurantes
    {
        private const int Idformulario = 4;
        private FiguranteDao _dao;

        public RepositorioDeFigurantes()
        {
            _dao = new FiguranteDao();
        }

        public DataTable ObterListaDeFigurantes(int idusuario, string dado, int status, int idpessoa)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaFigurantes() { Nome = dado, Status = status, IdPessoa = idpessoa });

                return result;
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public DataTable ObterListaDeFigurantesParaUnificar(int idusuario, string dado, int idpessoa)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.GetDataTable(new P_ListaFiguranteParaUnificar() { Nome = dado, IdPessoa = idpessoa });

                return result;
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }
        public DataTable ObterListaDeFigurantesDisponivelParaPedido(int idusuario, int idpedido, int tipoconsulta, string dado)
        {
            try
            {
                using (var db = new DB(true))
                {
                   return db.GetDataTable(new P_ListaFiguranteDisponivelParaPedido() { IdPedido = idpedido, IdTipoConsulta = tipoconsulta, Dado = dado });
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Figurante ObterPessoaPorId(int idusuario, int id)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.Get(new P_RecuperaFigurantePorId() { IdPessoa = id });

                return result;
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void Insere(Figurante figurante)
        {
            try
            {
                if (!FiguranteExiste(figurante.Nome))
                {
                    _dao.OpenConnection();

                    _dao.Execute(new P_RegistraFigurante()
                    {
                        Operacao = "INSERT",
                        IdFirma = figurante.IdFirma,
                        IdPessoa = figurante.IdPessoa,
                        IdTipoPessoa = figurante.IdTipoPessoa,
                        Nome = figurante.Nome,
                        Sexo = figurante.Sexo,
                        DataNascimento = figurante.Nascimento,
                        DataCadastro = figurante.Cadastro,
                        Status = figurante.Status,
                        IdBairro = figurante.IdBairro,
                        Logradouro = figurante.Logradouro,
                        Complemento = figurante.Complemento,
                        Cep = figurante.Cep,
                        Cpf = figurante.Cpf,
                        Rg = figurante.Rg,
                        Expedicao = figurante.Expedicao,
                        Pis = figurante.Pis,
                        TelFixo = figurante.Fixo,
                        TelCelular = figurante.Celular,
                        TelContato = figurante.Contato,
                        Email = figurante.Email,
                        NmeArtistico = figurante.NomeArtistico,
                        Nacionalidade = figurante.Nacionalidade,
                        Acesso = figurante.Acesso,
                        Pasta = figurante.Pasta,
                        Mae = figurante.Mae,
                        Pai = figurante.Pai,
                        EstadoCivil = figurante.EstadoCivil,
                        Profissao = figurante.Profissao,
                        RegistroAtor = figurante.RegistroArtistico,
                        Figurante = figurante.AtuaComoFigurante,
                        Ator = figurante.AtuaComoAtor,
                        Modelo = figurante.AtuaComoModelo,
                        Altura = figurante.Altura,
                        IdadeAparente = figurante.IdadeAparente,
                        Peso = figurante.Peso,
                        TipoEtnico = figurante.TipoEtnico,
                        Manequim = figurante.Manequim,
                        Calcado = figurante.Calcado,
                        Busto = figurante.Busto,
                        Quadril = figurante.Quadril,
                        Cintura = figurante.Cintura,
                        Celebridade = figurante.SemelhancaComCelebridade,
                        CorOlhos = figurante.CorOlhos,
                        Cabelo = figurante.Cabelo,
                        CorCabelo = figurante.CorCabelo,
                        TipoCabelo = figurante.TipoCabelo,
                        CorPele = figurante.CorPele,
                        AparelhoDental = figurante.UsaAparelho,
                        IdUsuario = figurante.IdUsuario

                        //Responsavel = figurante.Responsavel,
                        //CpfResp = figurante.CpfResp,
                       // CertNascimento = figurante.CertNascimento
                        //Livro = figurante.Livro

                    });

                }
                else
                {
                    throw new Exception(string.Format("Figurante informado já constã na base de dados."));
                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(figurante.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível registrar o Figurante solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        public void Altera(Figurante figurante)
        {
            try
            {
                if (FiguranteExiste(figurante.IdPessoa))
                {
                    _dao.OpenConnection();

                    _dao.Execute(new P_RegistraFigurante()
                    {
                        Operacao = "UPDATE",
                        IdFirma = figurante.IdFirma,
                        IdPessoa = figurante.IdPessoa,
                        IdTipoPessoa = figurante.IdTipoPessoa,
                        Nome = figurante.Nome,
                        Sexo = figurante.Sexo,
                        DataNascimento = figurante.Nascimento,
                        DataCadastro = figurante.Cadastro,
                        Status = figurante.Status,
                        IdBairro = figurante.IdBairro,
                        Logradouro = figurante.Logradouro,
                        Complemento = figurante.Complemento,
                        Cep = figurante.Cep,
                        Cpf = figurante.Cpf,
                        Rg = figurante.Rg,
                        Expedicao = figurante.Expedicao,
                        Pis = figurante.Pis,
                        TelFixo = figurante.Fixo,
                        TelCelular = figurante.Celular,
                        TelContato = figurante.Contato,
                        Email = figurante.Email,
                        NmeArtistico = figurante.NomeArtistico,
                        Nacionalidade =  figurante.Nacionalidade,
                        Acesso = figurante.Acesso,
                        Pasta = figurante.Pasta,
                        Mae = figurante.Mae,
                        Pai = figurante.Pai,
                        EstadoCivil = figurante.EstadoCivil,
                        Profissao = figurante.Profissao,
                        RegistroAtor = figurante.RegistroArtistico,
                        Figurante = figurante.AtuaComoFigurante,
                        Ator = figurante.AtuaComoAtor,
                        Modelo = figurante.AtuaComoModelo,
                        Altura = figurante.Altura,
                        IdadeAparente = figurante.IdadeAparente,
                        Peso = figurante.Peso,
                        TipoEtnico = figurante.TipoEtnico,
                        Manequim = figurante.Manequim,
                        Calcado = figurante.Calcado,
                        Busto = figurante.Busto,
                        Quadril = figurante.Quadril,
                        Cintura = figurante.Cintura,
                        Celebridade = figurante.SemelhancaComCelebridade,
                        CorOlhos = figurante.CorOlhos,
                        Cabelo = figurante.Cabelo,
                        CorCabelo = figurante.CorCabelo,
                        TipoCabelo = figurante.TipoCabelo,
                        CorPele = figurante.CorPele,
                        AparelhoDental = figurante.UsaAparelho,
                        IdUsuario = figurante.IdUsuario,

                        Responsavel = figurante.Responsavel,
                        CpfResp = figurante.CpfResp,
                        CertNascimento = figurante.CertNascimento,
                        Livro = figurante.Livro

                    });
                }
                else
                {
                    throw new Exception(string.Format("Figurante informado não constã na base de dados."));

                }
            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(figurante.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível alterar o Figurante solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        public void ExclusaoLogica(Figurante figurante)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Execute(string.Format("Update Pessoa set status = 0 where idpessoa = {0}", figurante .IdPessoa));

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(figurante.IdUsuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível excluir o Figurante solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        public void UnificaFigurante(int idusuario, int idcerto, int iderrado)
        {
            try
            {
                _dao.OpenConnection();
                _dao.Get(new P_UnificaFigurante() { IdPessoaC = idcerto, IdPessoaE = iderrado });

            }
            catch (Exception ex)
            {
                RegistraLogErro.LogAplicacao(idusuario, Idformulario, "Erro : " + ex.Message);
                throw new Exception("Não foi possível unificar o Figurante solicitado" + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        //verificar quais parametros necessários para saber se a pessoa existe
        public bool FiguranteExiste(string parametro)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.ExistsValue(string.Format("Select idpessoa from Pessoa Where nmepessoa = '{0}'", parametro));
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível verificar a existencia do Figurante." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }
        }

        //verificar quais parametros necessários para saber se a pessoa existe
        public bool FiguranteExiste(int id)
        {
            try
            {
                _dao.OpenConnection();
                var result = _dao.ExistsValue(string.Format("select idpessoa from pessoa where idpessoa = {0}", id));
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível verificar a existência do Figurante." + ex.Message);
            }
            finally
            {
                _dao.CloseConnection();
            }

        }

        static public class Retorna
        {
            static public string IdFigurante(string parametro)
            {
                var _dao = new FiguranteDao();
                try
                {
                    _dao.OpenConnection();
                    var result = _dao.GetValue("Select REPLICATE('0', 5 - LEN(idpessoa)) + RTrim(idpessoa) as idpessoa From Pessoa where nmepessoa = '" + parametro + "'");

                    return result;
                }
                catch (Exception ex)
                {
                    RegistraLogErro.LogAplicacao(32, Idformulario, "Erro : " + ex.Message);
                    throw new Exception("Erro : " + ex.Message);
                }
                finally
                {
                    _dao.CloseConnection();
                }

            }
        }

    }
}
