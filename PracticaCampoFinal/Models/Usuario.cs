using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticaCampoFinal.Models;

//
public class Usuario
{
    [Key] // Anotacion en C# equivalente al Primary Key en la base de datos
    public int Id_Usuario { get; set; }

    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    [StringLength(50)] // Anotacion en C# equivalente al varchar(50) en la base de datos
    public string Name_Usuario { get; set; }
    [Required] // Anotacion en C# equivalente al Not Null en la base de datos
    [StringLength(12)] // Anotacion en C# equivalente al varchar(12) en la base de datos
    public string Contra_Usuario { get; set; }
}
