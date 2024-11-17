using System;
using System.Diagnostics;
using WinFormsApp1.Processos;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Task.Run(AtualizarProcessos);
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new();
            startInfo.FileName = "notepad";
            Process process1 = new()
            {
                StartInfo = startInfo
            };
            Process process = process1;
            process.Start();
        }

        private void Button3_Click(object sender, EventArgs e) => cancelarLeituras = true;
        
        
        // Leitura de processos
        bool cancelarLeituras = false;
        private async Task AtualizarProcessos()
        {
            var cache = new GetProcessInfo();
            int currentProcessId = Environment.ProcessId;
            while (!cancelarLeituras)
            {
                Process[] processos = Process.GetProcesses();
                List<Processo> tasks = cache.GetProcessosAsync(processos).Result;
                List<Task> taskss = 
                    [
                        LoadProcess(tasks, currentProcessId, processos),
                        LoadMemory(tasks, currentProcessId)
                    ];
                await Task.WhenAll(taskss);
                await Task.Delay(5000);
            }
        }

        // Processos
        private Task LoadProcess(List<Processo> tasks, int currentProcessId, Process[] processos)
        {
            var processNodes = new Dictionary<int, TreeNode>();
            var processNodes2 = new Dictionary<int, TreeNode>();
            var processosAtuais = new HashSet<int>(processos.Select(p => p.Id));
            var processoFilhos = new Dictionary<int, List<int>>();
            treeView1.Invoke(new Action(treeView1.Nodes.Clear));
            treeView2.Invoke(new Action(treeView2.Nodes.Clear));
            foreach (Processo task in tasks)
            {
                if (!processoFilhos.ContainsKey(task.Pai))
                    processoFilhos[task.Pai] = [];
                processoFilhos[task.Pai].Add(task.Pid);
                if (task.Pai == currentProcessId || (processoFilhos.ContainsKey(task.Pai) && processoFilhos[task.Pai].Contains(currentProcessId)))
                {
                    treeView2.Invoke(new Action(() =>
                    {
                        if (!processNodes2.ContainsKey(task.Pid))
                        {
                            TreeNode processNode = new(task.ToString());
                            if (task.Pai == currentProcessId)
                                treeView2.Nodes.Add(processNode);
                            else
                            {
                                if (!processNodes2.ContainsKey(task.Pai))
                                {
                                    TreeNode parentNode = new(task.ToString());
                                    treeView2.Nodes.Add(parentNode);
                                    processNodes2[task.Pai] = parentNode;
                                }
                                processNodes2[task.Pai].Nodes.Add(processNode);
                            }
                            processNodes2[task.Pid] = processNode;
                        }
                        else
                        {
                            var existingNode = processNodes2[task.Pid];
                            existingNode.Text = task.ToString();
                        }
                        treeView2.ExpandAll();
                    }));
                }

                treeView1.Invoke(new Action(() =>
                {
                    if (!processNodes.ContainsKey(task.Pid))
                    {
                        TreeNode processNode = new(task.ToString());
                        if (task.Pai == 0 || !processNodes.ContainsKey(task.Pai))
                            treeView1.Nodes.Add(processNode);
                        else
                            processNodes[task.Pai].Nodes.Add(processNode);
                        processNodes[task.Pid] = processNode;
                    }
                    else
                    {
                        var existingNode = processNodes[task.Pid];
                        existingNode.Text = task.ToString();
                    }
                    treeView1.ExpandAll();
                }));
            }
            return Task.CompletedTask;
        }

        // Memórias
        private Task LoadMemory(List<Processo> tasks, int currentProcessId)
        {
            var processoMemoria = new Dictionary<int, long>();
            var processoFilhos = new Dictionary<int, List<int>>();
            var processosParaGrafico = new List<Processo>();
            var processosParaGraficoAtual = new List<Processo>();
            foreach (Processo task in tasks)
            {
                processoMemoria[task.Pid] = task.MemoryUsage;
                if (!processoFilhos.ContainsKey(task.Pai))
                    processoFilhos[task.Pai] = [];
                processoFilhos[task.Pai].Add(task.Pid);
                if (task.Pai == currentProcessId || (processoFilhos.ContainsKey(task.Pai) && processoFilhos[task.Pai].Contains(currentProcessId)))
                {
                    processosParaGraficoAtual.Add(new Processo
                    {
                        Nome = task.Nome,
                        Pid = task.Pid,
                        Pai = task.Pai,
                        MemoryUsage = CalcularMemoriaTotal(task.Pid, processoMemoria, processoFilhos)
                    });
                }
            }
            foreach (Processo task in tasks)
            {
                processosParaGrafico.Add(new Processo
                {
                    Nome = task.Nome,
                    Pid = task.Pid,
                    Pai = task.Pai,
                    MemoryUsage = CalcularMemoriaTotal(task.Pid, processoMemoria, processoFilhos)
                });
            }
            LoadMemoryUsageSystem(processosParaGrafico);
            LoadMemoryUsageAplication(processosParaGraficoAtual);
            return Task.CompletedTask;
        }
        private void LoadMemoryUsageAplication(List<Processo> processos)
        {
            webView22.Invoke(new Action(async () =>
            {
                await webView22.EnsureCoreWebView2Async();
                string html = Html.GerarTreemapHtml(processos, "Uso de memória: Aplicação");
                webView22.NavigateToString(html);
            }));
        }
        private void LoadMemoryUsageSystem(List<Processo> processos)
        {
            webView21.Invoke(new Action(async () =>
            {
                await webView21.EnsureCoreWebView2Async();
                string html = Html.GerarTreemapHtml(processos, "Uso de memória: Sistema");
                webView21.NavigateToString(html);
            }));
        }
        private static long CalcularMemoriaTotal(int pid, Dictionary<int, long> processoMemoria, Dictionary<int, List<int>> processoFilhos)
        {
            long memoriaTotal = processoMemoria.ContainsKey(pid) ? processoMemoria[pid] : 0;
            if (processoFilhos.TryGetValue(pid, out List<int>? value))
                foreach (int filhoPid in value)
                    memoriaTotal += CalcularMemoriaTotal(filhoPid, processoMemoria, processoFilhos);
            return memoriaTotal;
        }

    }
}
