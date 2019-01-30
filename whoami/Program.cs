using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Security.Principal;

namespace Whoami
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int uniq = random.Next(100);
            System.IO.StreamWriter file = new System.IO.StreamWriter(String.Format("c:\\temp\\who{0}.txt", uniq));
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "c:\\windows\\system32\\whoami.exe";
            startInfo.Arguments = "/groups";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            String output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            file.WriteLine(output);
            file.Close();
        }
    }
}