using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaCampoFinal.Models;

public class Pedidosdetalle
{
    [Key] // Anotacion en C# equivalente al Primary Key en la base de datos
    public int Id_PedidoDetalle { get; set; }

    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    [ForeignKey("Pedido")] // Anotacion en C# equivalente al Foreign Key en la base de datos que enlaza la tabla Pedidosdetalle con la tabla Pedido
    public int Id_Pedido { get; set; }

    public Pedido Pedido { get; set; } //nos pemite navegar en Pedido

    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    [ForeignKey("Producto")] // Anotacion en C# equivalente al Foreign Key en la base de datos que enlaza la tabla Pedidosdetalle con la tabla Producto
    public int Id_Producto { get; set; }

    public Producto Producto { get; set; }  //nos pemite navegar en Producto

    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    public int Cantidad_PedidoDetalle { get; set; }

    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    [DataType(DataType.Currency)] // Anotacion en C# equivalente al decimal(10,2) en la base de datos
    public decimal PrecioUnit_Pedido { get; set; }


    
}
