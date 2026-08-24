-- =========================================================
-- Script de creación de base de datos
-- Taller Mecánico Toluca
-- Genera el esquema exacto que espera TallerToluca.DAL
-- =========================================================

IF DB_ID('TallerMecanicoToluca.DB') IS NULL
BEGIN
    CREATE DATABASE [TallerMecanicoToluca.DB];
END
GO

USE [TallerMecanicoToluca.DB];
GO

-- ================= Clientes =================
IF OBJECT_ID('dbo.Clientes') IS NULL
CREATE TABLE dbo.Clientes (
    ClienteID     INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto NVARCHAR(150) NOT NULL,
    Telefono      NVARCHAR(30)  NOT NULL,
    Correo        NVARCHAR(150) NULL,
    Direccion     NVARCHAR(250) NULL,
    Estado        NVARCHAR(20)  NOT NULL DEFAULT 'Activo'
    DUI   CHAR (8) NOT NULL,
);
GO

-- ================= Empleados =================
IF OBJECT_ID('dbo.Empleados') IS NULL
CREATE TABLE dbo.Empleados (
    EmpleadoID     INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto NVARCHAR(150) NOT NULL,
    Cargo          NVARCHAR(100) NOT NULL,
    Telefono       NVARCHAR(30)  NULL,
    Estado         NVARCHAR(20)  NOT NULL DEFAULT 'Activo'
);
GO

-- ================= Usuarios =================
IF OBJECT_ID('dbo.Usuarios') IS NULL
CREATE TABLE dbo.Usuarios (
    UsuarioID     INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoID    INT NOT NULL REFERENCES dbo.Empleados(EmpleadoID),
    NombreUsuario NVARCHAR(50)  NOT NULL UNIQUE,
    ClaveHash     NVARCHAR(200) NOT NULL,
    Rol           NVARCHAR(30)  NOT NULL, -- Administrador, Recepcionista, Mecánico
    Estado        NVARCHAR(20)  NOT NULL DEFAULT 'Activo'
);
GO

-- ================= Vehiculos =================
IF OBJECT_ID('dbo.Vehiculos') IS NULL
CREATE TABLE dbo.Vehiculos (
    VehiculoID    INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID     INT NOT NULL REFERENCES dbo.Clientes(ClienteID),
    Placa         NVARCHAR(20)  NOT NULL,
    Marca         NVARCHAR(50)  NOT NULL,
    Modelo        NVARCHAR(50)  NOT NULL,
    Anio          INT           NOT NULL,
    Color         NVARCHAR(30)  NULL,
    TipoVehiculo  NVARCHAR(20)  NOT NULL DEFAULT 'Liviano'
);
GO

-- ================= OrdenesTrabajo =================
IF OBJECT_ID('dbo.OrdenesTrabajo') IS NULL
CREATE TABLE dbo.OrdenesTrabajo (
    OrdenID                INT IDENTITY(1,1) PRIMARY KEY,
    FechaCreacion           DATETIME NOT NULL DEFAULT GETDATE(),
    ClienteID               INT NOT NULL REFERENCES dbo.Clientes(ClienteID),
    VehiculoID              INT NOT NULL REFERENCES dbo.Vehiculos(VehiculoID),
    EmpleadoID              INT NOT NULL REFERENCES dbo.Empleados(EmpleadoID),
    Estado                  NVARCHAR(20) NOT NULL DEFAULT 'Pendiente', -- Pendiente, En Proceso, Finalizada
    KilometrajeEntrada      INT NOT NULL,
    UbicacionTaller         NVARCHAR(100) NOT NULL DEFAULT 'Taller Mecánico Toluca',
    DescripcionDiagnostico  NVARCHAR(500) NOT NULL,
    Observaciones           NVARCHAR(500) NULL
);
GO

-- ================= Citas =================
IF OBJECT_ID('dbo.Citas') IS NULL
CREATE TABLE dbo.Citas (
    CitaID      INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID   INT NOT NULL REFERENCES dbo.Clientes(ClienteID),
    VehiculoID  INT NOT NULL REFERENCES dbo.Vehiculos(VehiculoID),
    FechaHora   DATETIME NOT NULL,
    Motivo      NVARCHAR(300) NOT NULL,
    Estado      NVARCHAR(20) NOT NULL DEFAULT 'Programada' -- Programada, Cancelada, Atendida, No Recibida
);
GO

