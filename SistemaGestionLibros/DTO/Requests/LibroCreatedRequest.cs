using System.ComponentModel.DataAnnotations;

namespace SistemaGestionLibros.DTO.Requests;

public class LibroCreatedRequest
{
    [Required]
    [MaxLength(100)]
    public string Titulo { get; set; }

    [Required]
    [MaxLength(20)]
    public string ISBN { get; set; }

    [Required]
    public DateTime FechaPublicacion { get; set; }

    public bool Disponible { get; set; }

    [Required]
    public Guid AutorId { get; set; }

    [Required]
    public Guid CategoriaId { get; set; }
}