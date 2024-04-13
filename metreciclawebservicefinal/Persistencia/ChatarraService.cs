using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetReciclaWebServiceFinal.Persistencia
{
    public class ChatarraService : AbstractService<Chatarra>
    {
        public override void addEntity(Chatarra entity)
        {
            metreciclawebfinalEntities.Chatarra.Add(entity);
            metreciclawebfinalEntities.SaveChanges();
        }

        public override void deleteEntity(Chatarra entity)
        {
            if (entity != null)
            {
                metreciclawebfinalEntities.Chatarra.Remove(entity);
                metreciclawebfinalEntities.SaveChanges();
            }
            else
            {
                // Puedes lanzar una excepción, escribir un mensaje de registro, o manejar de alguna otra manera
                throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula al intentar eliminarla.");
            }
        }

        public override List<Chatarra> getEntities()
        {
            return metreciclawebfinalEntities.Chatarra
                .Select(c => new
                {
                    idchatarra = c.idchatarra,
                    nombre = c.nombre,
                    preciocompra = c.preciocompra
                })
                .AsEnumerable()
                .Select(c => new Chatarra
                {
                    idchatarra = c.idchatarra,
                    nombre = c.nombre,
                    preciocompra = c.preciocompra
                })
                .ToList();
        }


        public override Chatarra getEntityById(int id)
        {
            return metreciclawebfinalEntities.Chatarra.FirstOrDefault(c => c.idchatarra == id);
        }

        public override void updateEntity(Chatarra entity)
        {
            metreciclawebfinalEntities.SaveChanges();
        }
    }
}