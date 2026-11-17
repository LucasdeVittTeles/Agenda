namespace Agenda.Application.Exceptions
{
    public class BusinessSettingsNotFoundException : Exception
    {
      public BusinessSettingsNotFoundException()
      : base($"Configuração do Serviço não foi encontrada.")
        {
        }

    }
}
