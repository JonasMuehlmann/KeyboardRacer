using System.Diagnostics;


namespace Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start("/usr/bin/konsole", "-e /home/jonas/RiderProjects/LEA/LEA/bin/Debug/netcoreapp3.1/LEA");
        }
    }
}