using SistemaGestionLibros.DTO.Requests;
using SistemaGestionLibros.DTO.Responses;

namespace SistemaGestionLibros.Interface;

public interface ILibroService
{
    Task<ResultadoBase> ObtenerTodos();
    Task<ResultadoBase> ObtenerPorId(Guid id);
    Task<ResultadoBase> Crear(LibroCreatedRequest request);
    Task<ResultadoBase> Actualizar(Guid id, LibroUpdateRequest request);
    Task<ResultadoBase> Eliminar(Guid id);
    Task<ResultadoBase> ObtenerPrimero();
    Task<bool> ExisteISBN(string isbn);
}