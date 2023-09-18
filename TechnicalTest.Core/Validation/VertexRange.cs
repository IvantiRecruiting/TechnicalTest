using TechnicalTest.Core.Constants;
using TechnicalTest.Core.DTOs;
using TechnicalTest.Core.Interfaces;

namespace TechnicalTest.Core.Validation
{
    public class VertexRange : IGridValueValidator
    {
        public void Validate(CalculateGridValueDTO calculateGridValue)
        {
            foreach(var vertex in calculateGridValue.Vertices)
            {
                if(vertex.x !>= 0 && vertex.x !<= 60 && vertex.y !>= 0 && vertex.y !<= 60)
                {
                    throw new Exception(ErrorMessages.VertexRange);
                }
            }
        }
    }
}
