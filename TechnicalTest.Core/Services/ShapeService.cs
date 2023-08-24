using System;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Services
{
    public class ShapeService : IShapeService

    {

        public Shape ProcessTriangle(Grid grid, GridValue gridValue)
        {
            //Calculate the coordinates.

            Coordinate topLeftVortex;
            Coordinate outerVertex;
            Coordinate bottomVertex;


            //calculate left triangle
            if (gridValue.Column % 2 != 0)
            {
                topLeftVortex = new Coordinate(gridValue.Column / 2 * grid.Size, (gridValue.GetNumericRow() - 1) * grid.Size);
                outerVertex = new Coordinate(gridValue.Column / 2 * grid.Size, gridValue.GetNumericRow() * grid.Size);
                bottomVertex = new Coordinate((gridValue.Column / 2 + 1) * grid.Size, gridValue.GetNumericRow() * grid.Size);
            } else //calculate right triangle
            {
                topLeftVortex = new((gridValue.Column / 2 - 1) * grid.Size, (gridValue.GetNumericRow() - 1) * grid.Size);
                outerVertex = new(gridValue.Column / 2 * grid.Size, (gridValue.GetNumericRow() - 1) * grid.Size);
                bottomVertex = new(gridValue.Column / 2 * grid.Size, gridValue.GetNumericRow() * grid.Size);
            }

            return new Shape(new List<Coordinate>
            {
                topLeftVortex,
                outerVertex,
                bottomVertex,
            });
        }

        public GridValue ProcessGridValueFromTriangularShape(Grid grid, Triangle triangle)
        {
            // Calculate the grid value.
            Coordinate OuterVertex = triangle.OuterVertex;
            Coordinate BottomRightVertex = triangle.BottomRightVertex;

            // OuterVertex as the base point,BottomRightVertex is used to decided whether it is left or right triangle
            int row = OuterVertex.Y / grid.Size;
            int col = OuterVertex.X / grid.Size * 2;


            // process left triangle
            if (BottomRightVertex.Y == OuterVertex.Y)
            {
                col++;
            }
            // process right triangle
            if (BottomRightVertex.X == OuterVertex.X)
            {
                row++;
            }

            return new GridValue(row, col);
        }
    }

   
}