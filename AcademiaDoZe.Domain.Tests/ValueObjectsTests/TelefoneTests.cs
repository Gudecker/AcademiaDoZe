// Gustavo Decker Couto
using AcademiaDoZe.Domain.ValueObjects;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.ValueObjectsTests;

public class TelefoneTests
{
    [Theory]
    [InlineData("47", "999998888")]
    [InlineData("11", "33334444")]
    [InlineData("48", "98888-7777")]
    [InlineData("(49)", "3222-1111")]
    public void Telefone_DeveCriarComSucesso_QuandoFormatosForemValidos(string ddd, string numero)
    {
        var result = Telefone.Criar(ddd, numero);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(2, result.Value.DDD.Length);
        Assert.True(result.Value.Numero.Length == 8 || result.Value.Numero.Length == 9);
    }

    [Theory]
    [InlineData("", "999998888")]
    [InlineData(" ", "999998888")]
    [InlineData(null, "999998888")]
    [InlineData("4", "999998888")]
    [InlineData("477", "999998888")]
    public void Telefone_DeveFalhar_QuandoDDDForInvalido(string? ddd, string numero)
    {
        var result = Telefone.Criar(ddd, numero);

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Theory]
    [InlineData("47", "")]
    [InlineData("47", " ")]
    [InlineData("47", null)]
    [InlineData("47", "1234567")] // 7 dígitos
    [InlineData("47", "1234567890")] // 10 dígitos
    public void Telefone_DeveFalhar_QuandoNumeroForInvalido(string ddd, string? numero)
    {
        var result = Telefone.Criar(ddd, numero);

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }
}