using MetReciclaWebServiceFinal.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetReciclaWebServiceFinal
{
    public class VendedoresRest : IVendedoresRest
    {
        VendedoresService vendedoresService = new VendedoresService();
        public bool ActualizarVendedores(VendedoresDc vendedoresDc)
        {
            Vendedores entityVendedores = vendedoresService.getEntityById(vendedoresDc.Idvendedor);
            entityVendedores.nombre = vendedoresDc.Nombre;
            entityVendedores.telefono = vendedoresDc.Telefono;
            entityVendedores.direccion = vendedoresDc.Direccion;
            vendedoresService.updateEntity(entityVendedores);
            return true;
        }

        public bool AgregarVendedores(VendedoresDc vendedoresDc)
        {
            Vendedores vendedores = new Vendedores();
            vendedores.nombre = vendedoresDc.Nombre;
            vendedores.telefono = vendedoresDc.Telefono;
            vendedores.direccion = vendedoresDc.Direccion;
            vendedoresService.addEntity(vendedores);
            return true;
        }

        public bool EliminarVendedores(VendedoresDc vendedoresDc)
        {
            Vendedores entityVendedores = vendedoresService.getEntityById(vendedoresDc.Idvendedor);
            vendedoresService.deleteEntity(entityVendedores);
            return true;
        }

        public List<Vendedores> ListaVendedores()
        {
            return vendedoresService.getEntities().ToList();

        }
    }
}
