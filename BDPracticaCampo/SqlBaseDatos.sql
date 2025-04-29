Create Database ProyectCamp;
Use ProyectCamp;
DROP TABLE IF EXISTS PedidosDetalles, Pedidos, Productos, Clientes, Usuarios;
Create table Usuarios
(
Id_Usuario int primary key not null auto_increment,
Name_Usuario varchar (50) not null,
Contra_Usuario varchar (12) not null
);
Create table Clientes
(
Id_Cliente int primary key not null auto_increment,
Name_Cliente varchar (40) not null,
Ape_Cliente varchar (50) null,
Telefono_Cliente varchar (15) not null,
Email_Cliente varchar (50) null
);
Create table Productos
(
Id_Producto int primary key not null auto_increment,
Name_Producto varchar (50) not null,
Descripcion_Producto  longtext null,
Cantidad_Producto int not null,
Precio_Producto decimal(10,2) not null
);
Create table Pedidos
(
Id_Pedido int primary key not null auto_increment,
Id_Cliente int not null,
Fecha_Pedido datetime default current_timestamp,
Estado_Pedido varchar (20),
foreign key (Id_Cliente) references Clientes (Id_Cliente)
);
Create table PedidosDetalles
(
Id_PedidoDetalle int primary key not null auto_increment,
Id_Pedido int not null,
Id_Producto int not null,
cantidad_PedidoDetalle int not null,
PrecioUnit_Pedido decimal(10,2) not null,
foreign key (Id_Pedido) references Pedidos (Id_Pedido),
foreign key (Id_Producto) references Productos (Id_Producto)
)