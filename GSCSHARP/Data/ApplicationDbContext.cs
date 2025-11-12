using Microsoft.EntityFrameworkCore;
using GSCSHARP.Models;

namespace GSCSHARP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Trilha> Trilhas { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<TrilhaCompetencia> TrilhaCompetencias { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TrilhaCompetencia>()
                .HasKey(tc => new { tc.TrilhaId, tc.CompetenciaId });

            modelBuilder.Entity<TrilhaCompetencia>()
                .HasOne(tc => tc.Trilha)
                .WithMany(t => t.TrilhaCompetencias)
                .HasForeignKey(tc => tc.TrilhaId);

            modelBuilder.Entity<TrilhaCompetencia>()
                .HasOne(tc => tc.Competencia)
                .WithMany(c => c.TrilhaCompetencias)
                .HasForeignKey(tc => tc.CompetenciaId);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Usuario)
                .WithMany(u => u.Matriculas)
                .HasForeignKey(m => m.UsuarioId);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Trilha)
                .WithMany(t => t.Matriculas)
                .HasForeignKey(m => m.TrilhaId);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Competencia>().HasData(
                new Competencia { Id = 1, Nome = "Inteligência Artificial", Categoria = "Tecnologia", Descricao = "Machine Learning, Deep Learning, IA Generativa" },
                new Competencia { Id = 2, Nome = "Análise de Dados", Categoria = "Tecnologia", Descricao = "Big Data, Analytics, Data Science" },
                new Competencia { Id = 3, Nome = "Cloud Computing", Categoria = "Tecnologia", Descricao = "AWS, Azure, GCP" },
                new Competencia { Id = 4, Nome = "Empatia e Inteligência Emocional", Categoria = "Humana", Descricao = "Soft Skills essenciais para liderança" },
                new Competencia { Id = 5, Nome = "Colaboração Digital", Categoria = "Humana", Descricao = "Trabalho remoto e híbrido" },
                new Competencia { Id = 6, Nome = "Sustentabilidade e Green Tech", Categoria = "Tecnologia", Descricao = "Tecnologias verdes e sustentáveis" }
            );

            modelBuilder.Entity<Trilha>().HasData(
                new Trilha { Id = 1, Nome = "IA para Iniciantes", Descricao = "Introdução à Inteligência Artificial", Nivel = "INICIANTE", CargaHoraria = 40, FocoPrincipal = "IA" },
                new Trilha { Id = 2, Nome = "Cientista de Dados Completo", Descricao = "Trilha completa de Data Science", Nivel = "INTERMEDIARIO", CargaHoraria = 120, FocoPrincipal = "Dados" },
                new Trilha { Id = 3, Nome = "Liderança Digital", Descricao = "Soft Skills para líderes do futuro", Nivel = "AVANCADO", CargaHoraria = 60, FocoPrincipal = "Soft Skills" },
                new Trilha { Id = 4, Nome = "Cloud Architecture", Descricao = "Arquitetura de soluções em nuvem", Nivel = "AVANCADO", CargaHoraria = 80, FocoPrincipal = "Cloud" }
            );

            modelBuilder.Entity<TrilhaCompetencia>().HasData(
                new TrilhaCompetencia { TrilhaId = 1, CompetenciaId = 1 },
                new TrilhaCompetencia { TrilhaId = 2, CompetenciaId = 2 },
                new TrilhaCompetencia { TrilhaId = 2, CompetenciaId = 1 },
                new TrilhaCompetencia { TrilhaId = 3, CompetenciaId = 4 },
                new TrilhaCompetencia { TrilhaId = 3, CompetenciaId = 5 },
                new TrilhaCompetencia { TrilhaId = 4, CompetenciaId = 3 }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nome = "Maria Silva", Email = "maria.silva@email.com", AreaAtuacao = "Tecnologia", NivelCarreira = "Junior", DataCadastro = DateTime.Parse("2025-01-15") },
                new Usuario { Id = 2, Nome = "João Santos", Email = "joao.santos@email.com", AreaAtuacao = "Gestão", NivelCarreira = "Pleno", DataCadastro = DateTime.Parse("2025-02-20") }
            );

            modelBuilder.Entity<Matricula>().HasData(
                new Matricula { Id = 1, UsuarioId = 1, TrilhaId = 1, DataInscricao = DateTime.Parse("2025-03-01"), Status = "ATIVA" },
                new Matricula { Id = 2, UsuarioId = 2, TrilhaId = 3, DataInscricao = DateTime.Parse("2025-03-10"), Status = "ATIVA" }
            );
        }
    }
}
