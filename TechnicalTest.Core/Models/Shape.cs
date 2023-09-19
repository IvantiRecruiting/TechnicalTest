using TechnicalTest.Core.Interfaces;

namespace TechnicalTest.Core.Models
{
    public class Shape : IModel
    {
        public Shape(List<Coordinate> coordinates)
        {
            Coordinates = coordinates;
        }

        public Shape()
        {
            Coordinates = new List<Coordinate>();
        }

        public List<Coordinate> Coordinates { get; set; }
    }
}
