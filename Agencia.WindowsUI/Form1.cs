using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data.Base;
using Agencia.Infraestrutura.DAL;
using Agencia.Dominio.Modelo;
using Agencia.Dominio.Repositorio;

namespace Agencia.WindowsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new WindowsForm().LoadComboBoxFromDataTable(comboBox1, new RepositorioDeBairros().ObterListaDeBairros());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //entidade.IdForm, entidade.Data, entidade.Descricao);

            RepositorioDeLogErro rep = new RepositorioDeLogErro();
            LogErro l = new LogErro();
            l.IdForm = 1;
            //l.Data = DateTime.Now;
            l.Descricao = "TESTE";
            rep.RegistraLogErro(l);

        }
    }
}
