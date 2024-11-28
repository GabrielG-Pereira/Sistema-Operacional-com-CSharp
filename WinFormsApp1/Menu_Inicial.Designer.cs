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
            SuspendLayout();
            // 
            // button_BootLoader
            // 
            button_BootLoader.Location = new Point(51, 65);
            button_BootLoader.Name = "button_BootLoader";
            button_BootLoader.Size = new Size(183, 123);
            button_BootLoader.TabIndex = 0;
            button_BootLoader.Text = "BootLoader";
            button_BootLoader.UseVisualStyleBackColor = true;
            button_BootLoader.Click += button_BootLoader_Click;
            // 
            // button_Gerenciador
            // 
            button_Gerenciador.Location = new Point(293, 65);
            button_Gerenciador.Name = "button_Gerenciador";
            button_Gerenciador.Size = new Size(183, 123);
            button_Gerenciador.TabIndex = 1;
            button_Gerenciador.Text = "Gerenciador de Tarefas";
            button_Gerenciador.UseVisualStyleBackColor = true;
            button_Gerenciador.Click += button_Gerenciador_Click;
            // 
            // button_Criar_Processos
            // 
            button_Criar_Processos.Location = new Point(51, 256);
            button_Criar_Processos.Name = "button_Criar_Processos";
            button_Criar_Processos.Size = new Size(183, 123);
            button_Criar_Processos.TabIndex = 2;
            button_Criar_Processos.Text = "Criar Processos";
            button_Criar_Processos.UseVisualStyleBackColor = true;
            button_Criar_Processos.Click += button_Criar_Processos_Click;
            // 
            // button_Remover_Processo
            // 
            button_Remover_Processo.Location = new Point(293, 256);
            button_Remover_Processo.Name = "button_Remover_Processo";
            button_Remover_Processo.Size = new Size(183, 123);
            button_Remover_Processo.TabIndex = 3;
            button_Remover_Processo.Text = "Gerenciador de Processo";
            button_Remover_Processo.UseVisualStyleBackColor = true;
            button_Remover_Processo.Click += button_Remover_Processo_Click;
            // 
            // Menu_Inicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 450);
            Controls.Add(button_Remover_Processo);
            Controls.Add(button_Criar_Processos);
            Controls.Add(button_Gerenciador);
            Controls.Add(button_BootLoader);
            Name = "Menu_Inicial";
            Text = "Menu_Inicial";
            ResumeLayout(false);
        }

        #endregion

        private Button button_BootLoader;
        private Button button_Gerenciador;
        private Button button_Criar_Processos;
        private Button button_Remover_Processo;
    }
}