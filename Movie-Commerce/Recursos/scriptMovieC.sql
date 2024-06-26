USE [master]
GO
/****** Object:  Database [Movie-Commerce]    Script Date: 16/03/2023 12:03:37 ******/
CREATE DATABASE [Movie-Commerce]
GO
ALTER DATABASE [Movie-Commerce] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Movie-Commerce] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Movie-Commerce] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Movie-Commerce] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Movie-Commerce] SET ARITHABORT OFF 
GO
ALTER DATABASE [Movie-Commerce] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Movie-Commerce] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Movie-Commerce] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Movie-Commerce] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Movie-Commerce] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Movie-Commerce] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Movie-Commerce] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Movie-Commerce] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Movie-Commerce] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Movie-Commerce] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Movie-Commerce] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Movie-Commerce] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Movie-Commerce] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Movie-Commerce] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Movie-Commerce] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Movie-Commerce] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Movie-Commerce] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Movie-Commerce] SET RECOVERY FULL 
GO
ALTER DATABASE [Movie-Commerce] SET  MULTI_USER 
GO
ALTER DATABASE [Movie-Commerce] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Movie-Commerce] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Movie-Commerce] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Movie-Commerce] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Movie-Commerce] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Movie-Commerce] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Movie-Commerce', N'ON'
GO
ALTER DATABASE [Movie-Commerce] SET QUERY_STORE = OFF
GO
USE [Movie-Commerce]
GO
/****** Object:  Table [dbo].[CarritoCompra]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarritoCompra](
	[Carr_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Carr_Peli_Codigo] [int] NULL,
	[Carr_User_Codigo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compuesto]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compuesto](
	[Comp_Codigo] [int] NOT NULL,
	[Comp_Perm_Codigo] [int] NULL,
	[Comp_Padre_Codigo] [int] NULL,
 CONSTRAINT [PK_Compeusto] PRIMARY KEY CLUSTERED 
(
	[Comp_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[Gene_Codigo] [int] NOT NULL,
	[Gene_Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[Gene_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pelicula]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pelicula](
	[Peli_Codigo] [int] NOT NULL,
	[Peli_Nombre] [varchar](50) NULL,
	[Peli_Descripcion] [varchar](max) NULL,
	[Peli_Precio] [decimal](18, 0) NULL,
	[Peli_Imagen] [image] NULL,
	[Peli_PoseeImagen] [bit] NULL,
 CONSTRAINT [PK_Pelicula] PRIMARY KEY CLUSTERED 
(
	[Peli_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeliculaGenero]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeliculaGenero](
	[PelGen_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[PelGen_Peli_Codigo] [int] NULL,
	[PelGen_Gene_Codigo] [int] NULL,
 CONSTRAINT [PK_PeliculaGenero] PRIMARY KEY CLUSTERED 
(
	[PelGen_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Perm_Codigo] [int] NOT NULL,
	[Perm_Nombre] [varchar](50) NULL,
	[Perm_EsPadre] [bit] NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[Perm_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermisoRol]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisoRol](
	[PermRol_Codigo] [int] NOT NULL,
	[PermRol_Rol_Codigo] [int] NULL,
	[PermRol_Perm_Codigo] [int] NULL,
 CONSTRAINT [PK_PermisoRol] PRIMARY KEY CLUSTERED 
(
	[PermRol_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Rol_Codigo] [int] NOT NULL,
	[Rol_Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Rol_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TempPeli_ID]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempPeli_ID](
	[TPeli_ID] [int] NOT NULL,
 CONSTRAINT [PK_TempPeli_ID] PRIMARY KEY CLUSTERED 
(
	[TPeli_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TempPeliculaGenero]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempPeliculaGenero](
	[TPelGen_Codigo] [int] NOT NULL,
	[TPelGen_Peli_Codigo] [int] NULL,
	[TPelGen_Gen_Codigo] [int] NULL,
 CONSTRAINT [PK_TempPeliculaGenero] PRIMARY KEY CLUSTERED 
(
	[TPelGen_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[User_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[User_Nombre] [varchar](50) NULL,
	[User_Contraseña] [varchar](50) NULL,
	[User_Nombre_Real] [varchar](50) NULL,
	[User_Apellido] [varchar](50) NULL,
	[User_DNI] [varchar](50) NULL,
	[User_Rol_Codigo] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[User_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[Venta_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Venta_Fecha] [date] NULL,
	[Venta_Total] [decimal](18, 0) NULL,
	[Venta_User_Codigo] [int] NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[Venta_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta_Detalle]    Script Date: 16/03/2023 12:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta_Detalle](
	[VentaD_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[VentaD_Venta_Codigo] [int] NULL,
	[VentaD_Peli_Codigo] [int] NULL,
	[VentaD_User_Codigo] [int] NULL,
 CONSTRAINT [PK_Venta_Detalle] PRIMARY KEY CLUSTERED 
(
	[VentaD_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

GO
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (1, 5, 1)
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (2, 6, 1)
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (3, 5, 2)
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (4, 7, 2)
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (5, 9, 2)
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (6, 5, 3)
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (7, 8, 3)
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (8, 10, 3)
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (9, 11, 3)
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (10, 5, 4)
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (12, 8, 4)
INSERT [dbo].[Compuesto] ([Comp_Codigo], [Comp_Perm_Codigo], [Comp_Padre_Codigo]) VALUES (13, 13, 1)
GO
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (1, N'Accion')
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (2, N'Aventura')
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (3, N'Ciencia Ficción')
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (4, N'Comedia')
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (5, N'Drama')
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (6, N'Fantasía')
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (7, N'Musical')
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (8, N'Suspenso')
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (9, N'Terror')
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (10, N'Policial')
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (11, N'Deportivas')
INSERT [dbo].[Genero] ([Gene_Codigo], [Gene_Nombre]) VALUES (12, N'Historica')
GO
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (1, N'Kit Administrador', 1)
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (2, N'Kit Vendedor', 1)
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (3, N'Kit Cliente', 1)
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (4, N'Kit Invitado', 1)
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (5, N'Cerrar Sesion', 0)
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (6, N'Agregar Vendedor', 0)
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (7, N'Agregar Producto', 0)
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (9, N'Ver mis Productos', 0)
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (10, N'Ver Carrito', 0)
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (11, N'Ver mis Compras', 0)
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (12, N'Registrarse', 0)
INSERT [dbo].[Permiso] ([Perm_Codigo], [Perm_Nombre], [Perm_EsPadre]) VALUES (13, N'Gestión Vendedor', 0)
GO
INSERT [dbo].[PermisoRol] ([PermRol_Codigo], [PermRol_Rol_Codigo], [PermRol_Perm_Codigo]) VALUES (1, 1, 1)
INSERT [dbo].[PermisoRol] ([PermRol_Codigo], [PermRol_Rol_Codigo], [PermRol_Perm_Codigo]) VALUES (2, 2, 2)
INSERT [dbo].[PermisoRol] ([PermRol_Codigo], [PermRol_Rol_Codigo], [PermRol_Perm_Codigo]) VALUES (3, 3, 3)
INSERT [dbo].[PermisoRol] ([PermRol_Codigo], [PermRol_Rol_Codigo], [PermRol_Perm_Codigo]) VALUES (4, 4, 4)
GO
INSERT [dbo].[Rol] ([Rol_Codigo], [Rol_Nombre]) VALUES (1, N'Administrador')
INSERT [dbo].[Rol] ([Rol_Codigo], [Rol_Nombre]) VALUES (2, N'Vendedor')
INSERT [dbo].[Rol] ([Rol_Codigo], [Rol_Nombre]) VALUES (3, N'Cliente')
INSERT [dbo].[Rol] ([Rol_Codigo], [Rol_Nombre]) VALUES (4, N'Invitado')
GO
INSERT [dbo].[TempPeli_ID] ([TPeli_ID]) VALUES (2)
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([User_Codigo], [User_Nombre], [User_Contraseña], [User_Nombre_Real], [User_Apellido], [User_DNI], [User_Rol_Codigo]) VALUES (1, N'admin', N'admin', N'admin', N'admin', N'12345678', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
GO
USE [master]
GO
ALTER DATABASE [Movie-Commerce] SET  READ_WRITE 
GO
