using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Globalization;

namespace Agencia.WindowsUI
{
    public partial class frmProgressBar : Form
    {
        // Crie uma variável do tipo bool para controlar o timer
        public bool _timerElapsed;        

        public frmProgressBar()
        {
            InitializeComponent();
        }

        private void frmProgressBar_Load(object sender, EventArgs e)
        {

        }

        // Crie um método chamado Wait para pausar por alguns milisegundos para atualizar a barra
        private void Wait(int timervalue) // Este parâmetro define o valor dos milisegundos
        {
            // configura o timer para o número de milisegundos desejado
            timer1.Interval = timervalue;
            // habilitar o timer e configura o flag timerElapsed para false
            timer1.Enabled = true;
            _timerElapsed = false;

            //Insira este laço para realizar os eventos enquanto o flag estiver como false
            while (_timerElapsed == false)
            {
                Application.DoEvents();
            }
        }

        // Crie o método  timer1_Tick_1 (basta dar um duplo clique sobre o ícone do relógio no form)
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Configure o flag para true e desabilite o timer
            _timerElapsed = true;
            timer1.Enabled = false;
        }

        /*   Crie um método para configurar o tamanho máximo da Barra como o MaximumBar
*   A barra de progresso pode ser atualizada por função, por tempo ou pelo que se desejar. Neste exemplo
*ela está sendo atualizada por incremento. Eu configuro o tamanho máximo da barra para o número de laços
*da função. Se o laço ocorrer X vezes, então configuro o Maximum para X e a cada passada no laço   
* utilizo o  método AtualizaBarra() que incrementa 1 na barra, fazendo-a crescer.
*/
        public void MaximumBar(int maximum)
        {
            progressBar1.Maximum = maximum;
        }

        // Crie o método que atualiza a barra
        public void AtualizaBarra(string texto) // Esta string servirá para setar o texto do label informando o que está  sendo atualizado
        {
            // Atribui o texto e atualiza o label na tela
            label1.Text = texto;
            label1.Update();

            // Utiliza o método Wait (1 milisegundo) para atualizar a barra. Este tempo pode ser aumentado caso a barra vá muito rápido
            Wait(1);
            // Incrementa a barra para crescer
            progressBar1.Value++;
            // Atualiza a barra na tela
            progressBar1.Update();

        }                                 
    }
}
