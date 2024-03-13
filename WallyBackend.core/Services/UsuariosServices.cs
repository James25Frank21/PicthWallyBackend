using WallyBackend.core.DTOs;
using WallyBackend.core.Interfaces;
using WallyBackend.Infrastructure.Data;

namespace WallyBackend.core.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IJWTFactory _jwtFactory;
        public UsuariosServices(IUsuariosRepository usuariosRepository, IJWTFactory jWTFactory)
        {
            _usuariosRepository = usuariosRepository;
            _jwtFactory = jWTFactory;
        }
        // para validar el usuario

       
        public async Task<UsuarioAuthResponseDTO> Validate(string email, string contrasena)
        {
            var usuario = await _usuariosRepository.SignIn(email, contrasena);
            if (usuario == null)
            {
                return null;
            }
        var token = _jwtFactory.GenerateJWToken(usuario);
            var UsuariosDTO = new UsuarioAuthResponseDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                CorreoElectronico = usuario.CorreoElectronico,
                Token = token
            };
            return UsuariosDTO;


                

        }
        //para registrar el usuario
        public async Task<int> RegisterUsuario(UsuarioAuthRequestDTO usuario)
        {
            //validar si el correo ya existe
            var usuarioExist = await _usuariosRepository.IsEmailRegistered(usuario.CorreoElectronico);
            if (usuarioExist)
                return 0;
            //registrar el usuario
            var usuarios = new Usuarios()
            {
                Nombre = usuario.Nombre,

                Apellido = usuario.Apellido,

                Sexo = usuario.Sexo,

                Telefono = usuario.Telefono,

                CorreoElectronico = usuario.CorreoElectronico,

                Contraseña = usuario.Contraseña,

                Direccion = usuario.Direccion,

                Latitud = usuario.Latitud,

                Longitud = usuario.Longitud,

                IsActive = true,
            };
            var resultID = await _usuariosRepository.Insert(usuarios);
            return resultID;
        }
        //para actualizar el usuario
        public async Task<bool> UpdateUsuario(UsuarioUpdateRequestDTO usuario)
        {
            var usuarios = new Usuarios()
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Telefono = usuario.Telefono,
                Direccion = usuario.Direccion,
                Latitud = usuario.Latitud,
                Longitud = usuario.Longitud,
                IsActive = true,
                FotoPerfil = usuario.FotoPerfil
            };
            var result = await _usuariosRepository.Update(usuarios);
            return result;
        }

        //para obtener el usuario por id
        public async Task<Usuarios> GetUsuarioID(int id)
        {
            var result = await _usuariosRepository.GetUsuarioID(id);
            return result;
        }

        //para la reputacion del usuario
        public async Task<bool> UpdateReputacionUsuario(int id, int reputacion)
        {
            var usuario = await _usuariosRepository.GetUsuarioID(id);
            usuario.Reputacion = reputacion;
            var result = await _usuariosRepository.Update(usuario);
            return result;
        }
        //para el cambio de email y contraseña
        public async Task<bool> UpdateEmailPassword(UsuarioAuthenticationDTO usuario)
        {
            var usuarios = new Usuarios()
            {
                CorreoElectronico = usuario.CorreoElectronico,
                Contraseña = usuario.Contraseña
            };
            var result = await _usuariosRepository.Update(usuarios);
            return result;
        }
        //para obtener todos los usuarios con reputacion del UsuariosDTO
        public async Task<IEnumerable<UsuariosDTOs>> GetAll()
        {
            var result = await _usuariosRepository.GetAll();
            var usuariosDTO = result.Select(x => new UsuariosDTOs
            {
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Sexo = x.Sexo,
                Telefono = x.Telefono,
                Reputacion = x.Reputacion,
                Direccion = x.Direccion,
                Latitud = x.Latitud,
                Longitud = x.Longitud,
                IsActive = true,
                FotoPerfil = x.FotoPerfil
            });
            return usuariosDTO;
        }


    }
}





        
    

