using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Services
{
    public class ShapeService : IShapeService
    {
        public Shape ProcessTriangle(GridValue gridValue)
        {
            int x = gridValue.GetNumericRow()*10;
            int y = 0;
            if (gridValue.Column % 2 == 0) {
                y = gridValue.Column*5;
            }
            else {
                y = (gridValue.Column+1)*5;
            }
            return new Shape(new List<Coordinate>
            {
                new(x-10, y-10),
                new(x-10, y),
                new(x, y)
            });
        }

        public GridValue ProcessGridValueFromTriangularShape(Triangle triangle)
        {
            int row = triangle.BottomRightVertex.X/10;
            int column = 0;
            if (triangle.BottomRightVertex.Y % 2 == 0){
                column = triangle.BottomRightVertex.Y/20;
            }
            else {
                column = (triangle.BottomRightVertex.Y + 1)/20;
            }
            return new GridValue(row, column);
        }
    }
}