using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetReciclaWebServiceFinal.Persistencia
{
    public class VendedoresService : AbstractService<Vendedores>
    {
        public override void addEntity(Vendedores entity)
        {
            metreciclawebfinalEntities.Vendedores.Add(entity);
            metreciclawebfinalEntities.SaveChanges();
        }

        public override void deleteEntity(Vendedores entity)
        {
            if (entity != null)
            {
                metreciclawebfinalEntities.Vendedores.Remove(entity);
                metreciclawebfinalEntities.SaveChanges();
            }
            else
            {
                // Puedes lanzar una excepción, escribir un mensaje de registro, o manejar de alguna otra manera
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula al intentar eliminarla.");
            }
        }

        public override List<Vendedores> getEntities()
        {
            return metreciclawebfinalEntities.Vendedores
                .Select(c => new
                {
                    Idvendedor = c.idvendedor,
                    Nombre = c.nombre,
                    Telefono = c.telefono,
                    Direccion = c.direccion
                })
                .AsEnumerable()
                .Select(c => new Vendedores
                {
                    idvendedor = c.Idvendedor,
                    nombre = c.Nombre,
                    telefono = c.Telefono,
                    direccion = c.Direccion
                })
                .ToList();
        }

        public override Vendedores getEntityById(int id)
        {
            return metreciclawebfinalEntities.Vendedores.FirstOrDefault(c => c.idvendedor == id);
        }

        public override void updateEntity(Vendedores entity)
        {
            metreciclawebfinalEntities.SaveChanges();
        }
    }
}