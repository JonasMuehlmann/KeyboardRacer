using System.Diagnostics;


namespace KeyboardRacer
{
    namespace Launcher
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Process.Start("/usr/bin/konsole",
                              "-e /home/jonas/RiderProjects/Backend/Backend/bin/Debug/netcoreapp3.1/Backend"
                             );
            }
        }
    }
}