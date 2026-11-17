<%@ Page Language="C#" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Reparaciones</title>
    <link href="Content/estilos.css" rel="stylesheet" />
</head>
<body>
    <header>
        <span class="logo">Reparaciones</span>
        <nav>
            <a href="Default.aspx">Inicio</a>
            <a href="Usuarios.aspx">Usuarios</a>
            <a href="Equipos.aspx">Equipos</a>
        </nav>
    </header>
    <main>
        <h2>Sistema de Reparaciones</h2>
        <p>Seleccione una opción:</p>
        <div class="tarjetas">
            <a class="tarjeta" href="Usuarios.aspx"><h3>Usuarios</h3><p>Agregar, modificar y eliminar usuarios.</p></a>
            <a class="tarjeta" href="Equipos.aspx"><h3>Equipos</h3><p>Agregar, modificar y eliminar equipos.</p></a>
        </div>
    </main>
</body>
</html>
