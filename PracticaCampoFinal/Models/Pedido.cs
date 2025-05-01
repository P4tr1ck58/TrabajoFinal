using System;
using System.Collections.Generic;

namespace PracticaCampoFinal.Models;

public class Pedido
{
    public int Id_Pedido { get; set; }

    public int Id_Cliente { get; set; }

    public DateTime Fecha_Pedido { get; set; } = DateTime.Now;

    public string? Estado_Pedido { get; set; }

    public Cliente? Cliente { get; set; }

    public ICollection<Pedidosdetalle>? Pedidosdetalles { get; set; }
}
