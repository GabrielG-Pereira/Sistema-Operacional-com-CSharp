using System.Diagnostics;

namespace WinFormsApp1
{
    public class CustomProcess
    {
        public int Id { get; set; } // PID do processo
        public string? Name { get; set; } // Nome do criador (pai)
        public ProcessState State { get; set; }
        public Process? Process { get; set; } // Processo associado
        public long MemoryUsage { get; set; }
    }
}
