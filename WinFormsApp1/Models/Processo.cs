using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Sistema_Operacional
{
    public struct Processo
    {
        public int Pid { get; internal set; }
        public string? Nome { get; internal set; }
        public string? State { get; internal set; }
        public ProcessPriorityClass Prioridade { get; internal set; }
        public long MemoryUsage { get; internal set; }
        public int Pai { get; internal set; }
        public override readonly string ToString()
        {
            return $"Processo: {Nome} (PID: {Pai} | {State})";
        }
    }
}
