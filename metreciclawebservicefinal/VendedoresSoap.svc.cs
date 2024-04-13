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
    public class VendedoresSoap 
    {
        VendedoresService vendedoresService = new VendedoresService();
        [OperationContract]
        public List<Vendedores> ListaVendedores()
        {
            return vendedoresService.getEntities();

        }

        [OperationContract]
        public bool AgregarVendedores(VendedoresDc vendedoresDc)
        {
            Vendedores vendedores = new Vendedores();
            vendedores.nombre = vendedoresDc.Nombre;
            vendedores.telefono = vendedoresDc.Telefono;
            vendedores.direccion = vendedoresDc.Direccion;
            vendedoresService.addEntity(vendedores);
            return true;
        }

        [OperationContract]

        public bool ActualizarVendedores(VendedoresDc vendedoresDc)
        {
            Vendedores entityVendedores = vendedoresService.getEntityById(vendedoresDc.Idvendedor);
            entityVendedores.nombre = vendedoresDc.Nombre;
            entityVendedores.telefono = vendedoresDc.Telefono;
            entityVendedores.direccion = vendedoresDc.Direccion;
            vendedoresService.updateEntity(entityVendedores);
            return true;
        }

        [OperationContract]

        public bool EliminarVendedores(VendedoresDc vendedoresDc)
        {
            Vendedores entityVendedores = vendedoresService.getEntityById(vendedoresDc.Idvendedor);

            if (entityVendedores != null)
            {
                vendedoresService.deleteEntity(entityVendedores);
                return true;
            }
            else
            {
                return false; // O lanzar una excepción, según tus necesidades
            }
        }

        [OperationContract]
        public VendedoresDc ObtenerVendedores(int idVendedores)
        {
            var vendedores = vendedoresService.getEntityById(idVendedores);
            VendedoresDc vendedoresDc = new VendedoresDc();
            vendedoresDc.Idvendedor = vendedores.idvendedor;
            vendedoresDc.Nombre = vendedores.nombre;
            vendedoresDc.Telefono = vendedores.telefono;
            vendedoresDc.Direccion = vendedores.direccion;
            return vendedoresDc;
        }
    }
    [DataContract]
    public class VendedoresDc
    {
        [DataMember]
        public int Idvendedor { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Direccion { get; set; }
    }
}
