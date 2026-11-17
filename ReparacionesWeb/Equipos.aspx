<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="ReparacionesWeb.Equipos" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Equipos</title>
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
        <h2>Equipos</h2>

        <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>

        <div class="formulario">
            <asp:HiddenField ID="hfId" runat="server" />
            <label>Tipo de equipo
                <asp:TextBox ID="txtTipo" runat="server" MaxLength="50"></asp:TextBox>
            </label>
            <label>Modelo
                <asp:TextBox ID="txtModelo" runat="server" MaxLength="100"></asp:TextBox>
            </label>
            <label>Usuario (dueño)
                <asp:DropDownList ID="ddlUsuario" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Value="0" Text="-- Seleccione --"></asp:ListItem>
                </asp:DropDownList>
            </label>
            <div class="botones">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="peligro"
                    OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Eliminar este equipo?');" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
            </div>
        </div>

        <asp:GridView ID="gvEquipos" runat="server" AutoGenerateColumns="false"
            DataKeyNames="EquipoID" CssClass="tabla" GridLines="None"
            OnSelectedIndexChanged="gvEquipos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="EquipoID" HeaderText="ID" />
                <asp:BoundField DataField="TipoEquipo" HeaderText="Tipo" />
                <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                <asp:CommandField ShowSelectButton="True" SelectText="Editar" HeaderText="Acciones" />
            </Columns>
        </asp:GridView>
    </main>
</form>
</body>
</html>
