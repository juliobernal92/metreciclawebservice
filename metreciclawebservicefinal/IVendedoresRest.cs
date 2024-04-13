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
    public interface IVendedoresRest
    {
        [OperationContract]
        [WebGet(UriTemplate = "/ListaVendedores",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<Vendedores> ListaVendedores();

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/AgregarVendedores",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool AgregarVendedores(VendedoresDc vendedoresDc);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/ActualizarVendedores",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool ActualizarVendedores(VendedoresDc vendedoresDc);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/EliminarVendedores",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool EliminarVendedores(VendedoresDc vendedoresDc);
    }
}
