
CREATE DATABASE MOLSAL_COMPRAS
GO
USE MOLSAL_COMPRAS
GO
CREATE SCHEMA Auth AUTHORIZATION db_owner
GO


CREATE TABLE [Auth].[Usuario]
(
    [idUsuario][INT] identity(1,1),
    [CodDetaRol][INT],
    [idDirectorio][INT],
    [NombreUsuario][VARCHAR](200),
    [Clave][VARCHAR](1000),
    [Estado][INT],
    [UsuarioCreacion][INT],
    [UsuarioModificacion][INT],
    [FechaCreacion][DATETIME],
    [FechaModificacion][DATETIME]
)
GO

CREATE TABLE [Bodega] 
(
  idBodega[INT] IDENTITY(1,1),
  [Nombre][VARCHAR](100) NULL,
  [Direccion][VARCHAR](200) NULL,
  [Telefono][VARCHAR](10) NULL,
  [Estado][int] NULL,
  [UsuarioCreacion][VARCHAR](100) NULL,
  [UsuarioModificacion][VARCHAR](100) NULL,
  [FechaCreacion][DATETIME] NULL,
  [FechaModificacion][DATETIME] NULL
) 
GO

CREATE TABLE [Catalogo]
(
  [idCatalogo][int] IDENTITY(1,1) NOT NULL,
  [Descripcion][VARCHAR](200) NULL,
  [Estado][int] NULL,
  [UsuarioCreacion][VARCHAR](100) NULL,
  [UsuarioModificacion][VARCHAR](100) NULL,
  [FechaCreacion][DateTime] NULL,
  [FechaModificacion][DateTime] NULL
)
GO

CREATE TABLE CatalogoDetalle
(
  [idDetalle][int] IDENTITY(1,1) NOT NULL,
  [idCatalogo][int] NULL,
  [Descripcion][varchar](200) NULL,
  [Estado][int] NULL,
  [UsuarioCreacion][VARCHAR](100) NULL,
  [UsuarioModificacion][VARCHAR](100) NULL,
  [FechaCreacion][DateTime] NULL,
  [FechaModificacion][DateTime] NULL
)
GO

CREATE TABLE DetalleFactura (
  [idDetalle][int] IDENTITY(1,1) NOT NULL,
  [idFactura][int] NULL,
  [idProducto][int] NULL,
  [Cantidad][int] NULL,
  [PrecioVenta][float] NULL,
  [CostoUnitario][float] NULL,
  [UsuarioCreacion][VARCHAR](100) NULL,
  [UsuarioModificacion][VARCHAR](100) NULL,
  [FechaCreacion][DateTime] NULL,
  [FechaModificacion][DateTime] NULL
)
GO

CREATE TABLE Directorio (
  [idDirectorio][int] IDENTITY(1,1) NOT NULL,
  [Nombre][varchar](100) NULL,
  [Apellido][varchar](100) NULL,
  [Telefono][varchar](10) NULL,
  [FechaNac][date] NULL,
  [Direccion][varchar](200) NULL,
  [DUI][varchar](10) NULL,
  [Correo][varchar](100) NULL,
  [Estado][int] NULL,
  [UsuarioCreacion][VARCHAR](100) NULL,
  [UsuarioModificacion][VARCHAR](100) NULL,
  [FechaCreacion][DateTime] NULL,
  [FechaModificacion][DateTime] NULL

)
GO

CREATE TABLE Existencia
 (
  [idExistencia][int] IDENTITY(1,1) NOT NULL,
  [idProducto][int] NULL,
  [Estado][int] NULL,
  [Cantidad][int] NULL,
  [UsuarioCreacion][VARCHAR](100) NULL,
  [UsuarioModificacion][VARCHAR](100) NULL,
  [FechaCreacion][DateTime] NULL,
  [FechaModificacion][DateTime] NULL
)
GO

CREATE TABLE Factura (
  [idFactura][int] IDENTITY(1,1) NOT NULL,
  [idProveedor][int] NULL,
  [Correlativo][int] NULL,
  [Fecha][datetime] NULL,
  [Total][float] NULL,
  [Estado] int NULL,
  [UsuarioCreacion][VARCHAR](100) NULL,
  [UsuarioModificacion][VARCHAR](100) NULL,
  [FechaCreacion][DateTime] NULL,
  [FechaModificacion][DateTime] NULL
)
GO

CREATE TABLE Kardex (
  [idKardex][int] IDENTITY(1,1) NOT NULL,
  [idProducto][int] NULL,
  [idFactura][int] NULL,
  [Cantidad][int] NULL,
  [UsuarioCreacion][VARCHAR](100) NULL,
  [UsuarioModificacion][VARCHAR](100) NULL,
  [FechaCreacion][DateTime] NULL,
  [FechaModificacion][DateTime] NULL
)
GO

CREATE TABLE Producto (
  [idProducto][int] IDENTITY(1,1) NOT NULL,
  [idBodega][int] NULL,
  [Nombre][varchar](100) NULL,
  [Descripcion][varchar](200) NULL,
  [Precio][float]  NULL,
  [CostoUnitario][float] NULL,
  [Estado][int] NULL,
  [UsuarioCreacion][VARCHAR](100) NULL,
  [UsuarioModificacion][VARCHAR](100) NULL,
  [FechaCreacion][DateTime] NULL,
  [FechaModificacion][DateTime] NULL
)
GO

CREATE TABLE Proveedor (
  [idProveedor] int IDENTITY(1,1) NOT NULL,
  [Nombre][varchar](100) NULL,
  [Estado][int] NULL,
  [NIT][varchar](20) NULL,
  [RazonSocial][varchar](100) NULL,
  [Direccion][varchar](200) NULL,
  [Telefono][varchar](10) NULL,
  [UsuarioCreacion][VARCHAR](100) NULL,
  [UsuarioModificacion][VARCHAR](100) NULL,
  [FechaCreacion][DateTime] NULL,
  [FechaModificacion][DateTime] NULL
)
GO




-- INSERT INTO Auth.Usuario(NombreUsuario, Clave, Estado, FechaCreacion, FechaModificacion)
-- VALUES('Gerardo', 'asdfasdf', 1, SYSDATETIME(), SYSDATETIME())
