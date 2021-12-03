using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Exceptions;

public class ProvidedItemAlreadyExistsException : PizzeriaWebServiceException
{
    public ProvidedItemAlreadyExistsException()
    {
    }

    public ProvidedItemAlreadyExistsException(string? message) : base(message)
    {
    }

    public ProvidedItemAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
