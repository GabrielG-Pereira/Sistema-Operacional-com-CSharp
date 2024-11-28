namespace Sistema_Operacional
{
    partial class Visualizador_De_Processos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            treeView1 = new TreeView();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            maskedTextBox_PID = new MaskedTextBox();
            button9 = new Button();
            treeView2 = new TreeView();
            tableLayoutPanel2 = new TableLayoutPanel();
            button3 = new Button();
            button1 = new Button();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            webView22 = new Microsoft.Web.WebView2.WinForms.WebView2();
            tableLayoutPanel3 = new TableLayoutPanel();
            button4 = new Button();
            button5 = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            button6 = new Button();
            button7 = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView22).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(3, 3);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(394, 143);
            treeView1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 2);
            tableLayoutPanel1.Controls.Add(treeView1, 0, 0);
            tableLayoutPanel1.Controls.Add(treeView2, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Controls.Add(webView21, 0, 1);
            tableLayoutPanel1.Controls.Add(webView22, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 58.22222F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.666667F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(maskedTextBox_PID, 0, 0);
            tableLayoutPanel5.Controls.Add(button9, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 413);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(394, 34);
            tableLayoutPanel5.TabIndex = 13;
            // 
            // maskedTextBox_PID
            // 
            maskedTextBox_PID.Dock = DockStyle.Fill;
            maskedTextBox_PID.Location = new Point(200, 3);
            maskedTextBox_PID.Mask = "0000000";
            maskedTextBox_PID.Name = "maskedTextBox_PID";
            maskedTextBox_PID.Size = new Size(191, 23);
            maskedTextBox_PID.TabIndex = 5;
            // 
            // button9
            // 
            button9.Dock = DockStyle.Fill;
            button9.Location = new Point(3, 3);
            button9.Name = "button9";
            button9.Size = new Size(191, 28);
            button9.TabIndex = 2;
            button9.Text = "Arvore de um Processo";
            button9.UseVisualStyleBackColor = true;
            button9.Click += Button1_Click;
            // 
            // treeView2
            // 
            treeView2.Dock = DockStyle.Fill;
            treeView2.Location = new Point(403, 3);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(394, 143);
            treeView2.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(button3, 0, 0);
            tableLayoutPanel2.Controls.Add(button1, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(403, 413);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(394, 34);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(3, 3);
            button3.Name = "button3";
            button3.Size = new Size(191, 28);
            button3.TabIndex = 5;
            button3.Text = "Parar Atualização";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(200, 3);
            button1.Name = "button1";
            button1.Size = new Size(191, 28);
            button1.TabIndex = 6;
            button1.Text = "Atualizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(3, 152);
            webView21.Name = "webView21";
            webView21.Size = new Size(394, 255);
            webView21.TabIndex = 11;
            webView21.ZoomFactor = 0.8D;
            // 
            // webView22
            // 
            webView22.AllowExternalDrop = true;
            webView22.CreationProperties = null;
            webView22.DefaultBackgroundColor = Color.White;
            webView22.Dock = DockStyle.Fill;
            webView22.Location = new Point(403, 152);
            webView22.Name = "webView22";
            webView22.Size = new Size(394, 255);
            webView22.TabIndex = 12;
            webView22.ZoomFactor = 0.8D;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(button4, 1, 0);
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.Size = new Size(200, 100);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Location = new Point(103, 3);
            button4.Name = "button4";
            button4.Size = new Size(94, 94);
            button4.TabIndex = 3;
            button4.Text = "Gerar Processo";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Location = new Point(3, 3);
            button5.Name = "button5";
            button5.Size = new Size(94, 94);
            button5.TabIndex = 2;
            button5.Text = "Arvore de um Processo";
            button5.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(button6, 1, 0);
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.Size = new Size(200, 100);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Fill;
            button6.Location = new Point(103, 3);
            button6.Name = "button6";
            button6.Size = new Size(94, 94);
            button6.TabIndex = 3;
            button6.Text = "Gerar Processo";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Fill;
            button7.Location = new Point(3, 3);
            button7.Name = "button7";
            button7.Size = new Size(94, 94);
            button7.TabIndex = 2;
            button7.Text = "Arvore de um Processo";
            button7.UseVisualStyleBackColor = true;
            // 
            // Visualizador_De_Processos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Visualizador_De_Processos";
            Text = "Form1";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView22).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TreeView treeView1;
        private TableLayoutPanel tableLayoutPanel1;
        private TreeView treeView2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private TableLayoutPanel tableLayoutPanel2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView22;
        private TableLayoutPanel tableLayoutPanel4;
        private Button button6;
        private Button button7;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button4;
        private Button button5;
        private Button button3;
        private TableLayoutPanel tableLayoutPanel5;
        private Button button9;
        private MaskedTextBox maskedTextBox_PID;
        private Button button1;
    }
}
