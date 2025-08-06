using System.ComponentModel.DataAnnotations;

namespace SistemaGestionLibros.DTO.Requests;

public class CategoriaCreatedRequest
{
    [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
    public string Nombre { get; set; }
}