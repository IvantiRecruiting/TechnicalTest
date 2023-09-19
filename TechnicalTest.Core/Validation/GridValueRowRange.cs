using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechnicalTest.Core.Constants;
using TechnicalTest.Core.DTOs;
using TechnicalTest.Core.Interfaces;

namespace TechnicalTest.Core.Validation
{
    public class GridValueRowRange : ICoordinateValidator
    {
        public void Validate(CalculateCoordinatesDTO calculateCoordinates)
        {
            Regex pattern = new("[A-F]");

            if (!pattern.IsMatch(calculateCoordinates.GridValue))
            {
                throw new Exception(ErrorMessages.GridValueRowRange);
            }
        }
    }
}
