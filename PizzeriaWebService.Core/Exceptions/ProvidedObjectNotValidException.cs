using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Exceptions;

public class ProvidedObjectNotValidException : PizzeriaWebServiceException
{
    public ProvidedObjectNotValidException()
    {
    }

    public ProvidedObjectNotValidException(string? message) : base(message)
    {
    }

    public ProvidedObjectNotValidException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
