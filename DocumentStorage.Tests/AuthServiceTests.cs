using Xunit;
using DocumentStorage.Core.Services;

namespace DocumentStorage.Tests;

public class AuthServiceTests
{
    private readonly IAuthService _authService;

    public AuthServiceTests()
    {
        _authService = new AuthService();
    }

    [Fact]
    public void Register_ShouldReturnToken_WhenUserIsValid()
    {
        var token = _authService.Register("testuser", "password");
        Assert.False(string.IsNullOrEmpty(token));
    }

    [Fact]
    public void Login_ShouldReturnToken_WhenCredentialsAreCorrect()
    {
        _authService.Register("testuser", "password");
        var token = _authService.Login("testuser", "password");
        Assert.False(string.IsNullOrEmpty(token));
    }

    [Fact]
    public void Login_ShouldThrowException_WhenPasswordIsIncorrect()
    {
        _authService.Register("testuser", "password");

        var ex = Assert.Throws<UnauthorizedAccessException>(() =>
        {
            _authService.Login("testuser", "wrongpassword");
        });

        Assert.Equal("Invalid credentials.", ex.Message);
    }

    [Fact]
    public void Login_ShouldThrowException_WhenUserDoesNotExist()
    {
        var ex = Assert.Throws<UnauthorizedAccessException>(() =>
        {
            _authService.Login("nonexistent", "any");
        });

        Assert.Equal("Invalid credentials.", ex.Message);
    }
}
