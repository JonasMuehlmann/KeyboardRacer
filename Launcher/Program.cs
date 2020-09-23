using System.Diagnostics;


namespace Launcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Run 'chcp 65001' before starting the game natively on windows
            var run = Process.Start("docker", "run -it -d --name keyboardracer keyboardracer");
            run.WaitForExit();
            var attach = Process.Start("docker", "attach keyboardracer");
            attach.WaitForExit();
            Process.Start("docker", "rm keyboardracer");
        }
    }
}