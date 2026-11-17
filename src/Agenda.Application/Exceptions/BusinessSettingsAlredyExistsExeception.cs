namespace Agenda.Application.Exceptions;

public class BusinessSettingsAlredyExistsExeception : Exception
{
    public BusinessSettingsAlredyExistsExeception()
    : base("Já existe uma Configuração do Serviço para essa empresa")
    {
    }

}
