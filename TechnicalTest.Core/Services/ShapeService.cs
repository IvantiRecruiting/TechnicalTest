using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Services
{
    public class ShapeService : IShapeService
    {


        public Shape ProcessTriangle(Grid grid, GridValue gridValue)
        {

            if (IsLeftTriangle(gridValue.Column))
            {
                return new Triangle(CalculateLeftTopLeftVertex(grid, gridValue), CalculateLeftOuterVertex(grid, gridValue), CalculateLeftBottomRightVertex(grid, gridValue));

            }
            else
            {
                return new Triangle(CalculateRightTopLeftVertex(grid, gridValue), CalculateRightOuterVertex(grid, gridValue), CalculateRightBottomRightVertex(grid, gridValue));
            }

        }

        public GridValue ProcessGridValueFromTriangularShape(Grid grid, Triangle triangle)
        {

            int gvRow = GetGridValueRow(grid, triangle);

            int gvColumn = GetGridValueColumn(grid, triangle);

            if (IsLeftTriangleViaCoordinates(triangle))
            {
                gvColumn++;

            }
            else if (IsRightTriangleViaCoordinates(triangle))
            {
                gvRow++;
            }


            return new GridValue(gvRow, gvColumn);
        }


        private static bool IsLeftTriangle(int column)
        {
            return column % 2 != 0;
        }

        private static bool IsLeftTriangleViaCoordinates(Triangle triangle)
        {
            return triangle.BottomRightVertex.Y == triangle.OuterVertex.Y;
        }

        private static bool IsRightTriangleViaCoordinates(Triangle triangle)
        {
            return triangle.BottomRightVertex.X == triangle.OuterVertex.X;
        }



        public static Coordinate CalculateLeftTopLeftVertex(Grid grid, GridValue gridValue)
        {
            return new(gridValue.Column / 2 * grid.Size, (gridValue.GetNumericRow() - 1) * grid.Size);
        }

        public static Coordinate CalculateRightTopLeftVertex(Grid grid, GridValue gridValue)
        {
            return new((gridValue.Column / 2 - 1) * grid.Size, (gridValue.GetNumericRow() - 1) * grid.Size);
        }

        public static Coordinate CalculateLeftOuterVertex(Grid grid, GridValue gridValue)
        {
            return new(gridValue.Column / 2 * grid.Size, gridValue.GetNumericRow() * grid.Size);

        }

        public static Coordinate CalculateRightOuterVertex(Grid grid, GridValue gridValue)
        {
            return new(gridValue.Column / 2 * grid.Size, (gridValue.GetNumericRow() - 1) * grid.Size);
        }

        public static Coordinate CalculateLeftBottomRightVertex(Grid grid, GridValue gridValue)
        {
            return new((gridValue.Column / 2 + 1) * grid.Size, gridValue.GetNumericRow() * grid.Size);
        }

        public static Coordinate CalculateRightBottomRightVertex(Grid grid, GridValue gridValue)
        {
            return new(gridValue.Column / 2 * grid.Size, gridValue.GetNumericRow() * grid.Size);
        }


        public static int GetGridValueRow(Grid grid, Triangle triangle)
        {
            return triangle.OuterVertex.Y / grid.Size;
        }

        public static int GetGridValueColumn(Grid grid, Triangle triangle)
        {
            return triangle.OuterVertex.X / grid.Size * 2;
        }
    }
}