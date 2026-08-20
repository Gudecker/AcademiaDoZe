// Gustavo Decker Couto
using AcademiaDoZe.Domain.Entities;
using AcademiaDoZe.Domain.ValueObjects;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EntitiesTests;

public class LogradouroTests
{
    private static Cep ObterCepValido()
    {
        return Cep.Criar("88501000").Value!;
    }

    [Fact]
    public void Logradouro_DeveCriarComSucesso_QuandoDadosForemValidos()
    {
        var cep = ObterCepValido();

        var result = Logradouro.Criar(1, "Rua das Flores", cep, "Centro", "Lages", "SC");

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(1, result.Value.Id);
        Assert.Equal(cep, result.Value.Cep);
        Assert.Equal("SC", result.Value.Uf);
    }

    [Fact]
    public void Logradouro_DeveFalhar_QuandoCepForNulo()
    {
        var result = Logradouro.Criar(1, "Rua das Flores", null, "Centro", "Lages", "SC");

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Logradouro_DeveFalhar_QuandoNomeForInvalido(string? nomeInvalido)
    {
        var cep = ObterCepValido();

        var result = Logradouro.Criar(1, nomeInvalido, cep, "Centro", "Lages", "SC");

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Logradouro_DeveFalhar_QuandoBairroForInvalido(string? bairroInvalido)
    {
        var cep = ObterCepValido();

        var result = Logradouro.Criar(1, "Rua Central", cep, bairroInvalido, "Lages", "SC");

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Logradouro_DeveFalhar_QuandoCidadeForInvalida(string? cidadeInvalida)
    {
        var cep = ObterCepValido();

        var result = Logradouro.Criar(1, "Rua Central", cep, "Centro", cidadeInvalida, "SC");

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("S")]
    [InlineData("SAN")]
    [InlineData(null)]
    public void Logradouro_DeveFalhar_QuandoUfForInvalida(string? ufInvalida)
    {
        var cep = ObterCepValido();

        var result = Logradouro.Criar(1, "Rua Central", cep, "Centro", "Lages", ufInvalida);

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }
}