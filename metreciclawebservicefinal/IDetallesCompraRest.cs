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
    public interface IDetallesCompraRest
    {
        [OperationContract]
        [WebGet(UriTemplate = "/ListaDetalles",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<DetallesCompra> ListaDetalles();

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/AgregarDetalle",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool AgregarDetalles(DetalleCompraDc detalleDc);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/ActualizarDetalle",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool ActualizarDetalle(DetalleCompraDc detalleDc);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/EliminarDetalle",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool EliminarDetalle(DetalleCompraDc detalleDc);
    }
}
