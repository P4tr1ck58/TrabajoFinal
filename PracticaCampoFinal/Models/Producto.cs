using System;
using System.Collections.Generic;

namespace PracticaCampoFinal.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string NameProducto { get; set; } = null!;

    public string? DescripcionProducto { get; set; }

    public int CantidadProducto { get; set; }

    public decimal PrecioProducto { get; set; }

    public virtual ICollection<Pedidosdetalle> Pedidosdetalles { get; set; } = new List<Pedidosdetalle>();
}
