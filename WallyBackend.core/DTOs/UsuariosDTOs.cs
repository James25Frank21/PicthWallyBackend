using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallyBackend.core.DTOs
{
    public class UsuariosDTOs 
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Sexo { get; set; }

        public int? Telefono { get; set; }


        public decimal? Reputacion { get; set; }


        public string? Direccion { get; set; }

        public decimal? Latitud { get; set; }

        public decimal? Longitud { get; set; }

        public bool? IsActive { get; set; }

        public string? FotoPerfil { get; set; }
    }

    
    public class UsuarioAuthResponseDTO //para el login de usuario
    {
        public int UsuarioId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? CorreoElectronico { get; set; }

        public string? Token { get; set; }

    }
    //para el registro de usuario
    public class UsuarioAuthRequestDTO 
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Sexo { get; set; }

        public int? Telefono { get; set; }

        public string? CorreoElectronico { get; set; }

        public string? Contraseña { get; set; }

        public string? Direccion { get; set; }

        public decimal? Latitud { get; set; }

        public decimal? Longitud { get; set; }

        public bool? IsActive { get; set; }

    }
    //para la actualizacion de datos
    public class UsuarioUpdateRequestDTO
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public int? Telefono { get; set; }

        public string? Direccion { get; set; }

        public decimal? Latitud { get; set; }

        public decimal? Longitud { get; set; }

        public bool? IsActive { get; set; }

        public string? FotoPerfil { get; set; }
    }
    //para la autenticacion y la recuperacion de contraseña
    public class UsuarioAuthenticationDTO 
    {
        public string? CorreoElectronico { get; set; }

        public string? Contraseña { get; set; }
    }

   

    //para la reputacion
    public class UsuarioReputacionDTO
    {
        public int UsuarioId { get; set; }
        public decimal? Reputacion { get; set; }
    }

   

}
