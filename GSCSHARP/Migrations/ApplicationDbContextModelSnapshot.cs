using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GSCSHARP.Data;

#nullable disable

namespace GSCSHARP.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GSCSHARP.Models.Competencia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Categoria")
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Competencias");

                    b.HasData(
                        new { Id = 1L, Nome = "Inteligência Artificial", Categoria = "Tecnologia", Descricao = "Machine Learning, Deep Learning, IA Generativa" },
                        new { Id = 2L, Nome = "Análise de Dados", Categoria = "Tecnologia", Descricao = "Big Data, Analytics, Data Science" },
                        new { Id = 3L, Nome = "Cloud Computing", Categoria = "Tecnologia", Descricao = "AWS, Azure, GCP" },
                        new { Id = 4L, Nome = "Empatia e Inteligência Emocional", Categoria = "Humana", Descricao = "Soft Skills essenciais para liderança" },
                        new { Id = 5L, Nome = "Colaboração Digital", Categoria = "Humana", Descricao = "Trabalho remoto e híbrido" },
                        new { Id = 6L, Nome = "Sustentabilidade e Green Tech", Categoria = "Tecnologia", Descricao = "Tecnologias verdes e sustentáveis" }
                    );
                });

            modelBuilder.Entity("GSCSHARP.Models.Matricula", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("TrilhaId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TrilhaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Matriculas");

                    b.HasData(
                        new { Id = 1L, UsuarioId = 1L, TrilhaId = 1L, DataInscricao = new DateTime(2025, 3, 1), Status = "ATIVA" },
                        new { Id = 2L, UsuarioId = 2L, TrilhaId = 3L, DataInscricao = new DateTime(2025, 3, 10), Status = "ATIVA" }
                    );
                });

            modelBuilder.Entity("GSCSHARP.Models.Trilha", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("FocoPrincipal")
                        .HasColumnType("longtext");

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Trilhas");

                    b.HasData(
                        new { Id = 1L, Nome = "IA para Iniciantes", Descricao = "Introdução à Inteligência Artificial", Nivel = "INICIANTE", CargaHoraria = 40, FocoPrincipal = "IA" },
                        new { Id = 2L, Nome = "Cientista de Dados Completo", Descricao = "Trilha completa de Data Science", Nivel = "INTERMEDIARIO", CargaHoraria = 120, FocoPrincipal = "Dados" },
                        new { Id = 3L, Nome = "Liderança Digital", Descricao = "Soft Skills para líderes do futuro", Nivel = "AVANCADO", CargaHoraria = 60, FocoPrincipal = "Soft Skills" },
                        new { Id = 4L, Nome = "Cloud Architecture", Descricao = "Arquitetura de soluções em nuvem", Nivel = "AVANCADO", CargaHoraria = 80, FocoPrincipal = "Cloud" }
                    );
                });

            modelBuilder.Entity("GSCSHARP.Models.TrilhaCompetencia", b =>
                {
                    b.Property<long>("TrilhaId")
                        .HasColumnType("bigint");

                    b.Property<long>("CompetenciaId")
                        .HasColumnType("bigint");

                    b.HasKey("TrilhaId", "CompetenciaId");

                    b.HasIndex("CompetenciaId");

                    b.ToTable("TrilhaCompetencias");

                    b.HasData(
                        new { TrilhaId = 1L, CompetenciaId = 1L },
                        new { TrilhaId = 2L, CompetenciaId = 2L },
                        new { TrilhaId = 2L, CompetenciaId = 1L },
                        new { TrilhaId = 3L, CompetenciaId = 4L },
                        new { TrilhaId = 3L, CompetenciaId = 5L },
                        new { TrilhaId = 4L, CompetenciaId = 3L }
                    );
                });

            modelBuilder.Entity("GSCSHARP.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("AreaAtuacao")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NivelCarreira")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");

                    b.HasData(
                        new { Id = 1L, Nome = "Maria Silva", Email = "maria.silva@email.com", AreaAtuacao = "Tecnologia", NivelCarreira = "Junior", DataCadastro = new DateTime(2025, 1, 15) },
                        new { Id = 2L, Nome = "João Santos", Email = "joao.santos@email.com", AreaAtuacao = "Gestão", NivelCarreira = "Pleno", DataCadastro = new DateTime(2025, 2, 20) }
                    );
                });

            modelBuilder.Entity("GSCSHARP.Models.Matricula", b =>
                {
                    b.HasOne("GSCSHARP.Models.Trilha", "Trilha")
                        .WithMany("Matriculas")
                        .HasForeignKey("TrilhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GSCSHARP.Models.Usuario", "Usuario")
                        .WithMany("Matriculas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trilha");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GSCSHARP.Models.TrilhaCompetencia", b =>
                {
                    b.HasOne("GSCSHARP.Models.Competencia", "Competencia")
                        .WithMany("TrilhaCompetencias")
                        .HasForeignKey("CompetenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GSCSHARP.Models.Trilha", "Trilha")
                        .WithMany("TrilhaCompetencias")
                        .HasForeignKey("TrilhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competencia");

                    b.Navigation("Trilha");
                });

            modelBuilder.Entity("GSCSHARP.Models.Competencia", b =>
                {
                    b.Navigation("TrilhaCompetencias");
                });

            modelBuilder.Entity("GSCSHARP.Models.Trilha", b =>
                {
                    b.Navigation("Matriculas");

                    b.Navigation("TrilhaCompetencias");
                });

            modelBuilder.Entity("GSCSHARP.Models.Usuario", b =>
                {
                    b.Navigation("Matriculas");
                });
#pragma warning restore 612, 618
        }
    }
}
