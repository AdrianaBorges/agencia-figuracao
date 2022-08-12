using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Agencia.WindowsUI
{
    static public class Funcoes
    {

        static public void LimpaCamposFormulario(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is TextBox) { ((TextBox)(ctrl)).Clear(); }

                if (ctrl is ComboBox) { ((ComboBox)(ctrl)).Text = string.Empty; }

                if (ctrl is MaskedTextBox) { ((MaskedTextBox)(ctrl)).Clear(); }

                if (ctrl is RadioButton) { ((RadioButton)(ctrl)).Checked = false; }

                if (ctrl is CheckBox) { ((CheckBox)(ctrl)).Checked = false; }

                if (ctrl is DataGridView) { ((DataGridView)(ctrl)).Rows.Clear(); }

                //if (ctrl is CheckedListBox)
                //{
                //    ((CheckedListBox)(ctrl)).SetItemChecked(2, false);

                //    for (int x = 0; x <= ((CheckedListBox)(ctrl)).CheckedItems.Count - 1; x++)
                //    {
                //        ((CheckedListBox)(ctrl)).SetItemChecked(x, false);
                //    }
                //}

                LimpaCamposFormulario(ctrl.Controls);
            }
        }

       static public bool ValidaEmail(string Valor)
       {
            if (string.IsNullOrEmpty(Valor))
            {
                return true;
            }
            bool Valido = false;
            Regex regEx = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", RegexOptions.IgnoreCase);
            Valido = regEx.IsMatch(Valor);
            return Valido;
       }

        static public int CalculaIdade(DateTime dtNascimento)
        {
            var idade = DateTime.Now.Year - dtNascimento.Year;
            if (DateTime.Now.Month < dtNascimento.Month || (DateTime.Now.Month == dtNascimento.Month && DateTime.Now.Day < dtNascimento.Day))
                idade--;

            return idade;
        }

        static public bool DataDeBaixaValida(DateTime dtbaixa)
        {
            if (dtbaixa > DateTime.Now)
            {
                return true;
            }
            return false;
        }

        #region Controla as Cores da tela
        static public void RegisterFocusEvents(Control.ControlCollection controls)
        {
            if (controls == null) throw new ArgumentNullException("controls");
            foreach (Control control in controls)
            {
                if ((control is TextBox) ||
                  (control is RichTextBox) ||
                  (control is ComboBox) ||
                  (control is MaskedTextBox))
                {
                    control.Enter += new EventHandler(controlFocus_Enter);
                    control.Leave += new EventHandler(controlFocus_Leave);
                }

                RegisterFocusEvents(control.Controls);
            }
        }

        static void controlFocus_Leave(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.White;
        }

        static void controlFocus_Enter(object sender, EventArgs e)
        {
            (sender as Control).BackColor = Color.LightGreen;
        }

        #endregion


    }
}
