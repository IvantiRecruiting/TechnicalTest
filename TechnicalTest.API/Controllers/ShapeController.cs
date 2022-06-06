using Microsoft.AspNetCore.Mvc;
using TechnicalTest.API.DTOs;
using TechnicalTest.Core;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.API.Controllers
{
    /// <summary>
    /// Shape Controller which is responsible for calculating coordinates and grid value.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ShapeController : ControllerBase
    {
        private readonly IShapeFactory _shapeFactory;

        /// <summary>
        /// Constructor of the Shape Controller.
        /// </summary>
        /// <param name="shapeFactory"></param>
        public ShapeController(IShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
        }

        /// <summary>
        /// Calculates the Coordinates of a shape given the Grid Value.
        /// </summary>
        /// <param name="calculateCoordinatesRequest"></param>   
        /// <returns>A Coordinates response with a list of coordinates.</returns>
        /// <response code="200">Returns the Coordinates response model.</response>
        /// <response code="400">If an error occurred while calculating the Coordinates.</response>   
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Shape))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CalculateCoordinates")]
        [HttpPost]
        public IActionResult CalculateCoordinates([FromBody]CalculateCoordinatesDTO calculateCoordinatesRequest)
        {
            if (calculateCoordinatesRequest.ShapeType != 1) {
                return BadRequest();
            }
            Shape? tri = _shapeFactory.CalculateCoordinates(ShapeEnum.Triangle, new GridValue(calculateCoordinatesRequest.GridValue));
            if (tri == null) {
                return BadRequest(400);
            }
            CalculateCoordinatesResponseDTO response = new CalculateCoordinatesResponseDTO();
            response.Coordinates = tri.Coordinates;
            return Ok(response);
        }

        /// <summary>
        /// Calculates the Grid Value of a shape given the Coordinates.
        /// </summary>
        /// <remarks>
        /// A Triangle Shape must have 3 vertices, in this order: Top Left Vertex, Outer Vertex, Bottom Right Vertex.
        /// </remarks>
        /// <param name="gridValueRequest"></param>   
        /// <returns>A Grid Value response with a Row and a Column.</returns>
        /// <response code="200">Returns the Grid Value response model.</response>
        /// <response code="400">If an error occurred while calculating the Grid Value.</response>   
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GridValue))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CalculateGridValue")]
        [HttpPost]
        public IActionResult CalculateGridValue([FromBody]CalculateGridValueDTO gridValueRequest)
        {
            if (gridValueRequest.ShapeType != 1) {
                return BadRequest();
            }
            Shape shape = new Shape(gridValueRequest.Vertices);
            GridValue? gridVal = _shapeFactory.CalculateGridValue(ShapeEnum.Triangle, shape);
            if (gridVal == null){
                return BadRequest(400);
            }
            CalculateGridValueResponseDTO response = new CalculateGridValueResponseDTO(gridVal.Row, gridVal.Column);
            return Ok(response);
        }
    }
}
