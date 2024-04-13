using MetReciclaWebServiceFinal.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetReciclaWebServiceFinal
{
    public class TotalCompraRest : ITotalCompraRest
    {
        TotalCompraService totalCompraService = new TotalCompraService();
        public bool ActualizarTotalCompra(TotalCompraDc totalCompraDc)
        {
            TotalCompra entityTotal = totalCompraService.getEntityById(totalCompraDc.Idtotalcompra);
            entityTotal.idticketcompra = totalCompraDc.Idticketcompra;
            entityTotal.total = totalCompraDc.Total;
            totalCompraService.updateEntity(entityTotal);
            return true;
        }

        public bool AgregarTotalCompra(TotalCompraDc totalCompraDc)
        {
            TotalCompra totalCompra = new TotalCompra();
            totalCompra.idticketcompra = totalCompraDc.Idticketcompra;
            totalCompra.total = totalCompraDc.Total;
            totalCompraService.addEntity(totalCompra);
            return true;
        }

        public bool EliminarTotalCompra(TotalCompraDc totalCompraDc)
        {
            TotalCompra entityTotal = totalCompraService.getEntityById(totalCompraDc.Idtotalcompra);
            totalCompraService.deleteEntity(entityTotal);
            return true;
        }

        public List<TotalCompra> ListaTotalCompra()
        {
            return totalCompraService.getEntities();
        }
    }
}
