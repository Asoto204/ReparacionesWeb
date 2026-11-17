using System;
using System.Data;
using System.Web.UI;
using ReparacionesWeb.Entidades;
using ReparacionesWeb.Logica;

namespace ReparacionesWeb
{
    public partial class Equipos : Page
    {
        private readonly EquipoLogica logica = new EquipoLogica();
        private readonly UsuarioLogica usuarios = new UsuarioLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
                Cargar();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => logica.Agregar(Leer()), "Equipo agregado.");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => logica.Modificar(Leer()), "Equipo modificado.");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => logica.Eliminar(Leer().EquipoID), "Equipo eliminado.");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void gvEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvEquipos.SelectedDataKey.Value);
            DataRow[] filas = logica.Listar().Select("EquipoID = " + id);
            if (filas.Length == 0) return;

            hfId.Value = id.ToString();
            txtTipo.Text = filas[0]["TipoEquipo"].ToString();
            txtModelo.Text = filas[0]["Modelo"].ToString();
            ddlUsuario.SelectedValue = filas[0]["UsuarioID"].ToString();
        }

        private Equipo Leer()
        {
            int id;
            int.TryParse(hfId.Value, out id);
            return new Equipo
            {
                EquipoID = id,
                TipoEquipo = txtTipo.Text.Trim(),
                Modelo = txtModelo.Text.Trim(),
                UsuarioID = int.Parse(ddlUsuario.SelectedValue)
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

        private void CargarUsuarios()
        {
            try
            {
                ddlUsuario.DataSource = usuarios.Listar();
                ddlUsuario.DataTextField = "Nombre";
                ddlUsuario.DataValueField = "UsuarioID";
                ddlUsuario.DataBind();
            }
            catch (Exception ex)
            {
                Mostrar("No se pudo leer la base de datos: " + ex.Message, false);
            }
        }

        private void Cargar()
        {
            try
            {
                gvEquipos.DataSource = logica.Listar();
                gvEquipos.DataBind();
            }
            catch (Exception ex)
            {
                Mostrar("No se pudo leer la base de datos: " + ex.Message, false);
            }
        }

        private void Limpiar()
        {
            hfId.Value = "";
            txtTipo.Text = "";
            txtModelo.Text = "";
            ddlUsuario.SelectedValue = "0";
            gvEquipos.SelectedIndex = -1;
        }

        private void Mostrar(string mensaje, bool ok)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = ok ? "alert ok" : "alert error";
            lblMensaje.Visible = true;
        }
    }
}
