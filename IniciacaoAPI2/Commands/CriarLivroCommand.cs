namespace API.Commands
{
    public class CriarLivroCommand
    {
        public required string Nome { get; set; }
        public required string Autor { get; set; } = null!;
        public required string Edicao { get; set; } = null!;
        public required string Editora { get; set; } = null!;
        public required string ISBN { get; set; } = null!;
        public string? Descricao { get; set; }
        public required DateTime DataPublicacao { get; set; }
    }
}

