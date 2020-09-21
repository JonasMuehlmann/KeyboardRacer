using System.Diagnostics;


namespace Launcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Process.Start("/usr/bin/konsole",
                          "-e /home/jonas/RiderProjects/KeyboardRacer/KeyboardRacer/bin/Debug/netcoreapp3.1/KeyboardRacer"
                         );
        }
    }
}