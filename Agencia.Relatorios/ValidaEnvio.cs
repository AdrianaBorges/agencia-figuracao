using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agencia.Relatorios
{
    static public class ValidaEnvio
    {
        /// <summary>
        /// Verifica se os registro selecionados possuem email valido
        /// </summary>
        static public string Email(ListView lst)
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
        
    }
}
