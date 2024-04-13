using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetReciclaWebServiceFinal.Persistencia
{
    public abstract class AbstractService<T>
    {
        protected MetreciclawebfinalEntities metreciclawebfinalEntities;

        public AbstractService()
        {
            metreciclawebfinalEntities = new MetreciclawebfinalEntities();
        }

        public abstract List<T> getEntities();
        public abstract void updateEntity(T entity);
        public abstract void addEntity(T entity);
        public abstract T getEntityById(int id);
        public abstract void deleteEntity(T entity);
    }
}