using Microsoft.AspNetCore.Mvc;
using SistemaGestionLibros.Data;
using SistemaGestionLibros.DTO.Requests;
using SistemaGestionLibros.DTO.Responses;
using SistemaGestionLibros.Interface;

namespace SistemaGestionLibros.Controller;
[ApiController]
public class LibroController : ControllerBase
{
    private readonly ContextLibros _contexto;
    private readonly ILibroService _service;

    public LibroController(ContextLibros contexto, ILibroService service)
    {
        _contexto = contexto;
        _service = service;
    }

    [HttpGet("/libros")]
    public async Task<ResultadoBase> ObtenerTodos()
    {
        return await _service.ObtenerTodos();
    }

    [HttpGet("/libros/{id}")]
    public async Task<ResultadoBase> ObtenerPorId(Guid id)
    {
        return await _service.ObtenerPorId(id);
    }

    [HttpPost("/libros")]
    public async Task<ResultadoBase> Crear([FromBody] LibroCreatedRequest request)
    {
        return await _service.Crear(request);
    }
    [HttpPut("/libros/{id}")]
    public async Task<ResultadoBase> Actualizar(Guid id, [FromBody] LibroUpdateRequest request)
    {
        return await _service.Actualizar(id, request);
    }

    [HttpDelete("/libros/{id}")]
    public async Task<ResultadoBase> Eliminar(Guid id)
    {
        return await _service.Eliminar(id);
    }

    [HttpGet("/libros/primero")]
    public async Task<ResultadoBase> ObtenerPrimero()
    {
        return await _service.ObtenerPrimero();
    }
}