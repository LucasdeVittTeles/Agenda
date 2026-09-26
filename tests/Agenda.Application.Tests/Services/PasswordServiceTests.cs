using Agenda.Application.Services.Password;

namespace Agenda.Application.Tests.Services;

public class PasswordServiceTests
{
    [Fact]
    public void HashPassword_ShouldReturnDifferentValueFromPassword()
    {

        var service = new PasswordService();
        var password = "123456";

        var hash = service.HashPassword(password);

        Assert.NotEqual(password, hash);
    }

    [Fact]
    public void VerifyPassword_ShouldReturnTrue_WhenPasswordIsCorrect()
    {

        var service = new PasswordService();
        var password = "123456";
        var hash = service.HashPassword(password);

        var result = service.VerifyPassword(password, hash);

        Assert.True(result);
    }

    [Fact]
    public void VerifyPassword_ShouldReturnFalse_WhenPasswordIsIncorrect()
    {
        var service = new PasswordService();
        var hash = service.HashPassword("123456");

        var result = service.VerifyPassword("senha-errada", hash);

        Assert.False(result);
    }
}