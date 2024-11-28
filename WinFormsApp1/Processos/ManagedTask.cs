using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

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
        public void AddProcess(string executable, long memoryLimitBytes)
        {
            var process = new CustomProcess
            {
                Name = executable,
                MemoryLimit = memoryLimitBytes,
                State = ProcessState.Waiting,
            };
            processQueue.Enqueue(process);
            ProcessUpdated?.Invoke(process);
        }

        // Inicia o escalonador FCFS com suporte a JobObject
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
                            // Cria o JobObject e aplica o limite de memória
                            IntPtr jobHandle = CreateJobObject(IntPtr.Zero, null);
                            if (jobHandle == IntPtr.Zero)
                            {
                                throw new InvalidOperationException("Falha ao criar JobObject.");
                            }

                            SetJobObjectMemoryLimit(jobHandle, currentProcess.MemoryLimit);

                            // Cria e inicia um processo real
                            currentProcess.Process = CreateChildProcess(currentProcess.Name);

                            // Associa o processo ao JobObject
                            if (!AssignProcessToJobObject(jobHandle, currentProcess.Process.Handle))
                            {
                                throw new InvalidOperationException("Falha ao associar o processo ao JobObject.");
                            }

                            // Atualiza o PID real do processo
                            currentProcess.Id = currentProcess.Process.Id;

                            // Atualiza a interface gráfica
                            ProcessUpdated?.Invoke(currentProcess);

                            // Monitora o término do processo
                            currentProcess.Process.WaitForExit();

                            currentProcess.State = ProcessState.Completed;
                            ProcessUpdated?.Invoke(currentProcess);
                        }
                        catch (Exception ex)
                        {
                            // Caso o processo falhe ao iniciar ou JobObject falhe
                            currentProcess.State = ProcessState.Error;
                            Console.WriteLine($"Erro ao iniciar o processo '{currentProcess.Name}': {ex.Message}");
                            ProcessUpdated?.Invoke(currentProcess);
                        }
                        finally
                        {
                            Interlocked.Decrement(ref runningProcesses); // Reduz o contador de processos em execução
                        }

                        await Task.Delay(500); // Verifica a fila a cada 500ms
                    }

                    await Task.Delay(500); // Verifica a fila a cada 500ms
                }
            });
        }

        // Método que cria e retorna um processo real
        private static Process CreateChildProcess(string fileName)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            return process;
        }

        // Método para configurar limite de memória no JobObject
        private static void SetJobObjectMemoryLimit(IntPtr jobHandle, long memoryLimitBytes)
        {
            const int JobObjectExtendedLimitInformation = 9;
            const uint JOB_OBJECT_LIMIT_PROCESS_MEMORY = 0x100;

            JOBOBJECT_EXTENDED_LIMIT_INFORMATION jobInfo = new JOBOBJECT_EXTENDED_LIMIT_INFORMATION
            {
                BasicLimitInformation = new JOBOBJECT_BASIC_LIMIT_INFORMATION
                {
                    LimitFlags = JOB_OBJECT_LIMIT_PROCESS_MEMORY
                },
                ProcessMemoryLimit = (IntPtr)memoryLimitBytes
            };

            IntPtr jobInfoPtr = Marshal.AllocHGlobal(Marshal.SizeOf(jobInfo));
            try
            {
                Marshal.StructureToPtr(jobInfo, jobInfoPtr, false);
                if (!SetInformationJobObject(jobHandle, JobObjectExtendedLimitInformation, jobInfoPtr, (uint)Marshal.SizeOf(jobInfo)))
                {
                    throw new InvalidOperationException("Falha ao configurar limites no JobObject.");
                }
            }
            finally
            {
                Marshal.FreeHGlobal(jobInfoPtr);
            }
        }

        // Funções do Windows para JobObject
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateJobObject(IntPtr lpJobAttributes, string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AssignProcessToJobObject(IntPtr hJob, IntPtr hProcess);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetInformationJobObject(IntPtr hJob, int JobObjectInfoClass, IntPtr lpJobObjectInfo, uint cbJobObjectInfoLength);

        // Estruturas necessárias para configurar limites
        [StructLayout(LayoutKind.Sequential)]
        private struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
        {
            public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
            public IO_COUNTERS IoInfo;
            public IntPtr ProcessMemoryLimit;
            public IntPtr JobMemoryLimit;
            public IntPtr PeakProcessMemoryUsed;
            public IntPtr PeakJobMemoryUsed;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct JOBOBJECT_BASIC_LIMIT_INFORMATION
        {
            public long PerProcessUserTimeLimit;
            public long PerJobUserTimeLimit;
            public uint LimitFlags;
            public IntPtr MinimumWorkingSetSize;
            public IntPtr MaximumWorkingSetSize;
            public uint ActiveProcessLimit;
            public ulong Affinity;
            public uint PriorityClass;
            public uint SchedulingClass;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct IO_COUNTERS
        {
            public ulong ReadOperationCount;
            public ulong WriteOperationCount;
            public ulong OtherOperationCount;
            public ulong ReadTransferCount;
            public ulong WriteTransferCount;
            public ulong OtherTransferCount;
        }
    }

}
