using System;
using System.Collections.Generic;

namespace PracticaCampoFinal.Models;

public class Cliente
{
    public int Id_Cliente { get; set; }

    public string Name_Cliente { get; set; } = string.Empty;

    public string? Ape_Cliente { get; set; }

    public string Telefono_Cliente { get; set; } = string.Empty;

    public string? Email_Cliente { get; set; }

}
