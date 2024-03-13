using WallyBackend.core.DTOs;
using WallyBackend.Infrastructure.Data;

namespace WallyBackend.core.Interfaces
{
    public interface IUsuariosServices
    {
        Task<IEnumerable<UsuariosDTOs>> GetAll();
        Task<Usuarios> GetUsuarioID(int id);
        Task<int> RegisterUsuario(UsuarioAuthRequestDTO usuario);
        Task<bool> UpdateEmailPassword(UsuarioAuthenticationDTO usuario);
        Task<bool> UpdateReputacionUsuario(int id, int reputacion);
        Task<bool> UpdateUsuario(UsuarioUpdateRequestDTO usuario);
        Task<UsuarioAuthResponseDTO> Validate(string email, string contrasena);
    }
}