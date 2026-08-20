// Gustavo Decker Couto
using AcademiaDoZe.Domain.Enums;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EnumsTests;

public class ColaboradorVinculoTests
{
    [Theory]
    [InlineData(ColaboradorVinculo.CLT, 0)]
    [InlineData(ColaboradorVinculo.Estagio, 1)]
    public void ColaboradorVinculo_DevePossuirValoresInteirosCorretos(ColaboradorVinculo vinculo, int valorEsperado)
    {
        Assert.Equal(valorEsperado, (int)vinculo);
    }

    [Theory]
    [InlineData(0, ColaboradorVinculo.CLT)]
    [InlineData(1, ColaboradorVinculo.Estagio)]
    public void ColaboradorVinculo_DeveConverterDeInteiroParaEnumCorretamente(int valor, ColaboradorVinculo enumEsperado)
    {
        var resultado = (ColaboradorVinculo)valor;

        Assert.Equal(enumEsperado, resultado);
    }

    [Fact]
    public void ColaboradorVinculo_DeveConterQuantidadeExataDeOpcoes()
    {
        var valores = Enum.GetValues(typeof(ColaboradorVinculo));

        Assert.Equal(2, valores.Length);
    }
}
