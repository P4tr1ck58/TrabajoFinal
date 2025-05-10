Create Database ProyectCamp;
Use ProyectCamp;
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
Telefono_Cliente integer (9) not null,
Email_Cliente varchar (50) null
);
Create table Productos
(
Id_Producto int primary key not null auto_increment,
Name_Producto varchar (50) not null,
Descripcion_Producto  longtext not null,
Cantidad_Producto int not null,
Precio_Producto float not null
);
Create table Pedidos
(
Id_Pedido int primary key not null auto_increment,
Cantidad_Pedido int not null,
Precio_Pedido float not null
)