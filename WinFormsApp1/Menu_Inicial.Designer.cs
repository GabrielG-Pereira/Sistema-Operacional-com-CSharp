namespace Sistema_Operacional
{
    partial class Menu_Inicial
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
            button_BootLoader = new Button();
            button_Gerenciador = new Button();
            button_Criar_Processos = new Button();
            button_Remover_Processo = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            label4 = new Label();
            label1 = new Label();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // button_BootLoader
            // 
            button_BootLoader.Dock = DockStyle.Fill;
            button_BootLoader.Location = new Point(3, 3);
            button_BootLoader.Name = "button_BootLoader";
            button_BootLoader.Size = new Size(220, 83);
            button_BootLoader.TabIndex = 0;
            button_BootLoader.Text = "BootLoader";
            button_BootLoader.UseVisualStyleBackColor = true;
            button_BootLoader.Click += button_BootLoader_Click;
            // 
            // button_Gerenciador
            // 
            button_Gerenciador.Dock = DockStyle.Fill;
            button_Gerenciador.Location = new Point(229, 3);
            button_Gerenciador.Name = "button_Gerenciador";
            button_Gerenciador.Size = new Size(221, 83);
            button_Gerenciador.TabIndex = 1;
            button_Gerenciador.Text = "Visualizador de Processos";
            button_Gerenciador.UseVisualStyleBackColor = true;
            button_Gerenciador.Click += button_Gerenciador_Click;
            // 
            // button_Criar_Processos
            // 
            button_Criar_Processos.Dock = DockStyle.Fill;
            button_Criar_Processos.Location = new Point(3, 3);
            button_Criar_Processos.Name = "button_Criar_Processos";
            button_Criar_Processos.Size = new Size(220, 83);
            button_Criar_Processos.TabIndex = 2;
            button_Criar_Processos.Text = "Criar Processos";
            button_Criar_Processos.UseVisualStyleBackColor = true;
            button_Criar_Processos.Click += button_Criar_Processos_Click;
            // 
            // button_Remover_Processo
            // 
            button_Remover_Processo.Dock = DockStyle.Fill;
            button_Remover_Processo.Location = new Point(229, 3);
            button_Remover_Processo.Name = "button_Remover_Processo";
            button_Remover_Processo.Size = new Size(221, 83);
            button_Remover_Processo.TabIndex = 3;
            button_Remover_Processo.Text = "Gerenciador de Processo";
            button_Remover_Processo.UseVisualStyleBackColor = true;
            button_Remover_Processo.Click += button_Remover_Processo_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label1, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(50, 20, 50, 50);
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(559, 450);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(button_Criar_Processos, 0, 0);
            tableLayoutPanel3.Controls.Add(button_Remover_Processo, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(53, 308);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(453, 89);
            tableLayoutPanel3.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(button_Gerenciador, 1, 0);
            tableLayoutPanel4.Controls.Add(button_BootLoader, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(53, 118);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(453, 89);
            tableLayoutPanel4.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(70, 60);
            label4.Margin = new Padding(20, 40, 20, 20);
            label4.Name = "label4";
            label4.Size = new Size(419, 35);
            label4.TabIndex = 9;
            label4.Text = "Sistema";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(70, 250);
            label1.Margin = new Padding(20, 40, 20, 20);
            label1.Name = "label1";
            label1.Size = new Size(419, 35);
            label1.TabIndex = 10;
            label1.Text = "Processos";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Menu_Inicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 450);
            Controls.Add(tableLayoutPanel2);
            Name = "Menu_Inicial";
            Text = "Menu_Inicial";
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button_BootLoader;
        private Button button_Gerenciador;
        private Button button_Criar_Processos;
        private Button button_Remover_Processo;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private Label label4;
    }
}