using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Interfaces
{
    public interface IShapeService
    {
        Shape ProcessTriangle(GridValue gridValue);

        GridValue ProcessGridValueFromTriangularShape(Triangle triangle);
    }
}