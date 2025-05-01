using System;
using System.Collections.Generic;

namespace PracticaCampoFinal.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NameUsuario { get; set; } = null!;

    public string ContraUsuario { get; set; } = null!;
}
