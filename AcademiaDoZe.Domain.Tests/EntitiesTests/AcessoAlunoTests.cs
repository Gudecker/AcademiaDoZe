// Gustavo Decker Couto
using AcademiaDoZe.Domain.Entities;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EntitiesTests;

public class AcessoAlunoTests
{
    [Fact]
    public void AcessoAluno_DeveInstanciarCorretamente_SemDataHoraSaida()
    {
        var alunoId = 1;
        var dataHoraEntrada = new DateTime(2026, 8, 20, 10, 0, 0);

        var acesso = new AcessoAluno(1, alunoId, dataHoraEntrada);

        Assert.NotNull(acesso);
        Assert.Equal(1, acesso.Id);
        Assert.Equal(alunoId, acesso.AlunoId);
        Assert.Equal(dataHoraEntrada, acesso.DataHoraEntrada);
        Assert.Null(acesso.DataHoraSaida);
    }

    [Fact]
    public void AcessoAluno_DeveInstanciarCorretamente_ComDataHoraSaida()
    {
        var alunoId = 1;
        var dataHoraEntrada = new DateTime(2026, 8, 20, 10, 0, 0);
        var dataHoraSaida = new DateTime(2026, 8, 20, 11, 30, 0);

        var acesso = new AcessoAluno(2, alunoId, dataHoraEntrada, dataHoraSaida);

        Assert.NotNull(acesso);
        Assert.Equal(2, acesso.Id);
        Assert.Equal(alunoId, acesso.AlunoId);
        Assert.Equal(dataHoraEntrada, acesso.DataHoraEntrada);
        Assert.Equal(dataHoraSaida, acesso.DataHoraSaida);
    }

    [Fact]
    public void AcessosAluno_ComMesmoId_DevemPossuirMesmoId()
    {
        var dataHora = DateTime.Now;
        var acesso1 = new AcessoAluno(10, 1, dataHora);
        var acesso2 = new AcessoAluno(10, 2, dataHora);

        Assert.Equal(acesso1.Id, acesso2.Id);
    }
}