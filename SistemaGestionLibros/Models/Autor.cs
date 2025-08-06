using System.ComponentModel.DataAnnotations;

namespace SistemaGestionLibros.Models;

public class Autor
{
   public Guid Id {get;set;}
   [Required]
   public string NombreCompleto { get; set; }
   public string Nacionalidad { get; set; }
   public ICollection<Libro> Libros { get; set; }
   
}