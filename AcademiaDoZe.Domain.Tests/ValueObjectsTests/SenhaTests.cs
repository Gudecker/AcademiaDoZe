// Gustavo Decker Couto
using AcademiaDoZe.Domain.ValueObjects;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.ValueObjectsTests;

public class SenhaTests
{
    [Theory]
    [InlineData("123456")]
    [InlineData("Senha@123")]
    [InlineData("admin_2026")]
    public void Senha_DeveInstanciarCorretamente_QuandoValorForFornecido(string valor)
    {
        var senha = new Senha(valor);

        Assert.NotNull(senha);
        Assert.Equal(valor, senha.Valor);
    }

    [Fact]
    public void Senha_ComMesmoValor_DevemSerIguais()
    {
        var senha1 = new Senha("Senha@123");
        var senha2 = new Senha("Senha@123");

        Assert.Equal(senha1, senha2);
    }

    [Fact]
    public void Senha_ComValoresDiferentes_NaoDevemSerIguais()
    {
        var senha1 = new Senha("Senha@123");
        var senha2 = new Senha("OutraSenha#456");

        Assert.NotEqual(senha1, senha2);
    }
}