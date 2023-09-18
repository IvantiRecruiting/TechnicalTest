namespace TechnicalTest.Core.Interfaces
{
    public interface IValidationHandlerFactory
    {
        IValidationHandler GetHandler(IDTO dto);
    }
}