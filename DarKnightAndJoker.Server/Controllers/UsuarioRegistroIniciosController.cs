using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DarKnightAndJoker.Server.Data;
using DarKnightAndJoker.Server.Models;

namespace DarKnightAndJoker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRegistroIniciosController : ControllerBase
    {
        private readonly DarKnightDbContext _context;

        public UsuarioRegistroIniciosController(DarKnightDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioRegistroInicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRegistroInicio>>> GetUsuariosRegistrosInicios()
        {
            return await _context.UsuariosRegistrosInicios.ToListAsync();
        }

        // GET: api/UsuarioRegistroInicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRegistroInicio>> GetUsuarioRegistroInicio(int id)
        {
            var usuarioRegistroInicio = await _context.UsuariosRegistrosInicios.FindAsync(id);

            if (usuarioRegistroInicio == null)
            {
                return NotFound();
            }

            return usuarioRegistroInicio;
        }

        // PUT: api/UsuarioRegistroInicios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioRegistroInicio(int id, UsuarioRegistroInicio usuarioRegistroInicio)
        {
            if (id != usuarioRegistroInicio.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioRegistroInicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioRegistroInicioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UsuarioRegistroInicios
        [HttpPost]
        public async Task<ActionResult<UsuarioRegistroInicio>> PostUsuarioRegistroInicio(UsuarioRegistroInicio usuarioRegistroInicio)
        {
            // Aquí puedes verificar si el usuario ya existe antes de agregarlo
            var existeUsuario = await _context.UsuariosRegistrosInicios
                .AnyAsync(u => u.emailDark == usuarioRegistroInicio.emailDark);

            if (existeUsuario)
            {
                return Conflict("El usuario ya existe.");
            }

            _context.UsuariosRegistrosInicios.Add(usuarioRegistroInicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioRegistroInicio", new { id = usuarioRegistroInicio.Id }, usuarioRegistroInicio);
        }

        // POST: api/UsuarioRegistroInicios/iniciarSesion
        [HttpPost("iniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginRequest loginRequest)
        {
            var usuario = await _context.UsuariosRegistrosInicios
                .FirstOrDefaultAsync(u => u.emailDark == loginRequest.emailDark);

            if (usuario == null || usuario.passworDark != loginRequest.passworDark)
            {
                return Unauthorized(); // Usuario no encontrado o credenciales incorrectas
            }

            // Retornar información del usuario (o un token) según sea necesario
            return Ok(usuario); // Retorna el usuario o un token, según sea necesario
        }

        // DELETE: api/UsuarioRegistroInicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioRegistroInicio(int id)
        {
            var usuarioRegistroInicio = await _context.UsuariosRegistrosInicios.FindAsync(id);
            if (usuarioRegistroInicio == null)
            {
                return NotFound();
            }

            _context.UsuariosRegistrosInicios.Remove(usuarioRegistroInicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioRegistroInicioExists(int id)
        {
            return _context.UsuariosRegistrosInicios.Any(e => e.Id == id);
        }

        // Clase para recibir datos de inicio de sesión
        public class LoginRequest
        {
            public string emailDark { get; set; }
            public string passworDark { get; set; }
        }
    }
}
