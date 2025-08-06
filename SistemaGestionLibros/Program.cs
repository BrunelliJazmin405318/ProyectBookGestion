using Microsoft.EntityFrameworkCore;
using SistemaGestionLibros.Data;
using SistemaGestionLibros.Interface;
using SistemaGestionLibros.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//agregar los servicios
builder.Services.AddDbContext<ContextLibros>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase"));
});

//agregar la interfaz
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();



 