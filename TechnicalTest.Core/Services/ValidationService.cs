using System.Text.RegularExpressions;
using TechnicalTest.Core.Interfaces;

namespace TechnicalTest.Core.Services
{
    public class ValidationService : IValidationService
    {

        public bool ValidateShapeTypeTriangle(ShapeEnum shapeType)
        {
            return shapeType != ShapeEnum.Triangle;
        }

        public bool ValidateGridValue(string gridValue)
        {
            return ValidateGridValueRowIsLetter(gridValue) && ValidateGridValueRowRange(gridValue) && ValidateGridColumnsIsNumber(gridValue) && ValidateGridColumnNumberRange(gridValue); 
        }

        private static bool ValidateGridValueRowIsLetter(string gridValue)
        {
            return char.IsLetter(gridValue, 0);
        }

        private static bool ValidateGridValueRowRange(string gridValue)
        {
            Regex r = new("[A-F]");

            if (!r.IsMatch(gridValue)) {

                return false;
            }

            return true;
           
        }

        private static bool ValidateGridColumnsIsNumber(string gridValue)
        {
            var columns = gridValue.Remove(0,1);

            foreach (var column in columns)
            {
                if(!char.IsDigit(column))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ValidateGridColumnNumberRange(string gridValue)
        {
            var columns = int.Parse(gridValue.Remove(0,1));

            if (!Enumerable.Range(1, 12).Contains(columns))
            {
                return false;

            }

            return true;
        }
    }
}
