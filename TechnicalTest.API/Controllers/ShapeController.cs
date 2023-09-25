using Microsoft.AspNetCore.Mvc;
using TechnicalTest.API.DTOs;
using TechnicalTest.Core;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;
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
            // TODO: Get the ShapeEnum and if it is default (ShapeEnum.None) or not triangle, return BadRequest as only Triangle is implemented yet.

            // TODO: Call the Calculate function in the shape factory.

            // TODO: Return BadRequest with error message if the calculate result is null

            // TODO: Create ResponseModel with Coordinates and return as OK with responseModel.

            return Ok();
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
	        if (gridValueRequest.ShapeType != 1){ // TODO: Get the ShapeEnum and if it is default (ShapeEnum.None) or not triangle, return BadRequest as only Triangle is implemented yet.
                var response = new ResponseModel<String>("Not a triangle");
                return BadRequest(response);
                }
            ShapeEnum sE = ShapeEnum.Triangle;
            //else continue
            if (gridValueRequest.Vertices.Count() != 3){
                var response = new ResponseModel<String>("Doesn't have three sides");
                return BadRequest(response);
            }
            List<Coordinate> c = new List<Coordinate>();
            foreach (Vertex v in gridValueRequest.Vertices){
                Coordinate n = new Coordinate(v.x,v.y);
                c.Add(n);
            }
            Shape s = new Shape(c);// TODO: Create new Shape with coordinates based on the parameters from the DTO.
            
            IShapeService shapeService;
            shapeService = new IShapeServiceImplementation();
            ShapeFactory sf = new ShapeFactory(shapeService);// TODO: Call the function in the shape factory to calculate grid value.
            GridValue g = sf.CalculateGridValue(sE, new Grid(gridValueRequest.Grid.Size), s);
            // TODO: If the GridValue result is null then return BadRequest with an error message.
            if(g == null){
                var response = new ResponseModel<String>("Not succesful");
                return BadRequest();
            }
            // TODO: Generate a ResponseModel based on the result and return it in Ok();
            var successResponse = new ResponseModel<GridValue>(g);
            return Ok(successResponse);
        }
    }

    public class ResponseModel<T>{
        public bool Success {get; set;}
        public T Data {get;set;}
        public String message{get;set;}

        public ResponseModel(T data){
        Success = true;
        Data = data;
        }

        public ResponseModel(String m){
            Success = false;
            message = m;
        }
    }
}
