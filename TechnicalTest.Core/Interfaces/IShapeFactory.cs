using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Interfaces
{
    public interface IShapeFactory
    {
        Shape? CalculateCoordinates(ShapeEnum shapeEnum, GridValue gridValue);

        GridValue? CalculateGridValue(ShapeEnum shapeEnum, Shape shape);
    }
}
