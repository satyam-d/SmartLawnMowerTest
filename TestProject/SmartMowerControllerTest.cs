using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using SmartLawnMower.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace SmartMowerTestProject
{
    public class SmartMowerControllerTest
    {
        private MowingService _testMowerService = null;
        public SmartMowerControllerTest()
        {
            if (_testMowerService == null)
            {
                _testMowerService = new MowingService();
            }
        }
        [Fact]
        public void Test_Anticlockwise_NorthEdge_Positive()
        {
            SmartMower testSmartMower = new SmartMower();
            Coordinates testCoordinate = new Coordinates();

            testCoordinate.orientation = Orientation.North;
            testCoordinate.x = 2;
            testCoordinate.y = 3;

            Lawn testLawnDim = new Lawn();

            testLawnDim.length = 4;
            testLawnDim.width = 3;

            testSmartMower.coordinate = testCoordinate;
            testSmartMower.lawnDimensions = testLawnDim;
            var result = _testMowerService.turnAntiClockwise(testSmartMower);
            Assert.Equal(Orientation.West, result.orientation);
        }

        [Fact]
        public void Test_Anticlockwise_SouthEdge_Positive()
        {
            SmartMower testSmartMower = new SmartMower();
            Coordinates testCoordinate = new Coordinates();

            testCoordinate.orientation = Orientation.North;
            testCoordinate.x = 2;
            testCoordinate.y = 3;

            Lawn testLawnDim = new Lawn();

            testLawnDim.length = 4;
            testLawnDim.width = 3;

            testSmartMower.coordinate = testCoordinate;
            testSmartMower.lawnDimensions = testLawnDim;
            var result = _testMowerService.turnAntiClockwise(testSmartMower);
            Assert.Equal(Orientation.West, result.orientation);
        }
        [Theory]
        [MemberData(nameof(MoveMowerPositiveData))]
        public void Test_MoveMower_Positive(SmartMower testSmartMowerObj, Coordinates coordExpected)
        {
            var result = _testMowerService.moveMower(testSmartMowerObj);
            Assert.True(result.x==coordExpected.x && result.y == coordExpected.y && result.orientation == coordExpected.orientation);
        }

        [Theory]
        [MemberData(nameof(MoveMowerNegativeData))]
        public void Test_MoveMower_Negative(SmartMower testSmartMowerObj)
        {
            var controller = new LawnMowerController(_testMowerService);
            IActionResult response = controller.MoveMower(testSmartMowerObj);
            Assert.Equal(400, (response as ObjectResult)?.StatusCode);
        }

        public static IEnumerable<object[]> MoveMowerPositiveData =>
        new List<object[]>
        {
            new object[]{ new SmartMower(new Coordinates(2,2,Orientation.North),new Lawn(4,4)),new Coordinates(2,3,Orientation.North) },
            new object[]{ new SmartMower(new Coordinates(2,3,Orientation.East),new Lawn(4,4)) ,new Coordinates(3,3,Orientation.East) },
            new object[]{ new SmartMower(new Coordinates(2,3,Orientation.West),new Lawn(4,4)), new Coordinates(1, 3, Orientation.West) },
            new object[]{ new SmartMower(new Coordinates(2,3,Orientation.South),new Lawn(4,4)), new Coordinates(2, 2, Orientation.South) }
        };

        public static IEnumerable<object[]> MoveMowerNegativeData =>
        new List<object[]>
        {
            new object[]{ new SmartMower(new Coordinates(0,3,Orientation.North),new Lawn(2,3)) },
            new object[]{ new SmartMower(new Coordinates(0,3,Orientation.West),new Lawn(2,3)) },
            new object[]{ new SmartMower(new Coordinates(4,3,Orientation.East),new Lawn(4,3)) },
            new object[]{ new SmartMower(new Coordinates(4,0,Orientation.South),new Lawn(4,3))}
        };
    }
}
