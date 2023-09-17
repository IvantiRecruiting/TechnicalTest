using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Core;
using TechnicalTest.Core.DTOs;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;
using TechnicalTest.Core.Constants;

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
        private readonly IValidationService _validationService;



        /// <summary>
        /// Constructor of the Shape Controller.
        /// </summary>
        /// <param name="shapeFactory"></param>
        /// <param name="mappingService"></param>
        /// <param name="validationService"></param>
        public ShapeController(IShapeFactory shapeFactory, IMappingService mappingService, IValidationService validationService)
        {
            _shapeFactory = shapeFactory;
            _mappingService = mappingService;
            _validationService = validationService;
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
            // TODO: Get the ShapeEnum and if it is default (ShapeEnum.None) or not triangle, return BadRequest as only Triangle is implemented yet.

       
            if(!_validationService.ValidateGridValue(calculateCoordinatesRequest.GridValue))
            {
                return BadRequest(ErrorMessages.InvalidGridValue);
            }

            Grid grid = _mappingService.ConvertGridDTOtoModel(calculateCoordinatesRequest.Grid);

            GridValue gridValue = _mappingService.ConvertStringToGridValue(calculateCoordinatesRequest.GridValue);

            ShapeEnum shapeType = _mappingService.ConvertIntToShapeEnum(calculateCoordinatesRequest.ShapeType);

            if (_validationService.ValidateShapeTypeTriangle(shapeType))
            {
                return BadRequest(ErrorMessages.TriangleImplemented);
            }
            // TODO: Call the Calculate function in the shape factory.
            Shape? shape = _shapeFactory.CalculateCoordinates(shapeType, grid, gridValue);

            // TODO: Return BadRequest with error message if the calculate result is null

            if (shape == null)
            {
                return BadRequest(ErrorMessages.NoResult);
            }

            CalculateCoordinatesResponseDTO result = _mappingService.ConvertShapeToCoordinateResponseDTO(shape);


            // TODO: Create ResponseModel with Coordinates and return as OK with responseModel.

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
            // TODO: Get the ShapeEnum and if it is default (ShapeEnum.None) or not triangle, return BadRequest as only Triangle is implemented yet.
            ShapeEnum shapeType = _mappingService.ConvertIntToShapeEnum(gridValueRequest.ShapeType);

            if (_validationService.ValidateShapeTypeTriangle(shapeType))
            {
                return BadRequest(ErrorMessages.TriangleImplemented);
            }

            Grid grid = _mappingService.ConvertGridDTOtoModel(gridValueRequest.Grid);

            // TODO: Create new Shape with coordinates based on the parameters from the DTO.
            Shape shape = _mappingService.ConvertVerticesToShape(gridValueRequest.Vertices);

            // TODO: Call the function in the shape factory to calculate grid value.
            GridValue? gridValue = _shapeFactory.CalculateGridValue(shapeType, grid, shape);

            // TODO: If the GridValue result is null then return BadRequest with an error message.
            
            if(gridValue == null) {
                return BadRequest(ErrorMessages.NoResult);
            }

            // TODO: Generate a ResponseModel based on the result and return it in Ok();

            CalculateGridValueResponseDTO result = _mappingService.ConvertGridValueToGridValueResponseDTO(gridValue);

            return Ok(result);
        }

    }
}
