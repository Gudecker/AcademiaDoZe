// Gustavo Decker Couto
using AcademiaDoZe.Domain.Enums;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EnumsTests;

public class MatriculaPlanoTests
{
    [Theory]
    [InlineData(MatriculaPlano.Mensal, 0)]
    [InlineData(MatriculaPlano.Trimestral, 1)]
    [InlineData(MatriculaPlano.Semestral, 2)]
    [InlineData(MatriculaPlano.Anual, 3)]
    public void MatriculaPlano_DevePossuirValoresInteirosCorretos(MatriculaPlano plano, int valorEsperado)
    {
        Assert.Equal(valorEsperado, (int)plano);
    }

    [Theory]
    [InlineData(0, MatriculaPlano.Mensal)]
    [InlineData(1, MatriculaPlano.Trimestral)]
    [InlineData(2, MatriculaPlano.Semestral)]
    [InlineData(3, MatriculaPlano.Anual)]
    public void MatriculaPlano_DeveConverterDeInteiroParaEnumCorretamente(int valor, MatriculaPlano enumEsperado)
    {
        var resultado = (MatriculaPlano)valor;

        Assert.Equal(enumEsperado, resultado);
    }

    [Fact]
    public void MatriculaPlano_DeveConterQuantidadeExataDeOpcoes()
    {
        var valores = Enum.GetValues(typeof(MatriculaPlano));

        Assert.Equal(4, valores.Length);
    }
}