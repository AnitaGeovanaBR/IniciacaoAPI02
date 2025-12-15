using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Livro
    {
        [Key]
        public Guid IdLivro { get; set; }

        public string Nome { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public string Edicao { get; set; } = null!;
        public string Editora { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public string? Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
