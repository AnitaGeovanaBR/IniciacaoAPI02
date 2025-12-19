using API.Commands;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

[Route("api/livro")]
[ApiController]
public class LivroController : ControllerBase
{
    private ILivroRepository _livroRepository;

    public LivroController(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Livro>> RecuperarTodos()
    {
        var livros = _livroRepository.RecuperarTodos();
        return Ok(livros);
    }

    [HttpGet("{idLivro}")]
    public ActionResult<Livro> RecuperarLivroPorId(Guid idLivro)
    {
        var livro = _livroRepository.RecuperarLivroPorId(idLivro);
        return livro == null ? NotFound() : Ok(livro);
    }

    [HttpPost]
    public ActionResult<Livro> CriarNovoLivro([FromBody] CriarLivroCommand livro)
    {
        var novo = _livroRepository.CriarNovoLivro(
            livro.Nome, livro.Autor, livro.Edicao, livro.Editora,
            livro.ISBN, livro.Descricao, livro.DataPublicacao
        );

        return CreatedAtAction(nameof(RecuperarLivroPorId), new { idLivro = novo.IdLivro }, novo);
    }

    [HttpPut("{idLivro}")]
    public IActionResult AtualizarLivro([FromBody] CriarLivroCommand livro, Guid idLivro)
    {
        var atualizado = _livroRepository.AtualizarLivro(
            idLivro, livro.Nome, livro.Autor, livro.Edicao,
            livro.Editora, livro.ISBN, livro.Descricao, livro.DataPublicacao
        );

        return atualizado == null ? NotFound() : Ok(atualizado);
    }

    [HttpDelete("{idLivro}")]
    public IActionResult DeletarLivro(Guid idLivro)
    {
        var livro = _livroRepository.DeletarLivro(idLivro);
        return livro == null ? NotFound() : NoContent();
    }
}