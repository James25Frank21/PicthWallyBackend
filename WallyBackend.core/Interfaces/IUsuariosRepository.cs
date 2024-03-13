using WallyBackend.Infrastructure.Data;

namespace WallyBackend.core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<Usuarios>> GetAll();
        Task<Usuarios> GetUsuarioID(int id);
        Task<int> Insert(Usuarios usuario);
        Task<bool> IsEmailRegistered(string email);
        Task<Usuarios> SignIn(string correo, string contrasena);
        Task<bool> SignUp(Usuarios usuario);
        Task<bool> Update(Usuarios usuario);
    }
}