using System.Runtime.InteropServices;
using Sistema_Operacional.Models;

namespace Sistema_Operacional
{
    public partial class Creat_Process_Routines : Form
    {
        public Creat_Process_Routines(BootData data)
        {
            InitializeComponent();

            // Configurar o valor máximo dos TrackBars
            TrackBar_MEMORIA.Maximum = data.MemoryValue;
            TrackBar_RAM.Maximum = data.RAMValue;

            // Atualizar valores nas caixas de texto quando o TrackBar é ajustado
            TrackBar_RAM.Scroll += (s, e) => textBox_RAM.Text = TrackBar_RAM.Value.ToString() + " GB";
            TrackBar_MEMORIA.Scroll += (s, e) => textBox_MEMORIA.Text = TrackBar_MEMORIA.Value.ToString() + " GB";
        }

        private void Procurar_Executavel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos Executáveis (*.exe)|*.exe";
                openFileDialog.Title = "Selecione um Arquivo Executável";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Exibe o caminho do arquivo selecionado no TextBox
                    Caminho_Do_Arquivo.Text = openFileDialog.FileName;
                }
            }
        }

        public ProcessData GetFormData()
        {
            return new ProcessData
            {
                RAMValue = TrackBar_RAM.Value,
                MemoryValue = TrackBar_MEMORIA.Value,
                ExecutablePath = Caminho_Do_Arquivo.Text
            };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
