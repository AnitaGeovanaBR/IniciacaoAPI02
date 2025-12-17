using API.Commands;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBibliotecaRepository _bibliotecaRepository;

        public BibliotecaController(IBibliotecaRepository bibliotecaRepository)
        {
            _bibliotecaRepository = bibliotecaRepository;
        }

        [HttpGet]
        [Route("biblioteca")]
        public IActionResult RecuperarTodas()
        {
            var lista = _bibliotecaRepository.RecuperarTodas();
            return Ok(lista);
        }

        [HttpGet("biblioteca/{idBiblioteca}")]
        public IActionResult RecuperarBibliotecaPorId(Guid idBiblioteca)
        {
            var b = _bibliotecaRepository.RecuperarBibliotecaPorId(idBiblioteca);
            return b == null ? NotFound() : Ok(b);
        }

        [HttpPost]
        [Route("biblioteca")]
        public IActionResult CriarNova([FromBody] CriarBibliotecaCommand command)
        {
            try
            {
                var novaBiblioteca = _bibliotecaRepository.CriarNovaBiblioteca(command.Nome);
                return CreatedAtAction(nameof(RecuperarBibliotecaPorId), new { idBiblioteca = novaBiblioteca.IdBiblioteca }, novaBiblioteca);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("biblioteca/{idBiblioteca}")] 
        public IActionResult Atualizar(Guid idBiblioteca, [FromBody] CriarBibliotecaCommand command)
        {
            try
            {
                var atualizada = _bibliotecaRepository.AtualizarBiblioteca(idBiblioteca, command.Nome);
                if (atualizada == null) return NotFound();
                return Ok(atualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete]
        [Route("biblioteca/{idBiblioteca}")]
        public IActionResult DeletarBiblioteca(Guid idBiblioteca)
        {
            var deletada = _bibliotecaRepository.DeletarBiblioteca(idBiblioteca);
            if (deletada == null) return NotFound();
            return NoContent();
        }
    }
}