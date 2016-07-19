using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Principal;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace WcfConsoleApp
{
    class Program
    {
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            if (null != identity)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return false;
        }

        static void Main(string[] args)
        {
            if (IsAdministrator() == false)
            {
                try
                {
                    ProcessStartInfo procInfo = new ProcessStartInfo();
                    procInfo.UseShellExecute = true;
                    procInfo.FileName = System.Reflection.Assembly.GetEntryAssembly().Location;
                    procInfo.WorkingDirectory = Environment.CurrentDirectory;
                    procInfo.Verb = "runas";
                    Process.Start(procInfo);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message.ToString());
                    return;
                }
            }
            else
            {
                AppMain appMain = new AppMain();
                appMain.StartWebService();
            }
        }
    }
}
