using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticaCampoFinal.Models;

public class Cliente
{
    [Key] // Anotacion en C# equivalente al Primary Key en la base de datos
    public int Id_Cliente { get; set; }

    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    [StringLength(50)] // Anotacion en C# equivalente al varchar(50) en la base de datos
    public string Name_Cliente { get; set; }

    [StringLength(50)] // Anotacion en C# equivalente al varchar(50) en la base de datos
    public string? Ape_Cliente { get; set; }

    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    [StringLength(50)] // Anotacion en C# equivalente al varchar(50) en la base de datos
    public string Telefono_Cliente { get; set; }

    [StringLength(50)] // Anotacion en C# equivalente al varchar(50) en la base de datos
    public string? Email_Cliente { get; set; }

}
