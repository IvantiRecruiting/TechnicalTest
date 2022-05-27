namespace TechnicalTest.API.DTOs
{
    public class CalculateGridValueResponseDTO
    {
        public CalculateGridValueResponseDTO(string row, int column)
        {
            Row = row;
            Column = column;
        }

        public string Row { get; set; }

        public int Column { get; set; }
    }
}
