using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Livro
    {
        [Key]
        public Guid IdLivro { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public int Edicao { get; set; }
        public string Editora { get; set; }
        public string ISBN { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
