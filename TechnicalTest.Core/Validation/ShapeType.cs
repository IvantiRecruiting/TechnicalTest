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
    public class ShapeType : IDTOValidator
    {
        public void Validate(IDTO dto)
        {
            switch ((ShapeEnum)dto.ShapeType)
            {
                case ShapeEnum.Triangle:
                    break;
                case ShapeEnum.None:
                default:
                    throw new Exception(ErrorMessages.TriangleImplemented);
            }
        }
    }
}
