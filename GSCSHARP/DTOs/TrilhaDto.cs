using System.ComponentModel.DataAnnotations;

namespace GSCSHARP.DTOs
{
    public class TrilhaCreateDto
    {
        [Required(ErrorMessage = "O nome da trilha é obrigatório")]
        [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres")]
        public string Nome { get; set; } = string.Empty;

        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O nível é obrigatório")]
        [RegularExpression("^(INICIANTE|INTERMEDIARIO|AVANCADO)$", ErrorMessage = "Nível deve ser INICIANTE, INTERMEDIARIO ou AVANCADO")]
        public string Nivel { get; set; } = string.Empty;

        [Required(ErrorMessage = "A carga horária é obrigatória")]
        [Range(1, 1000, ErrorMessage = "A carga horária deve estar entre 1 e 1000 horas")]
        public int CargaHoraria { get; set; }

        [StringLength(100, ErrorMessage = "O foco principal deve ter no máximo 100 caracteres")]
        public string? FocoPrincipal { get; set; }
    }

    public class TrilhaUpdateDto
    {
        [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres")]
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        [RegularExpression("^(INICIANTE|INTERMEDIARIO|AVANCADO)$", ErrorMessage = "Nível deve ser INICIANTE, INTERMEDIARIO ou AVANCADO")]
        public string? Nivel { get; set; }

        [Range(1, 1000, ErrorMessage = "A carga horária deve estar entre 1 e 1000 horas")]
        public int? CargaHoraria { get; set; }

        [StringLength(100, ErrorMessage = "O foco principal deve ter no máximo 100 caracteres")]
        public string? FocoPrincipal { get; set; }
    }

    public class TrilhaResponseDto
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public string Nivel { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }
        public string? FocoPrincipal { get; set; }
    }
}
