using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

using WcfConsoleApp.DatabaseLogic;

namespace WcfConsoleApp.BusinessLogic
{
    public class BLogic_test
    {
        public static async Task<string> RestApi_test()
        {
            var stw = Stopwatch.StartNew();

            await MySqlManager.CheckDatabase("Server=127.0.0.1;Port=3306;Database=test;Uid=root;Pwd=throwin82!;", "show databases");
            
            return string.Format("test: {0}ticks", stw.ElapsedTicks);
        }
    }
}
