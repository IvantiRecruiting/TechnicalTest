using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Interfaces
{
    public interface IShapeFactory
    {
        Shape? CalculateCoordinates(ShapeEnum shapeEnum, Grid grid, GridValue gridValue);

        GridValue? CalculateGridValue(ShapeEnum shapeEnum, Grid grid, Shape shape);
    }
}
