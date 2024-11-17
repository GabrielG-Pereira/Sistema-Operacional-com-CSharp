using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinFormsApp1.Processos
{
    public class GetProcessInfo
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESS_BASIC_INFORMATION
        {
            public nint ExitStatus;
            public nint PebBaseAddress;
            public nint AffinityMask;
            public nint BasePriority;
            public nint UniqueProcessId;
            public nint InheritedFromUniqueProcessId;
        }

        [DllImport("ntdll.dll")]
        private static extern int NtQueryInformationProcess(
            nint processHandle,
            int processInformationClass,
            ref PROCESS_BASIC_INFORMATION processInformation,
            uint processInformationLength,
            out uint returnLength);

        // Cache para armazenar processos
        private static ConcurrentDictionary<int, Processo> processoCache = new ConcurrentDictionary<int, Processo>();

        private static string? GetProcessState(Process process)
        {
            try
            {
                if (!process.Responding)
                {
                    return "Não Respondendo";
                }

                foreach (ProcessThread thread in process.Threads)
                {
                    if (thread.ThreadState == System.Diagnostics.ThreadState.Running)
                    {
                        return "Executando";
                    }

                    if (thread.ThreadState == System.Diagnostics.ThreadState.Wait &&
                        thread.WaitReason == ThreadWaitReason.Suspended)
                    {
                        return "Suspenso";
                    }
                }

                return "Pronto"; // Se não houver threads executando
            }
            catch
            {
                return "Indefinido";
            }
        }

        private static int GetParentProcessId(Process process)
        {
            PROCESS_BASIC_INFORMATION pbi = new PROCESS_BASIC_INFORMATION();
            uint returnLength;

            int status = NtQueryInformationProcess(
                process.Handle,
                0, // ProcessBasicInformation
                ref pbi,
                (uint)Marshal.SizeOf(pbi),
                out returnLength);

            if (status == 0) // STATUS_SUCCESS
            {
                return (int)pbi.InheritedFromUniqueProcessId;
            }

            return -1; // Caso não consiga obter o pai
        }

        public async Task<List<Processo>> GetProcessosAsync(Process[] processList)
        {
            // Lista de processos que será retornada
            var processos = new ConcurrentBag<Processo>();

            // Limitar o paralelismo para evitar o uso excessivo de CPU
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount / 5 // Usar metade dos núcleos disponíveis
            };

            // Executa a coleta de informações de forma paralela com controle de paralelismo
            Parallel.ForEach(processList, parallelOptions, process =>
            {
                try
                {
                    // Verificar se o processo já está no cache
                    if (!processoCache.TryGetValue(process.Id, out var processo))
                    {
                        // Se não estiver no cache, cria uma nova instância de Processo
                        processo = new Processo
                        {
                            Pid = process.Id,
                            Nome = process.ProcessName,
                            State = GetProcessState(process),
                            Prioridade = process.PriorityClass,
                            MemoryUsage = process.WorkingSet64 / (1024 * 1024), // Em MB
                            Pai = GetParentProcessId(process)
                        };

                        // Armazena o processo no cache
                        processoCache[process.Id] = processo;
                    }
                    else
                    {
                        // Se o processo já está no cache, atualiza apenas as informações voláteis
                        processo.MemoryUsage = process.WorkingSet64 / (1024 * 1024); // Atualiza uso de memória
                        processo.State = GetProcessState(process); // Atualiza estado do processo
                    }

                    // Adiciona o processo à lista final
                    processos.Add(processo);
                }
                catch
                {
                    // Ignora processos que não podem ser acessados (possivelmente já finalizados)
                }
            });

            return processos.ToList();
        }
    }
}
