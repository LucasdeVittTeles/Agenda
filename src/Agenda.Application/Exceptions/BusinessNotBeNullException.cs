namespace Agenda.Application.Exceptions;

public class BusinessNotBeNullException : Exception
{
    public BusinessNotBeNullException(string message) : base(message)
    {
    }

}
