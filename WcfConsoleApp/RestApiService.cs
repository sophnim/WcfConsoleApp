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
        public async Task<string> RestApi_echo(string param)
        {
            return await Task<string>.Run(() => { return string.Format("Echo: {0}", param); });
        }

        public async Task<string> RestApi_test(string param)
        {
            return await BLogic_test.RestApi_test();
        }

        public async Task<string> RestApi_register(string param, Stream content)
        {
            return await BLogic_register.RestApi_register(param, content);
        }

        public async Task<string> RestApi_status(string param, Stream content)
        {
            return await BLogic_status.RestApi_status(param, content);
        }
    }
}
