using System;
using System.Drawing;
using System.Windows.Forms;
using Data.Base;
using Agencia.Dominio.Repositorio;
using Agencia.Dominio.Servico;
using Agencia.Dominio.Modelo;
using Agencia.Infraestrutura.DAL;

namespace Agencia.Relatorios
{
    public partial class frmRelatorioDeAlvara : Form
    {
        public static int ICodigoUsuario { get; set; }
        public static int IdFirma { get; set; }

        public frmRelatorioDeAlvara()
        {
            InitializeComponent();
            WindowsForm.RegisterFocusEvents(Controls);
        }

        private void frmRelatorioDeAlvara_Load(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
                Cursor = Cursors.WaitCursor;

                MontaComboProduto(toolCmbPrograma);

                CarregaRelatorio(0);

                rptAlvara.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n", "Atenção...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private void MontaComboProduto(ToolStripComboBox cmb)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeProdutos().ObterListaDeProdutosComAlvara(ICodigoUsuario));
                cmb.ComboBox.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Produto(s) cadastrados.") + ex.Message);
            }
        }

        private void MontaComboProcesso(ToolStripComboBox cmb, int idprograma)
        {
            try
            {
                new WindowsForm().LoadFromDataTable(cmb, new RepositorioDeAlvara().ObterListaDeProcessos(ICodigoUsuario, idprograma));
                cmb.ComboBox.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível listar o(s) Processos(s) cadastrados para o Produto.") + ex.Message);
            }
        }

        private void CarregaRelatorio(int idalvara)
        {
            try
            {
                p_geraRptAlvaraTableAdapter.Fill(dbAgenciaDataSet.p_geraRptAlvara, idalvara);
                rptAlvara.RefreshReport();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro : " + ex.Message);
            }
        }

        private void toolCmbPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MontaComboProcesso(tooProcesso, Convert.ToInt32(toolCmbPrograma.ComboBox.SelectedValue));
                CarregaRelatorio(0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message), string.Format("Atenção..."), MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CarregaRelatorio(Convert.ToInt32(tooProcesso.ComboBox.SelectedValue));

        }

        private void toolCmbPrograma_DropDownClosed(object sender, EventArgs e)
        {
            if (!this.tooProcesso.DroppedDown) { this.tooProcesso.DroppedDown = true; }

        }
        
    }
}
