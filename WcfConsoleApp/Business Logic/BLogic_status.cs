using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WcfConsoleApp.BusinessLogic
{
    public class BLogic_status
    {
        public static async Task<string> RestApi_status(string param, Stream content)
        {
            await Task.Delay(1);

            return "test";
        }
    }
}
