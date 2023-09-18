using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Core;
using TechnicalTest.Core.DTOs;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;
using TechnicalTest.Core.Constants;
using TechnicalTest.Core.Factories;

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
        private readonly IMappingService _mappingService;
        private readonly IValidationHandlerFactory _validationFactory;

        /// <summary>
        /// Constructor of the Shape Controller.
        /// </summary>
        /// <param name="shapeFactory"></param>
        /// <param name="mappingService"></param>
        /// <param name="validationFactory"></param>

        public ShapeController(IShapeFactory shapeFactory, IMappingService mappingService, IValidationHandlerFactory validationFactory)
        {
            _shapeFactory = shapeFactory;
            _mappingService = mappingService;
            _validationFactory = validationFactory;
            
        }

        /// <summary>
        /// Calculates the Coordinates of a shape given the Grid Value.
        /// </summary>
        /// <param name="calculateCoordinatesRequest"></param>   
        /// <returns>A Coordinates response with a list of coordinates.</returns>
        /// <response code="200">Returns the Coordinates response model.</response>
        /// <response code="400">If an error occurred while calculating the Coordinates.</response>   
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CalculateCoordinatesResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CalculateCoordinates")]
        [HttpPost]
        public IActionResult CalculateCoordinates([FromBody] CalculateCoordinatesDTO calculateCoordinatesRequest)
        {

            try
            {
                _validationFactory.GetHandler(calculateCoordinatesRequest).Validate();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            Grid grid = _mappingService.ConvertGridDTOtoModel(calculateCoordinatesRequest.Grid);

            GridValue gridValue = _mappingService.ConvertStringToGridValue(calculateCoordinatesRequest.GridValue);

            ShapeEnum shapeType = _mappingService.ConvertIntToShapeEnum(calculateCoordinatesRequest.ShapeType);

            Shape? shape = _shapeFactory.CalculateCoordinates(shapeType, grid, gridValue);

            if (shape == null)
            {
                return BadRequest(ErrorMessages.NoResult);
            }

            CalculateCoordinatesResponseDTO result = _mappingService.ConvertShapeToCoordinateResponseDTO(shape);

            return Ok(result);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CalculateGridValueResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CalculateGridValue")]
        [HttpPost]
        public IActionResult CalculateGridValue([FromBody] CalculateGridValueDTO gridValueRequest)
        {

            try
            {
                _validationFactory.GetHandler(gridValueRequest).Validate();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            ShapeEnum shapeType = _mappingService.ConvertIntToShapeEnum(gridValueRequest.ShapeType);

         
            Grid grid = _mappingService.ConvertGridDTOtoModel(gridValueRequest.Grid);

            Shape shape = _mappingService.ConvertVerticesToShape(gridValueRequest.Vertices);

            GridValue? gridValue = _shapeFactory.CalculateGridValue(shapeType, grid, shape);

            if (gridValue == null)
            {
                return BadRequest(ErrorMessages.NoResult);
            }

            CalculateGridValueResponseDTO result = _mappingService.ConvertGridValueToGridValueResponseDTO(gridValue);

            return Ok(result);
        }

    }
}
