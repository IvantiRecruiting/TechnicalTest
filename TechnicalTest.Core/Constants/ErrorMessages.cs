using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest.Core.Constants
{
    public static class ErrorMessages
    {
        public const string TriangleImplemented = "Only a Triangle is currently implemented";

        public const string NoResult = "Unable to calculate result";

        public const string InvalidGridValue = "Invalid Grid Value";

        public const string GridValueRowRange = "The first character in a GridValue must be in a range of (A-F)";

        public const string GridValueRowLetter = "The first character in the GridValue property must be a letter";

        public const string GridValueColumnRange = "GridValue second and optional third character must be in a range of (1-12)";

        public const string GridValueColumnNumber = "The GridValue second and optional third character must be a number";

        public const string VertexRange = "Each vertex must be in a range of (0-60)";
    }
}
