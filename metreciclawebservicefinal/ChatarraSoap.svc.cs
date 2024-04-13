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
    public class ChatarraSoap 
    {
        ChatarraService chatarraService = new ChatarraService();
        [OperationContract]
        public List<Chatarra> ListaChatarra()
        {
            return chatarraService.getEntities();

        }

        [OperationContract]
        public bool AgregarChatarra(ChatarraDc chatarraDc)
        {
            Chatarra chatarra = new Chatarra();
            chatarra.nombre = chatarraDc.Nombre;
            chatarra.preciocompra = (int?)chatarraDc.Preciocompra;
            chatarraService.addEntity(chatarra);
            return true;
        }

        [OperationContract]

        public bool ActualizarChatarra(ChatarraDc chatarraDc)
        {
            Chatarra entityChatarra = chatarraService.getEntityById(chatarraDc.Idchatarra);
            entityChatarra.nombre = chatarraDc.Nombre;
            entityChatarra.preciocompra = (int?)chatarraDc.Preciocompra;
            chatarraService.updateEntity(entityChatarra);
            return true;
        }

        [OperationContract]

        public bool EliminarChatarra(ChatarraDc chatarraDc)
        {
            Chatarra entityChatarra = chatarraService.getEntityById(chatarraDc.Idchatarra);
            chatarraService.deleteEntity(entityChatarra);
            return true;
        }

        [OperationContract]
        public ChatarraDc ObtenerChatarra(int idchatarra)
        {
            var chatarra = chatarraService.getEntityById(idchatarra);
            ChatarraDc chatarraDc = new ChatarraDc();
            chatarraDc.Idchatarra = chatarra.idchatarra;
            chatarraDc.Nombre = chatarra.nombre;
            chatarraDc.Preciocompra = (decimal)chatarra.preciocompra;
            return chatarraDc;
        }
    }
    [DataContract]
    public class ChatarraDc
    {
        [DataMember]
        public int Idchatarra { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public decimal Preciocompra { get; set; }
    }
}
