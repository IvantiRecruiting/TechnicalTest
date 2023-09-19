namespace TechnicalTest.Core.Interfaces
{
    public interface IValidationHandlerFactory
    {
        IValidationHandler GetDTOHandler(IDTO dto);

        IValidationHandler GetModelHandler(IModel model);
    }
}