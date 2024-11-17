using System.Diagnostics;

namespace WinFormsApp1.Processos
{
    public class CancelProcess
    {
        public static void ByPid(int pid)
        {
            try
            {
                Process process = Process.GetProcessById(pid);
                if (!process.HasExited)
                {
                    process.Kill();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}
