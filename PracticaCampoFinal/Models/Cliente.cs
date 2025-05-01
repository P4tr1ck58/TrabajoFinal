using System;
using System.Collections.Generic;

namespace PracticaCampoFinal.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NameCliente { get; set; } = null!;

    public string? ApeCliente { get; set; }

    public string TelefonoCliente { get; set; } = null!;

    public string? EmailCliente { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
