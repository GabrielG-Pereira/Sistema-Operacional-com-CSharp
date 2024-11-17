using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WinFormsApp1
{
    public class MemoryMonitor
    {
        private readonly string _processName; // Nome do processo a ser monitorado (e.g. notepad)
        private Process _process; // Instância do processo atualmente sendo monitorado
        private readonly Action<long> _onMemoryUpdated; // Ação a ser chamada quando a memória for atualizada
        private readonly Action _onProcessExited; // Ação a ser chamada quando o processo realmente for finalizado
        private CancellationTokenSource _cancellationTokenSource; // Para parar o monitoramento
        private Task _monitorTask; // Task para monitorar a memória

        public MemoryMonitor(string processName, Process initialProcess, Action<long> onMemoryUpdated, Action onProcessExited)
        {
            _processName = processName;
            _process = initialProcess;
            _onMemoryUpdated = onMemoryUpdated;
            _onProcessExited = onProcessExited;
        }

        // Inicia o monitoramento do uso de memória
        public void StartMonitoring()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _monitorTask = Task.Run(async () =>
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    try
                    {
                        // Verifica se o processo foi finalizado
                        if (_process.HasExited)
                        {
                            // Tentar localizar um novo processo com o mesmo nome
                            var newProcess = FindNewProcess(_processName);

                            if (newProcess != null)
                            {
                                // Se um novo processo for encontrado, passamos a monitorá-lo
                                _process = newProcess;
                                Console.WriteLine($"Novo processo {newProcess.ProcessName} detectado com PID {newProcess.Id}. Monitorando o novo processo.");
                            }
                            else
                            {
                                // Se não houver novo processo, consideramos o processo como finalizado
                                _onProcessExited?.Invoke();
                                break;
                            }
                        }

                        // Obtém o uso de memória atual do processo
                        long memoryUsage = _process.WorkingSet64;

                        // Chama a ação de callback para atualizar a interface
                        _onMemoryUpdated?.Invoke(memoryUsage);

                        // Aguardar 500ms antes de verificar novamente
                        await Task.Delay(500);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao monitorar a memória do processo: {ex.Message}");
                        break;
                    }
                }
            });
        }

        // Para o monitoramento de memória
        public void StopMonitoring()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _monitorTask?.Wait();
            }
        }

        // Método que tenta localizar um novo processo com o mesmo nome
        private static Process? FindNewProcess(string processName)
        {
            try
            {
                var processes = Process.GetProcessesByName(processName);
                return processes.FirstOrDefault(p => !p.HasExited); // Só retorna processos ainda ativos
            }
            catch
            {
                return null; // Se não encontrar nenhum processo, retorna null
            }
        }
    }
}