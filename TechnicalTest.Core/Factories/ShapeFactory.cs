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

        public Shape? CalculateCoordinates(ShapeEnum shapeEnum, GridValue gridValue)
        {
            switch (shapeEnum)
            {
                case ShapeEnum.Triangle:
	                return _shapeService.ProcessTriangle(gridValue);
                default:
                    return null;
            }
        }

        public GridValue? CalculateGridValue(ShapeEnum shapeEnum, Shape shape)
        {
            switch (shapeEnum)
            {
                case ShapeEnum.Triangle:
                    if (shape.Coordinates.Count != 3)
                        return null;
                    else
                        return _shapeService.ProcessGridValueFromTriangularShape((Triangle) shape);
                default:
                    return null;
            }
        }
    }
}
