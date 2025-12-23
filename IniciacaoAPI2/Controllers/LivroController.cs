using API.Commands;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LivroController : ControllerBase
    {
        private ILivroRepository _livroRepository;
        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        [HttpPost]
        [Route("livro")]
        [Produces("application/json")]
        public Livro? CriarNovo([FromBody] CriarLivroCommand novoLivro)
        {
            try
            {
                return _livroRepository.CriarNovoLivro(
                    novoLivro.Nome, 
                    novoLivro.Autor, 
                    novoLivro.Edicao, 
                    novoLivro.Editora, 
                    novoLivro.ISBN, 
                    novoLivro.Descricao, 
                    novoLivro.DataPublicacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        [Route("livro/{idLivro}")]
        [Produces("application/json")]
        public Livro? RecuperarLivroPorId(Guid idLivro)
        {
            try
            {
                return _livroRepository.RecuperarLivroPorId(idLivro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        [HttpGet]
        [Route("livro/todos")]
        [Produces("application/json")]
        public IEnumerable<Livro>? RecuperarTodos()
        {
            try
            {
                return _livroRepository.RecuperarTodosLivros();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        [Route("livro/{idLivro}")]
        [Produces("application/json")]
        public Livro? AtualizarLivro([FromBody] CriarLivroCommand update, Guid idLivro )
        {
            try
            {
                return _livroRepository.AtualizarLivro(
                    idLivro, 
                    update.Nome, 
                    update.Autor, 
                    update.Edicao, 
                    update.Editora, 
                    update.ISBN, 
                    update.Descricao, 
                    update.DataPublicacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpDelete]
        [Route("livro/{idLivro}")]
        [Produces("application/json")]
        public Livro? ExcluirLivro(Guid idLivro)
        {
            try
            {
                return _livroRepository.ExcluirLivro(idLivro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}