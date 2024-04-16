using Microsoft.Extensions.Logging;
using Net3.Services.User.Controllers;
using Net3.Services.User.UserServices.Models;
using UserServices.Services;

namespace Net3.Services.User.Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void LoginUserAsyncReturnsTrue()
        {
            string userId = "TestUser";
            string passwordHash = "HashedPassword";

            UserModel model = new UserModel();
            model.UserId = userId;
            model.PasswordHash = passwordHash;

            Mock<IUserService> mockUserService = new Mock<IUserService>();

            mockUserService.Setup(t => t.UserLoginAsync(It.IsAny<UserModel>())).ReturnsAsync(true);

            UserController userController = new UserController(mockUserService.Object, new Logger<UserController>(new LoggerFactory()));

            var result = userController.LoginUserAsync(userId, passwordHash);

            Assert.AreEqual(true, result.Result.Response);
        }

        [TestMethod]
        public void LoginUserAsyncReturnsFalse()
        {
            string userId = "TestUser";
            string passwordHash = "HashedPassword";

            UserModel model = new UserModel();
            model.UserId = userId;
            model.PasswordHash = passwordHash;

            Mock<IUserService> mockUserService = new Mock<IUserService>();

            mockUserService.Setup(t => t.UserLoginAsync(It.IsAny<UserModel>())).ReturnsAsync(false);

            UserController userController = new UserController(mockUserService.Object, new Logger<UserController>(new LoggerFactory()));

            var result = userController.LoginUserAsync(userId, passwordHash);

            Assert.AreEqual(false, result.Result.Response);
        }

        [TestMethod]
        public void LoginUserAsyncReturnsException()
        {
            string userId = "TestUser";
            string passwordHash = "HashedPassword";

            UserModel model = new UserModel();
            model.UserId = userId;
            model.PasswordHash = passwordHash;

            Mock<IUserService> mockUserService = new Mock<IUserService>();

            mockUserService.Setup(t => t.UserLoginAsync(It.IsAny<UserModel>())).ThrowsAsync(new Exception());

            UserController userController = new UserController(mockUserService.Object, new Logger<UserController>(new LoggerFactory()));

            var result = userController.LoginUserAsync(userId, passwordHash);

            Assert.AreEqual(500, result.Result.Error.Code);
        }



        [TestMethod]
        public void UserSignupAsyncReturnsTrue()
        {
            string userId = "TestUser";
            string passwordHash = "HashedPassword";

            UserModel model = new UserModel();
            model.UserId = userId;
            model.PasswordHash = passwordHash;

            Mock<IUserService> mockUserService = new Mock<IUserService>();

            mockUserService.Setup(t => t.UserSignupAsync(It.IsAny<UserModel>())).ReturnsAsync(true);

            UserController userController = new UserController(mockUserService.Object, new Logger<UserController>(new LoggerFactory()));

            var result = userController.SignupUserAsync(model);

            Assert.AreEqual(true, result.Result.Response);
        }

        [TestMethod]
        public void UserSignupAsyncReturnsFalse()
        {
            string userId = "TestUser";
            string passwordHash = "HashedPassword";

            UserModel model = new UserModel();
            model.UserId = userId;
            model.PasswordHash = passwordHash;

            Mock<IUserService> mockUserService = new Mock<IUserService>();

            mockUserService.Setup(t => t.UserSignupAsync(It.IsAny<UserModel>())).ReturnsAsync(false);

            UserController userController = new UserController(mockUserService.Object, new Logger<UserController>(new LoggerFactory()));

            var result = userController.SignupUserAsync(model);

            Assert.AreEqual(false, result.Result.Response);
        }

        [TestMethod]
        public void UserSignupAsyncReturnsException()
        {
            string userId = "TestUser";
            string passwordHash = "HashedPassword";

            UserModel model = new UserModel();
            model.UserId = userId;
            model.PasswordHash = passwordHash;

            Mock<IUserService> mockUserService = new Mock<IUserService>();

            mockUserService.Setup(t => t.UserSignupAsync(It.IsAny<UserModel>())).ThrowsAsync(new Exception());

            UserController userController = new UserController(mockUserService.Object, new Logger<UserController>(new LoggerFactory()));

            var result = userController.SignupUserAsync(model);

            Assert.AreEqual(500, result.Result.Error.Code);
        }
    }
}