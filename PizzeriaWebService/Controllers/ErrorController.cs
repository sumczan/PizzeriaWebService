using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PizzeriaWebService.Core.Exceptions;
using System.Net;

namespace PizzeriaWebService.Controllers;
[ApiController]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult HandleError()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var httpCode = exception.Error switch
        {
            RequestedItemDoesNotExistException => HttpStatusCode.NotFound,
            ProvidedItemAlreadyExistsException => HttpStatusCode.BadRequest,
            ProvidedObjectNotValidException => HttpStatusCode.BadRequest,
            PizzeriaWebServiceException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        return Problem(detail: exception.Error.Message, statusCode: (int)httpCode);
    }
}
