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
    public class TotalCompraWCF
    {
        TotalCompraService totalCompraService = new TotalCompraService();

        [OperationContract]
        public List<TotalCompra> ListaTotalCompra()
        {
            return totalCompraService.getEntities();
        }

        [OperationContract]
        public bool AgregarTotalCompra(TotalCompraDc totalCompraDc)
        {
            TotalCompra totalCompra = new TotalCompra();
            totalCompra.idticketcompra = totalCompraDc.Idticketcompra;
            totalCompra.total = totalCompraDc.Total;
            totalCompraService.addEntity(totalCompra);
            return true;
        }

        [OperationContract]
        public bool ActualizarTotalCompra(TotalCompraDc totalCompraDc)
        {
            TotalCompra entityTotal = totalCompraService.getEntityById(totalCompraDc.Idtotalcompra);
            entityTotal.idticketcompra = totalCompraDc.Idticketcompra;
            entityTotal.total = totalCompraDc.Total;
            totalCompraService.updateEntity(entityTotal);
            return true;
        }

        [OperationContract]

        public bool EliminarTotalCompra(TotalCompraDc totalCompraDc)
        {
            TotalCompra entityTotal = totalCompraService.getEntityById(totalCompraDc.Idtotalcompra);
            totalCompraService.deleteEntity(entityTotal);
            return true;
        }

        [OperationContract]
        public TotalCompraDc ObtenerTotalCompra(int idTotalCompra)
        {
            var total = totalCompraService.getEntityById(idTotalCompra);
            TotalCompraDc totalCompraDc = new TotalCompraDc();
            totalCompraDc.Idtotalcompra = total.idtotalcompra;
            totalCompraDc.Idticketcompra = (int)total.idticketcompra;
            totalCompraDc.Total = (int)total.total;
            return totalCompraDc;
        }

    }

    [DataContract]
    public class TotalCompraDc
    {
        [DataMember]
        public int Idtotalcompra { get; set; }
        
        [DataMember]
        public int Idticketcompra { get; set; }
        [DataMember]
        public int Total { get; set; }
    }
}
