using AngloEasternBEChallenge.Controllers;
using AngloEasternBEChallenge.Models;
using AngloEasternBEChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace TestProject
{
    public class UserControllerTest(TestFixture fixture) : IClassFixture<TestFixture>
    {
        [Fact]
        public async Task GetUsers_ShouldReturnUsers()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var actionResult = await controller.GetAllUsers();

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var returnResult = Assert.IsAssignableFrom<List<MdlUser>>(result.Value);
            Assert.NotNull(returnResult);
        }

        [Fact]
        public async Task GetUser_ShouldReturnUser()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var actionResult = await controller.GetUser("Admin1");

            // Assert
            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            var returnResult = Assert.IsAssignableFrom<MdlUser>(result.Value);
            Assert.NotNull(returnResult);
        }

        [Fact]
        public async Task CreateUser_ShouldReturnUser()
        {
            // Arrange
            var controller = new UserController();

            // Act
            foreach (var user in fixture.Users)
            {
                var actionResult = await controller.CreateUser(user);

                // Assert
                var result = actionResult.Result as OkObjectResult;
                Assert.NotNull(result);
            }
        }
    }
}