using System;
using System.Data;
using System.Data.SqlClient;
using ReparacionesWeb.Datos;
using ReparacionesWeb.Entidades;

namespace ReparacionesWeb.Logica
{
    public class EquipoLogica
    {
        private readonly EquipoDatos datos = new EquipoDatos();

        public DataTable Listar()
        {
            return datos.Listar();
        }

        public void Agregar(Equipo e)
        {
            Validar(e);
            datos.Agregar(e);
        }

        public void Modificar(Equipo e)
        {
            if (e.EquipoID <= 0)
                throw new ArgumentException("Seleccione un equipo de la lista.");
            Validar(e);
            datos.Modificar(e);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Seleccione un equipo de la lista.");
            try { datos.Eliminar(id); }
            catch (SqlException ex) when (ex.Number == 547)
            {
                throw new InvalidOperationException(
                    "No se puede eliminar: el equipo tiene reparaciones registradas.");
            }
        }

        private static void Validar(Equipo e)
        {
            if (string.IsNullOrWhiteSpace(e.TipoEquipo))
                throw new ArgumentException("El tipo de equipo es obligatorio.");
            if (string.IsNullOrWhiteSpace(e.Modelo))
                throw new ArgumentException("El modelo es obligatorio.");
            if (e.UsuarioID <= 0)
                throw new ArgumentException("Seleccione el usuario dueño del equipo.");
        }
    }
}
