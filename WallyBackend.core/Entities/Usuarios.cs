using System;
using System.Collections.Generic;

namespace WallyBackend.Infrastructure.Data;

public partial class Usuarios
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Sexo { get; set; }

    public int? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contraseña { get; set; }

    public decimal? Reputacion { get; set; }

    public string? Direccion { get; set; }

    public decimal? Latitud { get; set; }

    public decimal? Longitud { get; set; }

    public bool? IsActive { get; set; }

    public string? FotoPerfil { get; set; }

    public virtual ICollection<Historialchat> HistorialchatUsuarioEnviador { get; set; } = new List<Historialchat>();

    public virtual ICollection<Historialchat> HistorialchatUsuarioReceptor { get; set; } = new List<Historialchat>();

    public virtual ICollection<Materialesreciclados> Materialesreciclados { get; set; } = new List<Materialesreciclados>();
}
