using System.Net;
using Microsoft.EntityFrameworkCore;
using SistemaGestionLibros.Data;
using SistemaGestionLibros.DTO.Requests;
using SistemaGestionLibros.DTO.Responses;
using SistemaGestionLibros.DTO.Responses.LIbro;
using SistemaGestionLibros.Interface;
using SistemaGestionLibros.Models;

namespace SistemaGestionLibros.Service;

public class LibroService : ILibroService
{
    private readonly ContextLibros _context;

    public LibroService(ContextLibros context)
    {
        _context = context;
    }
    public async Task<ResultadoBase> ObtenerTodos()
    {
        var libros = await _context.Libros
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .ToListAsync();

        var listaDto = libros.Select(l => new LibroResponse
        {
            Id = l.Id,
            Titulo = l.Titulo,
            ISBN = l.ISBN,
            FechaPublicacion = l.FechaPublicacion,
            Disponible = l.Disponible,
            AutorId = l.AutorId,
            AutorNombre = l.Autor.NombreCompleto,
            CategoriaId = l.CategoriaId,
            CategoriaNombre = l.Categoria.Nombre
        }).ToList();

        return new ResultadoBase
        {
            Ok = true,
            Datos = listaDto,
            StatusCode = HttpStatusCode.OK
        };
    }

    public async Task<ResultadoBase> ObtenerPorId(Guid id)
    {
        var libro = await _context.Libros
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (libro == null)
        {
            return new ResultadoBase
            {
                Ok = false,
                MensajeError = "Libro no encontrado",
                StatusCode = HttpStatusCode.NotFound
            };
        }

        var dto = new LibroResponse
        {
            Id = libro.Id,
            Titulo = libro.Titulo,
            ISBN = libro.ISBN,
            FechaPublicacion = libro.FechaPublicacion,
            Disponible = libro.Disponible,
            AutorId = libro.AutorId,
            AutorNombre = libro.Autor.NombreCompleto,
            CategoriaId = libro.CategoriaId,
            CategoriaNombre = libro.Categoria.Nombre
        };

        return new ResultadoBase
        {
            Ok = true,
            Datos = dto,
            StatusCode = HttpStatusCode.OK
        };
    }

    public async Task<ResultadoBase> Crear(LibroCreatedRequest request)
    {
        if (await ExisteISBN(request.ISBN))
        {
            return new ResultadoBase
            {
                Ok = false,
                MensajeError = "Ya existe un libro con ese ISBN",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        if (request.FechaPublicacion > DateTime.Now)
        {
            return new ResultadoBase
            {
                Ok = false,
                MensajeError = "La fecha de publicación no puede ser futura",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        var libro = new Libro
        {
            Id = Guid.NewGuid(),
            Titulo = request.Titulo,
            ISBN = request.ISBN,
            FechaPublicacion = request.FechaPublicacion,
            Disponible = request.Disponible,
            AutorId = request.AutorId,
            CategoriaId = request.CategoriaId
        };

        _context.Libros.Add(libro);
        await _context.SaveChangesAsync();

        return await ObtenerPorId(libro.Id);
    }

    public async Task<ResultadoBase> Actualizar(Guid id, LibroUpdateRequest request)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro == null)
        {
            return new ResultadoBase
            {
                Ok = false,
                MensajeError = "Libro no encontrado",
                StatusCode = HttpStatusCode.NotFound
            };
        }

        if (request.FechaPublicacion > DateTime.Now)
        {
            return new ResultadoBase
            {
                Ok = false,
                MensajeError = "La fecha de publicación no puede ser futura",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        libro.Titulo = request.Titulo;
        libro.ISBN = request.ISBN;
        libro.FechaPublicacion = request.FechaPublicacion;
        libro.Disponible = request.Disponible;
        libro.AutorId = request.AutorId;
        libro.CategoriaId = request.CategoriaId;

        await _context.SaveChangesAsync();

        return await ObtenerPorId(id);
    }

    public async Task<ResultadoBase> Eliminar(Guid id)
    {
        var libro = await _context.Libros.FindAsync(id);

        if (libro == null)
        {
            return new ResultadoBase
            {
                Ok = false,
                MensajeError = "Libro no encontrado",
                StatusCode = HttpStatusCode.NotFound
            };
        }

        if (!libro.Disponible)
        {
            return new ResultadoBase
            {
                Ok = false,
                MensajeError = "No se puede eliminar un libro que no está disponible",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        _context.Libros.Remove(libro);
        await _context.SaveChangesAsync();

        return new ResultadoBase
        {
            Ok = true,
            Datos = true, // indicamos que se eliminó correctamente
            StatusCode = HttpStatusCode.OK
        };
    }

    public async Task<ResultadoBase> ObtenerPrimero()
    {
        var libro = await _context.Libros
            .Include(l => l.Autor)
            .Include(l => l.Categoria)
            .OrderBy(l => l.FechaPublicacion)
            .FirstOrDefaultAsync();

        if (libro == null)
        {
            return new ResultadoBase
            {
                Ok = false,
                MensajeError = "No hay libros cargados",
                StatusCode = HttpStatusCode.NotFound
            };
        }

        return await ObtenerPorId(libro.Id); 
    }

    public async Task<bool> ExisteISBN(string isbn)
    {
        return await _context.Libros.AnyAsync(l => l.ISBN == isbn);
    }
}