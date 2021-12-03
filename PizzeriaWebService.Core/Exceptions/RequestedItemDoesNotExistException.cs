using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWebService.Core.Exceptions;

public class RequestedItemDoesNotExistException : PizzeriaWebServiceException 
{ 
    public RequestedItemDoesNotExistException()
    {   
    }

    public RequestedItemDoesNotExistException(string? message) : base(message)
    {
    }

    public RequestedItemDoesNotExistException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
