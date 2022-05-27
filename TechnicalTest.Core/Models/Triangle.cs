namespace TechnicalTest.Core.Models
{
    public class Triangle : Shape
    {
        public Triangle(Coordinate topLeftVertex, Coordinate outerVertex, Coordinate bottomRightVertex)
        {
            Coordinates.AddRange(new List<Coordinate>{topLeftVertex, outerVertex, bottomRightVertex});
            TopLeftVertex = topLeftVertex;
            OuterVertex = outerVertex;
            BottomRightVertex = bottomRightVertex;
        }

        public Coordinate TopLeftVertex { get; set; }
        public Coordinate OuterVertex { get; set; }
        public Coordinate BottomRightVertex { get; set; }
    }
}
