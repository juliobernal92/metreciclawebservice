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
    public interface ITotalCompraRest
    {
        [OperationContract]
        [WebGet(UriTemplate = "/ListaTotalCompra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<TotalCompra> ListaTotalCompra();

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/AgregarTotalCompra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool AgregarTotalCompra(TotalCompraDc totalCompraDc);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/ActualizarTotalCompra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool ActualizarTotalCompra(TotalCompraDc totalCompraDc);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/EliminarTotalCompra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool EliminarTotalCompra(TotalCompraDc totalCompraDc);
    }
}
