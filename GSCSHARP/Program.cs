using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using GSCSHARP.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 0))
    )
);

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version")
    );
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Upskilling/Reskilling - O Futuro do Trabalho",
        Version = "v1",
        Description = "API RESTful para plataforma de Upskilling/Reskilling voltada ao futuro do trabalho (2030+). " +
                      "Permite cadastro de usuários e acesso a trilhas de aprendizagem focadas em competências do futuro.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "FIAP - Global Solution 2025",
            Email = "contato@fiap.com.br"
        }
    });

    options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Upskilling/Reskilling - O Futuro do Trabalho",
        Version = "v2",
        Description = "API RESTful v2 com informações expandidas incluindo relacionamentos entre entidades. " +
                      "Versão aprimorada com dados de matrículas e competências.",
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
