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
