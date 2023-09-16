using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Services
{
    public class ShapeService : IShapeService
    {
        

        public Shape ProcessTriangle(Grid grid, GridValue gridValue)
        {
            // TODO: Calculate the coordinates.

            // TODO: determine if triangle is left or right triangle based on column

            if(IsLeftTriangle(gridValue.Column))
            {
                return new Triangle(CalculateLeftTopLeftVertex(grid, gridValue), CalculateLeftOuterVertex(grid, gridValue), CalculateLeftBottomRightVertex(grid, gridValue));
            }



            return null;

            //return new Shape(new List<Coordinate>
            //{
            //    new(0, 0),
            //    new(0, 0),
            //    new(0, 0)
            //});
        }

        public GridValue ProcessGridValueFromTriangularShape(Grid grid, Triangle triangle)
        {
            // TODO: Calculate the grid value.
            return new GridValue(0, 0);
        }

   
        private static bool IsLeftTriangle(int column)
        {
            return column % 2 != 0;
        }

        
        public Coordinate CalculateLeftTopLeftVertex(Grid grid, GridValue gridValue)
        {
           return new Coordinate(gridValue.Column / 2 * grid.Size, (gridValue.GetNumericRow() - 1) * grid.Size);
        }

        public Coordinate CalculateLeftOuterVertex(Grid grid, GridValue gridValue)
        {
            return new Coordinate(gridValue.Column / 2 * grid.Size, gridValue.GetNumericRow() * grid.Size);

        }
        public Coordinate CalculateLeftBottomRightVertex(Grid grid, GridValue gridValue)
        {
            return new Coordinate((gridValue.Column / 2 + 1) * grid.Size, gridValue.GetNumericRow() * grid.Size);
        }
    }
}