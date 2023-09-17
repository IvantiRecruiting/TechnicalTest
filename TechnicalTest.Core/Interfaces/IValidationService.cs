using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Core.Interfaces
{
    public interface IValidationService
    {
        public bool ValidateShapeTypeTriangle(ShapeEnum shapeType);

        public bool ValidateGridValue(string gridValue);

    }
}
