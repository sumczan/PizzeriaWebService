namespace PizzeriaWebService.Core.Exceptions;

public class PizzeriaWebServiceException : Exception
{
    public PizzeriaWebServiceException()
    {
    }

    public PizzeriaWebServiceException(string? message) : base(message)
    {
    }

    public PizzeriaWebServiceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
