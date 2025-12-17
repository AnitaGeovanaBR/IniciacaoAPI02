using API.Commands;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class LivroController : ControllerBase
    {
        private ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        [Route("RecuperarLivro/{idLivro}")]
        [Produces("application/json")]
        public ActionResult<Livro> RecuperarLivroPorId(Guid idLivro)
        {
            var livro = _livroRepository.RecuperarLivroPorId(idLivro);

            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        [HttpPost]
        [Route("CriarLivro")]
        [Produces("application/json")]
        public ActionResult<Livro> CriarNovoLivro([FromBody] CriarLivroCommand livro)
        {
            var novo = _livroRepository.CriarNovoLivro(
                livro.Nome,
                livro.Autor,
                livro.Edicao,
                livro.Editora,
                livro.ISBN,
                livro.Descricao,
                livro.DataPublicacao
            );

            return CreatedAtAction(
                nameof(RecuperarLivroPorId),
                new { idLivro = novo.IdLivro },
                novo
            );
        }


        [HttpPut]
        [Route("AttLivro/{idLivro}")]
        [Produces("application/json")]
        public IActionResult AtualizarLivro(
     [FromBody] CriarLivroCommand livro,
     Guid idLivro)
        {
            try
            {
                var atualizado = _livroRepository.AtualizarLivro(
                    idLivro,
                    livro.Nome,
                    livro.Autor,
                    livro.Edicao,
                    livro.Editora,
                    livro.ISBN,
                    livro.Descricao,
                    livro.DataPublicacao
                );

                if (atualizado == null)
                    return NotFound();

                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("DelLivro/{idLivro}")]
        public IActionResult DeletarLivro(Guid idLivro)
        {
            var livro = _livroRepository.DeletarLivro(idLivro);

            if (livro == null)
                return NotFound();

            return NoContent();
        }
    }
}
