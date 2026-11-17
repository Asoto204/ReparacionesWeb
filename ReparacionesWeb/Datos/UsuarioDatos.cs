using System;
using System.Data;
using System.Data.SqlClient;
using ReparacionesWeb.Entidades;

// Adiel Soto Valverde y Andy Lopez Sanchez

namespace ReparacionesWeb.Datos
{
    public class UsuarioDatos
    {
        public DataTable Listar()
        {
            using (var cn = Conexion.Crear())
            using (var da = new SqlDataAdapter(
                "SELECT UsuarioID, Nombre, CorreoElectronico, Telefono FROM Usuarios ORDER BY Nombre", cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Agregar(Usuario u)
        {
            using (var cn = Conexion.Crear())
            using (var cmd = new SqlCommand(
                "INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono) VALUES (@n, @c, @t)", cn))
            {
                cmd.Parameters.AddWithValue("@n", u.Nombre);
                cmd.Parameters.AddWithValue("@c", u.CorreoElectronico);
                cmd.Parameters.AddWithValue("@t", (object)u.Telefono ?? DBNull.Value);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Usuario u)
        {
            using (var cn = Conexion.Crear())
            using (var cmd = new SqlCommand(
                "UPDATE Usuarios SET Nombre=@n, CorreoElectronico=@c, Telefono=@t WHERE UsuarioID=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", u.UsuarioID);
                cmd.Parameters.AddWithValue("@n", u.Nombre);
                cmd.Parameters.AddWithValue("@c", u.CorreoElectronico);
                cmd.Parameters.AddWithValue("@t", (object)u.Telefono ?? DBNull.Value);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var cn = Conexion.Crear())
            using (var cmd = new SqlCommand("DELETE FROM Usuarios WHERE UsuarioID=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
