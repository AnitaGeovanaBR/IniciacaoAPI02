using Domain.Entities;
using Domain.Repositories;
using Infraestructure.Data;

namespace Infraestructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private ApplicationDbContext _context;
        public LivroRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Livro? CriarNovoLivro(string NomeLivro, string Autor, string Edicao, string Editora, string ISBN, string? Descricao, DateTime DataPublicacao)
        {
            Livro novo = new()
            {
                Nome = NomeLivro,
                Autor = Autor,
                Edicao = Edicao,
                Editora = Editora,
                ISBN = ISBN,
                Descricao = Descricao,
                DataPublicacao = DataPublicacao,
                IdLivro = Guid.NewGuid()
            };

            _context.Livros.Add(novo);

            _context.SaveChanges();

            return novo;
        }
        public Livro? RecuperarLivroPorId(Guid IdLivro)
        {
            return _context.Livros.Where(x => x.IdLivro == IdLivro).FirstOrDefault();
        }
        public IEnumerable<Livro> RecuperarTodosLivros()
        {
            return _context.Livros.ToList(); 
        }
        public Livro? AtualizarLivro(Guid IdLivro, string Nome, string Autor, string Edicao, string Editora, string ISBN, string? Descricao, DateTime DataPublicacao)
        {
            Livro? atualizacao = RecuperarLivroPorId(IdLivro);

            if(atualizacao != null)
            {
                atualizacao.Nome = Nome;
                atualizacao.Autor = Autor;
                atualizacao.Edicao = Edicao;
                atualizacao.Editora = Editora;
                atualizacao.ISBN = ISBN;
                atualizacao.Descricao = Descricao;
                atualizacao.DataPublicacao = DataPublicacao;
                _context.SaveChanges();

                return atualizacao;
            }
            return null;
        }
        public Livro? ExcluirLivro(Guid IdLivro)
        {
            Livro? livro = RecuperarLivroPorId(IdLivro);

            if(livro != null)
            {
                _context.Livros.Remove(livro);
                _context.SaveChanges();
                return livro;
            }
            return null;
        }
    }
}