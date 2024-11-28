using System.Diagnostics;

namespace Sistema_Operacional
{
    public class CustomProcess
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Process Process { get; set; }
        public long MemoryLimit { get; set; }
        public ProcessState State { get; set; }
        public double MemoryUsage { get; set; }
    }
}
