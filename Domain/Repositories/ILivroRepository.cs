using Domain.Entities;

namespace Domain.Repositories
{
    public interface ILivroRepository
    {
        public Livro? CriarNovoLivro(string NomeLivro, string Autor, string Edicao, string Editora, string ISBN, string? Descricao, DateTime DataPublicacao); 
        public Livro? RecuperarLivroPorId(Guid IdLivro);      
        public Livro? RecuperarLivro(Guid IdLivro, string NomeLivro);
        public Livro? AtualizarLivro(Guid IdLivro, string NomeLivro, string Autor, string Edicao, string Editora, string ISBN, string? Descricao, DateTime DataPublicacao);
        public Livro? ExcluirLivro(Guid IdLivro);
  
    }
}