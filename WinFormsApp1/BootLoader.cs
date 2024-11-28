using Sistema_Operacional.Models;
using System.Runtime.InteropServices;

namespace Sistema_Operacional
{
    public partial class BootLoader : Form
    {
        public BootLoader()
        {
            InitializeComponent();

            // Configurar o valor máximo dos TrackBars
            TrackBar_CPU.Maximum = Environment.ProcessorCount;
            TrackBar_MEMORIA.Maximum = (int)Math.Ceiling(GetTotalDiskSpaceGB());
            TrackBar_RAM.Maximum = (int)Math.Ceiling(GetAvailablePhysicalMemoryGB());

            // Atualizar valores nas caixas de texto quando o TrackBar é ajustado
            TrackBar_CPU.Scroll += (s, e) => textBox_CPU.Text = TrackBar_CPU.Value.ToString();
            TrackBar_RAM.Scroll += (s, e) => textBox_RAM.Text = TrackBar_RAM.Value.ToString() + " GB";
            TrackBar_MEMORIA.Scroll += (s, e) => textBox_MEMORIA.Text = TrackBar_MEMORIA.Value.ToString() + " GB";
        }

        // Método para obter o espaço total do disco em GB
        public static double GetTotalDiskSpaceGB()
        {
            // Obtém a unidade onde o programa está sendo executado
            string driveName = Path.GetPathRoot(Environment.CurrentDirectory);
            DriveInfo drive = new DriveInfo(driveName);

            if (drive.IsReady)
            {
                return Math.Round(drive.TotalSize / (1024.0 * 1024.0 * 1024.0), 2); // Em GB
            }

            throw new InvalidOperationException("Não foi possível acessar o disco.");
        }

        // Método para obter a memória RAM disponível (GB)
        public static double GetAvailablePhysicalMemoryGB()
        {
            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            memStatus.Init();

            if (GlobalMemoryStatusEx(ref memStatus))
            {
                return Math.Round(memStatus.ullAvailPhys / (1024.0 * 1024.0 * 1024.0), 2); // Em GB
            }

            throw new InvalidOperationException("Não foi possível obter a memória RAM disponível.");
        }

        // Estrutura de memória do sistema
        [StructLayout(LayoutKind.Sequential)]
        private struct MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;

            public void Init()
            {
                dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            }
        }

        // Importa a função do Windows para obter informações sobre a memória
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

        // Função pública para retornar os dados dos componentes
        public BootData GetFormData()
        {
            return new BootData
            {
                CPUValue = TrackBar_CPU.Value,
                RAMValue = TrackBar_RAM.Value,
                MemoryValue = TrackBar_MEMORIA.Value,
            };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
