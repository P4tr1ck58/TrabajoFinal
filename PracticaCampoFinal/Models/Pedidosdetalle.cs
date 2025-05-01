using System;
using System.Collections.Generic;

namespace PracticaCampoFinal.Models;

public partial class Pedidosdetalle
{
    public int IdPedidoDetalle { get; set; }

    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public int CantidadPedidoDetalle { get; set; }

    public decimal PrecioUnitPedido { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
