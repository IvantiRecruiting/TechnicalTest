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
                    // TODO: Return shape returned from service.
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
                    // TODO: RM Move this check elsewhere it shouldn't be in a calculate value method
                    if (shape.Coordinates.Count != 3)
                        return null;

                    var triangle = new Triangle(shape.Coordinates[0], shape.Coordinates[1], shape.Coordinates[2]);

                    // TODO: Return grid value returned from service.
                    return _shapeService.ProcessGridValueFromTriangularShape(grid, triangle);
                default:
                    return null;
            }
        }
    }
}
