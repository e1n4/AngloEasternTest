using AngloEasternBEChallenge.Controllers;
using AngloEasternBEChallenge.Interfaces;
using AngloEasternBEChallenge.Models;
using AngloEasternBEChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class SeaPortControllerTest(TestFixture fixture) : IClassFixture<TestFixture>
    {
        [Fact]
        public async Task GetClosestPortAndEstimatedArrivalTime_ShouldReturnValue()
        {
            // Arrange
            var shipMock = new Mock<IShip>();
            var seaportMock = new Mock<ISeaPort>();

            shipMock.Setup(x => x.GetAllShips());
            seaportMock.Setup(x => x.GetAllSeaPorts());

            var controller = new SeaPortController(seaportMock.Object, shipMock.Object);

            // Act
            foreach (var ship in fixture.Ships)
            {
                var actionResult = await controller.GetClosestPortAndEstimatedArrivalTime(ship.ShipCode);

                // Assert
                var result = actionResult.ExecuteResult;
                Assert.NotNull(result);
            }
        }
    }
}
