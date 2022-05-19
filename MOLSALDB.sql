

CREATE DATABASE MOLSAL_COMPRAS
GO
USE MOLSAL_COMPRAS
GO
CREATE SCHEMA Auth AUTHORIZATION db_owner
GO


CREATE TABLE [Usuario]
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
  [UsuarioCreacion][int],
  [UsuarioModificacion][int],
  [FechaCreacion][DateTime],
  [FechaModificacion][DateTime]
) 
GO

CREATE TABLE [Catalogo]
(
  [idCatalogo][int] IDENTITY(1,1) NOT NULL,
  [Descripcion][VARCHAR](200) NULL,
  [Estado][int] NULL,
  [UsuarioCreacion][int],
  [UsuarioModificacion][int],
  [FechaCreacion][DateTime],
  [FechaModificacion][DateTime]
)
GO

CREATE TABLE CatalogoDetalle
(
  [idDetalle][int] IDENTITY(1,1) NOT NULL,
  [idCatalogo][int] NULL,
  [Descripcion][varchar](200) NULL,
  [Estado][int] NULL,
  [UsuarioCreacion][int],
  [UsuarioModificacion][int],
  [FechaCreacion][DateTime],
  [FechaModificacion][DateTime]
)
GO

CREATE TABLE DetalleFactura (
  [idDetalle][int] IDENTITY(1,1) NOT NULL,
  [idFactura][int] NULL,
  [idProducto][int] NULL,
  [Cantidad][int] NULL,
  [PrecioVenta][float] NULL,
  [CostoUnitario][float] NULL,
  [UsuarioCreacion][int],
  [UsuarioModificacion][int],
  [FechaCreacion][DateTime],
  [FechaModificacion][DateTime]
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
  [UsuarioCreacion][int],
  [UsuarioModificacion][int],
  [FechaCreacion][DateTime],
  [FechaModificacion][DateTime]

)
GO

CREATE TABLE Existencia
 (
  [idExistencia][int] IDENTITY(1,1) NOT NULL,
  [idProducto][int] NULL,
  [Estado][int] NULL,
  [Cantidad][int] NULL,
  [UsuarioCreacion][int],
  [UsuarioModificacion][int],
  [FechaCreacion][DateTime],
  [FechaModificacion][DateTime]
)
GO

CREATE TABLE Factura (
  [idFactura][int] IDENTITY(1,1) NOT NULL,
  [idProveedor][int] NULL,
  [Correlativo][VARCHAR](100) NULL,
  [Fecha][datetime] NULL,
  [Total][float] NULL,
  [Estado] int NULL,
  [UsuarioCreacion][int],
  [UsuarioModificacion][int],
  [FechaCreacion][DateTime],
  [FechaModificacion][DateTime]
)
GO

CREATE TABLE Kardex (
  [idKardex][int] IDENTITY(1,1) NOT NULL,
  [idProducto][int] NULL,
  [idFactura][int] NULL,
  [Cantidad][int] NULL,
  [UsuarioCreacion][int],
  [UsuarioModificacion][int],
  [FechaCreacion][DateTime],
  [FechaModificacion][DateTime]
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
  [UsuarioCreacion][int],
  [UsuarioModificacion][int],
  [FechaCreacion][DateTime],
  [FechaModificacion][DateTime]
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
  [UsuarioCreacion][int],
  [UsuarioModificacion][int],
  [FechaCreacion][DateTime],
  [FechaModificacion][DateTime]
)
GO

CREATE TABLE Compras (
  [idCompra]int IDENTITY(1,1) NOT NULL,
  [idFactura][int],
  [idProveedor][int],
  [Correlativo][varchar](100),
  [Fecha][DateTime],
  [Total][Float],
  [UsuarioCreacion][int],
  [UsuarioModificacion][int],
  [FechaCreacion][DateTime],
  [FechaModificacion][DateTime]
)
GO


-----------------------------------------------------------------------------------
CREATE OR ALTER VIEW Vw_ListadoCompras AS
	SELECT F.idFactura, P.Nombre, F.Correlativo, F.Fecha, F.Total, F.Estado 
  FROM Proveedor as P 
  INNER JOIN Factura as F 
    ON P.idProveedor = F.idProveedor
GO

CREATE OR ALTER VIEW Vw_DetalleCompra AS
	SELECT DF.idFactura, prod.Nombre as Producto, DF.Cantidad, DF.PrecioVenta, DF.CostoUnitario 
  FROM Proveedor as P 
  INNER JOIN DetalleFactura as DF 
    ON P.idProveedor = DF.idFactura 
  INNER JOIN Producto as prod 
    ON DF.idProducto = prod.idProducto
GO


-----------------------------------------------------------------------------------

INSERT INTO Usuario(NombreUsuario, Clave, Estado, FechaCreacion, FechaModificacion)
VALUES('Ale', 'MQAyADMA', 1, SYSDATETIME(), SYSDATETIME())

