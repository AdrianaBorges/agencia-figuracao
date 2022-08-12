using System;
using System.Data;
using System.Net.Mail;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;

namespace Agencia.Relatorios
{
    public partial class frmEnviaEmail : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }
        private ListViewColumnSorter lvwColumnSorter;

        public frmEnviaEmail()
        {
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            this.lstRecibo.ListViewItemSorter = lvwColumnSorter;

            WindowsForm.RegisterFocusEvents(Controls);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmEnviaEmail_Load(object sender, EventArgs e)
        {
            try
            {
                // trabalhar a procedure p_geraRptReciboEmGrupo para exibir os dados em grupo
                // ler de uma tabela temporária
                // criar rotina para ler a lista e gravar na tabela temporária tmpRecGrupo
                WindowState = FormWindowState.Maximized;
                Cursor = Cursors.WaitCursor;
                RepositorioDeFirmas.MontaCombo.Firma(cboNmeFirma, ICodigoUsuario);

                //ListaFigurantes(lstRecibo, -1, "-", 0, qtdPorNota);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;

                MessageBox.Show(string.Format("Erro: ") +
                Environment.NewLine + string.Format(ex.Message),
                string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        
        }

        private void MontaComboNotaFiscal(ComboBox cmb, int idnota)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeNotasFiscais().ObterListaDeNotas(ICodigoUsuario, idnota));
                cmb.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar a(s) Nota(s) cadastradas.") + ex.Message);
            }
        }

        private static void ListaFigurantes(ListView lst, int idnota, string nome, int idpessoa, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();
                var hd1 = lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left); //0
                var hd2 = lst.Columns.Add("Data-Pgto", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left); //1
                var hd3 = lst.Columns.Add("Nº Recibo", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left); //2
                var hd4 = lst.Columns.Add("Vlr-Líquido", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);//3
                var hd5 = lst.Columns.Add("Nome-Figurante", 35 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);//4
                var hd6 = lst.Columns.Add("E-mail", 25 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);//5
                var hd7 = lst.Columns.Add("Status de Envio de E-mail", 34 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);//6

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterListaDeRecibos(ICodigoUsuario, idnota, nome, idpessoa));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Figurante(s).") + ex.Message);
            }
        }

        private static void ListaFigurantePorFirma(ListView lst, int idfirma, string nome, int idpessoa, ToolStripLabel lab)
        {
            try
            {
                lst.Columns.Clear();
                lst.Columns.Add("Código", 7 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left); //0
                lst.Columns.Add("Data-Pgto", 9 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left); //1
                lst.Columns.Add("Nº Recibo", 11 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left); //2
                lst.Columns.Add("Vlr-Líquido", 8 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Right);//3
                lst.Columns.Add("Nome-Figurante", 35 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);//4
                lst.Columns.Add("E-mail", 25 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);//5
                lst.Columns.Add("Status de Envio de E-mail", 34 * Convert.ToInt32(lst.Font.SizeInPoints), HorizontalAlignment.Left);//6

                lst.Items.Clear();
                lst.Groups.Clear();

                new WindowsForm().LoadFromDataTable(lst, new RepositorioDeFigurantesPedidos().ObterReciboFigurantePorFirma(ICodigoUsuario, idfirma, nome, idpessoa));
                lab.Text = lst.Items.Count.ToString();
                lab.Text = string.Format("{0} registro(s) localizado(s)", lst.Items.Count);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Figurante(s).") + ex.Message);
            }
        }
        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ListaFigurantes(lstRecibo, Convert.ToInt32(cmbNotaFiscal.SelectedValue), tstNome.Text, 0, qtdPorNota);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
        //    }
        //}

        private void EnviaReciboPorEmail(ListView lst)
        {
            try
            {
                var repositorioDeFigurantePedido = new RepositorioDeFigurantesPedidos();
                var d = new Dados();

                try
                {
                    foreach (ListViewItem list in lst.Items)
                    {
                        if (list.Checked) //Convert.ToInt32(list.SubItems[0].Text)
                        {
                            d.IdPessoa = Convert.ToInt32(list.SubItems[0].Text);
                            d.NmePessoa = Convert.ToString(list.SubItems[4].Text);
                            d.Nrrb = Convert.ToString(list.SubItems[2].Text);
                            d.DtPagamento = Convert.ToString(list.SubItems[1].Text);
                            d.Valor = Convert.ToString(list.SubItems[3].Text);
                            d.Email = Convert.ToString(list.SubItems[5].Text);
                            //d.Email = "drika.fonseca.borges@gmail.com";
                            d.Conteudo = ConteudoDoRecibo(d.IdPessoa, d.Nrrb);
                            d.NmeFirma = RepositorioDeFirmas.Retorna.NomeFirma(IdFirma);

                            var repositoriodeDadoBancario = new RepositorioDeDadosBancarios();
                            var result = repositoriodeDadoBancario.ObterDadoBancario(ICodigoUsuario, Convert.ToInt32(list.SubItems[0].Text));

                            if (result != null)
                            {
                                d.Banco = result.NomeBanco;
                                d.Agencia = result.Agencia;
                                d.Tipo = result.Tipo;
                                d.NumConta = result.NumeroConta;
                            }

                            EnviaEmail(d);
                            repositorioDeFigurantePedido.RegistraEnvioDeRecibo(ICodigoUsuario, d.IdPessoa, d.Nrrb, d.Email);
                        }
                    }
                }

                catch (Exception ex)
                {
                    throw new ArgumentNullException("Erro : " + ex.Message);
                }

                MessageBox.Show(string.Format("Recibo(s) enviado para o(a) Figurante(s) com sucesso."), string.Format("Envio de Recibo Por Email"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                int idmatricula = 0;
                if (tstMatricula.Text != string.Empty) { idmatricula = Convert.ToInt32(tstMatricula.Text); }
                //ListaFigurantes(lstRecibo, Convert.ToInt32(cmbNotaFiscal.SelectedValue), tstNome.Text, idmatricula, qtdPorNota);
                ListaFigurantePorFirma(lstRecibo, IdFirma, tstNome.Text, 0, qtdPorNota);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                Cursor = Cursors.Default;

            }
        }

        public void SendMail(String nome, String email, String mensagem)
        {
            string sUserName = "pagamento.agencia@gmail.com";
            string sPassword = "Lum#2008";
            string sBobdy = "Mensagem:\n\n" +
                                                "Nome: " + nome + "\n" +
                                                "Email: " + email + "\n" +
                                                "Mensagem: " + mensagem + "\n\n";

            MailMessage objEmail = new MailMessage();
            objEmail.To.Add(email);
            objEmail.From = new MailAddress(sUserName.Trim());
            objEmail.Subject = "Titulo da mensagem";
            objEmail.Body = sBobdy;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587 /* TLS */);
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential(sUserName, sPassword, "");
            try
            {
                smtp.Send(objEmail);
                //exception = "Sucesso";
                //return true;
            }
            catch (Exception e)
            {
                //exception = e.ToString();
                //return false;
            }
        }
        private void EnviaEmail(Dados d)
        {
            string sUserName = "pagamento.agencia@gmail.com";
            string sPassword = "Lum#2008";
            //string sBobdy = "Prezado(a):\n\n" + 

            string sBobdy = "Prezado(a): " + d.NmePessoa + "\n\n" + "Segue dados ref. ao depósito efetuado em " + d.DtPagamento + ", no valor de R$ " + d.Valor + "\n\n" +
                            "Banco: " + d.Banco + "\n" +
                            "Agência: " + d.Agencia + "\n" +
                            "Tipo-Conta: " + d.Tipo + "\n" +
                            "Nº Conta: " + d.NumConta + "\n\n" +

                            "Gravações: " + "\n\n" +
                            "" + d.Conteudo + "\n\n";

                    //"Nome: " + nmepessoa + "\n" +
                    //    "Email: " + email + "\n" +
                    //    "Mensagem: " + mensagem + "\n\n";

            MailMessage objEmail = new MailMessage();
            objEmail.To.Add(d.Email);
            objEmail.From = new MailAddress(sUserName.Trim());
            objEmail.Subject = "Recibo de Pgto nº " + d.Nrrb + " - " + d.NmeFirma;
            objEmail.Body = sBobdy;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587 /* TLS */);
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential(sUserName, sPassword, "");
            try
            {
                smtp.Send(objEmail);
                //exception = "Sucesso";
                //return true;
            }
            catch (Exception e)
            {
                //exception = e.ToString();
                //return false;
            }

        }

        private void LimpaTabelaTemporaria()
        {
            var repositorioDeFigurantePedido = new RepositorioDeFigurantesPedidos();
            try
            {
                repositorioDeFigurantePedido.DeletaReciboTemp(ICodigoUsuario);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private string ConteudoDoRecibo(int idpessoa, string nrrb)
        {
            var repositorioDeFigurantePedido = new RepositorioDeFigurantesPedidos();
            try
            {
                var linha = "";

                string nome = "Mauricio";

                //nome = nome.PadRight(10, ' ');
                // "Mauricio  "

                string codigo = "123";
                codigo = codigo.PadLeft(6, '0');
                // "000123"

                int dif = 0;

                DataTable dataTable =  repositorioDeFigurantePedido.ObterDadosRecibo(ICodigoUsuario, idpessoa, nrrb);

                foreach (DataRow row in dataTable.Rows)
                {
                    //dif = Convert.ToInt32(30) - Convert.ToInt32(row.ItemArray[1].ToString().Length);

                    //nome = row.ItemArray[1].ToString().PadRight(dif, ' ');
                    //nome = row.ItemArray[1].ToString().PadRight(20 - row.ItemArray[1].ToString().Length);

                    //linha += row.ItemArray[0].ToString() + " -  " +
                    //         row.ItemArray[1].ToString().PadRight(40, '.') +
                    //         row.ItemArray[2].ToString().PadRight(40, '.') +
                    //         row.ItemArray[5].ToString() + Environment.NewLine;

                    linha += row.ItemArray[0].ToString() + Environment.NewLine;
                    linha += row.ItemArray[1].ToString() + Environment.NewLine;
                    linha += row.ItemArray[4].ToString() + Environment.NewLine;
                    linha += Environment.NewLine;
  
                }

                return linha;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private bool ItemSelecionado(ListView lst)
        {
            Cursor = Cursors.WaitCursor;

            foreach (ListViewItem list in lstRecibo.Items)
            {
                if (list.Checked) //Convert.ToInt32(list.SubItems[0].Text)
                {
                    return true;
                }
            }

            Cursor = Cursors.Default;

            return false;
        }

        private void toolEnviaEmail_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (ItemSelecionado(lstRecibo))
                {   
                    var mensagem = ValidaEnvio.Email(lstRecibo);

                    if (mensagem != string.Empty)
                    {
                        MessageBox.Show(mensagem, string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                    }
                    else
                    {
                        EnviaReciboPorEmail(lstRecibo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
            
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Verifica se os registro selecionados possuem email valido
        /// </summary>
        private string ValidaEmail(ListView lst)
        {
            var email = "";
            var mensagem = "";

            foreach (ListViewItem list in lst.Items)
            {
                if (list.Checked) 
                {
                    email = Convert.ToString(list.SubItems[5].Text);

                    if (email == string.Empty) 
                    {
                        mensagem += Convert.ToString(list.SubItems[4].Text) + ", não possui e-mail cadastrado" + "\n";
                    }
                }
            }

            return mensagem;
        }
        

        public class Dados
        {
            public int IdPessoa { get; set; }
            public string NmePessoa { get; set; }
            public string Nrrb { get; set; }
            public string DtPagamento { get; set; }
            public string Valor { get; set; }
            public string Email { get; set; }
            public string Conteudo { get; set; }
            public string NmeFirma { get; set; }
            public string Banco { get; set; }
            public string Agencia { get; set; }
            public string Tipo { get; set; }
            public string NumConta { get; set; }
        }
                 


        private void lstRecibo_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.lstRecibo.Sort();
        }

      

        private void tstMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (IdFirma > 0)
                {
                    int idmatricula = 0;

                    if (tstMatricula.Text != string.Empty) { idmatricula = Convert.ToInt32(tstMatricula.Text); }
                    ListaFigurantePorFirma(lstRecibo, IdFirma, tstNome.Text, idmatricula, qtdPorNota);
                }

            }
        }

        private void tstMatricula_Click(object sender, EventArgs e)
        {

        }

        private void cboNmeFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNmeFirma.Selected)
            {
                Cursor = Cursors.WaitCursor;
                IdFirma = Convert.ToInt32(RepositorioDeFirmas.Retorna.IdFirma(cboNmeFirma.Text));
                ListaFigurantePorFirma(lstRecibo, IdFirma, tstNome.Text, 0, qtdPorNota);
                tstNome.Focus();
                Cursor = Cursors.Default; 

            }
        }

        private void tstNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (IdFirma > 0)
                {
                    int idmatricula = 0;

                    if (tstMatricula.Text != string.Empty) { idmatricula = Convert.ToInt32(tstMatricula.Text); }
                    ListaFigurantePorFirma(lstRecibo, IdFirma, tstNome.Text, idmatricula, qtdPorNota);
                }
            }
        }

        private void toolAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdFirma > 0)
                {
                    int idmatricula = 0;

                    if (tstMatricula.Text != string.Empty) { idmatricula = Convert.ToInt32(tstMatricula.Text); }
                    ListaFigurantePorFirma(lstRecibo, IdFirma, tstNome.Text, idmatricula, qtdPorNota);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }
        }
    }
}
