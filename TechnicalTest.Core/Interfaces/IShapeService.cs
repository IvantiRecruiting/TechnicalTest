using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Interfaces
{
    public interface IShapeService
    {
        Shape ProcessTriangle(Grid grid, GridValue gridValue);

        GridValue ProcessGridValueFromTriangularShape(Grid grid, Triangle triangle);
    }
}