using TechnicalTest.Core.DTOs;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Interfaces
{
    public interface IMappingService
    {
        public Grid ConvertGridDTOtoModel(GridDTO gridDTO);

        public GridValue ConvertStringToGridValue(string value);

        public ShapeEnum ConvertIntToShapeEnum(int number);

        public CalculateCoordinatesResponseDTO ConvertShapeToCoordinateResponseDTO(Shape shape);

        public Shape ConvertVerticesToShape(List<Vertex> vertices); 
    }
}
