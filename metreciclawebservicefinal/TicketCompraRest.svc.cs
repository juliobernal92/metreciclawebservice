using MetReciclaWebServiceFinal.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetReciclaWebServiceFinal
{
    public class TicketCompraRest : ITicketCompraRest
    {
        TicketCompraService ticketcompraService = new TicketCompraService();
        public bool ActualizarTicketCompra(TicketCompraDc ticketCompraDc)
        {
            TicketCompra entityTicket = ticketcompraService.getEntityById(ticketCompraDc.Idticketcompra);
            entityTicket.fecha = ticketCompraDc.Fecha;
            entityTicket.idvendedor = ticketCompraDc.Idvendedor;
            entityTicket.idusuario = ticketCompraDc.Idusuario;
            ticketcompraService.updateEntity(entityTicket);
            return true;
        }

        public bool AgregarTicketCompra(TicketCompraDc ticketCompraDc)
        {
            TicketCompra ticketCompra = new TicketCompra();
            ticketCompra.fecha = ticketCompraDc.Fecha;
            ticketCompra.idvendedor = ticketCompraDc.Idvendedor;
            ticketCompra.idusuario = ticketCompraDc.Idusuario;
            ticketcompraService.addEntity(ticketCompra);
            return true;
        }

        public bool EliminarTicketCompra(TicketCompraDc ticketCompraDc)
        {
            TicketCompra entityTicket = ticketcompraService.getEntityById(ticketCompraDc.Idticketcompra);
            ticketcompraService.deleteEntity(entityTicket);
            return true;
        }

        public List<TicketCompra> ListaTicketCompra()
        {
            return ticketcompraService.getEntities();

        }

    }
}
