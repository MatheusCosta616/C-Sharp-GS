using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GSCSHARP.Data;
using GSCSHARP.DTOs;
using GSCSHARP.Models;

namespace GSCSHARP.Controllers.V2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    [ApiVersion("2.0")]
    public class TrilhasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TrilhasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<object>>> GetAll()
        {
            var trilhas = await _context.Trilhas
                .Include(t => t.TrilhaCompetencias)
                    .ThenInclude(tc => tc.Competencia)
                .Select(t => new
                {
                    t.Id,
                    t.Nome,
                    t.Descricao,
                    t.Nivel,
                    t.CargaHoraria,
                    t.FocoPrincipal,
                    Competencias = t.TrilhaCompetencias.Select(tc => new
                    {
                        tc.Competencia.Id,
                        tc.Competencia.Nome,
                        tc.Competencia.Categoria
                    })
                })
                .ToListAsync();

            return Ok(trilhas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<object>> GetById(long id)
        {
            var trilha = await _context.Trilhas
                .Include(t => t.TrilhaCompetencias)
                    .ThenInclude(tc => tc.Competencia)
                .Where(t => t.Id == id)
                .Select(t => new
                {
                    t.Id,
                    t.Nome,
                    t.Descricao,
                    t.Nivel,
                    t.CargaHoraria,
                    t.FocoPrincipal,
                    Competencias = t.TrilhaCompetencias.Select(tc => new
                    {
                        tc.Competencia.Id,
                        tc.Competencia.Nome,
                        tc.Competencia.Categoria,
                        tc.Competencia.Descricao
                    }),
                    TotalMatriculas = t.Matriculas.Count
                })
                .FirstOrDefaultAsync();

            if (trilha == null)
            {
                return NotFound(new { message = "Trilha não encontrada" });
            }

            return Ok(trilha);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TrilhaResponseDto>> Create([FromBody] TrilhaCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trilha = new Trilha
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Nivel = dto.Nivel,
                CargaHoraria = dto.CargaHoraria,
                FocoPrincipal = dto.FocoPrincipal
            };

            _context.Trilhas.Add(trilha);
            await _context.SaveChangesAsync();

            var trilhaResponse = new TrilhaResponseDto
            {
                Id = trilha.Id,
                Nome = trilha.Nome,
                Descricao = trilha.Descricao,
                Nivel = trilha.Nivel,
                CargaHoraria = trilha.CargaHoraria,
                FocoPrincipal = trilha.FocoPrincipal
            };

            return CreatedAtAction(nameof(GetById), new { id = trilha.Id }, trilhaResponse);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TrilhaResponseDto>> Update(long id, [FromBody] TrilhaUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trilha = await _context.Trilhas.FindAsync(id);
            if (trilha == null)
            {
                return NotFound(new { message = "Trilha não encontrada" });
            }

            if (dto.Nome != null) trilha.Nome = dto.Nome;
            if (dto.Descricao != null) trilha.Descricao = dto.Descricao;
            if (dto.Nivel != null) trilha.Nivel = dto.Nivel;
            if (dto.CargaHoraria.HasValue) trilha.CargaHoraria = dto.CargaHoraria.Value;
            if (dto.FocoPrincipal != null) trilha.FocoPrincipal = dto.FocoPrincipal;

            await _context.SaveChangesAsync();

            var trilhaResponse = new TrilhaResponseDto
            {
                Id = trilha.Id,
                Nome = trilha.Nome,
                Descricao = trilha.Descricao,
                Nivel = trilha.Nivel,
                CargaHoraria = trilha.CargaHoraria,
                FocoPrincipal = trilha.FocoPrincipal
            };

            return Ok(trilhaResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(long id)
        {
            var trilha = await _context.Trilhas.FindAsync(id);
            if (trilha == null)
            {
                return NotFound(new { message = "Trilha não encontrada" });
            }

            _context.Trilhas.Remove(trilha);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
