﻿namespace Agencia.WindowsUI
{
    partial class frmCentroDeCusto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCentroDeCusto));
            this.tabDiversos = new System.Windows.Forms.TabControl();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TxtConsulta = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAtualizar = new System.Windows.Forms.ToolStripButton();
            this.qtdCentroDeCusto = new System.Windows.Forms.ToolStripLabel();
            this.lstCentroDeCusto = new System.Windows.Forms.ListView();
            this.tabCentroDeCusto = new System.Windows.Forms.TabPage();
            this.tooTipçççç = new System.Windows.Forms.TabControl();
            this.tabDadosGerais = new System.Windows.Forms.TabPage();
            this.pnlCentroDeCustos = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbPrograma = new System.Windows.Forms.ComboBox();
            this.dtpEmissao = new System.Windows.Forms.DateTimePicker();
            this.txtNumFatura = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.tooTotalPrevisto = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.tooTotalPedido = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
            this.tooTotalPago = new System.Windows.Forms.ToolStripTextBox();
            this.tspMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.novaFatura = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CadastrarFatura = new System.Windows.Forms.ToolStripMenuItem();
            this.AlterarFatura = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcluiFatura = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPedido = new System.Windows.Forms.TabPage();
            this.tabSelecao = new System.Windows.Forms.TabControl();
            this.tabSelecionado = new System.Windows.Forms.TabPage();
            this.tooTipSelecionado = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.excluiPedidoFatura = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.qtdPedidoSelecionado = new System.Windows.Forms.ToolStripLabel();
            this.lstPedidoGravado = new System.Windows.Forms.ListView();
            this.tabDisponivel = new System.Windows.Forms.TabPage();
            this.tooTipRegistraPedido = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tooRegistraPedido = new System.Windows.Forms.ToolStripMenuItem();
            this.lstPedidoDisponivel = new System.Windows.Forms.ListView();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.tooTipFiltraPedido = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.stlAte = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tooFiltrarPedido = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.qtdPedidoDisponivel = new System.Windows.Forms.ToolStripLabel();
            this.tabDiversos.SuspendLayout();
            this.tabConsulta.SuspendLayout();
            this.toolMenuColaborador.SuspendLayout();
            this.tabCentroDeCusto.SuspendLayout();
            this.tooTipçççç.SuspendLayout();
            this.tabDadosGerais.SuspendLayout();
            this.pnlCentroDeCustos.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.tspMenu.SuspendLayout();
            this.tabPedido.SuspendLayout();
            this.tabSelecao.SuspendLayout();
            this.tabSelecionado.SuspendLayout();
            this.tooTipSelecionado.SuspendLayout();
            this.tabDisponivel.SuspendLayout();
            this.tooTipRegistraPedido.SuspendLayout();
            this.tooTipFiltraPedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDiversos
            // 
            this.tabDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabDiversos.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabDiversos.Controls.Add(this.tabConsulta);
            this.tabDiversos.Controls.Add(this.tabCentroDeCusto);
            this.tabDiversos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabDiversos.Location = new System.Drawing.Point(14, 14);
            this.tabDiversos.Name = "tabDiversos";
            this.tabDiversos.SelectedIndex = 0;
            this.tabDiversos.Size = new System.Drawing.Size(1026, 542);
            this.tabDiversos.TabIndex = 137;
            // 
            // tabConsulta
            // 
            this.tabConsulta.Controls.Add(this.toolMenuColaborador);
            this.tabConsulta.Controls.Add(this.lstCentroDeCusto);
            this.tabConsulta.ForeColor = System.Drawing.Color.Teal;
            this.tabConsulta.Location = new System.Drawing.Point(4, 27);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsulta.Size = new System.Drawing.Size(1018, 511);
            this.tabConsulta.TabIndex = 0;
            this.tabConsulta.Text = "Consulta(s)";
            this.tabConsulta.ToolTipText = "Consultas Diversas";
            this.tabConsulta.UseVisualStyleBackColor = true;
            // 
            // toolMenuColaborador
            // 
            this.toolMenuColaborador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenuColaborador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TxtConsulta,
            this.toolStripSeparator1,
            this.toolAtualizar,
            this.qtdCentroDeCusto});
            this.toolMenuColaborador.Location = new System.Drawing.Point(3, 3);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(1012, 25);
            this.toolMenuColaborador.TabIndex = 258;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel1.Text = "Nº :";
            // 
            // TxtConsulta
            // 
            this.TxtConsulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtConsulta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConsulta.Name = "TxtConsulta";
            this.TxtConsulta.Size = new System.Drawing.Size(160, 25);
            this.TxtConsulta.ToolTipText = "Digite aqui para filtrar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAtualizar
            // 
            this.toolAtualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAtualizar.Image = global::Agencia.WindowsUI.Properties.Resources.arrow_refresh;
            this.toolAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAtualizar.Name = "toolAtualizar";
            this.toolAtualizar.Size = new System.Drawing.Size(23, 22);
            this.toolAtualizar.Text = "toolStripLabel2";
            this.toolAtualizar.ToolTipText = "Filtrar Fatura(s)";
            // 
            // qtdCentroDeCusto
            // 
            this.qtdCentroDeCusto.Name = "qtdCentroDeCusto";
            this.qtdCentroDeCusto.Size = new System.Drawing.Size(13, 22);
            this.qtdCentroDeCusto.Text = "0";
            // 
            // lstCentroDeCusto
            // 
            this.lstCentroDeCusto.AllowColumnReorder = true;
            this.lstCentroDeCusto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCentroDeCusto.AutoArrange = false;
            this.lstCentroDeCusto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstCentroDeCusto.ForeColor = System.Drawing.Color.Teal;
            this.lstCentroDeCusto.FullRowSelect = true;
            this.lstCentroDeCusto.GridLines = true;
            this.lstCentroDeCusto.Location = new System.Drawing.Point(2, 31);
            this.lstCentroDeCusto.MultiSelect = false;
            this.lstCentroDeCusto.Name = "lstCentroDeCusto";
            this.lstCentroDeCusto.Size = new System.Drawing.Size(908, 463);
            this.lstCentroDeCusto.TabIndex = 247;
            this.lstCentroDeCusto.UseCompatibleStateImageBehavior = false;
            this.lstCentroDeCusto.View = System.Windows.Forms.View.Details;
            // 
            // tabCentroDeCusto
            // 
            this.tabCentroDeCusto.Controls.Add(this.tooTipçççç);
            this.tabCentroDeCusto.Location = new System.Drawing.Point(4, 27);
            this.tabCentroDeCusto.Name = "tabCentroDeCusto";
            this.tabCentroDeCusto.Padding = new System.Windows.Forms.Padding(3);
            this.tabCentroDeCusto.Size = new System.Drawing.Size(1018, 511);
            this.tabCentroDeCusto.TabIndex = 1;
            this.tabCentroDeCusto.Text = "Centro-De-Custo";
            this.tabCentroDeCusto.UseVisualStyleBackColor = true;
            // 
            // tooTipçççç
            // 
            this.tooTipçççç.Controls.Add(this.tabDadosGerais);
            this.tooTipçççç.Controls.Add(this.tabPedido);
            this.tooTipçççç.Location = new System.Drawing.Point(6, 6);
            this.tooTipçççç.Name = "tooTipçççç";
            this.tooTipçççç.SelectedIndex = 0;
            this.tooTipçççç.Size = new System.Drawing.Size(985, 504);
            this.tooTipçççç.TabIndex = 435;
            // 
            // tabDadosGerais
            // 
            this.tabDadosGerais.Controls.Add(this.pnlCentroDeCustos);
            this.tabDadosGerais.Controls.Add(this.toolStrip5);
            this.tabDadosGerais.Controls.Add(this.tspMenu);
            this.tabDadosGerais.Location = new System.Drawing.Point(4, 24);
            this.tabDadosGerais.Name = "tabDadosGerais";
            this.tabDadosGerais.Padding = new System.Windows.Forms.Padding(3);
            this.tabDadosGerais.Size = new System.Drawing.Size(977, 476);
            this.tabDadosGerais.TabIndex = 0;
            this.tabDadosGerais.Text = "Dados-Gerais";
            this.tabDadosGerais.UseVisualStyleBackColor = true;
            // 
            // pnlCentroDeCustos
            // 
            this.pnlCentroDeCustos.Controls.Add(this.label17);
            this.pnlCentroDeCustos.Controls.Add(this.cmbPrograma);
            this.pnlCentroDeCustos.Controls.Add(this.dtpEmissao);
            this.pnlCentroDeCustos.Controls.Add(this.txtNumFatura);
            this.pnlCentroDeCustos.Controls.Add(this.txtObservacao);
            this.pnlCentroDeCustos.Controls.Add(this.txtCodigo);
            this.pnlCentroDeCustos.Controls.Add(this.label18);
            this.pnlCentroDeCustos.Controls.Add(this.label19);
            this.pnlCentroDeCustos.Controls.Add(this.label21);
            this.pnlCentroDeCustos.Controls.Add(this.label22);
            this.pnlCentroDeCustos.Location = new System.Drawing.Point(6, 31);
            this.pnlCentroDeCustos.Name = "pnlCentroDeCustos";
            this.pnlCentroDeCustos.Size = new System.Drawing.Size(608, 244);
            this.pnlCentroDeCustos.TabIndex = 390;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label17.ForeColor = System.Drawing.Color.Teal;
            this.label17.Location = new System.Drawing.Point(3, 87);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 15);
            this.label17.TabIndex = 309;
            this.label17.Text = "Produto-Programa:";
            // 
            // cmbPrograma
            // 
            this.cmbPrograma.FormattingEnabled = true;
            this.cmbPrograma.Location = new System.Drawing.Point(113, 84);
            this.cmbPrograma.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPrograma.Name = "cmbPrograma";
            this.cmbPrograma.Size = new System.Drawing.Size(475, 23);
            this.cmbPrograma.TabIndex = 13;
            // 
            // dtpEmissao
            // 
            this.dtpEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEmissao.Location = new System.Drawing.Point(113, 30);
            this.dtpEmissao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpEmissao.Name = "dtpEmissao";
            this.dtpEmissao.Size = new System.Drawing.Size(104, 23);
            this.dtpEmissao.TabIndex = 11;
            // 
            // txtNumFatura
            // 
            this.txtNumFatura.BackColor = System.Drawing.Color.White;
            this.txtNumFatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumFatura.Location = new System.Drawing.Point(113, 57);
            this.txtNumFatura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumFatura.Name = "txtNumFatura";
            this.txtNumFatura.Size = new System.Drawing.Size(151, 23);
            this.txtNumFatura.TabIndex = 12;
            // 
            // txtObservacao
            // 
            this.txtObservacao.BackColor = System.Drawing.Color.White;
            this.txtObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacao.Location = new System.Drawing.Point(113, 112);
            this.txtObservacao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtObservacao.Size = new System.Drawing.Size(475, 94);
            this.txtObservacao.TabIndex = 14;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(113, 3);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(104, 23);
            this.txtCodigo.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label18.ForeColor = System.Drawing.Color.Teal;
            this.label18.Location = new System.Drawing.Point(30, 33);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 15);
            this.label18.TabIndex = 308;
            this.label18.Text = "Data-Emissão:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label19.ForeColor = System.Drawing.Color.Teal;
            this.label19.Location = new System.Drawing.Point(36, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 15);
            this.label19.TabIndex = 307;
            this.label19.Text = "Carta-Fatura:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label21.ForeColor = System.Drawing.Color.Teal;
            this.label21.Location = new System.Drawing.Point(40, 112);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 15);
            this.label21.TabIndex = 306;
            this.label21.Text = "Observação:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label22.ForeColor = System.Drawing.Color.Teal;
            this.label22.Location = new System.Drawing.Point(65, 6);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 15);
            this.label22.TabIndex = 305;
            this.label22.Text = "Código:";
            // 
            // toolStrip5
            // 
            this.toolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel6,
            this.tooTotalPrevisto,
            this.toolStripLabel7,
            this.tooTotalPedido,
            this.toolStripLabel9,
            this.tooTotalPago});
            this.toolStrip5.Location = new System.Drawing.Point(3, 456);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(971, 25);
            this.toolStrip5.TabIndex = 389;
            this.toolStrip5.Text = "toolStrip5";
            this.toolStrip5.Visible = false;
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.ForeColor = System.Drawing.Color.Teal;
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(89, 22);
            this.toolStripLabel6.Text = "Total-Previsto:";
            // 
            // tooTotalPrevisto
            // 
            this.tooTotalPrevisto.Enabled = false;
            this.tooTotalPrevisto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tooTotalPrevisto.Name = "tooTotalPrevisto";
            this.tooTotalPrevisto.Size = new System.Drawing.Size(80, 25);
            this.tooTotalPrevisto.Text = "0,0";
            this.tooTotalPrevisto.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.ForeColor = System.Drawing.Color.Teal;
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(81, 22);
            this.toolStripLabel7.Text = "Total-Pedido:";
            // 
            // tooTotalPedido
            // 
            this.tooTotalPedido.Enabled = false;
            this.tooTotalPedido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tooTotalPedido.Name = "tooTotalPedido";
            this.tooTotalPedido.Size = new System.Drawing.Size(80, 25);
            this.tooTotalPedido.Text = "0,0";
            this.tooTotalPedido.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStripLabel9
            // 
            this.toolStripLabel9.ForeColor = System.Drawing.Color.Teal;
            this.toolStripLabel9.Name = "toolStripLabel9";
            this.toolStripLabel9.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel9.Text = "Total-Pago:";
            // 
            // tooTotalPago
            // 
            this.tooTotalPago.Enabled = false;
            this.tooTotalPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tooTotalPago.Name = "tooTotalPago";
            this.tooTotalPago.Size = new System.Drawing.Size(80, 25);
            this.tooTotalPago.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tspMenu
            // 
            this.tspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.tspMenu.Location = new System.Drawing.Point(3, 3);
            this.tspMenu.Name = "tspMenu";
            this.tspMenu.Size = new System.Drawing.Size(971, 25);
            this.tspMenu.TabIndex = 364;
            this.tspMenu.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaFatura,
            this.toolStripSeparator3,
            this.CadastrarFatura,
            this.AlterarFatura,
            this.ExcluiFatura});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Teal;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButton1.Text = "Ferramentas";
            // 
            // novaFatura
            // 
            this.novaFatura.ForeColor = System.Drawing.Color.Teal;
            this.novaFatura.Image = ((System.Drawing.Image)(resources.GetObject("novaFatura.Image")));
            this.novaFatura.Name = "novaFatura";
            this.novaFatura.Size = new System.Drawing.Size(149, 22);
            this.novaFatura.Text = "Novo Registro";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(146, 6);
            // 
            // CadastrarFatura
            // 
            this.CadastrarFatura.ForeColor = System.Drawing.Color.Teal;
            this.CadastrarFatura.Name = "CadastrarFatura";
            this.CadastrarFatura.Size = new System.Drawing.Size(149, 22);
            this.CadastrarFatura.Text = "Cadastrar";
            // 
            // AlterarFatura
            // 
            this.AlterarFatura.ForeColor = System.Drawing.Color.Teal;
            this.AlterarFatura.Name = "AlterarFatura";
            this.AlterarFatura.Size = new System.Drawing.Size(149, 22);
            this.AlterarFatura.Text = "Alterar";
            // 
            // ExcluiFatura
            // 
            this.ExcluiFatura.ForeColor = System.Drawing.Color.Teal;
            this.ExcluiFatura.Name = "ExcluiFatura";
            this.ExcluiFatura.Size = new System.Drawing.Size(149, 22);
            this.ExcluiFatura.Text = "Excluir";
            // 
            // tabPedido
            // 
            this.tabPedido.Controls.Add(this.tabSelecao);
            this.tabPedido.Location = new System.Drawing.Point(4, 22);
            this.tabPedido.Name = "tabPedido";
            this.tabPedido.Padding = new System.Windows.Forms.Padding(3);
            this.tabPedido.Size = new System.Drawing.Size(977, 478);
            this.tabPedido.TabIndex = 1;
            this.tabPedido.Text = "Pedido(s) de Gravação";
            this.tabPedido.UseVisualStyleBackColor = true;
            // 
            // tabSelecao
            // 
            this.tabSelecao.Controls.Add(this.tabSelecionado);
            this.tabSelecao.Controls.Add(this.tabDisponivel);
            this.tabSelecao.Location = new System.Drawing.Point(6, 6);
            this.tabSelecao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabSelecao.Name = "tabSelecao";
            this.tabSelecao.SelectedIndex = 0;
            this.tabSelecao.Size = new System.Drawing.Size(822, 468);
            this.tabSelecao.TabIndex = 309;
            // 
            // tabSelecionado
            // 
            this.tabSelecionado.Controls.Add(this.tooTipSelecionado);
            this.tabSelecionado.Controls.Add(this.lstPedidoGravado);
            this.tabSelecionado.Location = new System.Drawing.Point(4, 24);
            this.tabSelecionado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabSelecionado.Name = "tabSelecionado";
            this.tabSelecionado.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabSelecionado.Size = new System.Drawing.Size(814, 440);
            this.tabSelecionado.TabIndex = 0;
            this.tabSelecionado.Text = "Selecionado(s)";
            this.tabSelecionado.UseVisualStyleBackColor = true;
            // 
            // tooTipSelecionado
            // 
            this.tooTipSelecionado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripSeparator5,
            this.qtdPedidoSelecionado});
            this.tooTipSelecionado.Location = new System.Drawing.Point(3, 4);
            this.tooTipSelecionado.Name = "tooTipSelecionado";
            this.tooTipSelecionado.Size = new System.Drawing.Size(808, 25);
            this.tooTipSelecionado.TabIndex = 368;
            this.tooTipSelecionado.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excluiPedidoFatura});
            this.toolStripDropDownButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton2.ForeColor = System.Drawing.Color.Teal;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButton2.Text = "Ferramentas";
            // 
            // excluiPedidoFatura
            // 
            this.excluiPedidoFatura.ForeColor = System.Drawing.Color.Teal;
            this.excluiPedidoFatura.Name = "excluiPedidoFatura";
            this.excluiPedidoFatura.Size = new System.Drawing.Size(108, 22);
            this.excluiPedidoFatura.Text = "Excluir";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // qtdPedidoSelecionado
            // 
            this.qtdPedidoSelecionado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.qtdPedidoSelecionado.ForeColor = System.Drawing.Color.Teal;
            this.qtdPedidoSelecionado.Name = "qtdPedidoSelecionado";
            this.qtdPedidoSelecionado.Size = new System.Drawing.Size(13, 22);
            this.qtdPedidoSelecionado.Text = "0";
            // 
            // lstPedidoGravado
            // 
            this.lstPedidoGravado.AllowColumnReorder = true;
            this.lstPedidoGravado.AutoArrange = false;
            this.lstPedidoGravado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstPedidoGravado.ForeColor = System.Drawing.Color.Teal;
            this.lstPedidoGravado.FullRowSelect = true;
            this.lstPedidoGravado.GridLines = true;
            this.lstPedidoGravado.Location = new System.Drawing.Point(3, 35);
            this.lstPedidoGravado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstPedidoGravado.MultiSelect = false;
            this.lstPedidoGravado.Name = "lstPedidoGravado";
            this.lstPedidoGravado.Size = new System.Drawing.Size(798, 390);
            this.lstPedidoGravado.TabIndex = 292;
            this.lstPedidoGravado.UseCompatibleStateImageBehavior = false;
            this.lstPedidoGravado.View = System.Windows.Forms.View.Details;
            // 
            // tabDisponivel
            // 
            this.tabDisponivel.Controls.Add(this.tooTipRegistraPedido);
            this.tabDisponivel.Controls.Add(this.lstPedidoDisponivel);
            this.tabDisponivel.Controls.Add(this.dtpAte);
            this.tabDisponivel.Controls.Add(this.dtpDe);
            this.tabDisponivel.Controls.Add(this.tooTipFiltraPedido);
            this.tabDisponivel.Location = new System.Drawing.Point(4, 22);
            this.tabDisponivel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDisponivel.Name = "tabDisponivel";
            this.tabDisponivel.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabDisponivel.Size = new System.Drawing.Size(814, 442);
            this.tabDisponivel.TabIndex = 1;
            this.tabDisponivel.Text = "Disponíveis";
            this.tabDisponivel.UseVisualStyleBackColor = true;
            // 
            // tooTipRegistraPedido
            // 
            this.tooTipRegistraPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton3});
            this.tooTipRegistraPedido.Location = new System.Drawing.Point(3, 29);
            this.tooTipRegistraPedido.Name = "tooTipRegistraPedido";
            this.tooTipRegistraPedido.Size = new System.Drawing.Size(808, 25);
            this.tooTipRegistraPedido.TabIndex = 367;
            this.tooTipRegistraPedido.Text = "toolStrip1";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooRegistraPedido});
            this.toolStripDropDownButton3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton3.ForeColor = System.Drawing.Color.Teal;
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButton3.Text = "Ferramentas";
            // 
            // tooRegistraPedido
            // 
            this.tooRegistraPedido.ForeColor = System.Drawing.Color.Teal;
            this.tooRegistraPedido.Name = "tooRegistraPedido";
            this.tooRegistraPedido.Size = new System.Drawing.Size(228, 22);
            this.tooRegistraPedido.Text = "Registrar Pedido de Gravação";
            this.tooRegistraPedido.ToolTipText = "Registra Pedido para Carta Fatura";
            // 
            // lstPedidoDisponivel
            // 
            this.lstPedidoDisponivel.AllowColumnReorder = true;
            this.lstPedidoDisponivel.AutoArrange = false;
            this.lstPedidoDisponivel.CheckBoxes = true;
            this.lstPedidoDisponivel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstPedidoDisponivel.ForeColor = System.Drawing.Color.Teal;
            this.lstPedidoDisponivel.FullRowSelect = true;
            this.lstPedidoDisponivel.GridLines = true;
            this.lstPedidoDisponivel.Location = new System.Drawing.Point(3, 58);
            this.lstPedidoDisponivel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstPedidoDisponivel.MultiSelect = false;
            this.lstPedidoDisponivel.Name = "lstPedidoDisponivel";
            this.lstPedidoDisponivel.Size = new System.Drawing.Size(798, 367);
            this.lstPedidoDisponivel.TabIndex = 304;
            this.lstPedidoDisponivel.UseCompatibleStateImageBehavior = false;
            this.lstPedidoDisponivel.View = System.Windows.Forms.View.Details;
            // 
            // dtpAte
            // 
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAte.Location = new System.Drawing.Point(244, 5);
            this.dtpAte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(111, 23);
            this.dtpAte.TabIndex = 300;
            // 
            // dtpDe
            // 
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDe.Location = new System.Drawing.Point(101, 5);
            this.dtpDe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(110, 23);
            this.dtpDe.TabIndex = 299;
            // 
            // tooTipFiltraPedido
            // 
            this.tooTipFiltraPedido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tooTipFiltraPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.stlAte,
            this.toolStripSeparator8,
            this.tooFiltrarPedido,
            this.toolStripSeparator10,
            this.qtdPedidoDisponivel});
            this.tooTipFiltraPedido.Location = new System.Drawing.Point(3, 4);
            this.tooTipFiltraPedido.Name = "tooTipFiltraPedido";
            this.tooTipFiltraPedido.Size = new System.Drawing.Size(808, 25);
            this.tooTipFiltraPedido.TabIndex = 302;
            this.tooTipFiltraPedido.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.ForeColor = System.Drawing.Color.Teal;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(88, 22);
            this.toolStripLabel3.Text = "Data-Gravação:";
            // 
            // stlAte
            // 
            this.stlAte.ForeColor = System.Drawing.Color.Teal;
            this.stlAte.Name = "stlAte";
            this.stlAte.Size = new System.Drawing.Size(254, 22);
            this.stlAte.Text = "                                      até                                       ";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tooFiltrarPedido
            // 
            this.tooFiltrarPedido.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tooFiltrarPedido.Image = global::Agencia.WindowsUI.Properties.Resources.arrow_refresh;
            this.tooFiltrarPedido.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooFiltrarPedido.Name = "tooFiltrarPedido";
            this.tooFiltrarPedido.Size = new System.Drawing.Size(23, 22);
            this.tooFiltrarPedido.Text = "toolStripButton2";
            this.tooFiltrarPedido.ToolTipText = "Atualiza Filtro de Pedidos Disponíveis";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // qtdPedidoDisponivel
            // 
            this.qtdPedidoDisponivel.ForeColor = System.Drawing.Color.Teal;
            this.qtdPedidoDisponivel.Name = "qtdPedidoDisponivel";
            this.qtdPedidoDisponivel.Size = new System.Drawing.Size(13, 22);
            this.qtdPedidoDisponivel.Text = "0";
            // 
            // frmCentroDeCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 572);
            this.Controls.Add(this.tabDiversos);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmCentroDeCusto";
            this.Text = "frmCentroDeCusto";
            this.Load += new System.EventHandler(this.frmCentroDeCusto_Load);
            this.tabDiversos.ResumeLayout(false);
            this.tabConsulta.ResumeLayout(false);
            this.tabConsulta.PerformLayout();
            this.toolMenuColaborador.ResumeLayout(false);
            this.toolMenuColaborador.PerformLayout();
            this.tabCentroDeCusto.ResumeLayout(false);
            this.tooTipçççç.ResumeLayout(false);
            this.tabDadosGerais.ResumeLayout(false);
            this.tabDadosGerais.PerformLayout();
            this.pnlCentroDeCustos.ResumeLayout(false);
            this.pnlCentroDeCustos.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.tspMenu.ResumeLayout(false);
            this.tspMenu.PerformLayout();
            this.tabPedido.ResumeLayout(false);
            this.tabSelecao.ResumeLayout(false);
            this.tabSelecionado.ResumeLayout(false);
            this.tabSelecionado.PerformLayout();
            this.tooTipSelecionado.ResumeLayout(false);
            this.tooTipSelecionado.PerformLayout();
            this.tabDisponivel.ResumeLayout(false);
            this.tabDisponivel.PerformLayout();
            this.tooTipRegistraPedido.ResumeLayout(false);
            this.tooTipRegistraPedido.PerformLayout();
            this.tooTipFiltraPedido.ResumeLayout(false);
            this.tooTipFiltraPedido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDiversos;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.ToolStrip toolMenuColaborador;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox TxtConsulta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolAtualizar;
        private System.Windows.Forms.ToolStripLabel qtdCentroDeCusto;
        private System.Windows.Forms.ListView lstCentroDeCusto;
        private System.Windows.Forms.TabPage tabCentroDeCusto;
        private System.Windows.Forms.TabControl tooTipçççç;
        private System.Windows.Forms.TabPage tabDadosGerais;
        private System.Windows.Forms.Panel pnlCentroDeCustos;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbPrograma;
        private System.Windows.Forms.DateTimePicker dtpEmissao;
        private System.Windows.Forms.TextBox txtNumFatura;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripTextBox tooTotalPrevisto;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripTextBox tooTotalPedido;
        private System.Windows.Forms.ToolStripLabel toolStripLabel9;
        private System.Windows.Forms.ToolStripTextBox tooTotalPago;
        private System.Windows.Forms.ToolStrip tspMenu;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem novaFatura;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem CadastrarFatura;
        private System.Windows.Forms.ToolStripMenuItem AlterarFatura;
        private System.Windows.Forms.ToolStripMenuItem ExcluiFatura;
        private System.Windows.Forms.TabPage tabPedido;
        private System.Windows.Forms.TabControl tabSelecao;
        private System.Windows.Forms.TabPage tabSelecionado;
        private System.Windows.Forms.ToolStrip tooTipSelecionado;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem excluiPedidoFatura;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel qtdPedidoSelecionado;
        private System.Windows.Forms.ListView lstPedidoGravado;
        private System.Windows.Forms.TabPage tabDisponivel;
        private System.Windows.Forms.ToolStrip tooTipRegistraPedido;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem tooRegistraPedido;
        private System.Windows.Forms.ListView lstPedidoDisponivel;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.ToolStrip tooTipFiltraPedido;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel stlAte;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tooFiltrarPedido;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripLabel qtdPedidoDisponivel;
    }
}