using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Core.DTOs
{
    public class CalculateCoordinatesDTO
    {
        [Required]
        [MaxLength(3)]
        [MinLength(2)]
        [DataType(DataType.Text)]
        public string GridValue { get; set; }

        public GridDTO Grid { get; set; }

        [Required]
        public int ShapeType { get; set; }
    }
}
