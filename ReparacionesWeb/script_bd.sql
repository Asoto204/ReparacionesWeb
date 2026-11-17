-- ============================================
-- Base de datos: ReparacionesDB
-- Adiel Soto Valverde y Andy Lopez Sanchez
-- ============================================
IF DB_ID('ReparacionesDB') IS NULL CREATE DATABASE ReparacionesDB;
GO
USE ReparacionesDB;
GO

CREATE TABLE Usuarios (
    UsuarioID         INT IDENTITY(1,1) PRIMARY KEY,
    Nombre            VARCHAR(100) NOT NULL,
    CorreoElectronico VARCHAR(100) NOT NULL,
    Telefono          VARCHAR(20)  NULL
);

CREATE TABLE Equipos (
    EquipoID   INT IDENTITY(1,1) PRIMARY KEY,
    TipoEquipo VARCHAR(50) NOT NULL,
    Modelo     VARCHAR(100) NOT NULL,
    UsuarioID  INT NOT NULL,
    CONSTRAINT FK_Equipos_Usuarios FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

CREATE TABLE Tecnicos (
    TecnicoID    INT IDENTITY(1,1) PRIMARY KEY,
    Nombre       VARCHAR(100) NOT NULL,
    Especialidad VARCHAR(100) NULL
);

CREATE TABLE Reparaciones (
    ReparacionID   INT IDENTITY(1,1) PRIMARY KEY,
    EquipoID       INT NOT NULL,
    FechaSolicitud DATE NOT NULL DEFAULT GETDATE(),
    Estado         VARCHAR(30) NOT NULL,
    CONSTRAINT FK_Reparaciones_Equipos FOREIGN KEY (EquipoID) REFERENCES Equipos(EquipoID)
);

CREATE TABLE Asignaciones (
    AsignacionID    INT IDENTITY(1,1) PRIMARY KEY,
    ReparacionID    INT NOT NULL,
    TecnicoID       INT NOT NULL,
    FechaAsignacion DATE NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Asignaciones_Reparaciones FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID),
    CONSTRAINT FK_Asignaciones_Tecnicos FOREIGN KEY (TecnicoID) REFERENCES Tecnicos(TecnicoID)
);

CREATE TABLE DetallesReparacion (
    DetalleID    INT IDENTITY(1,1) PRIMARY KEY,
    ReparacionID INT NOT NULL,
    Descripcion  VARCHAR(255) NOT NULL,
    FechaInicio  DATE NULL,
    FechaFin     DATE NULL,
    CONSTRAINT FK_Detalles_Reparaciones FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID)
);
GO

-- Datos de prueba (opcional)
INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono) VALUES
('Ana Pérez', 'ana@correo.com', '8888-1111'),
('Luis Mora', 'luis@correo.com', '8888-2222');
INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES
('Laptop', 'Dell Inspiron 15', 1),
('Celular', 'Samsung A54', 2);
GO
