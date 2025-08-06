using System.ComponentModel.DataAnnotations;

namespace SistemaGestionLibros.Models;

public class Prestamo
{
    public Guid Id {get; set;}
    
    [Required]
    public Guid LibroId { get; set; }
    public Libro Libro { get; set; }
    
    [Required]
    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    
    [Required]
    public DateTime FechaPrestamo { get; set; }
    public DateTime? FechaDevolucion {get; set;}
}