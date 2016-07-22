using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace WcfConsoleApp
{
    public class AppTester
    {
        static long processCount = 0;

        public static void StartTest()
        {
            Console.WriteLine("AppTester.Run()");

            System.Net.ServicePointManager.DefaultConnectionLimit = 1000;

            var stw = Stopwatch.StartNew();

            while (true)
            {
                //Task.Delay(1);
                //SendWebRequest("http://localhost:8080/test/1", "");
                SendWebRequest("http://localhost:8080/register/1", "");
                if (stw.ElapsedMilliseconds >= 1000)
                {
                    stw.Restart();
                    Console.WriteLine("{0}TPS", AppTester.processCount);
                    AppTester.processCount = 0;
                }
            }
        }

        static async void SendWebRequest(string uri, string postBody)
        {
            string responseString;

            try
            {
                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(uri);
                rq.Method = "POST";
                byte[] ba = Encoding.UTF8.GetBytes(postBody);
                rq.ContentType = "application/x-www-form-urlencoded";
                rq.ContentLength = ba.Length;

                Stream ds = rq.GetRequestStream();
                ds.Write(ba, 0, ba.Length);
                ds.Close();

                using (var res = (HttpWebResponse)(await rq.GetResponseAsync()))
                {
                    using (var stream = res.GetResponseStream())
                    {
                        var reader = new StreamReader(stream, Encoding.UTF8);
                        responseString = await reader.ReadToEndAsync();
                    }
                }

                Interlocked.Increment(ref AppTester.processCount);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendPostRequest Exception: {0}", ex.Message);
            }
        }
    }
}
