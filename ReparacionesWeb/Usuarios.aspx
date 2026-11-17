<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ReparacionesWeb.Usuarios" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Usuarios</title>
    <link href="Content/estilos.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
    <header>
        <span class="logo">Reparaciones</span>
        <nav>
            <a href="Default.aspx">Inicio</a>
            <a href="Usuarios.aspx">Usuarios</a>
            <a href="Equipos.aspx">Equipos</a>
        </nav>
    </header>
    <main>
        <h2>Usuarios</h2>

        <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>

        <div class="formulario">
            <asp:HiddenField ID="hfId" runat="server" />
            <label>Nombre
                <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
            </label>
            <label>Correo electrónico
                <asp:TextBox ID="txtCorreo" runat="server" MaxLength="100"></asp:TextBox>
            </label>
            <label>Teléfono
                <asp:TextBox ID="txtTelefono" runat="server" MaxLength="20"></asp:TextBox>
            </label>
            <div class="botones">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="peligro"
                    OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Eliminar este usuario?');" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
            </div>
        </div>

        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false"
            DataKeyNames="UsuarioID" CssClass="tabla" GridLines="None"
            OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="UsuarioID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:CommandField ShowSelectButton="True" SelectText="Editar" HeaderText="Acciones" />
            </Columns>
        </asp:GridView>
    </main>
</form>
</body>
</html>
