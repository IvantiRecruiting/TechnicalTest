using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Services
{
    public class ShapeService : IShapeService
    {
        public Shape ProcessTriangle(Grid grid, GridValue gridValue)
        {
            // TODO: Calculate the coordinates.
            return new Shape(new List<Coordinate>
            {
                new(0, 0),
                new(0, 0),
                new(0, 0)
            });
        }

        public GridValue ProcessGridValueFromTriangularShape(Grid grid, Triangle triangle)
        {
            // TODO: Calculate the grid value.
            return new GridValue(0, 0);
        }
    }
}