using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agencia.Relatorios
{
    static public class FormataDado
    {
        static public string CampoString(string dado, int tamanho)
        {
            var sDado = dado;

            while (sDado.Length < tamanho)
            {
                sDado += " ";
            }

            return sDado;

        }
    }
}
