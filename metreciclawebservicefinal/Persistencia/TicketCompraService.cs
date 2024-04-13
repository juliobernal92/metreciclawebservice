using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetReciclaWebServiceFinal.Persistencia
{
    public class TicketCompraService : AbstractService<TicketCompra>
    {
        public override void addEntity(TicketCompra entity)
        {
            metreciclawebfinalEntities.TicketCompra.Add(entity);
            metreciclawebfinalEntities.SaveChanges();
        }

        public override void deleteEntity(TicketCompra entity)
        {
            metreciclawebfinalEntities.TicketCompra.Remove(entity);
            metreciclawebfinalEntities.SaveChanges();
        }

        public override List<TicketCompra> getEntities()
        {
            return (List<TicketCompra>)metreciclawebfinalEntities.TicketCompra.Select(
                    c => new
                    {
                        idticketcompra = c.idticketcompra,
                        fecha = c.fecha,
                        idvendedor = c.idvendedor,
                        idusuario = c.idusuario
                    }
                ).AsEnumerable().Select(
                    c=> new TicketCompra
                    {
                        idticketcompra = c.idticketcompra,
                        fecha = c.fecha,
                        idvendedor = c.idvendedor,
                        idusuario = c.idusuario
                    }
                ).ToList();
        }

        public override TicketCompra getEntityById(int id)
        {
            return metreciclawebfinalEntities.TicketCompra.FirstOrDefault(a => a.idticketcompra == id);
        }

        public override void updateEntity(TicketCompra entity)
        {
            metreciclawebfinalEntities.SaveChanges();
        }
    }
}