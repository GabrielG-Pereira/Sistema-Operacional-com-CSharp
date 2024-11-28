using Sistema_Operacional.Models;
using System.Text.Json;

namespace Sistema_Operacional
{
    public partial class Menu_Inicial : Form
    {

        public Menu_Inicial()
        {
            InitializeComponent();
            BootData bootData = LoadBootDataFromJson();

            scheduler = new Scheduler(bootData.CPUValue);
            scheduler.StartFCFS();
        }

        private Scheduler? scheduler;

        private void button_BootLoader_Click(object sender, EventArgs e)
        {
            using (BootLoader creat_Process_Routines = new BootLoader())
            {
                if (creat_Process_Routines.ShowDialog() == DialogResult.OK)
                {
                    // Obter os dados do formulário
                    BootData data = creat_Process_Routines.GetFormData();

                    // Salvar os dados em um arquivo JSON
                    SaveDataToJson(data);
                }
            }
        }

        private void button_Gerenciador_Click(object sender, EventArgs e)
        {
            Visualizador_De_Processos form1 = new Visualizador_De_Processos();
            form1.ShowDialog();
        }

        private void button_Criar_Processos_Click(object sender, EventArgs e)
        {
            // Carrega os dados do arquivo BootData.json ou inicializa com valores padrão
            BootData bootData = LoadBootDataFromJson();

            // Passa o BootData ao formulário
            using (Creat_Process_Routines creat_Process_Routines = new Creat_Process_Routines(bootData))
            {
                if (creat_Process_Routines.ShowDialog() == DialogResult.OK)
                {
                    // Obter os dados atualizados do BootData
                    ProcessData updatedBootData = creat_Process_Routines.GetFormData();

                    // Salvar os dados atualizados em um arquivo JSON
                    SaveDataToJson(updatedBootData);
                }
            }
        }

        // Função para carregar BootData de um arquivo JSON
        private BootData LoadBootDataFromJson()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BootData.json");

            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<BootData>(jsonData) ?? new BootData
                    {
                        CPUValue = 4,  // Valor padrão
                        RAMValue = 8,  // Valor padrão
                        MemoryValue = 256 // Valor padrão
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar BootData: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Retorna valores padrão se o arquivo não existir ou houver falha ao carregar
            return new BootData
            {
                CPUValue = 4,  // Valor padrão
                RAMValue = 8,  // Valor padrão
                MemoryValue = 256 // Valor padrão
            };
        }

        private void button_Remover_Processo_Click(object sender, EventArgs e)
        {
            Gerenciador_De_Processos gerenciador_De_Processos = new Gerenciador_De_Processos(scheduler);
            gerenciador_De_Processos.ShowDialog();
        }

        public static void SaveDataToJson(object data, string filePath = null)
        {
            try
            {
                // Verifica o tipo do objeto enviado
                if (data is BootData)
                {
                    filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BootData.json");

                    // Salva ou substitui diretamente o arquivo
                    string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
                    File.WriteAllText(filePath, jsonData);
                }
                else if (data is ProcessData processData)
                {
                    filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProcessData.json");

                    List<ProcessData> processList = new();

                    // Verifica se o arquivo existe
                    if (File.Exists(filePath))
                    {
                        // Lê os dados existentes
                        string existingData = File.ReadAllText(filePath);
                        processList = JsonSerializer.Deserialize<List<ProcessData>>(existingData) ?? new List<ProcessData>();
                    }

                    // Verifica se já existe um item com o mesmo ExecutablePath
                    ProcessData existingProcess = processList.FirstOrDefault(p => p.ExecutablePath == processData.ExecutablePath);
                    if (existingProcess != null)
                    {
                        // Atualiza os dados existentes
                        existingProcess.RAMValue = processData.RAMValue;
                        existingProcess.MemoryValue = processData.MemoryValue;
                    }
                    else
                    {
                        // Adiciona um novo item à lista
                        processList.Add(processData);
                    }

                    // Serializa novamente a lista e salva no arquivo
                    string jsonData = JsonSerializer.Serialize(processList, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
                    File.WriteAllText(filePath, jsonData);
                }
                else
                {
                    throw new InvalidOperationException("Tipo de objeto não suportado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
