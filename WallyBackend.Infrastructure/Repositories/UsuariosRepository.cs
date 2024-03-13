using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WallyBackend.core.Interfaces;
using WallyBackend.Infrastructure.Data;

namespace WallyBackend.Infrastructure.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly WallyprojectContext _context;

        public UsuariosRepository(WallyprojectContext context)
        {
            _context = context;
        }

        public async Task<Usuarios> SignIn(string correo, string contrasena)
        {
            var result = await _context.Usuarios.Where(x => x.CorreoElectronico == correo && x.Contraseña == contrasena)
                .FirstOrDefaultAsync();
            return result;

           
        }
        public async Task<bool> SignUp(Usuarios usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Usuarios>> GetAll()
        {
            var result = await _context.Usuarios.Where(x => x.IsActive == true)
                .ToListAsync();
            return result;
        }

        public async Task<Usuarios> GetUsuarioID(int id)
        {
            var result = await _context.Usuarios.Where(x => x.UsuarioId == id && x.IsActive == true)
                .FirstOrDefaultAsync();
            return result;
        }

        //para recibor el id del usuario
        public async Task<int> Insert(Usuarios usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0 ? usuario.UsuarioId : 0;
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            var result = await _context.Usuarios.Where(x => x.CorreoElectronico == email).AnyAsync();
            return result;
        }


    }
}
