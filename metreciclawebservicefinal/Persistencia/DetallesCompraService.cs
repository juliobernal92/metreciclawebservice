using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetReciclaWebServiceFinal.Persistencia
{
    public class DetallesCompraService : AbstractService<DetallesCompra>
    {
        public override void addEntity(DetallesCompra entity)
        {
            metreciclawebfinalEntities.DetallesCompra.Add(entity);
            metreciclawebfinalEntities.SaveChanges();
        }

        public override void deleteEntity(DetallesCompra entity)
        {
            metreciclawebfinalEntities.DetallesCompra.Remove(entity);
            metreciclawebfinalEntities.SaveChanges();
        }

        public override List<DetallesCompra> getEntities()
        {
            return (List<DetallesCompra>)metreciclawebfinalEntities.DetallesCompra.Select(
                c=> new
                {
                    iddetallescompra = c.iddetallecompra,
                    idchatarra = c.idchatarra,
                    idticketcompra = c.idticketcompra,
                    cantidad = c.cantidad,
                    subtotal = c.subtotal
                }

                ).AsEnumerable().Select(
                    c=> new DetallesCompra
                    {
                        iddetallecompra = c.iddetallescompra,
                        idchatarra = c.idchatarra,
                        idticketcompra = c.idticketcompra,
                        cantidad = c.cantidad,
                        subtotal = c.subtotal
                    }
                ).ToList();



        }

        public override DetallesCompra getEntityById(int id)
        {
            return metreciclawebfinalEntities.DetallesCompra.FirstOrDefault(a => a.iddetallecompra == id);
        }

        public override void updateEntity(DetallesCompra entity)
        {
            metreciclawebfinalEntities.SaveChanges();
        }
    }
}