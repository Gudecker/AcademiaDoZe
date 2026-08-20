// Gustavo Decker Couto
using AcademiaDoZe.Domain.ValueObjects;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.ValueObjectsTests;

public class CepTests
{
    [Theory]
    [InlineData("88501000")]
    [InlineData("88501-000")]
    [InlineData("01001-000")]
    [InlineData("89201000")]
    public void Cep_DeveCriarComSucesso_QuandoFormatosForemValidos(string valor)
    {
        var result = Cep.Criar(valor);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(8, result.Value.Valor.Length);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Cep_DeveFalhar_QuandoValorForNuloOuVazio(string? valor)
    {
        var result = Cep.Criar(valor);

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("1234567")]
    [InlineData("123456789")]
    [InlineData("ABCDEFGH")]
    public void Cep_DeveFalhar_QuandoTamanhoForDiferenteDeOitoDigitos(string valor)
    {
        var result = Cep.Criar(valor);

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }
}