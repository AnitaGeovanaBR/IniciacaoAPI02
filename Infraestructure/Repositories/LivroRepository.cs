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

        public IEnumerable<Livro> RecuperarTodos()
        {
            return _context.Livros.ToList();
        }

        public Livro? RecuperarLivroPorId(Guid idLivro)
        {
            return _context.Livros
                .FirstOrDefault(l => l.IdLivro == idLivro);
        }

        public Livro? CriarNovoLivro(
            string nome,
            string autor,
            string edicao,
            string editora,
            string isbn,
            string? descricao,
            DateTime dataPublicacao)
        {
            Livro novo = new()
            {
                IdLivro = Guid.NewGuid(),
                Nome = nome,
                Autor = autor,
                Edicao = edicao,
                Editora = editora,
                ISBN = isbn,
                Descricao = descricao,
                DataPublicacao = dataPublicacao
            };

            _context.Livros.Add(novo);
            _context.SaveChanges();

            return novo;
        }

        public Livro? AtualizarLivro(
            Guid idLivro,
            string nome,
            string autor,
            string edicao,
            string editora,
            string isbn,
            string? descricao,
            DateTime dataPublicacao)
        {
            Livro? livro = RecuperarLivroPorId(idLivro);

            if (livro != null)
            {
                livro.Nome = nome;
                livro.Autor = autor;
                livro.Edicao = edicao;
                livro.Editora = editora;
                livro.ISBN = isbn;
                livro.Descricao = descricao;
                livro.DataPublicacao = dataPublicacao;

                _context.SaveChanges();
                return livro;
            }

            return null;
        }

        public Livro? DeletarLivro(Guid idLivro)
        {
            var livro = _context.Livros
                .FirstOrDefault(l => l.IdLivro == idLivro);

            if (livro == null)
                return null;

            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return livro;
        }
    }
}
