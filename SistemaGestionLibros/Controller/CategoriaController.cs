using Microsoft.AspNetCore.Mvc;
using SistemaGestionLibros.DTO.Requests;
using SistemaGestionLibros.DTO.Responses;
using SistemaGestionLibros.Interface;

namespace SistemaGestionLibros.Controller;
[ApiController]
[Route("categorias")] 
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;
    
    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpPost]
    public async Task<ActionResult<ResultadoBase>> Crear([FromBody] CategoriaCreatedRequest request)
    {
        var resultado = await _categoriaService.CrearAsync(request);

        if (!resultado.Ok)
            return StatusCode((int)resultado.StatusCode, resultado);

        return StatusCode(201, resultado); // Created
    }
}