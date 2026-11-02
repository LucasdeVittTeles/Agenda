namespace Agenda.Application.Exceptions;

public class BusinessNotFoundException : Exception
{
    public BusinessNotFoundException(int businessId)
       : base($"Estabelecimento com ID {businessId} não foi encontrado.")
    {
    }

}
