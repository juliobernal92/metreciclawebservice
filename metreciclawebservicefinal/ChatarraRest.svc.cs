using MetReciclaWebServiceFinal.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MetReciclaWebServiceFinal
{
    public class ChatarraRest : IChatarraRest
    {
        ChatarraService chatarraService = new ChatarraService();
        public bool ActualizarChatarra(ChatarraDc chatarraDc)
        {
            Chatarra entityChatarra = chatarraService.getEntityById(chatarraDc.Idchatarra);
            entityChatarra.nombre = chatarraDc.Nombre;
            entityChatarra.preciocompra = (int?)chatarraDc.Preciocompra;
            chatarraService.updateEntity(entityChatarra);
            return true;
        }

        public bool AgregarChatarra(ChatarraDc chatarraDc)
        {
            Chatarra chatarra = new Chatarra();
            chatarra.nombre = chatarraDc.Nombre;
            chatarra.preciocompra = (int?)chatarraDc.Preciocompra;
            chatarraService.addEntity(chatarra);
            return true;
        }

        public bool EliminarChatarra(ChatarraDc chatarraDc)
        {
            Chatarra entityChatarra = chatarraService.getEntityById(chatarraDc.Idchatarra);
            chatarraService.deleteEntity(entityChatarra);
            return true;
        }

        public List<Chatarra> ListaChatarra()
        {
            return chatarraService.getEntities();
        }
    }
}
