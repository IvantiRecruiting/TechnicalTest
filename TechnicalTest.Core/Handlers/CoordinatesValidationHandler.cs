using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Core.DTOs;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Validation;

namespace TechnicalTest.Core.Handlers
{
    public class CoordinatesValidationHandler : IValidationHandler
    {
        private CalculateCoordinatesDTO _dto;
        public CoordinatesValidationHandler(CalculateCoordinatesDTO dto)
        {
            _dto = dto;
        }


        public List<IDTOValidator> commonValidators = new()
        {
            new ShapeType()
        };

        public List<ICoordinateValidator> validators = new()
        {
            new GridValueRowIsLetter(),
            new GridValueRowRange(),
            new GridValueColumnIsNumber(),
            new GridValueColumnRange(),
        };

        public void Validate()
        {
            foreach (var validator in commonValidators)
            {
                validator.Validate(_dto);
            }

            foreach (var validator in validators)
            {
                validator.Validate(_dto);
            }
        }
    }
}
