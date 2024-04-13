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
    public interface ITicketCompraRest
    {
        [OperationContract]
        [WebGet(UriTemplate = "/ListaTicketCompra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<TicketCompra> ListaTicketCompra();

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/AgregarTicketCompra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool AgregarTicketCompra(TicketCompraDc ticketCompraDc);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/ActualizarTicketCompra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool ActualizarTicketCompra(TicketCompraDc ticketCompraDc);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/EliminarTicketCompra",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool EliminarTicketCompra(TicketCompraDc ticketCompraDc);
    }
}
