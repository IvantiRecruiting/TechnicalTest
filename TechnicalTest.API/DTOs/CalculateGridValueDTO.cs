namespace TechnicalTest.API.DTOs
{
    public class CalculateGridValueDTO
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
