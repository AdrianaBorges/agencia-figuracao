namespace Agencia.WindowsUI
{
    partial class frmPosicaoCache
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosicaoCache));
            this.tabDiversos = new System.Windows.Forms.TabControl();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.cmbNotaFiscal = new System.Windows.Forms.ComboBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.qtdPorNota = new System.Windows.Forms.ToolStripLabel();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstMatricula = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tstNome = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAtualizar = new System.Windows.Forms.ToolStripButton();
            this.qtdPosicao = new System.Windows.Forms.ToolStripLabel();
            this.lstPosicao = new System.Windows.Forms.ListView();
            this.tabFigurante = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
            this.txtPessoa = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tooTipçççç = new System.Windows.Forms.TabControl();
            this.tabPendente = new System.Windows.Forms.TabPage();
            this.lstVlrCachePendente = new System.Windows.Forms.ListView();
            this.dtBaixa = new System.Windows.Forms.DateTimePicker();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolbaixaCache = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.qtdCachePendente = new System.Windows.Forms.ToolStripLabel();
            this.lstCachePendente = new System.Windows.Forms.ListView();
            this.tabPago = new System.Windows.Forms.TabPage();
            this.lstVlrPago = new System.Windows.Forms.ListView();
            this.lstRecibo = new System.Windows.Forms.ListBox();
            this.tspRecibo = new System.Windows.Forms.ToolStrip();
            this.tsImprimeRecibo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.qtdCachePago = new System.Windows.Forms.ToolStripLabel();
            this.lstPago = new System.Windows.Forms.ListView();
            this.toolGeraReciboManual = new System.Windows.Forms.ToolStripButton();
            this.tabDiversos.SuspendLayout();
            this.tabConsulta.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolMenuColaborador.SuspendLayout();
            this.tabFigurante.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tooTipçççç.SuspendLayout();
            this.tabPendente.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPago.SuspendLayout();
            this.tspRecibo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDiversos
            // 
            this.tabDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabDiversos.Controls.Add(this.tabConsulta);
            this.tabDiversos.Controls.Add(this.tabFigurante);
            this.tabDiversos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabDiversos.Location = new System.Drawing.Point(14, 14);
            this.tabDiversos.Name = "tabDiversos";
            this.tabDiversos.SelectedIndex = 0;
            this.tabDiversos.Size = new System.Drawing.Size(1191, 780);
            this.tabDiversos.TabIndex = 138;
            // 
            // tabConsulta
            // 
            this.tabConsulta.Controls.Add(this.cmbNotaFiscal);
            this.tabConsulta.Controls.Add(this.toolStrip3);
            this.tabConsulta.Controls.Add(this.toolMenuColaborador);
            this.tabConsulta.Controls.Add(this.lstPosicao);
            this.tabConsulta.ForeColor = System.Drawing.Color.Teal;
            this.tabConsulta.Location = new System.Drawing.Point(4, 24);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsulta.Size = new System.Drawing.Size(1183, 752);
            this.tabConsulta.TabIndex = 0;
            this.tabConsulta.Text = "Consulta(s)";
            this.tabConsulta.ToolTipText = "Consultas Diversas";
            this.tabConsulta.UseVisualStyleBackColor = true;
            // 
            // cmbNotaFiscal
            // 
            this.cmbNotaFiscal.FormattingEnabled = true;
            this.cmbNotaFiscal.Location = new System.Drawing.Point(811, 6);
            this.cmbNotaFiscal.Name = "cmbNotaFiscal";
            this.cmbNotaFiscal.Size = new System.Drawing.Size(161, 23);
            this.cmbNotaFiscal.TabIndex = 267;
            this.cmbNotaFiscal.SelectedValueChanged += new System.EventHandler(this.cmbNotaFiscal_SelectedValueChanged);
            this.cmbNotaFiscal.Click += new System.EventHandler(this.cmbNotaFiscal_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripLabel5,
            this.btnFiltrar,
            this.qtdPorNota,
            this.toolGeraReciboManual});
            this.toolStrip3.Location = new System.Drawing.Point(728, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(445, 25);
            this.toolStrip3.TabIndex = 269;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(244, 22);
            this.toolStripLabel2.Text = "Nota-Fiscal:                                                          ";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(0, 22);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Image")));
            this.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(23, 22);
            this.btnFiltrar.ToolTipText = "Filtrar por Nota Fiscal";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // qtdPorNota
            // 
            this.qtdPorNota.Name = "qtdPorNota";
            this.qtdPorNota.Size = new System.Drawing.Size(13, 22);
            this.qtdPorNota.Text = "0";
            // 
            // toolMenuColaborador
            // 
            this.toolMenuColaborador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenuColaborador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tstMatricula,
            this.toolStripLabel4,
            this.tstNome,
            this.toolStripSeparator5,
            this.toolAtualizar,
            this.qtdPosicao});
            this.toolMenuColaborador.Location = new System.Drawing.Point(3, 3);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(1177, 25);
            this.toolMenuColaborador.TabIndex = 258;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(104, 22);
            this.toolStripLabel1.Text = "Código-Matricula:";
            // 
            // tstMatricula
            // 
            this.tstMatricula.Name = "tstMatricula";
            this.tstMatricula.Size = new System.Drawing.Size(100, 25);
            this.tstMatricula.ToolTipText = "Filtrar por Mátricula";
            this.tstMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstMatricula_KeyPress);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(98, 22);
            this.toolStripLabel4.Text = "Nome-Figurante:";
            // 
            // tstNome
            // 
            this.tstNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tstNome.Name = "tstNome";
            this.tstNome.Size = new System.Drawing.Size(233, 25);
            this.tstNome.ToolTipText = "Filtrar pelo Nome do Figurante";
            this.tstNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstNome_KeyPress);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAtualizar
            // 
            this.toolAtualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAtualizar.Image = global::Agencia.WindowsUI.Properties.Resources.arrow_refresh;
            this.toolAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAtualizar.Name = "toolAtualizar";
            this.toolAtualizar.Size = new System.Drawing.Size(23, 22);
            this.toolAtualizar.Text = "toolStripLabel2";
            this.toolAtualizar.ToolTipText = "Filtrar Figurante";
            this.toolAtualizar.Click += new System.EventHandler(this.toolAtualizar_Click);
            // 
            // qtdPosicao
            // 
            this.qtdPosicao.Name = "qtdPosicao";
            this.qtdPosicao.Size = new System.Drawing.Size(13, 22);
            this.qtdPosicao.Text = "0";
            // 
            // lstPosicao
            // 
            this.lstPosicao.AllowColumnReorder = true;
            this.lstPosicao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPosicao.AutoArrange = false;
            this.lstPosicao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstPosicao.ForeColor = System.Drawing.Color.Teal;
            this.lstPosicao.FullRowSelect = true;
            this.lstPosicao.GridLines = true;
            this.lstPosicao.Location = new System.Drawing.Point(2, 31);
            this.lstPosicao.MultiSelect = false;
            this.lstPosicao.Name = "lstPosicao";
            this.lstPosicao.Size = new System.Drawing.Size(1160, 678);
            this.lstPosicao.TabIndex = 247;
            this.lstPosicao.UseCompatibleStateImageBehavior = false;
            this.lstPosicao.View = System.Windows.Forms.View.Details;
            this.lstPosicao.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstPosicao_ColumnClick);
            this.lstPosicao.Click += new System.EventHandler(this.lstPosicao_Click);
            // 
            // tabFigurante
            // 
            this.tabFigurante.Controls.Add(this.toolStrip1);
            this.tabFigurante.Controls.Add(this.tooTipçççç);
            this.tabFigurante.Location = new System.Drawing.Point(4, 24);
            this.tabFigurante.Name = "tabFigurante";
            this.tabFigurante.Padding = new System.Windows.Forms.Padding(3);
            this.tabFigurante.Size = new System.Drawing.Size(1183, 752);
            this.tabFigurante.TabIndex = 1;
            this.tabFigurante.Text = "Figurante";
            this.tabFigurante.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel11,
            this.txtPessoa,
            this.toolStripSeparator7});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1177, 25);
            this.toolStrip1.TabIndex = 436;
            this.toolStrip1.Text = "toolStrip3";
            // 
            // toolStripLabel11
            // 
            this.toolStripLabel11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel11.ForeColor = System.Drawing.Color.Teal;
            this.toolStripLabel11.Name = "toolStripLabel11";
            this.toolStripLabel11.Size = new System.Drawing.Size(98, 22);
            this.toolStripLabel11.Text = "Nome-Figurante:";
            // 
            // txtPessoa
            // 
            this.txtPessoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPessoa.Enabled = false;
            this.txtPessoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.Size = new System.Drawing.Size(543, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tooTipçççç
            // 
            this.tooTipçççç.Controls.Add(this.tabPendente);
            this.tooTipçççç.Controls.Add(this.tabPago);
            this.tooTipçççç.Location = new System.Drawing.Point(7, 36);
            this.tooTipçççç.Name = "tooTipçççç";
            this.tooTipçççç.SelectedIndex = 0;
            this.tooTipçççç.Size = new System.Drawing.Size(1127, 553);
            this.tooTipçççç.TabIndex = 435;
            // 
            // tabPendente
            // 
            this.tabPendente.Controls.Add(this.lstVlrCachePendente);
            this.tabPendente.Controls.Add(this.dtBaixa);
            this.tabPendente.Controls.Add(this.toolStrip2);
            this.tabPendente.Controls.Add(this.lstCachePendente);
            this.tabPendente.Location = new System.Drawing.Point(4, 24);
            this.tabPendente.Name = "tabPendente";
            this.tabPendente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPendente.Size = new System.Drawing.Size(1119, 525);
            this.tabPendente.TabIndex = 0;
            this.tabPendente.Text = "Cache-Pendente";
            this.tabPendente.UseVisualStyleBackColor = true;
            // 
            // lstVlrCachePendente
            // 
            this.lstVlrCachePendente.AllowColumnReorder = true;
            this.lstVlrCachePendente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVlrCachePendente.AutoArrange = false;
            this.lstVlrCachePendente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstVlrCachePendente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVlrCachePendente.ForeColor = System.Drawing.Color.Teal;
            this.lstVlrCachePendente.FullRowSelect = true;
            this.lstVlrCachePendente.GridLines = true;
            this.lstVlrCachePendente.Location = new System.Drawing.Point(2, 469);
            this.lstVlrCachePendente.MultiSelect = false;
            this.lstVlrCachePendente.Name = "lstVlrCachePendente";
            this.lstVlrCachePendente.Size = new System.Drawing.Size(1080, 48);
            this.lstVlrCachePendente.TabIndex = 441;
            this.lstVlrCachePendente.UseCompatibleStateImageBehavior = false;
            this.lstVlrCachePendente.View = System.Windows.Forms.View.Details;
            // 
            // dtBaixa
            // 
            this.dtBaixa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBaixa.Location = new System.Drawing.Point(120, 3);
            this.dtBaixa.Name = "dtBaixa";
            this.dtBaixa.Size = new System.Drawing.Size(101, 23);
            this.dtBaixa.TabIndex = 439;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbaixaCache,
            this.toolStripLabel6,
            this.toolStripSeparator1,
            this.qtdCachePendente});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1113, 25);
            this.toolStrip2.TabIndex = 437;
            this.toolStrip2.Text = "toolStrip3";
            // 
            // toolbaixaCache
            // 
            this.toolbaixaCache.Image = ((System.Drawing.Image)(resources.GetObject("toolbaixaCache.Image")));
            this.toolbaixaCache.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbaixaCache.Name = "toolbaixaCache";
            this.toolbaixaCache.Size = new System.Drawing.Size(106, 22);
            this.toolbaixaCache.Text = "Registra Baixa";
            this.toolbaixaCache.Click += new System.EventHandler(this.toolbaixaCache_Click);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(115, 22);
            this.toolStripLabel6.Text = "                                    ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // qtdCachePendente
            // 
            this.qtdCachePendente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.qtdCachePendente.ForeColor = System.Drawing.Color.Teal;
            this.qtdCachePendente.Name = "qtdCachePendente";
            this.qtdCachePendente.Size = new System.Drawing.Size(13, 22);
            this.qtdCachePendente.Text = "0";
            // 
            // lstCachePendente
            // 
            this.lstCachePendente.AllowColumnReorder = true;
            this.lstCachePendente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCachePendente.AutoArrange = false;
            this.lstCachePendente.CheckBoxes = true;
            this.lstCachePendente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstCachePendente.ForeColor = System.Drawing.Color.Teal;
            this.lstCachePendente.FullRowSelect = true;
            this.lstCachePendente.GridLines = true;
            this.lstCachePendente.Location = new System.Drawing.Point(2, 36);
            this.lstCachePendente.MultiSelect = false;
            this.lstCachePendente.Name = "lstCachePendente";
            this.lstCachePendente.Size = new System.Drawing.Size(1078, 427);
            this.lstCachePendente.TabIndex = 316;
            this.lstCachePendente.UseCompatibleStateImageBehavior = false;
            this.lstCachePendente.View = System.Windows.Forms.View.Details;
            this.lstCachePendente.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstCachePendente_ColumnClick);
            // 
            // tabPago
            // 
            this.tabPago.Controls.Add(this.lstVlrPago);
            this.tabPago.Controls.Add(this.lstRecibo);
            this.tabPago.Controls.Add(this.tspRecibo);
            this.tabPago.Controls.Add(this.lstPago);
            this.tabPago.Location = new System.Drawing.Point(4, 24);
            this.tabPago.Name = "tabPago";
            this.tabPago.Padding = new System.Windows.Forms.Padding(3);
            this.tabPago.Size = new System.Drawing.Size(1119, 525);
            this.tabPago.TabIndex = 1;
            this.tabPago.Text = "Cache-Pago";
            this.tabPago.UseVisualStyleBackColor = true;
            // 
            // lstVlrPago
            // 
            this.lstVlrPago.AllowColumnReorder = true;
            this.lstVlrPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVlrPago.AutoArrange = false;
            this.lstVlrPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstVlrPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVlrPago.ForeColor = System.Drawing.Color.Teal;
            this.lstVlrPago.FullRowSelect = true;
            this.lstVlrPago.GridLines = true;
            this.lstVlrPago.Location = new System.Drawing.Point(213, 428);
            this.lstVlrPago.MultiSelect = false;
            this.lstVlrPago.Name = "lstVlrPago";
            this.lstVlrPago.Size = new System.Drawing.Size(896, 47);
            this.lstVlrPago.TabIndex = 440;
            this.lstVlrPago.UseCompatibleStateImageBehavior = false;
            this.lstVlrPago.View = System.Windows.Forms.View.Details;
            // 
            // lstRecibo
            // 
            this.lstRecibo.FormattingEnabled = true;
            this.lstRecibo.ItemHeight = 15;
            this.lstRecibo.Location = new System.Drawing.Point(7, 36);
            this.lstRecibo.Name = "lstRecibo";
            this.lstRecibo.Size = new System.Drawing.Size(200, 439);
            this.lstRecibo.TabIndex = 321;
            this.lstRecibo.Click += new System.EventHandler(this.lstRecibo_Click);
            // 
            // tspRecibo
            // 
            this.tspRecibo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspRecibo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsImprimeRecibo,
            this.toolStripButton1,
            this.qtdCachePago});
            this.tspRecibo.Location = new System.Drawing.Point(3, 3);
            this.tspRecibo.Name = "tspRecibo";
            this.tspRecibo.Size = new System.Drawing.Size(1113, 25);
            this.tspRecibo.TabIndex = 320;
            this.tspRecibo.Text = "toolStrip3";
            // 
            // tsImprimeRecibo
            // 
            this.tsImprimeRecibo.ForeColor = System.Drawing.Color.Teal;
            this.tsImprimeRecibo.Image = ((System.Drawing.Image)(resources.GetObject("tsImprimeRecibo.Image")));
            this.tsImprimeRecibo.Name = "tsImprimeRecibo";
            this.tsImprimeRecibo.Size = new System.Drawing.Size(118, 22);
            this.tsImprimeRecibo.Text = "Imprimir-Recibo";
            this.tsImprimeRecibo.Click += new System.EventHandler(this.tsImprimeRecibo_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // qtdCachePago
            // 
            this.qtdCachePago.ForeColor = System.Drawing.Color.Teal;
            this.qtdCachePago.Name = "qtdCachePago";
            this.qtdCachePago.Size = new System.Drawing.Size(14, 22);
            this.qtdCachePago.Text = "0";
            // 
            // lstPago
            // 
            this.lstPago.AllowColumnReorder = true;
            this.lstPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPago.AutoArrange = false;
            this.lstPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstPago.ForeColor = System.Drawing.Color.Teal;
            this.lstPago.FullRowSelect = true;
            this.lstPago.GridLines = true;
            this.lstPago.Location = new System.Drawing.Point(213, 36);
            this.lstPago.MultiSelect = false;
            this.lstPago.Name = "lstPago";
            this.lstPago.Size = new System.Drawing.Size(896, 370);
            this.lstPago.TabIndex = 319;
            this.lstPago.UseCompatibleStateImageBehavior = false;
            this.lstPago.View = System.Windows.Forms.View.Details;
            this.lstPago.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstPago_ColumnClick);
            // 
            // toolGeraReciboManual
            // 
            this.toolGeraReciboManual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolGeraReciboManual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolGeraReciboManual.Image = ((System.Drawing.Image)(resources.GetObject("toolGeraReciboManual.Image")));
            this.toolGeraReciboManual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGeraReciboManual.Name = "toolGeraReciboManual";
            this.toolGeraReciboManual.Size = new System.Drawing.Size(122, 22);
            this.toolGeraReciboManual.Text = "Gera Recibo Manual";
            this.toolGeraReciboManual.Visible = false;
            this.toolGeraReciboManual.Click += new System.EventHandler(this.toolGeraReciboManual_Click);
            // 
            // frmPosicaoCache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 733);
            this.Controls.Add(this.tabDiversos);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.Teal;
            this.Name = "frmPosicaoCache";
            this.Text = "frmPosicaoCache";
            this.Load += new System.EventHandler(this.frmPosicaoCache_Load);
            this.tabDiversos.ResumeLayout(false);
            this.tabConsulta.ResumeLayout(false);
            this.tabConsulta.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolMenuColaborador.ResumeLayout(false);
            this.toolMenuColaborador.PerformLayout();
            this.tabFigurante.ResumeLayout(false);
            this.tabFigurante.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tooTipçççç.ResumeLayout(false);
            this.tabPendente.ResumeLayout(false);
            this.tabPendente.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPago.ResumeLayout(false);
            this.tabPago.PerformLayout();
            this.tspRecibo.ResumeLayout(false);
            this.tspRecibo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDiversos;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.ToolStrip toolMenuColaborador;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolAtualizar;
        private System.Windows.Forms.ToolStripLabel qtdPosicao;
        private System.Windows.Forms.ListView lstPosicao;
        private System.Windows.Forms.TabPage tabFigurante;
        private System.Windows.Forms.TabPage tabPendente;
        private System.Windows.Forms.ToolStripTextBox tstNome;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel11;
        private System.Windows.Forms.ToolStripTextBox txtPessoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.TabPage tabPago;
        private System.Windows.Forms.ListView lstCachePendente;
        private System.Windows.Forms.ToolStrip tspRecibo;
        private System.Windows.Forms.ToolStripButton tsImprimeRecibo;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ListView lstPago;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel qtdCachePendente;
        private System.Windows.Forms.ListBox lstRecibo;
        private System.Windows.Forms.ToolStripLabel qtdCachePago;
        private System.Windows.Forms.DateTimePicker dtBaixa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tooTipçççç;
        private System.Windows.Forms.ToolStripButton toolbaixaCache;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ListView lstVlrPago;
        private System.Windows.Forms.ListView lstVlrCachePendente;
        private System.Windows.Forms.ComboBox cmbNotaFiscal;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripButton btnFiltrar;
        private System.Windows.Forms.ToolStripLabel qtdPorNota;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tstMatricula;
        private System.Windows.Forms.ToolStripButton toolGeraReciboManual;
    }
}