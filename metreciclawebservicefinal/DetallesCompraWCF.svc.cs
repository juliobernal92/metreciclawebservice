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
    public class DetallesCompraWCF
    {
        DetallesCompraService detallesCompraService = new DetallesCompraService();

        [OperationContract]
        public bool AñadirDetalleCompra(DetalleCompraDc detalleDc)
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
        [OperationContract]
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
        [OperationContract]
        public bool EliminarDetalle(DetalleCompraDc detalleDc)
        {
            DetallesCompra detallecompra = detallesCompraService.getEntityById(detalleDc.Iddetallecompra);
            detallesCompraService.deleteEntity(detallecompra);
            return true;
        }

        [OperationContract]
        public List<DetallesCompra> ListarDetalles()
        {
            return detallesCompraService.getEntities();
        }

        [OperationContract]
        public DetalleCompraDc ObtenerDetalles(int idDetalle)
        {
            var detalle = detallesCompraService.getEntityById(idDetalle);
            DetalleCompraDc detalleDc = new DetalleCompraDc();
            detalleDc.Idchatarra = (int)detalle.idchatarra;
            detalleDc.Idticketcompra = (int)detalle.idticketcompra;
            detalleDc.Cantidad = (decimal)detalle.cantidad;
            detalleDc.Subtotal = (float)detalle.subtotal;
            return detalleDc;
        }
    }

    [DataContract]
    public class DetalleCompraDc
    {
        [DataMember]
        public int Iddetallecompra { get; set; }
        [DataMember]
        public int Idchatarra { get; set; }
        [DataMember]
        public int Idticketcompra { get; set; }
        [DataMember]
        public decimal Cantidad { get; set; }
        [DataMember]
        public float Subtotal { get; set; }
    }
}
