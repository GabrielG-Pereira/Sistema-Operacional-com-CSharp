using System.Collections.Concurrent;
using System.Diagnostics;

namespace Sistema_Operacional
{
    public class Scheduler
    {
        private readonly ConcurrentQueue<CustomProcess> processQueue = new ConcurrentQueue<CustomProcess>();
        private Task schedulerTask;
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public event Action<CustomProcess> ProcessUpdated; // Evento para atualizar a interface gráfica
        private readonly int maxConcurrentProcesses; // Limitador de processos simultâneos
        private int runningProcesses = 0; // Contador de processos sendo executados

        public Scheduler(int maxProcesses) => maxConcurrentProcesses = maxProcesses;

        // Adiciona um processo real à fila
        public void AddProcess(string executable)
        {
            var process = new CustomProcess
            {
                Name = executable,
                State = ProcessState.Waiting,
            };
            processQueue.Enqueue(process);
            ProcessUpdated?.Invoke(process);
        }

        // Inicia o escalonador FCFS com processos reais e limitador
        public void StartFCFS()
        {
            schedulerTask = Task.Run(async () =>
            {
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    // Verifica se ainda há processos em execução
                    if (runningProcesses < maxConcurrentProcesses && processQueue.TryDequeue(out CustomProcess currentProcess))
                    {
                        // Aumenta o contador de processos em execução
                        Interlocked.Increment(ref runningProcesses);

                        currentProcess.State = ProcessState.Running;
                        ProcessUpdated?.Invoke(currentProcess);

                        try
                        {
                            // Cria e inicia um processo real
                            currentProcess.Process = CreateChildProcess(currentProcess.Name);

                            // Atualiza o PID real do processo
                            currentProcess.Id = currentProcess.Process.Id;

                            // Atualiza a interface gráfica
                            ProcessUpdated?.Invoke(currentProcess);

                            // Cria e inicia o monitor de memória
                            var memoryMonitor = new MemoryMonitor(
                                currentProcess.Name,
                                currentProcess.Process,
                                memoryUsage =>
                                {
                                    currentProcess.MemoryUsage = memoryUsage;
                                    ProcessUpdated?.Invoke(currentProcess); // Atualiza a UI com o uso de memória
                                },
                                () =>
                                {
                                    currentProcess.State = ProcessState.Completed;
                                    ProcessUpdated?.Invoke(currentProcess);
                                    Interlocked.Decrement(ref runningProcesses); // Reduz o contador de processos em execução
                                });

                            memoryMonitor.StartMonitoring(); // Inicia o monitoramento dinâmico de memória
                        }
                        catch (Exception ex)
                        {
                            // Caso o processo falhe ao iniciar
                            currentProcess.State = ProcessState.Error;
                            Console.WriteLine($"Erro ao iniciar o processo '{currentProcess.Name}': {ex.Message}");
                            ProcessUpdated?.Invoke(currentProcess);
                        }

                        await Task.Delay(500); // Verifica a fila a cada 500ms
                    }

                    await Task.Delay(500); // Verifica a fila a cada 500ms
                }
            });
        }

        public static bool IsProcessRunning(int pid)
        {
            try
            {
                Process process = Process.GetProcessById(pid);
                return !process.HasExited; // Verifica se o processo ainda está rodando
            }
            catch (ArgumentException)
            {
                // O ArgumentException é lançado se o processo não for encontrado
                return false;
            }
        }




        // Método que cria e retorna um processo real
        private static Process CreateChildProcess(string fileName)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,   // Nome do arquivo executável do processo filho
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true, // Redireciona a saída de erro para capturar possíveis falhas
                    CreateNoWindow = true
                }
            };

            // Tenta iniciar o processo e trata exceções
            process.Start();
            return process;
        }

        // Para o escalonador
        public void StopScheduler()
        {
            cancellationTokenSource.Cancel();
            schedulerTask.Wait();
        }

        // Método para cancelar um processo pelo PID
        
    }
}
