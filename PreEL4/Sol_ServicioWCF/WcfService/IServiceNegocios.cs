using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceNegocios" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceNegocios
    {
        [OperationContract]
        List<Cliente> Clientes();
        [OperationContract]
        List<Cliente> ClienteXNombre(string nombre);
    }

    [DataContract]
    public class Cliente
    {
        [DataMember]
        public string IdCliente { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public string Telefono { get; set; }
    }
}
