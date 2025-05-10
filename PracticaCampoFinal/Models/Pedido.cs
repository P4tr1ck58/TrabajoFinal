using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaCampoFinal.Models;

public class Pedido
{
    [Key] // Anotacion en C# equivalente al Primary Key en la base de datos
    public int Id_Pedido { get; set; }

    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    [ForeignKey("Cliente")] // Anotacion en C# equivalente al Foreign Key en la base de datos que enlaza la tabla Pedido con la tabla Cliente
    public int Id_Cliente { get; set; }

    public Cliente Cliente { get; set; } //nos pemite navegar en Cliente

    public DateTime Fecha_Pedido { get; set; } = DateTime.Now;

    [StringLength(20)] // Anotacion en C# equivalente al varchar(50) en la base de datos
    public string? Estado_Pedido { get; set; }

    

    public ICollection<Pedidosdetalle>? Pedidosdetalles { get; set; }
}
