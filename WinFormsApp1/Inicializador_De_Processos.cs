using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Operacional
{
    public partial class Inicializador_De_Processos : Form
    {
        public Inicializador_De_Processos()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Cria um JobObject
            IntPtr jobHandle = CreateJobObject(IntPtr.Zero, null);
            if (jobHandle == IntPtr.Zero)
            {
                MessageBox.Show("Falha ao criar JobObject.");
                return;
            }

            // Configura limites do JobObject (opcional: limite de memória, etc.)
            SetJobObjectMemoryLimit(jobHandle, 200 * 1024 * 1024); // Limite de 200 MB de memória por processo

            // Configura o processo a ser iniciado
            ProcessStartInfo startInfo = new()
            {
                FileName = "notepad"
            };

            Process process1 = new()
            {
                StartInfo = startInfo
            };
            process1.Start();

            // Associa o processo ao JobObject
            if (!AssignProcessToJobObject(jobHandle, process1.Handle))
            {
                MessageBox.Show("Falha ao associar o processo ao JobObject.");
            }
            else
            {
                MessageBox.Show("Processo associado ao JobObject com sucesso.");
            }
        }

        // Função para criar um JobObject
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateJobObject(IntPtr lpJobAttributes, string lpName);

        // Função para associar um processo ao JobObject
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AssignProcessToJobObject(IntPtr hJob, IntPtr hProcess);

        // Função para configurar limites de memória no JobObject
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

        // Função para configurar informações no JobObject
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
