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
    public class CalculateGridValueValidationHandler : IValidationHandler
    {
        private CalculateGridValueDTO _dto;

        public CalculateGridValueValidationHandler(CalculateGridValueDTO dto)
        {
            _dto = dto;
        }



        public List<IDTOValidator> commonValidators = new()
        {
            new ShapeType()
        };


        public List<IGridValueValidator> validators = new()
        {
            new VertexRange()
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
