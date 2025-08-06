using System.Net;

namespace SistemaGestionLibros.DTO.Responses;

public class ResultadoBase
{
    public bool Ok { get; set; } = true;
    public string MensajeError { get; set; } = " ";
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public object Datos { get; set; }
    
    public void SetError(string mensajeError, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
    {
        Ok = false;
        MensajeError = mensajeError;
        StatusCode = statusCode;
    }
}