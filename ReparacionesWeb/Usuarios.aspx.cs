using System;
using System.Data;
using System.Web.UI;
using ReparacionesWeb.Entidades;
using ReparacionesWeb.Logica;

namespace ReparacionesWeb
{
    public partial class Usuarios : Page
    {
        private readonly UsuarioLogica logica = new UsuarioLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) Cargar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => logica.Agregar(Leer()), "Usuario agregado.");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => logica.Modificar(Leer()), "Usuario modificado.");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => logica.Eliminar(Leer().UsuarioID), "Usuario eliminado.");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvUsuarios.SelectedDataKey.Value);
            DataRow[] filas = logica.Listar().Select("UsuarioID = " + id);
            if (filas.Length == 0) return;

            hfId.Value = id.ToString();
            txtNombre.Text = filas[0]["Nombre"].ToString();
            txtCorreo.Text = filas[0]["CorreoElectronico"].ToString();
            txtTelefono.Text = filas[0]["Telefono"].ToString();
        }

        private Usuario Leer()
        {
            int id;
            int.TryParse(hfId.Value, out id);
            return new Usuario
            {
                UsuarioID = id,
                Nombre = txtNombre.Text.Trim(),
                CorreoElectronico = txtCorreo.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim()
            };
        }

        private void Ejecutar(Action accion, string exito)
        {
            try
            {
                accion();
                Limpiar();
                Cargar();
                Mostrar(exito, true);
            }
            catch (Exception ex)
            {
                Mostrar(ex.Message, false);
            }
        }

        private void Cargar()
        {
            try
            {
                gvUsuarios.DataSource = logica.Listar();
                gvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                Mostrar("No se pudo leer la base de datos: " + ex.Message, false);
            }
        }

        private void Limpiar()
        {
            hfId.Value = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            gvUsuarios.SelectedIndex = -1;
        }

        private void Mostrar(string mensaje, bool ok)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = ok ? "alert ok" : "alert error";
            lblMensaje.Visible = true;
        }
    }
}
