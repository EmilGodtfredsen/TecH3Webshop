using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TecH3Webshop.Api.Database;
using TecH3Webshop.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using TecH3Webshop.Api.Domain;

namespace TecH3Webshop.Tests.RepositoryTests
{
    public class LoginRepositoryTests
    {
        private readonly DbContextOptions<TecH3WebshopDbContext> _options;
        private readonly TecH3WebshopDbContext _context;


        public LoginRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<TecH3WebshopDbContext>()
                .UseInMemoryDatabase(databaseName: "LoginsDatabase")
                .Options;
            _context = new TecH3WebshopDbContext(_options);
            _context.Database.EnsureDeleted();

            _context.Logins.Add(new Login
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
            }); ;
            _context.Logins.Add(new Login
            {
                Id = 2,
                Email = "2emil@hotmail.com",
                Password = "123456",
                FirstName = "Emil",
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
            }); ;
            _context.Logins.Add(new Login
            {
                Id = 3,
                Email = "3emil@hotmail.com",
                Password = "123456",
                FirstName = "Emil",
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
            }); ;

            _context.SaveChanges();
            
        }

        [Fact]
        public async Task GetAllLogins_ShouldReturnAllLogins_WhenLoginsExist()
        {
            // Arrange
            LoginRepository loginRepository = new LoginRepository(_context);

            // Act
            var logins = await loginRepository.GetAll();
            // Assert
            Assert.NotNull(logins);

            Assert.Equal(3, logins.Count);
        }
        [Fact]
        public async Task GetLoginByEmail_ShouldReturnLogin_WhenLoginWithSpecificEmailExists()
        {
            // Arrange
            LoginRepository loginRepository = new LoginRepository(_context);
            // Act
            var login = await loginRepository.GetByEmail("emil@hotmail.com");
            // Assert
            Assert.NotNull(login);

            Assert.Equal("123456", login.Password);
        }
        [Fact]
        public async Task CreateLogin_ShouldReturnNewLogin_WhenCreatedAt_NotEqualsDatetime_MinValue()
        {
            // Arrange
            LoginRepository loginRepository = new LoginRepository(_context);
            // Act
            var login = await loginRepository.Create(new Login
            {
                Id = 4,
                Email = "Jim@hotmail.com",
                Password = "123456",
                FirstName = "Jim",
                LastName = "Daggerthuggert",
                Role = 10,
                Address =
                {
                    Id = 4,
                    Street = "ToBackTotheFromTime",
                    House = "66",
                    Zipcode = 2860,
                    City = "Søborg",
                    Country = "Danmark"
                }
            }); ;
            // Assert
            Assert.NotNull(login);

            Assert.NotEqual(DateTime.MinValue, login.CreatedAt);
        }
        [Fact]
        public async Task UpdateLogin_ShouldReturnUpdatedLogin_WhenUpdateAt_IsNotNull()
        {
            // Arrange
            LoginRepository loginRepository = new LoginRepository(_context);
            // Act
            var updateLogin = await loginRepository.Update("emil@hotmail.com", new Login
            {
                Password = "654321"
            });
            // Assert
            Assert.NotNull(updateLogin);
            Assert.NotNull(updateLogin.UpdatedAt);

        }
        [Fact]
        public async Task DeleteLogin_ShouldReturnDeletedLogin_WhenDeletedAt_IsNotNull()
        {
            // Arrange
            LoginRepository loginRepository = new LoginRepository(_context);
            // Act
            var login = await loginRepository.Delete(3);
            // Assert
            Assert.NotNull(login);
            Assert.NotNull(login.DeletedAt);
        }
    }
}
