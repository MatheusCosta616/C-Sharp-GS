using Microsoft.EntityFrameworkCore;
using GSCSHARP.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 0))
    )
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Upskilling/Reskilling - O Futuro do Trabalho",
        Version = "1.0",
        Description = "API RESTful para plataforma de Upskilling/Reskilling voltada ao futuro do trabalho (2030+). " +
                      "Permite cadastro de usuários e acesso a trilhas de aprendizagem focadas em competências do futuro. " +
                      "Inclui informações expandidas com relacionamentos entre entidades, dados de matrículas e competências.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "FIAP - Global Solution 2025",
            Email = "contato@fiap.com.br"
        }
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Upskilling/Reskilling");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
