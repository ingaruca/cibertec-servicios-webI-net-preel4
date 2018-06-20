using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceNegocios" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceNegocios.svc o ServiceNegocios.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceNegocios : IServiceNegocios
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnNegocios"].ConnectionString);

        List<Cliente> ListaClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ventas.clientes", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cliente reg = new Cliente();
                    reg.IdCliente = dr[0].ToString();
                    reg.Nombre = dr[1].ToString();
                    reg.Direccion = dr[2].ToString();
                    reg.Pais = dr[3].ToString();
                    reg.Telefono = dr[4].ToString();

                    lista.Add(reg);
                }

                dr.Close();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                cn.Close();
            }

            return lista;
        }

        public List<Cliente> Clientes()
        {
            return ListaClientes().ToList();
        }

        public List<Cliente> ClienteXNombre(string nombre)
        {
            return ListaClientes().Where(c => c.Nombre.StartsWith(nombre)).ToList();
        }
        
    }
}
