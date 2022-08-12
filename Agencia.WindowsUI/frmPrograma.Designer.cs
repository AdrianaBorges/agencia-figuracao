namespace Agencia.WindowsUI
{
    partial class frmPrograma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrograma));
            this.tabDiversos = new System.Windows.Forms.TabControl();
            this.tabConsulta = new System.Windows.Forms.TabPage();
            this.toolMenuColaborador = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.TxtConsulta = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAtualizar = new System.Windows.Forms.ToolStripButton();
            this.lblQtd = new System.Windows.Forms.ToolStripLabel();
            this.lstProdutos = new System.Windows.Forms.ListView();
            this.tabProduto = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProdutos = new System.Windows.Forms.TabPage();
            this.tsRegistraPrograma = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.novoRegistro = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cadastrarPrograma = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mtbCadastro = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.tabPedidos = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tooNomeProduto = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblQtdPedido = new System.Windows.Forms.ToolStripLabel();
            this.lstPedidos = new System.Windows.Forms.ListView();
            this.tabDiversos.SuspendLayout();
            this.tabConsulta.SuspendLayout();
            this.toolMenuColaborador.SuspendLayout();
            this.tabProduto.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabProdutos.SuspendLayout();
            this.tsRegistraPrograma.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPedidos.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDiversos
            // 
            this.tabDiversos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDiversos.Controls.Add(this.tabConsulta);
            this.tabDiversos.Controls.Add(this.tabProduto);
            this.tabDiversos.Location = new System.Drawing.Point(12, 12);
            this.tabDiversos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabDiversos.Name = "tabDiversos";
            this.tabDiversos.SelectedIndex = 0;
            this.tabDiversos.Size = new System.Drawing.Size(1079, 551);
            this.tabDiversos.TabIndex = 206;
            // 
            // tabConsulta
            // 
            this.tabConsulta.Controls.Add(this.toolMenuColaborador);
            this.tabConsulta.Controls.Add(this.lstProdutos);
            this.tabConsulta.ForeColor = System.Drawing.Color.Teal;
            this.tabConsulta.Location = new System.Drawing.Point(4, 24);
            this.tabConsulta.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabConsulta.Name = "tabConsulta";
            this.tabConsulta.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabConsulta.Size = new System.Drawing.Size(1071, 523);
            this.tabConsulta.TabIndex = 0;
            this.tabConsulta.Text = "Consulta(s)";
            this.tabConsulta.ToolTipText = "Consultas Diversas";
            this.tabConsulta.UseVisualStyleBackColor = true;
            // 
            // toolMenuColaborador
            // 
            this.toolMenuColaborador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenuColaborador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.TxtConsulta,
            this.toolStripSeparator2,
            this.toolAtualizar,
            this.lblQtd});
            this.toolMenuColaborador.Location = new System.Drawing.Point(3, 5);
            this.toolMenuColaborador.Name = "toolMenuColaborador";
            this.toolMenuColaborador.Size = new System.Drawing.Size(1065, 25);
            this.toolMenuColaborador.TabIndex = 259;
            this.toolMenuColaborador.Text = "toolStrip3";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(110, 22);
            this.toolStripLabel4.Text = "Produto-Programa:";
            // 
            // TxtConsulta
            // 
            this.TxtConsulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtConsulta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConsulta.Name = "TxtConsulta";
            this.TxtConsulta.Size = new System.Drawing.Size(339, 25);
            this.TxtConsulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtConsulta_KeyPress);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAtualizar
            // 
            this.toolAtualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("toolAtualizar.Image")));
            this.toolAtualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAtualizar.Name = "toolAtualizar";
            this.toolAtualizar.Size = new System.Drawing.Size(23, 22);
            this.toolAtualizar.Text = "toolStripButton1";
            this.toolAtualizar.ToolTipText = "\"Atualiza de acordo com parametro informado\"";
            this.toolAtualizar.Click += new System.EventHandler(this.toolAtualizar_Click);
            // 
            // lblQtd
            // 
            this.lblQtd.Name = "lblQtd";
            this.lblQtd.Size = new System.Drawing.Size(13, 22);
            this.lblQtd.Text = "0";
            // 
            // lstProdutos
            // 
            this.lstProdutos.AllowColumnReorder = true;
            this.lstProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProdutos.AutoArrange = false;
            this.lstProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstProdutos.ForeColor = System.Drawing.Color.Teal;
            this.lstProdutos.FullRowSelect = true;
            this.lstProdutos.GridLines = true;
            this.lstProdutos.Location = new System.Drawing.Point(3, 31);
            this.lstProdutos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lstProdutos.MultiSelect = false;
            this.lstProdutos.Name = "lstProdutos";
            this.lstProdutos.Size = new System.Drawing.Size(1057, 472);
            this.lstProdutos.TabIndex = 242;
            this.lstProdutos.UseCompatibleStateImageBehavior = false;
            this.lstProdutos.View = System.Windows.Forms.View.Details;
            this.lstProdutos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstProdutos_ColumnClick);
            this.lstProdutos.Click += new System.EventHandler(this.lstProdutos_Click);
            // 
            // tabProduto
            // 
            this.tabProduto.Controls.Add(this.tabControl1);
            this.tabProduto.Location = new System.Drawing.Point(4, 24);
            this.tabProduto.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabProduto.Name = "tabProduto";
            this.tabProduto.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabProduto.Size = new System.Drawing.Size(1071, 523);
            this.tabProduto.TabIndex = 1;
            this.tabProduto.Text = "Produto(s)";
            this.tabProduto.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabProdutos);
            this.tabControl1.Controls.Add(this.tabPedidos);
            this.tabControl1.Location = new System.Drawing.Point(6, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1010, 511);
            this.tabControl1.TabIndex = 139;
            // 
            // tabProdutos
            // 
            this.tabProdutos.Controls.Add(this.tsRegistraPrograma);
            this.tabProdutos.Controls.Add(this.panel1);
            this.tabProdutos.Location = new System.Drawing.Point(4, 24);
            this.tabProdutos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabProdutos.Name = "tabProdutos";
            this.tabProdutos.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tabProdutos.Size = new System.Drawing.Size(1002, 483);
            this.tabProdutos.TabIndex = 0;
            this.tabProdutos.Text = "Detalhes do Produto";
            this.tabProdutos.UseVisualStyleBackColor = true;
            // 
            // tsRegistraPrograma
            // 
            this.tsRegistraPrograma.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.tsRegistraPrograma.Location = new System.Drawing.Point(3, 5);
            this.tsRegistraPrograma.Name = "tsRegistraPrograma";
            this.tsRegistraPrograma.Size = new System.Drawing.Size(996, 25);
            this.tsRegistraPrograma.TabIndex = 369;
            this.tsRegistraPrograma.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoRegistro,
            this.toolStripSeparator1,
            this.cadastrarPrograma,
            this.alterarProduto,
            this.excluirProduto});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Teal;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButton1.Text = "Ferramentas";
            // 
            // novoRegistro
            // 
            this.novoRegistro.ForeColor = System.Drawing.Color.Teal;
            this.novoRegistro.Image = ((System.Drawing.Image)(resources.GetObject("novoRegistro.Image")));
            this.novoRegistro.Name = "novoRegistro";
            this.novoRegistro.Size = new System.Drawing.Size(149, 22);
            this.novoRegistro.Text = "Novo Registro";
            this.novoRegistro.ToolTipText = "\"Registra novo Produto\"";
            this.novoRegistro.Click += new System.EventHandler(this.NovoRegistro_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // cadastrarPrograma
            // 
            this.cadastrarPrograma.ForeColor = System.Drawing.Color.Teal;
            this.cadastrarPrograma.Name = "cadastrarPrograma";
            this.cadastrarPrograma.Size = new System.Drawing.Size(149, 22);
            this.cadastrarPrograma.Text = "Cadastrar";
            this.cadastrarPrograma.ToolTipText = "\"Cadastrar Programa\"";
            this.cadastrarPrograma.Click += new System.EventHandler(this.CadastrarPrograma_Click);
            // 
            // alterarProduto
            // 
            this.alterarProduto.ForeColor = System.Drawing.Color.Teal;
            this.alterarProduto.Name = "alterarProduto";
            this.alterarProduto.Size = new System.Drawing.Size(149, 22);
            this.alterarProduto.Text = "Alterar";
            this.alterarProduto.Click += new System.EventHandler(this.AlterarProduto_Click);
            // 
            // excluirProduto
            // 
            this.excluirProduto.ForeColor = System.Drawing.Color.Teal;
            this.excluirProduto.Name = "excluirProduto";
            this.excluirProduto.Size = new System.Drawing.Size(149, 22);
            this.excluirProduto.Text = "Excluir";
            this.excluirProduto.Click += new System.EventHandler(this.ExcluirProduto_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mtbCadastro);
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.lblSituacao);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtObservacao);
            this.panel1.Controls.Add(this.lblObservacao);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.lblDescricao);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Location = new System.Drawing.Point(3, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 276);
            this.panel1.TabIndex = 368;
            // 
            // mtbCadastro
            // 
            this.mtbCadastro.CalendarForeColor = System.Drawing.Color.Black;
            this.mtbCadastro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbCadastro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mtbCadastro.Location = new System.Drawing.Point(114, 33);
            this.mtbCadastro.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.mtbCadastro.Name = "mtbCadastro";
            this.mtbCadastro.Size = new System.Drawing.Size(122, 25);
            this.mtbCadastro.TabIndex = 326;
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "01- ATIVO",
            "00- INATIVO"});
            this.cmbStatus.Location = new System.Drawing.Point(307, 33);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(125, 23);
            this.cmbStatus.TabIndex = 315;
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.ForeColor = System.Drawing.Color.Teal;
            this.lblSituacao.Location = new System.Drawing.Point(246, 40);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(48, 13);
            this.lblSituacao.TabIndex = 325;
            this.lblSituacao.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(2, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 322;
            this.label1.Text = "Data-Cadastro:";
            // 
            // txtObservacao
            // 
            this.txtObservacao.BackColor = System.Drawing.Color.White;
            this.txtObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacao.Location = new System.Drawing.Point(114, 96);
            this.txtObservacao.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtObservacao.Size = new System.Drawing.Size(451, 108);
            this.txtObservacao.TabIndex = 318;
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacao.ForeColor = System.Drawing.Color.Teal;
            this.lblObservacao.Location = new System.Drawing.Point(20, 93);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(80, 13);
            this.lblObservacao.TabIndex = 321;
            this.lblObservacao.Text = "Observação:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(114, 66);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(451, 23);
            this.txtDescricao.TabIndex = 316;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.ForeColor = System.Drawing.Color.Teal;
            this.lblDescricao.Location = new System.Drawing.Point(35, 69);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(68, 13);
            this.lblDescricao.TabIndex = 320;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(114, 2);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(122, 23);
            this.txtCodigo.TabIndex = 314;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.Teal;
            this.lblCodigo.Location = new System.Drawing.Point(55, 9);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 13);
            this.lblCodigo.TabIndex = 319;
            this.lblCodigo.Text = "Código:";
            // 
            // tabPedidos
            // 
            this.tabPedidos.Controls.Add(this.toolStrip1);
            this.tabPedidos.Controls.Add(this.lstPedidos);
            this.tabPedidos.Location = new System.Drawing.Point(4, 24);
            this.tabPedidos.Name = "tabPedidos";
            this.tabPedidos.Size = new System.Drawing.Size(1002, 483);
            this.tabPedidos.TabIndex = 1;
            this.tabPedidos.Text = "Pedido(s) ";
            this.tabPedidos.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooNomeProduto,
            this.toolStripSeparator3,
            this.lblQtdPedido});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1002, 25);
            this.toolStrip1.TabIndex = 261;
            this.toolStrip1.Text = "toolStrip3";
            // 
            // tooNomeProduto
            // 
            this.tooNomeProduto.ForeColor = System.Drawing.Color.Teal;
            this.tooNomeProduto.Name = "tooNomeProduto";
            this.tooNomeProduto.Size = new System.Drawing.Size(107, 22);
            this.tooNomeProduto.Text = "Produto-Programa";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblQtdPedido
            // 
            this.lblQtdPedido.ForeColor = System.Drawing.Color.Teal;
            this.lblQtdPedido.Name = "lblQtdPedido";
            this.lblQtdPedido.Size = new System.Drawing.Size(13, 22);
            this.lblQtdPedido.Text = "0";
            // 
            // lstPedidos
            // 
            this.lstPedidos.AllowColumnReorder = true;
            this.lstPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPedidos.AutoArrange = false;
            this.lstPedidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstPedidos.ForeColor = System.Drawing.Color.Teal;
            this.lstPedidos.FullRowSelect = true;
            this.lstPedidos.GridLines = true;
            this.lstPedidos.Location = new System.Drawing.Point(3, 30);
            this.lstPedidos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lstPedidos.MultiSelect = false;
            this.lstPedidos.Name = "lstPedidos";
            this.lstPedidos.Size = new System.Drawing.Size(986, 441);
            this.lstPedidos.TabIndex = 260;
            this.lstPedidos.UseCompatibleStateImageBehavior = false;
            this.lstPedidos.View = System.Windows.Forms.View.Details;
            // 
            // frmPrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 690);
            this.Controls.Add(this.tabDiversos);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmPrograma";
            this.Text = "frmPrograma";
            this.Load += new System.EventHandler(this.FrmProgramaLoad);
            this.tabDiversos.ResumeLayout(false);
            this.tabConsulta.ResumeLayout(false);
            this.tabConsulta.PerformLayout();
            this.toolMenuColaborador.ResumeLayout(false);
            this.toolMenuColaborador.PerformLayout();
            this.tabProduto.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabProdutos.ResumeLayout(false);
            this.tabProdutos.PerformLayout();
            this.tsRegistraPrograma.ResumeLayout(false);
            this.tsRegistraPrograma.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPedidos.ResumeLayout(false);
            this.tabPedidos.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDiversos;
        private System.Windows.Forms.TabPage tabConsulta;
        private System.Windows.Forms.ListView lstProdutos;
        private System.Windows.Forms.TabPage tabProduto;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProdutos;
        private System.Windows.Forms.ToolStrip tsRegistraPrograma;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem novoRegistro;
        private System.Windows.Forms.ToolStripMenuItem cadastrarPrograma;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker mtbCadastro;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ToolStrip toolMenuColaborador;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox TxtConsulta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblQtd;
        private System.Windows.Forms.ToolStripMenuItem alterarProduto;
        private System.Windows.Forms.ToolStripMenuItem excluirProduto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolAtualizar;
        private System.Windows.Forms.TabPage tabPedidos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tooNomeProduto;
        private System.Windows.Forms.ToolStripLabel lblQtdPedido;
        private System.Windows.Forms.ListView lstPedidos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}