// Gustavo Decker Couto
using AcademiaDoZe.Domain.Entities;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EntitiesTests;

public class AcessoColaboradorTests
{
    [Fact]
    public void AcessoColaborador_DeveInstanciarCorretamente_SemDataHoraSaida()
    {
        var colaboradorId = 1;
        var dataHoraEntrada = new DateTime(2026, 8, 20, 8, 0, 0);

        var acesso = new AcessoColaborador(1, colaboradorId, dataHoraEntrada);

        Assert.NotNull(acesso);
        Assert.Equal(1, acesso.Id);
        Assert.Equal(colaboradorId, acesso.ColaboradorId);
        Assert.Equal(dataHoraEntrada, acesso.DataHoraEntrada);
        Assert.Null(acesso.DataHoraSaida);
    }

    [Fact]
    public void AcessoColaborador_DeveInstanciarCorretamente_ComDataHoraSaida()
    {
        var colaboradorId = 1;
        var dataHoraEntrada = new DateTime(2026, 8, 20, 8, 0, 0);
        var dataHoraSaida = new DateTime(2026, 8, 20, 12, 0, 0);

        var acesso = new AcessoColaborador(2, colaboradorId, dataHoraEntrada, dataHoraSaida);

        Assert.NotNull(acesso);
        Assert.Equal(2, acesso.Id);
        Assert.Equal(colaboradorId, acesso.ColaboradorId);
        Assert.Equal(dataHoraEntrada, acesso.DataHoraEntrada);
        Assert.Equal(dataHoraSaida, acesso.DataHoraSaida);
    }

    [Fact]
    public void AcessosColaborador_ComMesmoId_DevemPossuirMesmoId()
    {
        var dataHora = DateTime.Now;
        var acesso1 = new AcessoColaborador(10, 1, dataHora);
        var acesso2 = new AcessoColaborador(10, 2, dataHora);

        Assert.Equal(acesso1.Id, acesso2.Id);
    }
}