using TechnicalTest.Core.Interfaces;

namespace TechnicalTest.Core.DTOs
{
    public class CalculateGridValueDTO :IDTO
    {
        public GridDTO Grid { get; set; }

        public List<Vertex> Vertices { get; set; }

        public int ShapeType { get; set; }
    }

    public class Vertex
    {
        public int x { get; set; }

        public int y { get; set; }
    }
}
