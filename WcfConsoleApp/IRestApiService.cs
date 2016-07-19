using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

namespace WcfConsoleApp
{
    [ServiceContract]
    public interface IRestApiService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "echo/{param}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)] 
        Task<string> RestApi_echo(string param);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "test/{param}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> RestApi_test(string param);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "status/{param}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> RestApi_status(string param, Stream content);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "register/{param}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Task<string> RestApi_register(string param, Stream content);
    }
}
