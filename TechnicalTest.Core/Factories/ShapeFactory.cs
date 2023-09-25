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

        public Shape? CalculateCoordinates(ShapeEnum shapeEnum, Grid grid, GridValue gridValue)//1A
        {
            /*
            */
            switch (shapeEnum)
            {
                case ShapeEnum.Triangle:
                    char letter = char.Parse(gridValue.Row);// get letter
                    int rowNumber = (int)letter - 64;// letter * 10
                    int maxValue = rowNumber * 10, minValue = maxValue - 10;
                    Coordinate beginning = new(minValue, minValue);
                    Coordinate middle;
                    if (gridValue.Column % 2 == 0)
                    {
                        middle = new(maxValue, minValue);//if grid number is even, return (10,0)
                    }
                    else
                    {
                        middle = new(minValue, maxValue);//else return (0,10)
                    }
                    Coordinate end = new(maxValue, maxValue);
                    List<Coordinate> coords = new(){ beginning,middle,end};
                    return new Shape(coords);
                default:
                    return null;
            }
        }

        public GridValue? CalculateGridValue(ShapeEnum shapeEnum, Grid grid, Shape shape)//1B
        {
            /*
                Start by getting letter from y
                0-10 is A (GridValue Row = 1) 
                10-20 is B (GridValue Row = 2)
                ...
                50-60 is F (GridValue Row = 6)

                Lower it down to what number it could be from x
                0-10 could be 1 or 2
                10-20 could be 3 or 4
                ...
                50-60 could be 11 or 12
                (0,0) and (10,10) or equiv belong to both traingles
                (0,10) or equiv belongs to A1 or equiv
                (10, 0) or equic belongs to A2 or equiv
            */
            switch (shapeEnum)
            {
                case ShapeEnum.Triangle:
                    int gridRow = 0, gridRef = 0;
                    if (shape.Coordinates.Count != 3)
                    {
                        return null;
                    }
                    else
                    {
                        Coordinate uniqueCoords = shape.Coordinates[1];
                        gridRow = getGridInfo(uniqueCoords.Y);
                        if (gridRow == 0){
                            return null;
                        }
                        gridRef = getGridInfo(uniqueCoords.X)*2;
                        if (gridRef == 0){
                            return null;
                        }
                        int tenEquivalent = (gridRef / 2) * 10, zeroEquivalent = tenEquivalent - 10;
                        if (uniqueCoords.X == zeroEquivalent && uniqueCoords.Y == tenEquivalent)
                        {
                            gridRef--;
                        }
                        //else do nothing, set to max value which is already met in gridRef
                    }
                    return new GridValue(gridRow, gridRef);
                default:
                    return null;
            }
        }

        public int getGridInfo(int y)
        {
            int gridRow=0;
            if (y > -1 && y < 11)
            {
                gridRow = 1;
            }
            else if (y > 10 && y < 21)
            {
                gridRow = 2;
            }
            else if (y > 20 && y < 31)
            {
                gridRow = 3;
            }
            else if (y > 30 && y < 41)
            {
                gridRow = 4;
            }
            else if (y > 40 && y < 51)
            {
                gridRow = 5;
            }
            else if (y > 50 && y < 61)
            {
                gridRow = 6;
            }
            //I couldn't get switch cases to work
            return gridRow;
        }
    }
}
