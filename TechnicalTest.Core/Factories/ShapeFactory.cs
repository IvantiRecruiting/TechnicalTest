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
                    //Return shape returned from service.
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
                    List<Coordinate> coordinates = shape.Coordinates;
                    if (coordinates.Count != 3)
                        return null;
                    //Return grid value returned from service.
                    return _shapeService.ProcessGridValueFromTriangularShape(grid, new Triangle(coordinates[0], coordinates[1], coordinates[2]));
                default:
                    return null;
            }
        }
    }
}
