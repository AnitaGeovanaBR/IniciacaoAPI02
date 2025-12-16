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
        [Route("livro/{idLivro}")]
        [Produces("application/json")]
        public ActionResult<Livro> RecuperarLivroPorId(Guid idLivro)
        {
            var livro = _livroRepository.RecuperarLivroPorId(idLivro);

            if (livro == null)
                return NotFound();

            return Ok(livro);
        }

        [HttpPost]
        [Route("livro")]
        [Produces("application/json")]
        public Livro? CriarNovoLivro(
            string Nome,
            string Autor,
            string Edicao,
            string Editora,
            string ISBN,
            string? Descricao,
            DateTime DataPublicacao)
                {
                    Livro novo = new()
                    {
                        IdLivro = Guid.NewGuid(),
                        Nome = Nome,
                        Autor = Autor,
                        Edicao = Edicao,
                        Editora = Editora,
                        ISBN = ISBN,
                        Descricao = Descricao,
                        DataPublicacao = DataPublicacao
                    };

                    return novo;
                }


        [HttpPut]
        [Route("livro/{idLivro}")]
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


        [HttpDelete("livro/{idLivro}")]
        public IActionResult DeletarLivro(Guid idLivro)
        {
            var livro = _livroRepository.DeletarLivro(idLivro);

            if (livro == null)
                return NotFound();

            return NoContent();
        }
    }
}
