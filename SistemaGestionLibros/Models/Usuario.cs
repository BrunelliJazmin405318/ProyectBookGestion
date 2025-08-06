using System.ComponentModel.DataAnnotations;

namespace SistemaGestionLibros.Models;

public class Usuario
{
    public Guid Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Apellido { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public bool Activo { get; set; }
    public ICollection<Prestamo> Prestamos { get; set; }
}