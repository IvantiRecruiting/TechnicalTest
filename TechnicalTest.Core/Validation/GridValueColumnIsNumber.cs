using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Core.Constants;
using TechnicalTest.Core.DTOs;
using TechnicalTest.Core.Interfaces;

namespace TechnicalTest.Core.Validation
{
    public class GridValueColumnIsNumber : ICoordinateValidator
    {
        public void Validate(CalculateCoordinatesDTO calculateCoordinates)
        {
            var columns = calculateCoordinates.GridValue.Remove(0, 1);

            foreach (var column in columns)
            {
                if (!char.IsDigit(column))
                {
                    throw new Exception(ErrorMessages.GridValueColumnNumber);
                }
            }
          
        }
    }
}
