using Domain.Entities;

namespace Domain.Repositories
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> RecuperarTodos();

        Livro? RecuperarLivroPorId(Guid idLivro);

        Livro? CriarNovoLivro(
            string nome,
            string autor,
            string edicao,
            string editora,
            string isbn,
            string? descricao,
            DateTime dataPublicacao);

        Livro? AtualizarLivro(
            Guid idLivro,
            string nome,
            string autor,
            string edicao,
            string editora,
            string isbn,
            string? descricao,
            DateTime dataPublicacao);

        Livro? DeletarLivro(Guid idLivro);
    }
}
