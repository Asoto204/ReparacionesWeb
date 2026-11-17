using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ReparacionesWeb.Datos;
using ReparacionesWeb.Entidades;

namespace ReparacionesWeb.Logica
{
    public class UsuarioLogica
    {
        private readonly UsuarioDatos datos = new UsuarioDatos();

        public DataTable Listar()
        {
            return datos.Listar();
        }

        public void Agregar(Usuario u)
        {
            Validar(u);
            datos.Agregar(u);
        }

        public void Modificar(Usuario u)
        {
            if (u.UsuarioID <= 0)
                throw new ArgumentException("Seleccione un usuario de la lista.");
            Validar(u);
            datos.Modificar(u);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Seleccione un usuario de la lista.");
            try { datos.Eliminar(id); }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new InvalidOperationException(
                    "No se puede eliminar: el usuario tiene equipos registrados.");
            }
        }

        private static void Validar(Usuario u)
        {
            if (string.IsNullOrWhiteSpace(u.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(u.CorreoElectronico) || !u.CorreoElectronico.Contains("@"))
                throw new ArgumentException("Ingrese un correo electrónico válido.");
            if (!string.IsNullOrWhiteSpace(u.Telefono) &&
                !u.Telefono.All(c => char.IsDigit(c) || c == '-' || c == ' ' || c == '+'))
                throw new ArgumentException("El teléfono solo puede tener números.");
        }
    }
}
