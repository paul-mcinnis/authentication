using System.Collections.Generic;
using Auth.API.Controllers;
using Auth.Data.Repository.Interfaces;
using Auth.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Auth.Tests.UnitTests.Library
{
    public class InputValidationTest
    {
        [Theory]
        [InlineData("123")]
        [InlineData("aaa")]
        [InlineData("test@example.com")]
        [InlineData("a")]
        public async void UserAcceptsValidInput(string username)
        {
            // arrange
            var u = new User(){UserName = username};
            
            //act
            Assert.NotNull(u.UserName);
        }
    }
}