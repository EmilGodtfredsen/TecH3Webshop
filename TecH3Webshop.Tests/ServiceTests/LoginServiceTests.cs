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
    }
}
