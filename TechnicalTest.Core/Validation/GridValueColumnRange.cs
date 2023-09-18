using TechnicalTest.Core.Constants;
using TechnicalTest.Core.DTOs;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Validation
{
    public class GridValueColumnRange : ICoordinateValidator
    {
        public void Validate(CalculateCoordinatesDTO calculateCoordinates)
        {
            var columns = int.Parse(calculateCoordinates.GridValue.Remove(0, 1));

            if (!Enumerable.Range(1, 12).Contains(columns))
            {
                throw new Exception(ErrorMessages.GridValueColumnRange);
            }
        }
    }
}
