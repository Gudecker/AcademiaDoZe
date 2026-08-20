// Gustavo Decker Couto
using AcademiaDoZe.Domain.Entities;
using AcademiaDoZe.Domain.ValueObjects;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.ValueObjectsTests;

public class EnderecoTests
{
    private Logradouro CriarLogradouroValido()
{
    var cep = Cep.Criar("88501000").Value;
    var result = Logradouro.Criar(1, "Rua XV de Novembro", cep, "Centro", "Lages", "SC");
    return result.Value!;
}

    [Fact]
    public void Endereco_DeveCriarComSucesso_QuandoDadosForemValidos()
    {
        var logradouro = CriarLogradouroValido();
        var numero = "100";

        var result = Endereco.Criar(logradouro, numero);
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(logradouro, result.Value.Logradouro);
        Assert.Equal("100", result.Value.Numero);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Endereco_DeveFalhar_QuandoNumeroForNuloOuVazio(string? numero)
    {
        var logradouro = CriarLogradouroValido();

        var result = Endereco.Criar(logradouro, numero);

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Fact]
    public void Endereco_DeveFalhar_QuandoLogradouroForNulo()
    {
        var result = Endereco.Criar(null, "100");

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }
}