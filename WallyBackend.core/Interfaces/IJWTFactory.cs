using WallyBackend.Infrastructure.Data;

namespace WallyBackend.core.Interfaces
{
    public interface IJWTFactory
    {
        string GenerateJWToken(Usuarios user);
    }
}