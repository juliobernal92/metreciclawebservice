using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetReciclaWebServiceFinal.Persistencia
{
    public class TotalCompraService : AbstractService<TotalCompra>
    {
        public override void addEntity(TotalCompra entity)
        {
            metreciclawebfinalEntities.TotalCompra.Add(entity);
            metreciclawebfinalEntities.SaveChanges();
        }

        public override void deleteEntity(TotalCompra entity)
        {
            metreciclawebfinalEntities.TotalCompra.Remove(entity);
            metreciclawebfinalEntities.SaveChanges();
        }

        public override List<TotalCompra> getEntities()
        {
            return (List<TotalCompra>)metreciclawebfinalEntities.TotalCompra.Select(
                    c=> new
                    {
                        idtotalcompra = c.idtotalcompra,
                        idticketcompra = c.idticketcompra,
                        total = c.total
                    }
                ).AsEnumerable().Select(
                    c => new TotalCompra
                    {
                        idtotalcompra = c.idtotalcompra,
                        idticketcompra = c.idticketcompra,
                        total = c.total
                    }).ToList();
        }

        public override TotalCompra getEntityById(int id)
        {
            return metreciclawebfinalEntities.TotalCompra.FirstOrDefault(a => a.idtotalcompra == id);
        }

        public override void updateEntity(TotalCompra entity)
        {
            metreciclawebfinalEntities.SaveChanges();
        }
    }
}