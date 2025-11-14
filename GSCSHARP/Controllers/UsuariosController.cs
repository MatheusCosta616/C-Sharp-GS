using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GSCSHARP.Data;
using GSCSHARP.DTOs;
using GSCSHARP.Models;

namespace GSCSHARP.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<object>>> GetAll()
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Matriculas)
                    .ThenInclude(m => m.Trilha)
                .Select(u => new
                {
                    u.Id,
                    u.Nome,
                    u.Email,
                    u.AreaAtuacao,
                    u.NivelCarreira,
                    u.DataCadastro,
                    TotalMatriculas = u.Matriculas.Count,
                    Matriculas = u.Matriculas.Select(m => new
                    {
                        m.Id,
                        TrilhaNome = m.Trilha.Nome,
                        m.DataInscricao,
                        m.Status
                    })
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<object>> GetById(long id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Matriculas)
                    .ThenInclude(m => m.Trilha)
                .Where(u => u.Id == id)
                .Select(u => new
                {
                    u.Id,
                    u.Nome,
                    u.Email,
                    u.AreaAtuacao,
                    u.NivelCarreira,
                    u.DataCadastro,
                    TotalMatriculas = u.Matriculas.Count,
                    Matriculas = u.Matriculas.Select(m => new
                    {
                        m.Id,
                        TrilhaNome = m.Trilha.Nome,
                        TrilhaNivel = m.Trilha.Nivel,
                        TrilhaCargaHoraria = m.Trilha.CargaHoraria,
                        m.DataInscricao,
                        m.Status
                    })
                })
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            return Ok(usuario);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<UsuarioResponseDto>> Create([FromBody] UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
            {
                return UnprocessableEntity(new { message = "Email já cadastrado" });
            }

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                AreaAtuacao = dto.AreaAtuacao,
                NivelCarreira = dto.NivelCarreira,
                DataCadastro = DateTime.UtcNow
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var usuarioResponse = new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                AreaAtuacao = usuario.AreaAtuacao,
                NivelCarreira = usuario.NivelCarreira,
                DataCadastro = usuario.DataCadastro
            };

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuarioResponse);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<UsuarioResponseDto>> Update(long id, [FromBody] UsuarioUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            if (dto.Email != null && dto.Email != usuario.Email)
            {
                if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email && u.Id != id))
                {
                    return UnprocessableEntity(new { message = "Email já cadastrado" });
                }
            }

            if (dto.Nome != null) usuario.Nome = dto.Nome;
            if (dto.Email != null) usuario.Email = dto.Email;
            if (dto.AreaAtuacao != null) usuario.AreaAtuacao = dto.AreaAtuacao;
            if (dto.NivelCarreira != null) usuario.NivelCarreira = dto.NivelCarreira;

            await _context.SaveChangesAsync();

            var usuarioResponse = new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                AreaAtuacao = usuario.AreaAtuacao,
                NivelCarreira = usuario.NivelCarreira,
                DataCadastro = usuario.DataCadastro
            };

            return Ok(usuarioResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
