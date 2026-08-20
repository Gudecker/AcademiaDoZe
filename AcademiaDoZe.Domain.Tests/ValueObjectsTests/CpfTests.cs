// Gustavo Decker Couto
using AcademiaDoZe.Domain.ValueObjects;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.ValueObjectsTests;

public class CpfTests
{
    [Theory]
    [InlineData("12345678901")]
    [InlineData("123.456.789-01")]
    [InlineData("00000000000")]
    public void Cpf_DeveInstanciarCorretamente_QuandoValorForFornecido(string valor)
    {
        var cpf = new Cpf(valor);

        Assert.NotNull(cpf);
        Assert.Equal(valor, cpf.Valor);
    }

    [Fact]
    public void Cpf_ComMesmoValor_DevemSerIguais()
    {
        var cpf1 = new Cpf("12345678901");
        var cpf2 = new Cpf("12345678901");

        Assert.Equal(cpf1, cpf2);
    }

    [Fact]
    public void Cpf_ComValoresDiferentes_NaoDevemSerIguais()
    {
        var cpf1 = new Cpf("12345678901");
        var cpf2 = new Cpf("98765432100");

        Assert.NotEqual(cpf1, cpf2);
    }
}