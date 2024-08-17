using AngloEasternBEChallenge.Controllers;
using AngloEasternBEChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestProject
{
    public class ShipControllerTest(TestFixture fixture) : IClassFixture<TestFixture>
    {
        [Fact]
        public async Task GetShips_ShouldReturnShips()
        {
            // Arrange
            var controller = new ShipController();

            // Act
            var actionResult = await controller.GetAllShips();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var returnResult = Assert.IsAssignableFrom<List<MdlShip>>(result.Value);
            Assert.NotNull(returnResult);
            Assert.Contains(returnResult, c => c.Velocity > 10);
        }

        [Fact]
        public async Task GetShip_ShouldReturnShip()
        {
            // Arrange
            var controller = new ShipController();

            // Act
            var actionResult = await controller.GetShip("S01");

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var returnResult = Assert.IsAssignableFrom<MdlShip>(result.Value);
            Assert.NotNull(returnResult);
            Assert.True(returnResult.Velocity > 0);
        }


        [Fact]
        public async Task GetAssignedShips_ShouldReturnShips()
        {
            // Arrange
            var controller = new ShipController();

            // Act
            var actionResult = await controller.GetAssignedShips("Admin");

            // Assert
            var result = actionResult.Result as OkObjectResult;
            if (result != null)
            {
                var returnResult = Assert.IsAssignableFrom<List<MdlShip>>(result.Value);
                Assert.NotNull(returnResult);
            }
        }

        [Fact]
        public async Task GetUnassignedShips_ShouldReturnShips()
        {
            // Arrange
            var controller = new ShipController();

            // Act
            var actionResult = await controller.GetUnassignedShips();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            if (result != null)
            {
                var returnResult = Assert.IsAssignableFrom<List<MdlShip>>(result.Value);
                Assert.Contains(returnResult, c => c.Velocity > 10);
            }
        }

        [Fact]
        public async Task CreateShip_ShouldReturnShip()
        {
            // Arrange
            var controller = new ShipController();

            // Act
            foreach (var ship in fixture.Ships)
            {
                var actionResult = await controller.CreateShip(ship);

                // Assert
                var result = actionResult.Result as OkObjectResult;
                Assert.NotNull(result);
            }           
        }

        [Fact]
        public async Task UpdateAssignedShip_ShouldReturnShip()
        {
            // Arrange
            var controller = new ShipController();

            // Act
            foreach (var ship in fixture.Ships)
            {
                ship.UserCode = fixture.Users.First().UserCode;
                var actionResult = await controller.UpdateAssignedShip(ship.ShipCode, ship.UserCode);

                // Assert
                var result = actionResult.Result as OkObjectResult;
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task UpdateShipVelocity_ShouldReturnShip()
        {
            // Arrange
            var controller = new ShipController();

            // Act
            foreach (var ship in fixture.Ships)
            {
                await controller.CreateShip(ship);
                ship.Velocity += 10;
                var actionResult = await controller.UpdateShipVelocity(ship.ShipCode, ship.Velocity);

                // Assert
                var result = actionResult.Result as OkObjectResult;
                Assert.NotNull(result);
            }
        }
    }
}