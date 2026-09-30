namespace Agenda.Application.Exceptions;

public class BusinessServiceNotFoundException : Exception
{
    public BusinessServiceNotFoundException(int serviceId)
        : base($"Serviço com ID {serviceId} não foi encontrado.")
    {
    }
}