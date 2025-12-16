using Domain.Entities;

namespace Domain.Repositories
{
    public interface ILivroRepository
    {
        public Livro? RecuperarLivroPorId(Guid IdLivro);
        public Livro? CriarNovoLivro(string NomeLivro, string AutorLivro, string EdicaoLivro, string EditoraLivro, string ISBNLivro, string DescricaoLivro, DateTime DatapublicacaoLivro);
        public Livro? AtualizarLivro(Guid IdLivro,string NomeLivro, string AutorLivro, string EdicaoLivro, string EditoraLivro, string ISBNLivro, string DescricaoLivro, DateTime DatapublicacaoLivro);
        public Livro? DeletarLivro(Guid IdLivro);
    }
}