using System;
using System.Collections.Generic;

namespace DL;

public partial class Historial
{
    public int IdHistorial { get; set; }

    public int? Digito { get; set; }

    public int? SuperDigito { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
