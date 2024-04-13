using MetReciclaWebServiceFinal.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetReciclaWebServiceFinal
{
    public class DetallesCompraRest : IDetallesCompraRest
    {
        DetallesCompraService detallesCompraService = new DetallesCompraService();
        public bool ActualizarDetalle(DetalleCompraDc detalleDc)
        {
            DetallesCompra detallecompra = detallesCompraService.getEntityById(detalleDc.Iddetallecompra);
            detallecompra.idchatarra = detalleDc.Idchatarra;
            detallecompra.idticketcompra = detalleDc.Idticketcompra;
            detallecompra.cantidad = detalleDc.Cantidad;
            detallecompra.subtotal = detalleDc.Subtotal;
            detallesCompraService.updateEntity(detallecompra);
            return true;
        }


        public bool AgregarDetalles(DetalleCompraDc detalleDc)
        {
            DetallesCompra detallecompra = new DetallesCompra();
            detallecompra.iddetallecompra = detalleDc.Iddetallecompra;
            detallecompra.idchatarra = detalleDc.Idchatarra;
            detallecompra.idticketcompra = detalleDc.Idticketcompra;
            detallecompra.cantidad = detalleDc.Cantidad;
            detallecompra.subtotal = detalleDc.Subtotal;
            detallesCompraService.addEntity(detallecompra);
            return true;
        }

        public bool EliminarDetalle(DetalleCompraDc detalleDc)
        {
            DetallesCompra detallecompra = detallesCompraService.getEntityById(detalleDc.Iddetallecompra);
            detallesCompraService.deleteEntity(detallecompra);
            return true;
        }

        public List<DetallesCompra> ListaDetalles()
        {
            return detallesCompraService.getEntities();
        }
    }
}
