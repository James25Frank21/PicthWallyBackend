using System;
using System.Collections.Generic;

namespace WallyBackend.Infrastructure.Data;

public partial class Historialchat
{
    public int ChatId { get; set; }

    public int? UsuarioEnviadorId { get; set; }

    public int? UsuarioReceptorId { get; set; }

    public string? Mensaje { get; set; }

    public DateTime? FechaHora { get; set; }

    public ulong? IsActive { get; set; }

    public virtual Usuarios? UsuarioEnviador { get; set; }

    public virtual Usuarios? UsuarioReceptor { get; set; }
}
