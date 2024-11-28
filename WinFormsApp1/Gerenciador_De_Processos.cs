using Sistema_Operacional.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Sistema_Operacional
{
    public partial class Gerenciador_De_Processos : Form
    {
        private Scheduler? scheduler;
        private List<ProcessData> processList = new List<ProcessData>(); // Lista carregada do JSON

        public Gerenciador_De_Processos(Scheduler agendador)
        {
            InitializeComponent();
            LoadExecutablePaths();
            scheduler = agendador;
        }

        private void LoadExecutablePaths()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProcessData.json");

            try
            {
                // Verifica se o arquivo existe
                if (File.Exists(filePath))
                {
                    // Lê os dados do arquivo
                    string jsonData = File.ReadAllText(filePath);
                    processList = JsonSerializer.Deserialize<List<ProcessData>>(jsonData) ?? new List<ProcessData>();

                    // Preenche o ComboBox com os ExecutablePaths
                    comboBox1.Items.Clear(); // Limpa os itens antes de adicionar novos
                    foreach (var process in processList)
                    {
                        comboBox1.Items.Add(process.ExecutablePath);
                    }
                }
                else
                {
                    MessageBox.Show("O arquivo ProcessData.json não foi encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os caminhos dos executáveis: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string executablePath = comboBox1.SelectedItem.ToString();

                // Busca o processo correspondente na lista
                var processData = processList.FirstOrDefault(p => p.ExecutablePath == executablePath);

                if (processData != null)
                {
                    // Verifica se é um diretório
                    if (Directory.Exists(executablePath))
                    {
                        // Converte o MemoryValue para bytes
                        long storageLimitBytes = processData.MemoryValue * 1024L * 1024L * 1024L;

                        // Obtém o uso atual do diretório
                        long currentStorageUsedBytes = GetDirectorySize(executablePath);

                        if (currentStorageUsedBytes + storageLimitBytes > storageLimitBytes)
                        {
                            MessageBox.Show($"O limite de armazenamento do diretório '{executablePath}' foi atingido.\n" +
                                            $"Limite: {storageLimitBytes / (1024 * 1024 * 1024)} GB\n" +
                                            $"Usado: {currentStorageUsedBytes / (1024 * 1024 * 1024)} GB",
                                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        MessageBox.Show($"Espaço suficiente disponível no diretório '{executablePath}'.",
                                        "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Converte a memória destinada (em GB) para bytes
                        long memoryLimitBytes = processData.RAMValue * 1024L * 1024L * 1024L;

                        // Envia o caminho do executável e a memória ao escalonador
                        scheduler.AddProcess(executablePath, memoryLimitBytes);

                        MessageBox.Show($"Processo '{executablePath}' com limite de {processData.RAMValue} GB adicionado ao escalonador.",
                                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Processo não encontrado nos dados carregados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um executável no ComboBox.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        // Método para calcular o tamanho total de um diretório
        private static long GetDirectorySize(string path)
        {
            try
            {
                return Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                                .Sum(file => new FileInfo(file).Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao calcular o tamanho do diretório '{path}': {ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string executablePath = comboBox1.SelectedItem.ToString();

                // Busca o processo correspondente na lista
                var processToRemove = processList.FirstOrDefault(p => p.ExecutablePath == executablePath);

                if (processToRemove != null)
                {
                    // Remove o processo da lista
                    processList.Remove(processToRemove);

                    // Atualiza o arquivo JSON
                    SaveProcessListToJson();

                    // Remove o item do ComboBox
                    comboBox1.Items.Remove(executablePath);

                    MessageBox.Show($"Processo '{executablePath}' foi removido com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Processo não encontrado na lista carregada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um executável no ComboBox.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para salvar a lista atualizada no arquivo JSON
        private void SaveProcessListToJson()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProcessData.json");

            try
            {
                string jsonData = JsonSerializer.Serialize(processList, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar os dados atualizados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se há um item selecionado no ComboBox
            if (comboBox1.SelectedItem != null)
            {
                string selectedExecutablePath = comboBox1.SelectedItem.ToString();

                // Busca o processo correspondente na lista
                var selectedProcess = processList.FirstOrDefault(p => p.ExecutablePath == selectedExecutablePath);

                if (selectedProcess != null)
                {
                    // Atualiza o RichTextBox com as informações do processo
                    richTextBox1.Text = $"Executável: {selectedProcess.ExecutablePath}\n" +
                                        $"RAM: {selectedProcess.RAMValue} GB\n" +
                                        $"Memória: {selectedProcess.MemoryValue} GB";
                }
                else
                {
                    richTextBox1.Text = "Processo não encontrado.";
                }
            }
            else
            {
                richTextBox1.Text = "Nenhum processo selecionado.";
            }
        }
    }
}
