using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth.Data.Repository;
using Auth.Data.Repository.Interfaces;
using Auth.Library.Interfaces;
using Auth.Library.Models;
using Auth.Tests.UnitTests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Auth.Tests.UnitTests
{
    public class RepositoryTests
    {
        
        // yeah I know this test doesn't test the repo particularly well. But I'm working on it
        [Fact]
        public async void MockedAuthUser()
        {
            //Arrange
            var u = new User() { UserName = "test@example.com", ModelId = 1 };
            var userList = new List<User> {u};
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(userList);
            mockRepo.Setup(repo => repo.AuthAsync(u)).ReturnsAsync(true);

            //Act
            var controller = new ClientController(mockRepo.Object);
            var getResult = await controller.Authenticate(u);

            var okObject = getResult as OkObjectResult;
            Assert.NotNull(okObject);
            var taskObject = (Boolean) okObject.Value;

            //Assert
            Assert.True(taskObject);
        }
    }
}