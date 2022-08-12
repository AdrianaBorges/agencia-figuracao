namespace EnviarEmail
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDe = new System.Windows.Forms.TextBox();
            this.tbPara = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbCorpo = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSenha = new System.Windows.Forms.TextBox();
            this.tbSMTP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCco = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAssunto = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.cbImportante = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbSSL = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "De:*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Para:*";
            // 
            // tbDe
            // 
            this.tbDe.Location = new System.Drawing.Point(66, 12);
            this.tbDe.Name = "tbDe";
            this.tbDe.Size = new System.Drawing.Size(169, 20);
            this.tbDe.TabIndex = 1;
            // 
            // tbPara
            // 
            this.tbPara.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPara.Location = new System.Drawing.Point(66, 38);
            this.tbPara.Name = "tbPara";
            this.tbPara.Size = new System.Drawing.Size(599, 20);
            this.tbPara.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(505, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Senha:*";
            // 
            // rtbCorpo
            // 
            this.rtbCorpo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCorpo.Location = new System.Drawing.Point(12, 150);
            this.rtbCorpo.Name = "rtbCorpo";
            this.rtbCorpo.Size = new System.Drawing.Size(760, 300);
            this.rtbCorpo.TabIndex = 16;
            this.rtbCorpo.Text = "Este email de teste foi criado a partir de um programa desenvolvido em C#";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Servidor SMTP:*";
            // 
            // tbSenha
            // 
            this.tbSenha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSenha.Location = new System.Drawing.Point(556, 12);
            this.tbSenha.Name = "tbSenha";
            this.tbSenha.PasswordChar = '*';
            this.tbSenha.Size = new System.Drawing.Size(152, 20);
            this.tbSenha.TabIndex = 5;
            // 
            // tbSMTP
            // 
            this.tbSMTP.Location = new System.Drawing.Point(333, 12);
            this.tbSMTP.Name = "tbSMTP";
            this.tbSMTP.Size = new System.Drawing.Size(166, 20);
            this.tbSMTP.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cc:";
            // 
            // tbCc
            // 
            this.tbCc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCc.Location = new System.Drawing.Point(66, 64);
            this.tbCc.Name = "tbCc";
            this.tbCc.Size = new System.Drawing.Size(599, 20);
            this.tbCc.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cco:";
            // 
            // tbCco
            // 
            this.tbCco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCco.Location = new System.Drawing.Point(66, 89);
            this.tbCco.Name = "tbCco";
            this.tbCco.Size = new System.Drawing.Size(599, 20);
            this.tbCco.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Assunto:";
            // 
            // tbAssunto
            // 
            this.tbAssunto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAssunto.Location = new System.Drawing.Point(66, 115);
            this.tbAssunto.Name = "tbAssunto";
            this.tbAssunto.Size = new System.Drawing.Size(599, 20);
            this.tbAssunto.TabIndex = 14;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Location = new System.Drawing.Point(671, 38);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(101, 71);
            this.btnEnviar.TabIndex = 17;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            this.btnEnviar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnEnviar_MouseDown);
            // 
            // cbImportante
            // 
            this.cbImportante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbImportante.AutoSize = true;
            this.cbImportante.Location = new System.Drawing.Point(671, 117);
            this.cbImportante.Name = "cbImportante";
            this.cbImportante.Size = new System.Drawing.Size(79, 17);
            this.cbImportante.TabIndex = 15;
            this.cbImportante.Text = "Importante!";
            this.cbImportante.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // cbSSL
            // 
            this.cbSSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSSL.AutoSize = true;
            this.cbSSL.Location = new System.Drawing.Point(714, 14);
            this.cbSSL.Name = "cbSSL";
            this.cbSSL.Size = new System.Drawing.Size(46, 17);
            this.cbSSL.TabIndex = 6;
            this.cbSSL.Text = "SSL";
            this.cbSSL.UseVisualStyleBackColor = true;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.cbSSL);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbImportante);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.tbAssunto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbCco);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbCc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSMTP);
            this.Controls.Add(this.tbSenha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbCorpo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPara);
            this.Controls.Add(this.tbDe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.Text = "Enviar Email";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDe;
        private System.Windows.Forms.TextBox tbPara;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbCorpo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSenha;
        private System.Windows.Forms.TextBox tbSMTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCco;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbAssunto;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.CheckBox cbImportante;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.CheckBox cbSSL;
    }
}

