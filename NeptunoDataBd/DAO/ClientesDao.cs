using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NeptunoDataBd.Models;
using System.Configuration; 
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls.WebParts;
//using NeptunoDataBd.Models;


namespace NeptunoDataBd.DAO
{
    public class ClientesDao
    {
        string cadena = ConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString;

        public List<Clientes> ListarClientes()
        {

            SqlConnection conn = new SqlConnection(cadena);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Sp_Cliente", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Clientes> lista = new List<Clientes>();
            Clientes obj;
            while (reader.Read()) 
            {
                obj = new Clientes()
                {
                    IdCliente = reader.GetString(0),
                    NombreCliente = reader.GetString(1),
                    Direccion = reader.GetString(2),
                    Telefono = reader.GetString(3),
                    Pais =  reader.GetString(4),                     
                };
                lista.Add(obj);
            }
            reader.Close();     
            conn .Close(); 
            return lista;
        }
            
    }
}