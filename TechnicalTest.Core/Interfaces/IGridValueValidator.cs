using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest.Core.DTOs;

namespace TechnicalTest.Core.Interfaces
{
    public interface IGridValueValidator
    {
        public void Validate(CalculateGridValueDTO calculateGridValue);
    }
}
