using System.Data;
using System.Data.SqlClient;
using ReparacionesWeb.Entidades;

// Adiel Soto Valverde y Andy Lopez Sanchez

namespace ReparacionesWeb.Datos
{
    public class EquipoDatos
    {
        public DataTable Listar()
        {
            using (var cn = Conexion.Crear())
            using (var da = new SqlDataAdapter(
                @"SELECT e.EquipoID, e.TipoEquipo, e.Modelo, e.UsuarioID, u.Nombre AS Usuario
                  FROM Equipos e INNER JOIN Usuarios u ON u.UsuarioID = e.UsuarioID
                  ORDER BY e.EquipoID", cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Agregar(Equipo e)
        {
            using (var cn = Conexion.Crear())
            using (var cmd = new SqlCommand(
                "INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES (@t, @m, @u)", cn))
            {
                cmd.Parameters.AddWithValue("@t", e.TipoEquipo);
                cmd.Parameters.AddWithValue("@m", e.Modelo);
                cmd.Parameters.AddWithValue("@u", e.UsuarioID);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Equipo e)
        {
            using (var cn = Conexion.Crear())
            using (var cmd = new SqlCommand(
                "UPDATE Equipos SET TipoEquipo=@t, Modelo=@m, UsuarioID=@u WHERE EquipoID=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", e.EquipoID);
                cmd.Parameters.AddWithValue("@t", e.TipoEquipo);
                cmd.Parameters.AddWithValue("@m", e.Modelo);
                cmd.Parameters.AddWithValue("@u", e.UsuarioID);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var cn = Conexion.Crear())
            using (var cmd = new SqlCommand("DELETE FROM Equipos WHERE EquipoID=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
