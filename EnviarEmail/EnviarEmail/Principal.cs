using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace EnviarEmail
{
    public partial class Principal : Form
    {
        String de, para, cc, cco, assunto, corpo, senha, smtpServer;

        public Principal()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //tenta enviar o email
            try
            {
                //atribuindo valores dos textbox às variáveis
                de = tbDe.Text.ToString().Trim();
                para = tbPara.Text.ToString().Trim();
                cc = tbCc.Text.ToString().Trim();
                cco = tbCco.Text.ToString().Trim();
                assunto = tbAssunto.Text.ToString();
                corpo = rtbCorpo.Text.ToString();
                senha = tbSenha.TabIndex.ToString();
                smtpServer = tbSMTP.Text.ToString().Trim();

                //verifica se os campos obrigatórios estão preenchidos
                if (!String.IsNullOrEmpty(tbDe.Text.ToString()) || !String.IsNullOrEmpty(tbPara.Text.ToString()) || !String.IsNullOrEmpty(tbSenha.Text.ToString()) || !String.IsNullOrEmpty(tbSMTP.Text.ToString()))
                {
                    //instanciando novo email
                    MailMessage novoEmail = new MailMessage();
                    //smtp
                    SmtpClient smtp = new SmtpClient(smtpServer);
                    smtp.Port = 587;
                    //enviando de
                    novoEmail.From = new MailAddress(de, "Programa de teste c#");
                    //enviar para
                    novoEmail.To.Add(para);
                    //com cópia
                    if(!String.IsNullOrEmpty(cc)) {novoEmail.CC.Add(cc);}
                    //com cópia oculta
                    if (!String.IsNullOrEmpty(cco)) { novoEmail.Bcc.Add(cco); };
                    //assunto
                    novoEmail.Subject = assunto;
                    //corpo
                    novoEmail.Body = corpo;
                    //permitir html
                    novoEmail.IsBodyHtml = true;
                    //prioridade
                    novoEmail.Priority = cbImportante.Checked ? MailPriority.High : MailPriority.Normal;
                    //email e senha para autenticacao
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new NetworkCredential(de, senha);
                    //ssl
                    smtp.EnableSsl = cbSSL.Checked ? true : false;
                    //envia o email usando o smtp
                    smtp.Send(novoEmail);
                    //mensagem de confirmação
                    MessageBox.Show("Email enviado com sucesso.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //pedir para inserir os campos que ficaram em branco
                    MessageBox.Show("Há campos obrigatórios não preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //mensagem de erro genérica
                MessageBox.Show(ex.Message, "Erro durante o envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lblStatus.Text = null;
            }
        }

        private void btnEnviar_MouseDown(object sender, MouseEventArgs e)
        {
            lblStatus.Text = "Enviando...";
        }
    }    
}
