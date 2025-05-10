using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticaCampoFinal.Models;

public class Producto
{
    [Key] // Anotacion en C# equivalente al Primary Key en la base de datos
    public int Id_Producto { get; set; }

    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    [StringLength(50)] // Anotacion en C# equivalente al varchar(50) en la base de datos
    public string Name_Producto { get; set; }

    public string? Descripcion_Producto { get; set; }

    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    public int Cantidad_Producto { get; set; }

    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    [DataType(DataType.Currency)] // Anotacion en C# equivalente al decimal(10,2) en la base de datos
    public decimal Precio_Producto { get; set; }
}
