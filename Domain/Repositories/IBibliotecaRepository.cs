using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBibliotecaRepository
    {
        public Biblioteca? RecuperarBibliotecaPorId(Guid IdBiblioteca);
        public Biblioteca? CriarNovaBiblioteca(string NomeBiblioteca);
        public Biblioteca? AtualizarBiblioteca(Guid IdBiblioteca, string NomeBiblioteca);
    }
}