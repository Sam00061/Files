using System;
using System.Text;
using System.IO;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            System.Diagnostics.Process SubProcess = new System.Diagnostics.Process()
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = "C:\\Windows\\System32\\w32tm.exe",
                    Arguments = "/config /manualpeerlist:\"time.stdtime.gov.tw clock.stdtime.gov.tw tick.stdtime.gov.tw watch.stdtime.gov.tw\" /syncfromflags:manual /reliable:yes /update",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                }
            };
            SubProcess.Start();
            SubProcess.WaitForExit();
            File.WriteAllText("Output.txt", SubProcess.StandardError.ReadToEnd());
            File.AppendAllText("Output.txt", SubProcess.StandardOutput.ReadToEnd());
        }

    }
}