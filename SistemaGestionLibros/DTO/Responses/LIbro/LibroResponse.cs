namespace SistemaGestionLibros.DTO.Responses.LIbro;

public class LibroResponse
{
    public Guid Id { get; set; }

    public string Titulo { get; set; }
    public string ISBN { get; set; }
    public DateTime FechaPublicacion { get; set; }
    public bool Disponible { get; set; }
    
    public Guid AutorId { get; set; }
    public string AutorNombre { get; set; }
    public Guid CategoriaId { get; set; }
    public string CategoriaNombre { get; set; }
}