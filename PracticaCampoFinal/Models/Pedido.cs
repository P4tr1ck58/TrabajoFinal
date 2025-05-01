using System;
using System.Collections.Generic;

namespace PracticaCampoFinal.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int IdCliente { get; set; }

    public DateTime? FechaPedido { get; set; }

    public string? EstadoPedido { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Pedidosdetalle> Pedidosdetalles { get; set; } = new List<Pedidosdetalle>();
}
