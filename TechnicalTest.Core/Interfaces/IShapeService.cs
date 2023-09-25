using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Interfaces
{
    public interface IShapeService
    {
        Shape ProcessTriangle(Grid grid, GridValue gridValue);

        GridValue ProcessGridValueFromTriangularShape(Grid grid, Triangle triangle);
    }

    public class IShapeServiceImplementation:IShapeService{
        public GridValue ProcessGridValueFromTriangularShape(Grid grid, Triangle triangle)
        {
            throw new NotImplementedException();
        }

        public Shape ProcessTriangle(Grid grid, GridValue gridValue)
        {
            throw new NotImplementedException();
        }
    }
}