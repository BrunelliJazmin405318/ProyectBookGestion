using System.Net;
using Microsoft.EntityFrameworkCore;
using SistemaGestionLibros.Data;
using SistemaGestionLibros.DTO.Requests;
using SistemaGestionLibros.DTO.Responses;
using SistemaGestionLibros.Interface;
using SistemaGestionLibros.Models;

namespace SistemaGestionLibros.Service;

public class CategoriaService : ICategoriaService
{
    private readonly ContextLibros _context;

    public CategoriaService(ContextLibros context)
    {
        _context = context;
    }
    public async Task<ResultadoBase> CrearAsync(CategoriaCreatedRequest request)
    {
        var resultado = new ResultadoBase();
        
        bool existeNombre = await _context.Categorias.AnyAsync(c => c.Nombre.ToLower() == request.Nombre.Trim().ToLower());
        if (existeNombre)
        {
            resultado.SetError("Ya existe una categoría con ese nombre.", HttpStatusCode.BadRequest);
            return resultado;
        }
        
        var categoria = new Categoria
        {
            Id = Guid.NewGuid(),
            Nombre = request.Nombre.Trim()
        };

        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        resultado.Datos = categoria;
        return resultado;
    }
}