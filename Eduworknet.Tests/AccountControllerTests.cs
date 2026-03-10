using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Eduworknet.DTOs;
using Worknet.Services;

public class AccountControllerTests
{
    private readonly Mock<IAuthService> _mockAuth;
    private readonly AccountController _controller;

    public AccountControllerTests()
    {
        _mockAuth = new Mock<IAuthService>();
        _controller = new AccountController(_mockAuth.Object);
    }

    [Fact]
    public async Task Register_ReturnsOkWithToken()
    {
        // Arrange
        var dto = new RegisterDto { Email = "test@test.com", Password = "Password123!" };
        _mockAuth.Setup(a => a.RegisterAsync(dto)).ReturnsAsync("fake-token");

        // Act
        var result = await _controller.Register(dto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var value = okResult.Value as dynamic;
        Assert.Equal("fake-token", value.token);
        _mockAuth.Verify(a => a.RegisterAsync(dto), Times.Once);
    }

    [Fact]
    public async Task Login_ReturnsOkWithToken()
    {
        // Arrange
        var dto = new LoginDto { Email = "test@test.com", Password = "Password123!" };
        _mockAuth.Setup(a => a.LoginAsync(dto)).ReturnsAsync("login-token");

        // Act
        var result = await _controller.Login(dto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var value = okResult.Value as dynamic;
        Assert.Equal("login-token", value.token);
        _mockAuth.Verify(a => a.LoginAsync(dto), Times.Once);
    }
}
