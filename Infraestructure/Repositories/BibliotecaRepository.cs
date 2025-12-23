using Domain.Entities;
using Domain.Repositories;
using Infraestructure.Data;

namespace Infraestructure.Repositories
{
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private ApplicationDbContext _context;
        public BibliotecaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Biblioteca? RecuperarBibliotecaPorId(Guid IdBiblioteca)
        {
            return _context.Biblioteca.Where(x => x.IdBiblioteca == IdBiblioteca).FirstOrDefault();
        }

        public Biblioteca? CriarNovaBiblioteca(string NomeBiblioteca)
        {
            Biblioteca nova = new()
            {
                Nome = NomeBiblioteca,
                IdBiblioteca = Guid.NewGuid()
            };

            _context.Biblioteca.Add(nova);

            _context.SaveChanges();

            return nova;
        }

        public Biblioteca? AtualizarBiblioteca(Guid IdBiblioteca, string NomeBiblioteca)
        {
            Biblioteca? atualizacao = RecuperarBibliotecaPorId(IdBiblioteca);

            if(atualizacao != null)
            {
                atualizacao.Nome = NomeBiblioteca;

                _context.SaveChanges();

                return atualizacao;
            }
            return null;
        }
        public Biblioteca? ExcluirBiblioteca(Guid idBiblioteca)
        {
            var biblioteca = _context.Biblioteca.FirstOrDefault(b => b.IdBiblioteca == idBiblioteca);
            
                if (biblioteca == null) return null;
                _context.Biblioteca.Remove(biblioteca);
                _context.SaveChanges(); 
                return biblioteca;
        }

        public IEnumerable<Biblioteca> RecuperarTodasBibliotecas()
        {
        return _context.Biblioteca.ToList();
        }
    }   
}
