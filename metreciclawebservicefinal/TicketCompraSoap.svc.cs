using MetReciclaWebServiceFinal.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetReciclaWebServiceFinal
{
    [ServiceContract]
    public class TicketCompraSoap 
    {
        TicketCompraService ticketcompraService = new TicketCompraService();

        [OperationContract]
        public List<TicketCompra> ListaTicketCompra()
        {
            return ticketcompraService.getEntities();

        }

        [OperationContract]
        public bool AgregarTicketCompra(TicketCompraDc ticketCompraDc)
        {
            TicketCompra ticketCompra = new TicketCompra();
            ticketCompra.fecha = ticketCompraDc.Fecha;
            ticketCompra.idvendedor = ticketCompraDc.Idvendedor;
            ticketCompra.idusuario = ticketCompraDc.Idusuario;
            ticketcompraService.addEntity(ticketCompra);
            return true;
        }

        [OperationContract]

        public bool ActualizarTicketCompra(TicketCompraDc ticketCompraDc)
        {
            TicketCompra entityTicket = ticketcompraService.getEntityById(ticketCompraDc.Idticketcompra);
            entityTicket.fecha = ticketCompraDc.Fecha;
            entityTicket.idvendedor = ticketCompraDc.Idvendedor;
            entityTicket.idusuario = ticketCompraDc.Idusuario;
            ticketcompraService.updateEntity(entityTicket);
            return true;
        }

        [OperationContract]

        public bool EliminarTicketCompra(TicketCompraDc ticketCompraDc)
        {
            TicketCompra entityTicket = ticketcompraService.getEntityById(ticketCompraDc.Idticketcompra);
            ticketcompraService.deleteEntity(entityTicket);
            return true;
        }

        [OperationContract]
        public TicketCompraDc ObtenerTicketCompra(int idTicketCompra)
        {
            var ticket = ticketcompraService.getEntityById(idTicketCompra);
            TicketCompraDc ticketCompraDc = new TicketCompraDc();
            ticketCompraDc.Idticketcompra = ticket.idticketcompra;
            ticketCompraDc.Fecha = (DateTime)ticket.fecha;
            ticketCompraDc.Idvendedor = (int)ticket.idvendedor;
            ticketCompraDc.Idusuario = (int)ticket.idusuario;
            return ticketCompraDc;
        }


    }
    [DataContract]
    public class TicketCompraDc
    {
        [DataMember]
        public int Idticketcompra{ get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public int Idvendedor { get; set; }
        [DataMember]
        public int Idusuario { get; set; }
    }
}
