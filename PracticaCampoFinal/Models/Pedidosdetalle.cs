using System;
using System.Collections.Generic;

namespace PracticaCampoFinal.Models;

public class Pedidosdetalle
{
    public int Id_PedidoDetalle { get; set; }

    public int Id_Pedido { get; set; }

    public int Id_Producto { get; set; }

    public int Cantidad_PedidoDetalle { get; set; }

    public decimal PrecioUnit_Pedido { get; set; }

    public Pedido? Pedido { get; set; }

    public Producto? Producto { get; set; }
}
