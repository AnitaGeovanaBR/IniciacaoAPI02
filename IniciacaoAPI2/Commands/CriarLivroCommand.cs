namespace API.Commands
{
    public class CriarLivroCommand
    {
        public required string Nome { get; set; }
        public required string Autor { get; set; }
        public required string Edicao { get; set; } 
        public required string Editora { get; set; } 
        public required string ISBN { get; set; } 
        public string? Descricao { get; set; }
        public required DateTime DataPublicacao { get; set; } 
    }
}