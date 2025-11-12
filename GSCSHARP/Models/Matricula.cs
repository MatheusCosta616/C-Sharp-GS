namespace GSCSHARP.Models
{
    public class Matricula
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public long TrilhaId { get; set; }
        public Trilha Trilha { get; set; } = null!;

        public DateTime DataInscricao { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
