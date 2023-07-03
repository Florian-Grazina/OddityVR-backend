using Backend_OddityVR.Application.AppService;
using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Application.DTO.UserDTO;
using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Test_Token
{
    [TestClass]
    public class TokenServiceTests
    {
        private readonly ITokenAppService _tokenAppService;

        private IConfiguration configuration;
        public IConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    var builder = new ConfigurationBuilder().AddJsonFile("appsettings.Test.json", optional: false);
                    configuration = builder.Build();
                }

                return configuration;
            }
        }


        public TokenServiceTests()
        {
            var services = new ServiceCollection();
            services.AddSingleton(Configuration);
            services.AddSingleton<Database>();
            services.AddSingleton<UserRepo>();
            services.AddSingleton<RoleRepo>();
            services.AddSingleton<TokenAppService>();
            services.AddSingleton<IUserAppService, UserAppService>();

            var serviceProvider = services.BuildServiceProvider();

            _tokenAppService = serviceProvider.GetService<TokenAppService>();

        }
        

        [TestMethod]
        public void GetExistingUser_UserIsReturned()
        {
            // Arrange
            LoginUserDTO loginUserDTO = new() { Email = "string", Password = "string" };

            // Action
            User? user = _tokenAppService.GetUser(loginUserDTO);

            // Assert
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void GetNonExistingUser_ExceptionIsThrown()
        {
            // Arrange
            LoginUserDTO loginUserDTO = new() { Email = "null", Password = "null" };

            // Assert
            Assert.ThrowsException<Exception>(() => _tokenAppService.GetUser(loginUserDTO));
        }

        [TestMethod]
        public void GetExistingUserWithWrongPassword_ExceptionIsThrown()
        {
            // Arrange
            LoginUserDTO loginUserDTO = new() { Email = "string", Password = "null" };

            // Assert
            Assert.ThrowsException<Exception>(() => _tokenAppService.GetUser(loginUserDTO));
        }

        [TestMethod]
        [DataRow("string", "")]
        [DataRow("", "string")]
        public void GetUserOneFieldIsEmpty_ExceptionIsThrown(string email, string password)
        {
            // Arrange
            LoginUserDTO loginUserDTO = new() { Email = email, Password = password };

            // Assert
            Assert.ThrowsException<Exception>(() => _tokenAppService.GetUser(loginUserDTO));
        }

        [TestMethod]
        public void GetTokenUserIsLogged_JWTDTOIsReturned()
        {
            // Arrange
            LoginUserDTO loginUserDTO = new() { Email = "string", Password = "string"};

            // Action
            JwtDTO jwt = _tokenAppService.GetToken(loginUserDTO);

            // Assert
            Assert.IsNotNull(jwt);
            Assert.IsTrue(jwt.Key.Length > 0);
        }

        [TestMethod]
        [DataRow("string", "")]
        [DataRow("", "string")]
        [DataRow("null", "null")]
        public void GetTokenUserIsNotLogged_ExceptionIsThrown(string email, string password)
        {
            // Arrange
            LoginUserDTO loginUserDTO = new() { Email = email, Password = password };

            // Assert
            Assert.ThrowsException<Exception>(() => _tokenAppService.GetToken(loginUserDTO));
        }
    }
}