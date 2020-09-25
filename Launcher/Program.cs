#region

using System.Diagnostics;

#endregion


namespace Launcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // // TODO: Run 'chcp 65001' before starting the game natively on windows
            var p = Process.Start("../../../../Backend/bin/Debug/netcoreapp3.1/Backend");
            p.WaitForExit();
            // var run = Process.Start("docker", "build -t keyboardracer ../../../../Backend");
            // run.WaitForExit();
            // run = Process.Start("docker", "run -it -d --name keyboardracer keyboardracer");
            // run.WaitForExit();
            // var attach = Process.Start("docker", "attach keyboardracer");
            // attach.WaitForExit();
            // Process.Start("docker", "rm keyboardracer");
        }
    }
}