using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Factories
{
    public class ShapeFactory : IShapeFactory
    {
	    private readonly IShapeService _shapeService;

        public ShapeFactory(IShapeService shapeService)
        {
	        _shapeService = shapeService;
        }

        public Shape? CalculateCoordinates(ShapeEnum shapeEnum, Grid grid, GridValue gridValue)
        {
            switch (shapeEnum)
            {
                case ShapeEnum.Triangle:
                    //Returns shape returned from service.
                    return _shapeService.ProcessTriangle(grid, gridValue);
                default:
                    return null;
            }
        }

        public GridValue? CalculateGridValue(ShapeEnum shapeEnum, Grid grid, Shape shape)
        {
            switch (shapeEnum)
            {
                case ShapeEnum.Triangle:

                    if (shape.Coordinates.Count != 3)
                        return null;

                    List<Coordinate> coordinates = shape.Coordinates;

                    //Returns grid value returned from service.
                    return _shapeService.ProcessGridValueFromTriangularShape(grid, new Triangle(coordinates[1], coordinates[2], coordinates[3]));
                default:
                    return null;
            }
        }

        Shape? IShapeFactory.CalculateCoordinates(Grid grid, GridValue gridValue)
        {
            throw new NotImplementedException();
        }
    }
}
