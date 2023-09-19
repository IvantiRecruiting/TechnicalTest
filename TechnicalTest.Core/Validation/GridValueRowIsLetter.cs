using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Core.Constants;
using TechnicalTest.Core.DTOs;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Validation
{
    public class GridValueRowIsLetter : ICoordinateValidator
    {

        public void Validate(CalculateCoordinatesDTO calculateCoordinates)
        {
            if (!char.IsLetter(calculateCoordinates.GridValue, 0))
            {
                throw new Exception(ErrorMessages.GridValueRowLetter);
            }
        }
    }
}
