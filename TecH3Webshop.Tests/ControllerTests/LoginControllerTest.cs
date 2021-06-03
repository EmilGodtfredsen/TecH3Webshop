using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecH3Webshop.Api.Controllers;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Services;
using Xunit;

namespace TecH3Webshop.Tests.ControllerTests
{
    public class LoginControllerTest
    {
        private readonly LoginController _sut;
        private readonly Mock<ILoginService> _loginServiceMock = new();

        public LoginControllerTest()
        {
            _sut = new LoginController(_loginServiceMock.Object);
        }

        [Fact]
        public async Task GetAllLogins_ShouldReturnStatusCode_200_IfDataIsPresent()
        {

            // Arrange
            List<Login> logins = new List<Login>();
            logins.Add(new Login());
            logins.Add(new Login());
            logins.Add(new Login());

            _loginServiceMock
                .Setup(x => x.GetAll())
                .ReturnsAsync(logins);
            // Act
            var res = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)res;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task GetAllLogins_ShouldReturnStatusCode204NoContent_WhenNoDataIsPresent()
        {
            // Arrange
            List<Login> logins = new List<Login>();
            _loginServiceMock
                .Setup(x => x.GetAll())
                .ReturnsAsync(logins);
            // Act
            var res = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)res;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task GetAllLogins_ShouldReturnStatusCode500InternalServerError_WhenDataIsNull()
        {
            // Arrange
            List<Login> logins = null;
            _loginServiceMock
               .Setup(x => x.GetAll())
               .ReturnsAsync(logins);
            // Act
            var res = await _sut.GetAll();
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)res;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task GetLoginByEmail_ShouldReturnStatusCode200Ok_WhenTheLoginExists()
        {
            // Arrange
            Login mockLogin = new Login
            {
                Id = 1,
                Email = "emil@hotmail.com",
                Password = "123456",
                FirstName = "Emil",
                LastName = "Godtfredsen",
                Role = 10,
                Address =
                {
                    Id = 1,
                    Street = "Porsevænget",
                    House = "47",
                    Zipcode = 2800,
                    City = "Kgs. Lyngby",
                    Country = "Danmark"
                }
            };
            _loginServiceMock
               .Setup(x => x.GetByEmail(mockLogin.Email))
               .ReturnsAsync(mockLogin);
            // Act
            var res = await _sut.Get(mockLogin.Email);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)res;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task GetLoginByEmail_ShouldReturnStatusCode404NotFoubnd_WhenTheLoginIsNull()
        {
            // Arrange
            Login mockLogin = new Login
            {
                Id = 1,
                Email = "emil@hotmail.com",
                Password = "123456",
                FirstName = "Emil",
                LastName = "Godtfredsen",
                Role = 10,
                Address =
                {
                    Id = 1,
                    Street = "Porsevænget",
                    House = "47",
                    Zipcode = 2800,
                    City = "Kgs. Lyngby",
                    Country = "Danmark"
                }
            };
            _loginServiceMock
               .Setup(x => x.GetByEmail(mockLogin.Email))
               .ReturnsAsync(mockLogin);
            // Act
            var res = await _sut.Get("Something@email.com");
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)res;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task CreateLogin_ShouldReturnStatusCode200Ok_WhenLoginSuccessfullyCreated()
        {
            // Arrange
            Login mockLogin = new Login
            {
                Id = 1,
                Email = "emil@hotmail.com",
                Password = "123456",
                FirstName = "Emil",
                LastName = "Godtfredsen",
                Role = 10,
                Address =
                {
                    Id = 1,
                    Street = "Porsevænget",
                    House = "47",
                    Zipcode = 2800,
                    City = "Kgs. Lyngby",
                    Country = "Danmark"
                }
            };
            _loginServiceMock
               .Setup(x => x.Create(mockLogin))
               .ReturnsAsync(mockLogin);

            // Act

            var res = await _sut.Create(mockLogin);

            // Assert

            var statusCodeResult = (IStatusCodeActionResult)res;

            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task CreateLogin_ShouldReturnStatusCode400BadRequest_WhenLoginIsNull()
        {
            // Arrange
            Login mockLogin = null;
            _loginServiceMock
               .Setup(x => x.Create(mockLogin))
               .ReturnsAsync(mockLogin);

            // Act

            var res = await _sut.Create(mockLogin);

            // Assert

            var statusCodeResult = (IStatusCodeActionResult)res;

            Assert.Equal(400, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task UpdateLogin_ShouldReturnStatusCode200Ok_WhenLoginSuccessfullyUpdated()
        {
            // Arrange
            string updateEmail = "emil@hotmail.com";

            Login mockLogin = new Login
            {
                Id = 1,
                Email = "emil@hotmail.com",
                Password = "123456",
                FirstName = "Emil",
                LastName = "Godtfredsen",
                Role = 10,
                Address =
                {
                    Id = 1,
                    Street = "Porsevænget",
                    House = "47",
                    Zipcode = 2800,
                    City = "Kgs. Lyngby",
                    Country = "Danmark"
                }
            };
            _loginServiceMock
               .Setup(x => x.Update(updateEmail, mockLogin))
               .ReturnsAsync(mockLogin);

            // Act

            var res = await _sut.Update(updateEmail, mockLogin);

            // Assert

            var statusCodeResult = (IStatusCodeActionResult)res;

            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task UpdateLogin_ShouldReturnStatusCode404BadRequest_WhenLoginIsNull()
        {
            // Arrange
            string updateEmail = "emil@hotmail.com";

            Login mockLogin = null;
            
            _loginServiceMock
               .Setup(x => x.Update(updateEmail, mockLogin))
               .ReturnsAsync(mockLogin);

            // Act

            var res = await _sut.Update(updateEmail, mockLogin);

            // Assert

            var statusCodeResult = (IStatusCodeActionResult)res;

            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task DeleteLogin_ShouldReturnStatusCode200Ok_WhenLoginSuccesfullyDeleted()
        {
            int deleteId = 1;
            // Arrange
            Login mockLogin = new Login
            {
                Id = 1,
                Email = "emil@hotmail.com",
                Password = "123456",
                FirstName = "Emil",
                LastName = "Godtfredsen",
                Role = 10,
                Address =
                {
                    Id = 1,
                    Street = "Porsevænget",
                    House = "47",
                    Zipcode = 2800,
                    City = "Kgs. Lyngby",
                    Country = "Danmark"
                }
            };
            _loginServiceMock
                .Setup(x => x.Delete(deleteId))
                .ReturnsAsync(mockLogin);
            // Act
            var res = await _sut.Delete(deleteId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)res;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task DeleteAuthor_ShouldReturnStatusCode404NotFound_WhenAuthorIsNull()
        {
            int deleteId = 2;
            // Arrange
            Login mockLogin = null;
            _loginServiceMock
                .Setup(x => x.Delete(deleteId))
                .ReturnsAsync(mockLogin);
            // Act
            var res = await _sut.Delete(deleteId);
            // Assert
            var statusCodeResult = (IStatusCodeActionResult)res;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
    }
}
