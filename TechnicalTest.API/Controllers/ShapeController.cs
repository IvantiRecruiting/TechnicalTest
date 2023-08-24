using System;
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

            //Get the ShapeEnum and if it is default (ShapeEnum.None) or not triangle, return BadRequest as only Triangle is implemented yet.

            ShapeEnum ShapeResult = (ShapeEnum)calculateCoordinatesRequest.ShapeType;

            if (ShapeResult == ShapeEnum.None || ShapeResult != ShapeEnum.Triangle)
            {
                return BadRequest("shape returned as none or not a triangle");
            }


            //Call the Calculate function in the shape factory.

            Grid grid = new Grid(calculateCoordinatesRequest.Grid.Size);
            GridValue gridValue = new GridValue(calculateCoordinatesRequest.GridValue);
            ShapeEnum shapeEnum = new ShapeEnum();


            Shape? shape = _shapeFactory.CalculateCoordinates(shapeEnum,  grid,  gridValue);


            //Return BadRequest with error message if the calculate result is null

            if (shape == null || grid == null || gridValue == null)
            {
                return BadRequest("result cannot be null");
            } 

            //Create ResponseModel with Coordinates and return as OK with responseModel.

            return Ok(shape.Coordinates);
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
            //Get the ShapeEnum and if it is default (ShapeEnum.None) or not triangle, return BadRequest as only Triangle is implemented yet.

            ShapeEnum shapeEnumResult = (ShapeEnum)gridValueRequest.ShapeType;
            
            if (shapeEnumResult == ShapeEnum.None || shapeEnumResult != ShapeEnum.Triangle)
            {
                return BadRequest("ERROR Only Triangle is implemented so far");
            }

            //Create new Shape with coordinates based on the parameters from the dto

            List<Coordinate> coordinates = new();
            foreach (Vertex v in gridValueRequest.Vertices)
            {
                coordinates.Add(new(v.x, v.y));
            }



            //Call the function in the shape factory to calculate grid value.

            Shape shape = new(coordinates);

            GridValue? gridValue = _shapeFactory.CalculateGridValue(shapeEnumResult, new Grid(gridValueRequest.Grid.Size), shape);

            //If the GridValue result is null then return BadRequest with an error message.

            if (gridValue == null)
            {
                return BadRequest("ERROR GridValue cannot be NULL");
            }

            //Generate a ResponseModel based on the result and return it in Ok();


            return Ok(new CalculateGridValueResponseDTO(gridValue.Row, gridValue.Column));
        }
    }
}
