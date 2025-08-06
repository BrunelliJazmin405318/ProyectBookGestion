using System.ComponentModel.DataAnnotations;

namespace SistemaGestionLibros.Models;

public class Libro
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Titulo { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string ISBN { get; set; }
    
    [Required]
    public DateTime FechaPublicacion {get; set;}
    
    public bool Disponible { get; set; }
    
    [Required]
    public Guid AutorId { get; set; }
    public Autor Autor { get; set; }
    
    [Required]
    public Guid CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    public ICollection<Prestamo> Prestamos { get; set; }
}