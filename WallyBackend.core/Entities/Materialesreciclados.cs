using System;
using System.Collections.Generic;

namespace WallyBackend.Infrastructure.Data;

public partial class Materialesreciclados
{
    public int MaterialId { get; set; }

    public int? UsuarioId { get; set; }

    public string? NombreMaterial { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public string? Estado { get; set; }

    public decimal? Latitud { get; set; }

    public decimal? Longitud { get; set; }

    public string? FotoMaterial { get; set; }

    public ulong? IsActive { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
