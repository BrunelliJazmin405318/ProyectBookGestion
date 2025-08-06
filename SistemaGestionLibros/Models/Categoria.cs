using System.ComponentModel.DataAnnotations;

namespace SistemaGestionLibros.Models;

public class Categoria
{
    public Guid Id { get; set; }
    [Required]
    public string Nombre { get;set;}
    public ICollection<Libro> Libros { get; set; }
}