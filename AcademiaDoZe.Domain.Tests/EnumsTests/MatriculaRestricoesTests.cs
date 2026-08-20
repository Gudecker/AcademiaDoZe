// Gustavo Decker Couto
using AcademiaDoZe.Domain.Enums;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EnumsTests;

public class MatriculaRestricoesTests
{
    [Theory]
    [InlineData(MatriculaRestricoes.None, 0)]
    [InlineData(MatriculaRestricoes.Diabetes, 1)]
    [InlineData(MatriculaRestricoes.PressaoAlta, 2)]
    [InlineData(MatriculaRestricoes.Labirintite, 4)]
    [InlineData(MatriculaRestricoes.Alergias, 8)]
    [InlineData(MatriculaRestricoes.ProblemasRespiratorios, 16)]
    [InlineData(MatriculaRestricoes.RemedioContinuo, 32)]
    public void MatriculaRestricoes_DevePossuirValoresInteirosCorretos(MatriculaRestricoes restricao, int valorEsperado)
    {
        Assert.Equal(valorEsperado, (int)restricao);
    }

    [Fact]
    public void MatriculaRestricoes_DeveCombinarFlagsCorretamente()
    {
        var restricoes = MatriculaRestricoes.Diabetes | MatriculaRestricoes.PressaoAlta;

        Assert.True(restricoes.HasFlag(MatriculaRestricoes.Diabetes));
        Assert.True(restricoes.HasFlag(MatriculaRestricoes.PressaoAlta));
        Assert.False(restricoes.HasFlag(MatriculaRestricoes.Labirintite));
        Assert.Equal(3, (int)restricoes);
    }

    [Fact]
    public void MatriculaRestricoes_DeveConterQuantidadeExataDeOpcoes()
    {
        var valores = Enum.GetValues(typeof(MatriculaRestricoes));

        Assert.Equal(7, valores.Length);
    }
}