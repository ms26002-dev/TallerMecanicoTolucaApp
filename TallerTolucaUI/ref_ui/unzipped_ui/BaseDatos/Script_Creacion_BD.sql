/* ============================================================
   TALLER MECÁNICO TOLUCA - SCRIPT DE CREACIÓN DE BASE DE DATOS
   Ejecutar en SQL Server (LocalDB, Express o Full) con SSMS
   o con `sqlcmd -S "(localdb)\MSSQLLocalDB" -i Script_Creacion_BD.sql`
   ============================================================ */

IF DB_ID('TallerMecanicoToluca.DB') IS NULL
BEGIN
    CREATE DATABASE [TallerMecanicoToluca.DB];
END
GO

USE [TallerMecanicoToluca.DB];
GO

/* ---------- Clientes ---------- */
IF OBJECT_ID('dbo.Clientes') IS NULL
CREATE TABLE dbo.Clientes (
    ClienteID       INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto  NVARCHAR(150) NOT NULL,
    Telefono        NVARCHAR(20)  NOT NULL,
    Correo          NVARCHAR(150) NULL,
    Direccion       NVARCHAR(250) NULL,
    Estado          NVARCHAR(20)  NOT NULL DEFAULT 'Activo'
);
GO

/* ---------- Empleados ---------- */
IF OBJECT_ID('dbo.Empleados') IS NULL
CREATE TABLE dbo.Empleados (
    EmpleadoID      INT IDENTITY(1,1) PRIMARY KEY,
    NombreCompleto  NVARCHAR(150) NOT NULL,
    Cargo           NVARCHAR(80)  NOT NULL,
    Telefono        NVARCHAR(20)  NULL,
    Estado          NVARCHAR(20)  NOT NULL DEFAULT 'Activo'
);
GO

/* ---------- Usuarios (login del sistema) ---------- */
IF OBJECT_ID('dbo.Usuarios') IS NULL
CREATE TABLE dbo.Usuarios (
    UsuarioID       INT IDENTITY(1,1) PRIMARY KEY,
    EmpleadoID      INT NOT NULL FOREIGN KEY REFERENCES dbo.Empleados(EmpleadoID),
    NombreUsuario   NVARCHAR(50)  NOT NULL UNIQUE,
    ClaveHash       NVARCHAR(200) NOT NULL,
    Rol             NVARCHAR(30)  NOT NULL, -- Administrador, Recepcionista, Mecánico
    Estado          NVARCHAR(20)  NOT NULL DEFAULT 'Activo'
);
GO

/* ---------- Vehículos ---------- */
IF OBJECT_ID('dbo.Vehiculos') IS NULL
CREATE TABLE dbo.Vehiculos (
    VehiculoID      INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID       INT NOT NULL FOREIGN KEY REFERENCES dbo.Clientes(ClienteID),
    Placa           NVARCHAR(20)  NOT NULL,
    Marca           NVARCHAR(60)  NOT NULL,
    Modelo          NVARCHAR(60)  NOT NULL,
    Anio            INT NOT NULL,
    Color           NVARCHAR(30)  NULL,
    TipoVehiculo    NVARCHAR(20)  NOT NULL DEFAULT 'Liviano' -- solo Liviano permitido por reglas de negocio
);
GO

/* ---------- Control de Caja ---------- */
IF OBJECT_ID('dbo.ControlCaja') IS NULL
CREATE TABLE dbo.ControlCaja (
    CajaID          INT IDENTITY(1,1) PRIMARY KEY,
    FechaApertura   DATETIME NOT NULL DEFAULT GETDATE(),
    FechaCierre     DATETIME NULL,
    MontoApertura   DECIMAL(12,2) NOT NULL,
    MontoIngresos   DECIMAL(12,2) NOT NULL DEFAULT 0,
    MontoEgresos    DECIMAL(12,2) NOT NULL DEFAULT 0,
    Estado          NVARCHAR(20)  NOT NULL DEFAULT 'Abierta' -- Abierta, Cerrada
);
GO

/* ---------- Órdenes de Trabajo ---------- */
IF OBJECT_ID('dbo.OrdenesTrabajo') IS NULL
CREATE TABLE dbo.OrdenesTrabajo (
    OrdenID                 INT IDENTITY(1,1) PRIMARY KEY,
    FechaCreacion           DATETIME NOT NULL DEFAULT GETDATE(),
    ClienteID               INT NOT NULL FOREIGN KEY REFERENCES dbo.Clientes(ClienteID),
    VehiculoID              INT NOT NULL FOREIGN KEY REFERENCES dbo.Vehiculos(VehiculoID),
    EmpleadoID              INT NOT NULL FOREIGN KEY REFERENCES dbo.Empleados(EmpleadoID),
    Estado                  NVARCHAR(20) NOT NULL DEFAULT 'Pendiente', -- Pendiente, En Proceso, Finalizada
    KilometrajeEntrada      INT NOT NULL,
    UbicacionTaller         NVARCHAR(100) NOT NULL DEFAULT 'Taller Mecánico Toluca',
    DescripcionDiagnostico  NVARCHAR(MAX) NOT NULL,
    Observaciones           NVARCHAR(MAX) NULL
);
GO

