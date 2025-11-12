using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSCSHARP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Competencias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Categoria = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Trilhas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nivel = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    FocoPrincipal = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AreaAtuacao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NivelCarreira = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrilhaCompetencias",
                columns: table => new
                {
                    TrilhaId = table.Column<long>(type: "bigint", nullable: false),
                    CompetenciaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrilhaCompetencias", x => new { x.TrilhaId, x.CompetenciaId });
                    table.ForeignKey(
                        name: "FK_TrilhaCompetencias_Competencias_CompetenciaId",
                        column: x => x.CompetenciaId,
                        principalTable: "Competencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrilhaCompetencias_Trilhas_TrilhaId",
                        column: x => x.TrilhaId,
                        principalTable: "Trilhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    TrilhaId = table.Column<long>(type: "bigint", nullable: false),
                    DataInscricao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Trilhas_TrilhaId",
                        column: x => x.TrilhaId,
                        principalTable: "Trilhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_TrilhaId",
                table: "Matriculas",
                column: "TrilhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_UsuarioId",
                table: "Matriculas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TrilhaCompetencias_CompetenciaId",
                table: "TrilhaCompetencias",
                column: "CompetenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            // Seed Data - Competências
            migrationBuilder.InsertData(
                table: "Competencias",
                columns: new[] { "Id", "Nome", "Categoria", "Descricao" },
                values: new object[,]
                {
                    { 1L, "Inteligência Artificial", "Tecnologia", "Machine Learning, Deep Learning, IA Generativa" },
                    { 2L, "Análise de Dados", "Tecnologia", "Big Data, Analytics, Data Science" },
                    { 3L, "Cloud Computing", "Tecnologia", "AWS, Azure, GCP" },
                    { 4L, "Empatia e Inteligência Emocional", "Humana", "Soft Skills essenciais para liderança" },
                    { 5L, "Colaboração Digital", "Humana", "Trabalho remoto e híbrido" },
                    { 6L, "Sustentabilidade e Green Tech", "Tecnologia", "Tecnologias verdes e sustentáveis" }
                });

            // Seed Data - Trilhas
            migrationBuilder.InsertData(
                table: "Trilhas",
                columns: new[] { "Id", "Nome", "Descricao", "Nivel", "CargaHoraria", "FocoPrincipal" },
                values: new object[,]
                {
                    { 1L, "IA para Iniciantes", "Introdução à Inteligência Artificial", "INICIANTE", 40, "IA" },
                    { 2L, "Cientista de Dados Completo", "Trilha completa de Data Science", "INTERMEDIARIO", 120, "Dados" },
                    { 3L, "Liderança Digital", "Soft Skills para líderes do futuro", "AVANCADO", 60, "Soft Skills" },
                    { 4L, "Cloud Architecture", "Arquitetura de soluções em nuvem", "AVANCADO", 80, "Cloud" }
                });

            // Seed Data - Usuários
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nome", "Email", "AreaAtuacao", "NivelCarreira", "DataCadastro" },
                values: new object[,]
                {
                    { 1L, "Maria Silva", "maria.silva@email.com", "Tecnologia", "Junior", new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "João Santos", "joao.santos@email.com", "Gestão", "Pleno", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            // Seed Data - TrilhaCompetencia
            migrationBuilder.InsertData(
                table: "TrilhaCompetencias",
                columns: new[] { "TrilhaId", "CompetenciaId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 2L },
                    { 2L, 1L },
                    { 3L, 4L },
                    { 3L, 5L },
                    { 4L, 3L }
                });

            // Seed Data - Matrículas
            migrationBuilder.InsertData(
                table: "Matriculas",
                columns: new[] { "Id", "UsuarioId", "TrilhaId", "DataInscricao", "Status" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATIVA" },
                    { 2L, 2L, 3L, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ATIVA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Matriculas");
            migrationBuilder.DropTable(name: "TrilhaCompetencias");
            migrationBuilder.DropTable(name: "Usuarios");
            migrationBuilder.DropTable(name: "Trilhas");
            migrationBuilder.DropTable(name: "Competencias");
        }
    }
}
