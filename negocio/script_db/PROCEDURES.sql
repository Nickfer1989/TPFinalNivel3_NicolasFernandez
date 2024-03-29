USE [CATALOGO_WEB_DB]
GO
/****** Object:  StoredProcedure [dbo].[insertarNuevo]    Script Date: 29/1/2024 16:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[insertarNuevo]
@email varchar(50),
@pass varchar(50)
as
insert into USERS (email, pass, admin) output inserted.id values (@email, @pass, 0)
GO
/****** Object:  StoredProcedure [dbo].[storedAltaArticulo]    Script Date: 29/1/2024 16:55:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[storedAltaArticulo]
@Codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(150),
@idMarca int,
@idCategoria int,
@imagenUrl varchar(1000),
@precio int
as
insert into articulos values(@Codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)
GO
/****** Object:  StoredProcedure [dbo].[storedListar]    Script Date: 29/1/2024 16:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER procedure [dbo].[storedListar] as
select Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio,A.IdMarca, A.IdCategoria,A.Id 
From ARTICULOS A, CATEGORIAS C, MARCAS M 
Where M.Id = IdMarca And C.Id = IdCategoria 
GO
/****** Object:  StoredProcedure [dbo].[storedModificarArticulo]    Script Date: 29/1/2024 16:57:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[storedModificarArticulo]
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(150),
@idMarca int,
@idCategoria int,
@imagenUrl varchar(1000),
@precio money,
@id int
as
update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion,
IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio 
where Id = @id