/* ---------- Facturas ---------- */
IF OBJECT_ID('dbo.Facturas') IS NULL
CREATE TABLE dbo.Facturas (
    FacturaID       INT IDENTITY(1,1) PRIMARY KEY,
    OrdenID         INT NOT NULL FOREIGN KEY REFERENCES dbo.OrdenesTrabajo(OrdenID),
    ClienteID       INT NOT NULL FOREIGN KEY REFERENCES dbo.Clientes(ClienteID),
    CajaID          INT NOT NULL FOREIGN KEY REFERENCES dbo.ControlCaja(CajaID),
    Fecha           DATETIME NOT NULL DEFAULT GETDATE(),
    SubTotal        DECIMAL(12,2) NOT NULL,
    Total           DECIMAL(12,2) NOT NULL,
    MetodoPago      NVARCHAR(20)  NOT NULL DEFAULT 'Efectivo' -- solo Efectivo
);
GO

/* ---------- Citas ---------- */
IF OBJECT_ID('dbo.Citas') IS NULL
CREATE TABLE dbo.Citas (
    CitaID          INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID       INT NOT NULL FOREIGN KEY REFERENCES dbo.Clientes(ClienteID),
    VehiculoID      INT NOT NULL FOREIGN KEY REFERENCES dbo.Vehiculos(VehiculoID),
    FechaHora       DATETIME NOT NULL,
    Motivo          NVARCHAR(250) NOT NULL,
    Estado          NVARCHAR(20)  NOT NULL DEFAULT 'Programada' -- Programada, Cancelada, Atendida, No Recibida
);
GO

/* ---------- Repuestos ---------- */
IF OBJECT_ID('dbo.Repuestos') IS NULL
CREATE TABLE dbo.Repuestos (
    RepuestoID      INT IDENTITY(1,1) PRIMARY KEY,
    Codigo          NVARCHAR(30)  NOT NULL UNIQUE,
    NombreRepuesto  NVARCHAR(150) NOT NULL,
    PrecioUnitario  DECIMAL(12,2) NOT NULL,
    Existencia      INT NOT NULL DEFAULT 0
);
GO

/* ---------- Movimientos de Inventario ---------- */
IF OBJECT_ID('dbo.MovimientosInventario') IS NULL
CREATE TABLE dbo.MovimientosInventario (
    MovimientoID    INT IDENTITY(1,1) PRIMARY KEY,
    RepuestoID      INT NOT NULL FOREIGN KEY REFERENCES dbo.Repuestos(RepuestoID),
    TipoMovimiento  NVARCHAR(20) NOT NULL, -- Entrada, Salida
    Cantidad        INT NOT NULL,
    Fecha           DATETIME NOT NULL DEFAULT GETDATE(),
    Motivo          NVARCHAR(250) NULL
);
GO

/* ---------- Detalle Orden - Repuesto (opcional, para futuras funciones) ---------- */
IF OBJECT_ID('dbo.OrdenRepuesto') IS NULL
CREATE TABLE dbo.OrdenRepuesto (
    DetalleID       INT IDENTITY(1,1) PRIMARY KEY,
    OrdenID         INT NOT NULL FOREIGN KEY REFERENCES dbo.OrdenesTrabajo(OrdenID),
    RepuestoID      INT NOT NULL FOREIGN KEY REFERENCES dbo.Repuestos(RepuestoID),
    Cantidad        INT NOT NULL,
    PrecioUnitario  DECIMAL(12,2) NOT NULL
);
GO

/* ============================================================
   DATOS INICIALES (SEED) - Usuario administrador para poder
   iniciar sesión la primera vez que se ejecuta la aplicación
   ============================================================ */

IF NOT EXISTS (SELECT 1 FROM dbo.Empleados WHERE NombreCompleto = 'Administrador General')
BEGIN
    INSERT INTO dbo.Empleados (NombreCompleto, Cargo, Telefono, Estado)
    VALUES ('Administrador General', 'Administrador', '7000-0000', 'Activo');
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Usuarios WHERE NombreUsuario = 'admin')
BEGIN
    DECLARE @EmpleadoAdminID INT = (SELECT TOP 1 EmpleadoID FROM dbo.Empleados WHERE NombreCompleto = 'Administrador General');

    INSERT INTO dbo.Usuarios (EmpleadoID, NombreUsuario, ClaveHash, Rol, Estado)
    VALUES (@EmpleadoAdminID, 'admin', 'admin123', 'Administrador', 'Activo');
END
GO

/* NOTA IMPORTANTE:
   El campo ClaveHash actualmente se compara en texto plano dentro de
   UsuarioDAL.ValidarLogin (TallerToluca.DAL/Usuario.cs). Para un entorno
   real de producción se recomienda aplicar un hash (por ejemplo BCrypt)
   antes de guardar y comparar las contraseñas.

   Usuario de acceso inicial:
     Usuario:   admin
     Contraseña: admin123
*/
