using TechnicalTest.Core.DTOs;
using TechnicalTest.Core.Handlers;
using TechnicalTest.Core.Interfaces;

namespace TechnicalTest.Core.Factories
{
    public class ValidationHandlerFactory : IValidationHandlerFactory
    {
        public IValidationHandler GetHandler(IDTO dto)
        {
            if (dto is CalculateCoordinatesDTO)
            {
                return new CoordinatesValidationHandler((CalculateCoordinatesDTO)dto);
            }

            if (dto is CalculateGridValueDTO)
            {
                return new CalculateGridValueValidationHandler((CalculateGridValueDTO)dto);
            }

            throw new Exception("Handler Not Found");
        }
    }
}
