using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WallyBackend.core.DTOs;
using WallyBackend.core.Interfaces;
using WallyBackend.core.Services;

namespace WallyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServices _usuariosServices;

        public UsuariosController(IUsuariosServices usuariosServices)
        {
            _usuariosServices = usuariosServices;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UsuarioAuthRequestDTO usuarioDTO)
        {
            var result = await _usuariosServices.RegisterUsuario(usuarioDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UsuarioAuthenticationDTO usuarioDTO)
        {
            var result = await _usuariosServices.Validate(usuarioDTO.CorreoElectronico, usuarioDTO.Contraseña);
            if (result == null)
                return NotFound();

            return Ok(result);
        }


    }
}
