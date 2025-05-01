using System;
using System.Collections.Generic;

namespace PracticaCampoFinal.Models;

public class Producto
{
    public int Id_Producto { get; set; }

    public string Name_Producto { get; set; } = string.Empty;

    public string? Descripcion_Producto { get; set; }

    public int Cantidad_Producto { get; set; }

    public decimal Precio_Producto { get; set; }

    public ICollection<Pedidosdetalle>? Pedidosdetalles { get; set; }
}