insert into Factura (  idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (1 ,'A01', GETDATE(), 523.34, 1, GETDATE(), GETDATE())
insert into Factura (  idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (1 ,'A02', GETDATE(), 1234.32, 1, GETDATE(), GETDATE())
insert into Factura (  idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (2 ,'A03', GETDATE(), 2341.45, 1, GETDATE(), GETDATE())
insert into Factura (  idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (1 ,'A04', GETDATE(), 253.21, 1, GETDATE(), GETDATE())
insert into Factura (  idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (2 ,'A05', GETDATE(), 2345.34, 1, GETDATE(), GETDATE())
insert into Factura (  idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (2 ,'A06', GETDATE(), 543.32, 1, GETDATE(), GETDATE())
insert into Factura(  idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (1 ,'A07', GETDATE(), 345.45, 1, GETDATE(), GETDATE())
insert into Factura (  idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (2 ,'A08', GETDATE(), 4365.21, 1, GETDATE(), GETDATE())

insert into Compras ( idFactura, idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values ( 1, 1 ,'A01', GETDATE(), 523.34, 1, GETDATE(), GETDATE())
insert into Compras ( idFactura, idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values ( 2, 1 ,'A02', GETDATE(), 1234.32, 1, GETDATE(), GETDATE())
insert into Compras ( idFactura, idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values ( 3, 2 ,'A03', GETDATE(), 2341.45, 1, GETDATE(), GETDATE())
insert into Compras ( idFactura, idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values ( 4, 1 ,'A04', GETDATE(), 253.21, 1, GETDATE(), GETDATE())
insert into Compras ( idFactura, idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (5, 2 ,'A05', GETDATE(), 2345.34, 1, GETDATE(), GETDATE())
insert into Compras ( idFactura, idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (6, 2 ,'A06', GETDATE(), 543.32, 1, GETDATE(), GETDATE())
insert into Compras ( idFactura, idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (7, 1 ,'A07', GETDATE(), 345.45, 1, GETDATE(), GETDATE())
insert into Compras ( idFactura, idProveedor, Correlativo, Fecha, Total, UsuarioCreacion, FechaCreacion, FechaModificacion)
values (8, 2 ,'A08', GETDATE(), 4365.21, 1, GETDATE(), GETDATE())

insert into DetalleFactura (idFactura, idProducto, Cantidad, PrecioVenta, CostoUnitario, UsuarioCreacion, FechaCreacion)
values (1, 1, 12, 523.34, 43.61, 1, GETDATE())
insert into DetalleFactura (idFactura, idProducto, Cantidad, PrecioVenta, CostoUnitario, UsuarioCreacion, FechaCreacion)
values (1, 2, 1, 10, 10, 1, GETDATE())
insert into DetalleFactura (idFactura, idProducto, Cantidad, PrecioVenta, CostoUnitario, UsuarioCreacion, FechaCreacion)
values (1, 1, 12, 523.34, 43.61, 1, GETDATE())
insert into DetalleFactura (idFactura, idProducto, Cantidad, PrecioVenta, CostoUnitario, UsuarioCreacion, FechaCreacion)
values (2, 1, 13, 152.13, 105.40, 1, GETDATE())
insert into DetalleFactura (idFactura, idProducto, Cantidad, PrecioVenta, CostoUnitario, UsuarioCreacion, FechaCreacion)
values (2, 1, 19, 99.01, 64.78, 1, GETDATE())
insert into DetalleFactura (idFactura, idProducto, Cantidad, PrecioVenta, CostoUnitario, UsuarioCreacion, FechaCreacion)
values (2, 2, 23, 49.99 , 27.68, 1, GETDATE())

insert into Proveedor (Nombre, Estado, NIT, RazonSocial, Direccion, Telefono, UsuarioCreacion, FechaCreacion)
values ('Kevin y asociados', 1, '1234-121212-123-1', 'Distribuidora central','San Salvador centro n123', '2222-5445', 1, GETDATE())
insert into Proveedor (Nombre, Estado, NIT, RazonSocial, Direccion, Telefono, UsuarioCreacion, FechaCreacion)
values ('La milagrosa', 1, '2342-513245-654-9', 'Fabrica la milagrosa S.A DE C.V','San Salvador centro n533', '2112-3545', 1, GETDATE())

insert into Producto (idBodega, Nombre, Descripcion, Precio, CostoUnitario, Estado, UsuarioCreacion, FechaCreacion)
values (1, 'RESMA PAPEL BOND A4', '', 1.99, 1.99, 1, 1, GETDATE()) 
insert into Producto (idBodega, Nombre, Descripcion, Precio, CostoUnitario, Estado, UsuarioCreacion, FechaCreacion)
values (1, 'CARTUCHO IMPRESORA HP', '', 29.34, 29.34, 1, 1, GETDATE()) 




																											  