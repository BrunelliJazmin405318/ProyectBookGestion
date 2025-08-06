using SistemaGestionLibros.DTO.Requests;
using SistemaGestionLibros.DTO.Responses;

namespace SistemaGestionLibros.Interface;

public interface ICategoriaService
{
    Task<ResultadoBase> CrearAsync(CategoriaCreatedRequest request);
}