using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfConsoleApp
{
    public class AppMain
    {
        public void StartWebService()
        {
            try
            {
                Uri baseAddress = new Uri("http://localhost:8080/");

                // Create the ServiceHost.
                using (WebServiceHost host = new WebServiceHost(typeof(RestApiService), baseAddress))
                {
                    // host.AddServiceEndpoint(typeof(IGameService), new WebHttpBinding(), "");

                    // 쓰로틀링 세팅 
                    /*
                    var throttle = host.Description.Behaviors.Find<ServiceThrottlingBehavior>();
                    if (null == throttle)
                    {
                        throttle = new ServiceThrottlingBehavior();
                        throttle.MaxConcurrentCalls = 150;
                        throttle.MaxConcurrentInstances = 464;
                        throttle.MaxConcurrentSessions = 400;
                        host.Description.Behaviors.Add(throttle);
                    }
                    */

                    host.Open();

                    Task.Run(() => AppTester.StartTest());

                    Console.WriteLine("The service is ready at {0}", baseAddress);
                    Console.WriteLine("Press <Enter> to stop the service.");
                    Console.ReadLine();

                    // Close the ServiceHost.
                    host.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
