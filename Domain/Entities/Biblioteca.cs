using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Biblioteca
    {
        [Key]
        public Guid IdBiblioteca { get; set; }
        public string Nome { get; set; } = null!;

    }
}
