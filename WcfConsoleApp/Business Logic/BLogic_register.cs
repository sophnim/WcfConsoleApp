using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WcfConsoleApp.BusinessLogic
{
    public class BLogic_register
    {
        public static async Task<string> RestApi_register(string param, Stream content)
        {
            await Task.Delay(1);

            return "test";
        }
    }
}
