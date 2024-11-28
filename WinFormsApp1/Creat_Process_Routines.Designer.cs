namespace Sistema_Operacional
{
    partial class Creat_Process_Routines
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
            label3 = new Label();
            TrackBar_MEMORIA = new TrackBar();
            label4 = new Label();
            button1 = new Button();
            label5 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            Caminho_Do_Arquivo = new TextBox();
            label2 = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            textBox_RAM = new TextBox();
            TrackBar_RAM = new TrackBar();
            tableLayoutPanel8 = new TableLayoutPanel();
            textBox_MEMORIA = new TextBox();
            tableLayoutPanel9 = new TableLayoutPanel();
            button4 = new Button();
            button5 = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            button2 = new Button();
            textBox1 = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            button3 = new Button();
            textBox2 = new TextBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)TrackBar_MEMORIA).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackBar_RAM).BeginInit();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(23, 275);
            label3.Name = "label3";
            label3.Size = new Size(754, 51);
            label3.TabIndex = 5;
            label3.Text = "Limite de uso do Armazenamento";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TrackBar_MEMORIA
            // 
            TrackBar_MEMORIA.Dock = DockStyle.Fill;
            TrackBar_MEMORIA.Location = new Point(20, 3);
            TrackBar_MEMORIA.Margin = new Padding(20, 3, 3, 3);
            TrackBar_MEMORIA.Name = "TrackBar_MEMORIA";
            TrackBar_MEMORIA.Size = new Size(519, 39);
            TrackBar_MEMORIA.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 20);
            label4.Name = "label4";
            label4.Size = new Size(754, 51);
            label4.TabIndex = 6;
            label4.Text = "Criador de Processos";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(141, 39);
            button1.TabIndex = 7;
            button1.Text = "Procurar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Procurar_Executavel_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(23, 71);
            label5.Name = "label5";
            label5.Size = new Size(754, 51);
            label5.TabIndex = 8;
            label5.Text = "Selecione o arquivo EXE";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 0);
            tableLayoutPanel1.Controls.Add(label5, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel6, 0, 4);
            tableLayoutPanel1.Controls.Add(label3, 0, 5);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel8, 0, 6);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel9, 0, 7);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20);
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.9457264F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.0542755F));
            tableLayoutPanel2.Controls.Add(button1, 0, 0);
            tableLayoutPanel2.Controls.Add(Caminho_Do_Arquivo, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(40, 125);
            tableLayoutPanel2.Margin = new Padding(20, 3, 3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(737, 45);
            tableLayoutPanel2.TabIndex = 10;
            // 
            // Caminho_Do_Arquivo
            // 
            Caminho_Do_Arquivo.Dock = DockStyle.Fill;
            Caminho_Do_Arquivo.Location = new Point(150, 3);
            Caminho_Do_Arquivo.Name = "Caminho_Do_Arquivo";
            Caminho_Do_Arquivo.Size = new Size(584, 23);
            Caminho_Do_Arquivo.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(23, 173);
            label2.Name = "label2";
            label2.Size = new Size(754, 51);
            label2.TabIndex = 3;
            label2.Text = "Limite de uso de Memória RAM";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            tableLayoutPanel6.Controls.Add(textBox_RAM, 1, 0);
            tableLayoutPanel6.Controls.Add(TrackBar_RAM, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(23, 227);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(754, 45);
            tableLayoutPanel6.TabIndex = 11;
            // 
            // textBox_RAM
            // 
            textBox_RAM.Dock = DockStyle.Fill;
            textBox_RAM.Location = new Point(545, 3);
            textBox_RAM.Name = "textBox_RAM";
            textBox_RAM.Size = new Size(206, 23);
            textBox_RAM.TabIndex = 9;
            // 
            // TrackBar_RAM
            // 
            TrackBar_RAM.Dock = DockStyle.Fill;
            TrackBar_RAM.Location = new Point(20, 3);
            TrackBar_RAM.Margin = new Padding(20, 3, 3, 3);
            TrackBar_RAM.Name = "TrackBar_RAM";
            TrackBar_RAM.Size = new Size(519, 39);
            TrackBar_RAM.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            tableLayoutPanel8.Controls.Add(textBox_MEMORIA, 1, 0);
            tableLayoutPanel8.Controls.Add(TrackBar_MEMORIA, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(23, 329);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(754, 45);
            tableLayoutPanel8.TabIndex = 12;
            // 
            // textBox_MEMORIA
            // 
            textBox_MEMORIA.Dock = DockStyle.Fill;
            textBox_MEMORIA.Location = new Point(545, 3);
            textBox_MEMORIA.Name = "textBox_MEMORIA";
            textBox_MEMORIA.Size = new Size(206, 23);
            textBox_MEMORIA.TabIndex = 9;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Controls.Add(button4, 0, 0);
            tableLayoutPanel9.Controls.Add(button5, 1, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(23, 380);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Size = new Size(754, 47);
            tableLayoutPanel9.TabIndex = 14;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Location = new Point(3, 3);
            button4.Name = "button4";
            button4.Size = new Size(371, 41);
            button4.TabIndex = 1;
            button4.Text = "Cancelar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Location = new Point(380, 3);
            button5.Name = "button5";
            button5.Size = new Size(371, 41);
            button5.TabIndex = 0;
            button5.Text = "Salvar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.9457264F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.0542755F));
            tableLayoutPanel3.Controls.Add(button2, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(20, 3, 3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.Size = new Size(200, 100);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(33, 94);
            button2.TabIndex = 7;
            button2.Text = "Procurar";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(42, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(155, 23);
            textBox1.TabIndex = 8;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.9457264F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.0542755F));
            tableLayoutPanel4.Controls.Add(button3, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Margin = new Padding(20, 3, 3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(200, 100);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(3, 3);
            button3.Name = "button3";
            button3.Size = new Size(33, 94);
            button3.TabIndex = 7;
            button3.Text = "Procurar";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(42, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(155, 23);
            textBox2.TabIndex = 8;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.Size = new Size(200, 100);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // Creat_Process_Routines
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Creat_Process_Routines";
            Text = "Creat_Process_Routines";
            ((System.ComponentModel.ISupportInitialize)TrackBar_MEMORIA).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrackBar_RAM).EndInit();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label3;
        private TrackBar TrackBar_MEMORIA;
        private Label label4;
        private Button button1;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox Caminho_Do_Arquivo;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button2;
        private TextBox textBox1;
        private TableLayoutPanel tableLayoutPanel4;
        private Button button3;
        private TextBox textBox2;
        private TableLayoutPanel tableLayoutPanel8;
        private TextBox textBox_MEMORIA;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel9;
        private Button button4;
        private Button button5;
        private TableLayoutPanel tableLayoutPanel6;
        private TextBox textBox_RAM;
        private TrackBar TrackBar_RAM;
        private Label label2;
    }
}