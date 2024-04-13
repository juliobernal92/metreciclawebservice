using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MetReciclaWebServiceFinal
{
    [ServiceContract]
    public interface IChatarraRest
    {
        [OperationContract]
        [WebGet(UriTemplate = "/ListaChatarra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<Chatarra> ListaChatarra();

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/AgregarChatarra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool AgregarChatarra(ChatarraDc chatarraDc);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/ActualizarChatarra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool ActualizarChatarra(ChatarraDc chatarraDc);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/EliminarChatarra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool EliminarChatarra(ChatarraDc chatarraDc);
    }
}
