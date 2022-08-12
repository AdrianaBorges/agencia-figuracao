using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agencia.Relatorios
{
    public partial class frmCachePorNota : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }


        public frmCachePorNota()
        {
            InitializeComponent();
        }

        private void frmCachePorNota_Load(object sender, EventArgs e)
        {

            this.rpt.RefreshReport();
        }
    }
}
