namespace Dodge_Car
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_iniciar = new System.Windows.Forms.Button();
            this.button_controles = new System.Windows.Forms.Button();
            this.button_sair = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer_pontua = new System.Windows.Forms.Timer(this.components);
            this.timer_explosao = new System.Windows.Forms.Timer(this.components);
            this.button_opcao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.ForestGreen;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(850, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button_iniciar
            // 
            this.button_iniciar.BackColor = System.Drawing.Color.White;
            this.button_iniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_iniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_iniciar.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_iniciar.ForeColor = System.Drawing.Color.Brown;
            this.button_iniciar.Location = new System.Drawing.Point(642, 351);
            this.button_iniciar.Name = "button_iniciar";
            this.button_iniciar.Size = new System.Drawing.Size(166, 43);
            this.button_iniciar.TabIndex = 1;
            this.button_iniciar.Text = "Iniciar";
            this.button_iniciar.UseVisualStyleBackColor = false;
            this.button_iniciar.Click += new System.EventHandler(this.button_iniciar_Click);
            // 
            // button_controles
            // 
            this.button_controles.BackColor = System.Drawing.Color.White;
            this.button_controles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_controles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_controles.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_controles.ForeColor = System.Drawing.Color.Brown;
            this.button_controles.Location = new System.Drawing.Point(642, 406);
            this.button_controles.Name = "button_controles";
            this.button_controles.Size = new System.Drawing.Size(166, 43);
            this.button_controles.TabIndex = 2;
            this.button_controles.Text = "Controles";
            this.button_controles.UseVisualStyleBackColor = false;
            this.button_controles.Click += new System.EventHandler(this.button_controles_Click);
            // 
            // button_sair
            // 
            this.button_sair.BackColor = System.Drawing.Color.White;
            this.button_sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sair.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sair.ForeColor = System.Drawing.Color.Brown;
            this.button_sair.Location = new System.Drawing.Point(642, 516);
            this.button_sair.Name = "button_sair";
            this.button_sair.Size = new System.Drawing.Size(166, 43);
            this.button_sair.TabIndex = 3;
            this.button_sair.Text = "Sair";
            this.button_sair.UseVisualStyleBackColor = false;
            this.button_sair.Click += new System.EventHandler(this.button_sair_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 80;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 166);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(81, 422);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "\n";
            this.richTextBox1.Visible = false;
            // 
            // timer_pontua
            // 
            this.timer_pontua.Interval = 1000;
            this.timer_pontua.Tick += new System.EventHandler(this.timer_pontua_Tick);
            // 
            // timer_explosao
            // 
            this.timer_explosao.Interval = 30;
            this.timer_explosao.Tick += new System.EventHandler(this.timer_explosao_Tick);
            // 
            // button_opcao
            // 
            this.button_opcao.BackColor = System.Drawing.Color.White;
            this.button_opcao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_opcao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_opcao.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_opcao.ForeColor = System.Drawing.Color.Brown;
            this.button_opcao.Location = new System.Drawing.Point(642, 462);
            this.button_opcao.Name = "button_opcao";
            this.button_opcao.Size = new System.Drawing.Size(166, 43);
            this.button_opcao.TabIndex = 6;
            this.button_opcao.Text = "Carros";
            this.button_opcao.UseVisualStyleBackColor = false;
            this.button_opcao.Click += new System.EventHandler(this.button_opcao_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.button_opcao);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button_sair);
            this.Controls.Add(this.button_controles);
            this.Controls.Add(this.button_iniciar);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_iniciar;
        private System.Windows.Forms.Button button_controles;
        private System.Windows.Forms.Button button_sair;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer_pontua;
        private System.Windows.Forms.Timer timer_explosao;
        private System.Windows.Forms.Button button_opcao;
    }
}

