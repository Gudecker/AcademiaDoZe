// Gustavo Decker Couto
using AcademiaDoZe.Domain.Enums;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EnumsTests;

public class ColaboradorTipoTests
{
    [Theory]
    [InlineData(ColaboradorTipo.Administrador, 0)]
    [InlineData(ColaboradorTipo.Atendente, 1)]
    [InlineData(ColaboradorTipo.Instrutor, 2)]
    public void ColaboradorTipo_DevePossuirValoresInteirosCorretos(ColaboradorTipo tipo, int valorEsperado)
    {
        Assert.Equal(valorEsperado, (int)tipo);
    }

    [Theory]
    [InlineData(0, ColaboradorTipo.Administrador)]
    [InlineData(1, ColaboradorTipo.Atendente)]
    [InlineData(2, ColaboradorTipo.Instrutor)]
    public void ColaboradorTipo_DeveConverterDeInteiroParaEnumCorrectamente(int valor, ColaboradorTipo enumEsperado)
    {
        var resultado = (ColaboradorTipo)valor;

        Assert.Equal(enumEsperado, resultado);
    }

    [Fact]
    public void ColaboradorTipo_DeveConterQuantidadeExataDeOpcoes()
    {
        var valores = Enum.GetValues(typeof(ColaboradorTipo));

        Assert.Equal(3, valores.Length);
    }
}