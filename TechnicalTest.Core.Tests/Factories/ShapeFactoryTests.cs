using Moq;
using TechnicalTest.Core.Factories;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;
using Xunit;

namespace TechnicalTest.Core.Tests.Factories
{
    public class ShapeServiceTests
    {
        private readonly Mock<IShapeService> _shapeService = new();

        [Fact]
        public void GivenGridValueIsA1WhenCalculatingCoordinatesThenResultIsValid()
        {
            var expectedResult = new Shape(new List<Coordinate>
            {
                new(0, 0),
                new(0, 10),
                new(10, 10)
            });

            var grid = new Grid(10);
            var gridValue = new GridValue("A1");
            var shapeEnum = ShapeEnum.Triangle;

            _shapeService.Setup(x => x.ProcessTriangle(It.IsAny<Grid>(), It.IsAny<GridValue>()))
                .Returns(expectedResult);
            var shapeFactory = new ShapeFactory(_shapeService.Object);
            var actualResult = shapeFactory.CalculateCoordinates(shapeEnum, grid, gridValue);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GivenGridValueIsA1WhenCalculatingCoordinatesThenProcessLeftSidedTriangleIsCalled()
        {
            var expectedResult = new Shape(new List<Coordinate>
            {
                new(0, 0),
                new(0, 10),
                new(10, 10)
            });

            var grid = new Grid(10);
            var gridValue = new GridValue("A1");
            var shapeEnum = ShapeEnum.Triangle;

            _shapeService.Setup(x => x.ProcessTriangle(It.IsAny<Grid>(), It.IsAny<GridValue>()))
                .Returns(expectedResult);
            var shapeFactory = new ShapeFactory(_shapeService.Object);
            shapeFactory.CalculateCoordinates(shapeEnum, grid, gridValue);

            _shapeService.Verify(x => x.ProcessTriangle(grid, gridValue));
            _shapeService.VerifyNoOtherCalls();
        }

        [Fact]
        public void GivenGridValueIsA2WhenCalculatingCoordinatesThenResultIsValid()
        {
            var expectedResult = new Shape(new List<Coordinate>
            {
                new(0, 0),
                new(10, 10),
                new(10, 10)
            });

            var grid = new Grid(10);
            var gridValue = new GridValue("A2");
            var shapeEnum = ShapeEnum.Triangle;

            _shapeService.Setup(x => x.ProcessTriangle(It.IsAny<Grid>(), It.IsAny<GridValue>()))
                .Returns(expectedResult);
            var shapeFactory = new ShapeFactory(_shapeService.Object);
            var actualResult = shapeFactory.CalculateCoordinates(shapeEnum, grid, gridValue);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GivenGridValueIsA2WhenCalculatingCoordinatesThenProcessRightSidedTriangleIsCalled()
        {
            var expectedResult = new Shape(new List<Coordinate>
            {
                new(0, 0),
                new(10, 10),
                new(10, 10)
            });

            var grid = new Grid(10);
            var gridValue = new GridValue("A2");
            var shapeEnum = ShapeEnum.Triangle;

            _shapeService.Setup(x => x.ProcessTriangle(It.IsAny<Grid>(), It.IsAny<GridValue>()))
                .Returns(expectedResult);
            var shapeFactory = new ShapeFactory(_shapeService.Object);
            shapeFactory.CalculateCoordinates(shapeEnum, grid, gridValue);

            _shapeService.Verify(x => x.ProcessTriangle(grid, gridValue));
            _shapeService.VerifyNoOtherCalls();
        }

        [Fact]
        public void GivenShapeIsNotTriangleWhenCalculatingCoordinatesThenShapeIsNull()
        {
            var grid = new Grid(10);
            var gridValue = new GridValue("A2");
            var shapeEnum = ShapeEnum.Other;

            var shapeFactory = new ShapeFactory(_shapeService.Object);
            var actualResult = shapeFactory.CalculateCoordinates(shapeEnum, grid, gridValue);

            Assert.Null(actualResult);
            _shapeService.VerifyNoOtherCalls();
        }

        [Fact]
        public void GivenShapeIsNotProvidedWhenCalculatingCoordinatesThenShapeIsNull()
        {
            var grid = new Grid(10);
            var gridValue = new GridValue("A2");
            var shapeEnum = ShapeEnum.None;

            var shapeFactory = new ShapeFactory(_shapeService.Object);
            var actualResult = shapeFactory.CalculateCoordinates(shapeEnum, grid, gridValue);

            Assert.Null(actualResult);
            _shapeService.VerifyNoOtherCalls();
        }

        [Fact]
        public void GivenA1TriangleCoordinatesWhenCalculatingGridValueThenGridValueIsNotNullAndA1()
        {
            var expectedResult = new GridValue("A1");
            var grid = new Grid(10);
            var shape = new Shape(new List<Coordinate> { new(0, 0), new(0, 0), new(10, 10) });
            var shapeEnum = ShapeEnum.Triangle;

            _shapeService.Setup(x => x.ProcessGridValueFromTriangularShape(It.IsAny<Grid>(), It.IsAny<Triangle>()))
                .Returns(expectedResult);

            var shapeFactory = new ShapeFactory(_shapeService.Object);
            var actualResult = shapeFactory.CalculateGridValue(shapeEnum, grid, shape);

            Assert.NotNull(actualResult);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GivenShapeIsNotTriangleWhenCalculatingGridValueThenGridValueIsNull()
        {
            var grid = new Grid(10);
            var shape = new Shape(new List<Coordinate> { new(0, 0), new(0, 0), new(10, 10) });
            var shapeEnum = ShapeEnum.Other;

            var shapeFactory = new ShapeFactory(_shapeService.Object);
            var actualResult = shapeFactory.CalculateGridValue(shapeEnum, grid, shape);

            Assert.Null(actualResult);
            _shapeService.VerifyNoOtherCalls();
        }

        [Fact]
        public void GivenShapeIsTriangleButHas4VerticesWhenCalculatingGridValueThenGridValueIsNull()
        {
            var grid = new Grid(10);
            var shape = new Shape(new List<Coordinate> { new(0, 0), new(0, 0), new(0, 0), new(10, 10) });
            var shapeEnum = ShapeEnum.Triangle;

            var shapeFactory = new ShapeFactory(_shapeService.Object);
            var actualResult = shapeFactory.CalculateGridValue(shapeEnum, grid, shape);

            Assert.Null(actualResult);
            _shapeService.VerifyNoOtherCalls();
        }
    }
}
