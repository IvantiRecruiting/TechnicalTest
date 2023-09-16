using TechnicalTest.Core.DTOs;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Services
{
    public class MappingService : IMappingService
    {
        public Grid ConvertGridDTOtoModel(GridDTO gridDTO)
        {
            return new Grid(gridDTO.Size);
        }

        public GridValue ConvertStringToGridValue(string value)
        {
            return new GridValue(value);
        }

        public ShapeEnum ConvertIntToShapeEnum(int number)
        {
            return (ShapeEnum)number;
        }

        public CalculateCoordinatesResponseDTO ConvertShapeToCoordinateResponseDTO(Shape shape)
        {
            var result = new CalculateCoordinatesResponseDTO
            {
                Coordinates = new List<CalculateCoordinatesResponseDTO.Coordinate>()
            };

            foreach (var coordinate in shape.Coordinates)
            {
                result.Coordinates.Add(new CalculateCoordinatesResponseDTO.Coordinate(coordinate.X, coordinate.Y));
            }

            return result;
        }

        public Shape ConvertVerticesToShape(List<Vertex> vertices)
        {
            var result = new Shape
            {
                Coordinates = new List<Coordinate>()
            };

            foreach (var vertex in vertices)
            {
                result.Coordinates.Add(new Coordinate(vertex.x, vertex.y));
            }

            return result;

        }
    }
}
