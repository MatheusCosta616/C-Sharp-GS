using System.ComponentModel.DataAnnotations;

namespace GSCSHARP.DTOs
{
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(150, ErrorMessage = "O email deve ter no máximo 150 caracteres")]
        public string Email { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "A área de atuação deve ter no máximo 100 caracteres")]
        public string? AreaAtuacao { get; set; }

        [StringLength(50, ErrorMessage = "O nível de carreira deve ter no máximo 50 caracteres")]
        public string? NivelCarreira { get; set; }
    }

    public class UsuarioUpdateDto
    {
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(150, ErrorMessage = "O email deve ter no máximo 150 caracteres")]
        public string? Email { get; set; }

        [StringLength(100, ErrorMessage = "A área de atuação deve ter no máximo 100 caracteres")]
        public string? AreaAtuacao { get; set; }

        [StringLength(50, ErrorMessage = "O nível de carreira deve ter no máximo 50 caracteres")]
        public string? NivelCarreira { get; set; }
    }

    public class UsuarioResponseDto
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? AreaAtuacao { get; set; }
        public string? NivelCarreira { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
