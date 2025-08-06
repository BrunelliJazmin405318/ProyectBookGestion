using Microsoft.EntityFrameworkCore;
using SistemaGestionLibros.Models;

namespace SistemaGestionLibros.Data;

public class ContextLibros : DbContext
{
    public ContextLibros(DbContextOptions<ContextLibros> options) : base(options)
    {
        
    }
    
    public DbSet<Autor> Autores {get; set;}
    public DbSet<Categoria> Categorias {get; set;}
    public DbSet<Libro> Libros {get; set;}
    public DbSet<Prestamo> Prestamos {get; set;}
    public DbSet<Usuario> Usuarios {get; set;}
}