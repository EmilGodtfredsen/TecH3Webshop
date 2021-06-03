using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Repositories;
using TecH3Webshop.Api.Services;
using Xunit;

namespace TecH3Webshop.Tests.ServiceTests
{
    public class LoginServiceTests
    {
        private readonly LoginService _sut;
        private readonly Mock<ILoginRepository> _loginRepositoryMock = new();

        public LoginServiceTests()
        {
            _sut = new LoginService(_loginRepositoryMock.Object);
        }
        [Fact]
        public async Task GetAllLogins_ShouldReturnListOfLogins_WhenListOfLoginsExist()
        {
            // Arrange
            List<Login> mockLoginList = new List<Login>
            {
                new Login
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
                },
                new Login
                {
                    Id = 2,
                    Email = "emil2@hotmail.com",
                    Password = "123456",
                    FirstName = "Emil2",
                    LastName = "Godtfredsen",
                    Role = 10,
                    Address =
                    {
                        Id = 2,
                        Street = "Porsevænget",
                        House = "47",
                        Zipcode = 2800,
                        City = "Kgs. Lyngby",
                        Country = "Danmark"
                    }
                },
                new Login
                {
                    Id = 3,
                    Email = "emil3@hotmail.com",
                    Password = "123456",
                    FirstName = "Emil3",
                    LastName = "Godtfredsen",
                    Role = 10,
                    Address =
                    {
                        Id = 3,
                        Street = "Porsevænget",
                        House = "47",
                        Zipcode = 2800,
                        City = "Kgs. Lyngby",
                        Country = "Danmark"
                    }
                }

            };
            _loginRepositoryMock
                .Setup(x => x.GetAll())
                .ReturnsAsync(mockLoginList);

            // Act
            var loginList = await _sut.GetAll();
            var localId = 1;

            // Assert
            Assert.NotNull(loginList);
            Assert.Equal(mockLoginList.Count, loginList.Count);
            Assert.Equal(localId, loginList[0].Id);

        }
        [Fact]
        public async Task GetByEmail_ShouldReturnLogin_IfLoginExists()
        {
            // Arrange
            Login mockLogin = new Login
            {
                Id = 5,
                Email = "mock@hotmail.com",
                Password = "123456",
                FirstName = "Mock",
                LastName = "Mocksen",
                Role = 10,
                Address =
                    {
                        Id = 5,
                        Street = "Porsevænget",
                        House = "47",
                        Zipcode = 2800,
                        City = "Kgs. Lyngby",
                        Country = "Danmark"
                    }
            };

            _loginRepositoryMock
                .Setup(x => x.GetByEmail(mockLogin.Email))
                .ReturnsAsync(mockLogin);
            // Act
            var login = await _sut.GetByEmail(mockLogin.Email);
            // Assert
            Assert.NotNull(login);
            Assert.Equal(mockLogin, login);
        }
        [Fact]
        public async Task GetLoginByEmail_ShouldReturnNull_IfLoginDoesNotExist()
        {
            // Arrange
            _loginRepositoryMock
                .Setup(x => x.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(() => null);
            // Act
            var login = await _sut.GetByEmail("pladder");
            // Assert
            Assert.Null(login);
        }
        [Fact]
        public async Task CreateLogin_ShouldReturnCratedLogin_IfLoginIsSuccessfullyCreated()
        {
            // Arrange
            Login mockLogin = new Login
            {
                Id = 6,
                Email = "mock2@hotmail.com",
                Password = "123456",
                FirstName = "Mock",
                LastName = "Mocksen",
                Role = 10,
                CreatedAt = DateTime.Now,
                Address =
                    {
                        Id = 5,
                        Street = "Porsevænget",
                        House = "47",
                        Zipcode = 2800,
                        City = "Kgs. Lyngby",
                        Country = "Danmark"
                    }
            };

            _loginRepositoryMock
                .Setup(x => x.Create(mockLogin))
                .ReturnsAsync(mockLogin);
            // Act
            var login = await _sut.Create(mockLogin);
            // Assert
            Assert.NotNull(login);

            Assert.NotEqual(DateTime.MinValue, login.CreatedAt);

            Assert.Equal(mockLogin.FirstName, login.FirstName);
        }
        [Fact]
        public async Task UpdateLogin_ShouldReturnDifferentLogin_IfSuccessfullyUpdated()
        {
            string updateEmail = "mock2@hotmail.com";
            // Arrange
            Login mockLogin = new Login
            {
                Id = 6,
                Email = "mock2@hotmail.com",
                Password = "123456",
                FirstName = "Mock",
                LastName = "Mocksen",
                Role = 10,
                Address =
                    {
                        Id = 5,
                        Street = "Porsevænget",
                        House = "47",
                        Zipcode = 2800,
                        City = "Kgs. Lyngby",
                        Country = "Danmark"
                    }
            };

            _loginRepositoryMock
                .Setup(x => x.Update(updateEmail, mockLogin))
                .ReturnsAsync(mockLogin);
            // Act
            var login = await _sut.Update(updateEmail, mockLogin);
            // Assert
            Assert.NotNull(login);
            Assert.NotEqual(DateTime.MinValue, login.UpdatedAt);
        }
        [Fact]
        public async Task DeleteLoginById_ShouldReturnDifferentDeletedAtThanMinValue_IfSuccessfull()
        {
            int deleteId = 3;
            // Arrange
            Login mockLogin = new Login
            {
                Id = 6,
                Email = "mock2@hotmail.com",
                Password = "123456",
                FirstName = "Mock",
                LastName = "Mocksen",
                Role = 10,
                Address =
                    {
                        Id = 5,
                        Street = "Porsevænget",
                        House = "47",
                        Zipcode = 2800,
                        City = "Kgs. Lyngby",
                        Country = "Danmark"
                    }
            };

            _loginRepositoryMock
                .Setup(x => x.Delete(deleteId))
                .ReturnsAsync(mockLogin);
            // Act
            var login = await _sut.Delete(deleteId);
            // Assert
            Assert.NotNull(login);
            Assert.NotEqual(DateTime.MinValue, login.DeletedAt);
        }
    }
}
