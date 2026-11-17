using System.Configuration;
using System.Data.SqlClient;

namespace ReparacionesWeb.Datos
{
    public static class Conexion
    {
        // La cadena está en Web.config -> <connectionStrings>
        public static SqlConnection Crear()
        {
            string cadena = ConfigurationManager.ConnectionStrings["ReparacionesDB"].ConnectionString;
            return new SqlConnection(cadena);
        }
    }
}
