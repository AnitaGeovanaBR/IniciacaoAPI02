using Domain.Entities;

namespace Domain.Repositories
{
    public interface ILivroRepository
    {
        public Livro? CriarNovoLivro(string NomeLivro, string Autor, string Edicao, string Editora, string ISBN, string? Descricao, DateTime DataPublicacao); 
        public Livro? RecuperarLivroPorId(Guid IdLivro);      
        public IEnumerable<Livro> RecuperarTodosLivros();
        public Livro? AtualizarLivro(Guid IdLivro, string NomeLivro, string Autor, string Edicao, string Editora, string ISBN, string? Descricao, DateTime DataPublicacao);
        public Livro? ExcluirLivro(Guid IdLivro);
  
    }
}