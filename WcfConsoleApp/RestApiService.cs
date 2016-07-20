using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceModel;

using WcfConsoleApp.BusinessLogic;

namespace WcfConsoleApp
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall, AddressFilterMode = AddressFilterMode.Any)]
    public class RestApiService : IRestApiService
    {
        public Task<string> RestApi_echo(string param)
        {
            return Task<string>.Run(() => { return string.Format("Echo: {0}", param); });
        }

        public Task<string> RestApi_test(string param)
        {
            return BLogic_test.RestApi_test();
        }

        public Task<string> RestApi_status(string param, Stream content)
        {
            return BLogic_status.RestApi_status(param, content);
        }

        public Task<string> RestApi_register(string param, Stream content)
        {
            return BLogic_register.RestApi_register(param, content);
        }




    }
}