-- ================= ControlCaja =================
IF OBJECT_ID('dbo.ControlCaja') IS NULL
CREATE TABLE dbo.ControlCaja (
    CajaID          INT IDENTITY(1,1) PRIMARY KEY,
    FechaApertura   DATETIME NOT NULL DEFAULT GETDATE(),
    FechaCierre     DATETIME NULL,
    MontoApertura   DECIMAL(12,2) NOT NULL,
    MontoIngresos   DECIMAL(12,2) NOT NULL DEFAULT 0,
    MontoEgresos    DECIMAL(12,2) NOT NULL DEFAULT 0,
    Estado          NVARCHAR(20) NOT NULL DEFAULT 'Abierta' -- Abierta, Cerrada
    FacturaId INT IDENTITY(1,1) PRIMARY KEY,
    AdministradorId INT NOT NULL,
    EmpleadoId INT NOT NULL,

);
GO

-- ================= Facturas =================
IF OBJECT_ID('dbo.Facturas') IS NULL
CREATE TABLE dbo.Facturas (
    FacturaID   INT IDENTITY(1,1) PRIMARY KEY,
    OrdenID     INT NOT NULL REFERENCES dbo.OrdenesTrabajo(OrdenID),
    ClienteID   INT NOT NULL REFERENCES dbo.Clientes(ClienteID),
    CajaID      INT NOT NULL REFERENCES dbo.ControlCaja(CajaID),
    Fecha       DATETIME NOT NULL DEFAULT GETDATE(),
    SubTotal    DECIMAL(12,2) NOT NULL,
    Total       DECIMAL(12,2) NOT NULL,
    MetodoPago  NVARCHAR(20) NOT NULL DEFAULT 'Efectivo'
);
GO

-- ================= Repuestos =================
IF OBJECT_ID('dbo.Repuestos') IS NULL
CREATE TABLE dbo.Repuestos (
    RepuestoID      INT IDENTITY(1,1) PRIMARY KEY,
    Codigo          NVARCHAR(30)  NOT NULL UNIQUE,
    NombreRepuesto  NVARCHAR(150) NOT NULL,
    PrecioUnitario  DECIMAL(12,2) NOT NULL,
    Existencia      INT NOT NULL DEFAULT 0
);
GO

-- ================= MovimientosInventario =================
IF OBJECT_ID('dbo.MovimientosInventario') IS NULL
CREATE TABLE dbo.MovimientosInventario (
    MovimientoID    INT IDENTITY(1,1) PRIMARY KEY,
    RepuestoID      INT NOT NULL REFERENCES dbo.Repuestos(RepuestoID),
    TipoMovimiento  NVARCHAR(20) NOT NULL, -- Entrada, Salida
    Cantidad        INT NOT NULL,
    Fecha           DATETIME NOT NULL DEFAULT GETDATE(),
    Motivo          NVARCHAR(300) NULL
);
GO

-- =========================================================
-- Datos semilla: un empleado administrador y su usuario
-- para poder iniciar sesión la primera vez.
-- Usuario: admin   Contraseña: admin123
-- (El sistema compara la contraseña en texto plano en
-- ClaveHash, tal como está implementado en UsuarioDAL)
-- =========================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Empleados WHERE NombreCompleto = 'Administrador General')
BEGIN
    INSERT INTO dbo.Empleados (NombreCompleto, Cargo, Telefono, Estado)
    VALUES ('Administrador General', 'Administrador', '0000-0000', 'Activo');
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE NombreUsuario = 'admin')
BEGIN
    DECLARE @EmpleadoAdminID INT = (SELECT TOP 1 EmpleadoID FROM dbo.Empleados WHERE NombreCompleto = 'Administrador General');

    INSERT INTO dbo.Usuarios (EmpleadoID, NombreUsuario, ClaveHash, Rol, Estado)
    VALUES (@EmpleadoAdminID, 'admin', 'admin123', 'Administrador', 'Activo');
END
GO

PRINT 'Base de datos TallerMecanicoToluca.DB creada/verificada correctamente.';
