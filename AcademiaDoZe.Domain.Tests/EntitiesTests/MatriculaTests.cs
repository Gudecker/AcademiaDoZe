// Gustavo Decker Couto
using AcademiaDoZe.Domain.Entities;
using AcademiaDoZe.Domain.Enums;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EntitiesTests;

public class MatriculaTests
{
    private Arquivo CriarLaudoMedicoValido()
    {
        var bytes = new byte[] { 0x10, 0x20, 0x30 };
        return Arquivo.Criar(1, "laudo.pdf", bytes, "application/pdf").Value!;
    }

    [Fact]
    public void Matricula_DeveInstanciarCorretamente_QuandoDadosForemValidos()
    {
        var alunoId = 1;
        var plano = (MatriculaPlano)1; // Enum de Plano
        var dataInicio = new DateOnly(2026, 1, 1);
        var dataFim = new DateOnly(2026, 12, 31);
        var objetivo = "Hipertrofia";
        var restricoes = (MatriculaRestricoes)0; // Enum de Restrições
        var obsRestricoes = "Nenhuma instrução especial";
        var laudoMedico = CriarLaudoMedicoValido();

        var matricula = new Matricula(
            1,
            alunoId,
            plano,
            dataInicio,
            dataFim,
            objetivo,
            restricoes,
            obsRestricoes,
            laudoMedico
        );

        Assert.NotNull(matricula);
        Assert.Equal(1, matricula.Id);
        Assert.Equal(alunoId, matricula.AlunoId);
        Assert.Equal(plano, matricula.Plano);
        Assert.Equal(dataInicio, matricula.DataInicio);
        Assert.Equal(dataFim, matricula.DataFim);
        Assert.Equal(objetivo, matricula.Objetivo);
        Assert.Equal(restricoes, matricula.Restricoes);
        Assert.Equal(obsRestricoes, matricula.ObservacoesRestricoes);
        Assert.Equal(laudoMedico, matricula.LaudoMedico);
    }

    [Fact]
    public void Matriculas_ComMesmoId_DevemPossuirMesmoId()
    {
        var laudo = CriarLaudoMedicoValido();
        var dataInicio = new DateOnly(2026, 1, 1);
        var dataFim = new DateOnly(2026, 6, 1);

        var matricula1 = new Matricula(10, 1, (MatriculaPlano)1, dataInicio, dataFim, "Perda de peso", (MatriculaRestricoes)0, "Sem obs", laudo);
        var matricula2 = new Matricula(10, 2, (MatriculaPlano)2, dataInicio, dataFim, "Condicionamento", (MatriculaRestricoes)0, "Sem obs", laudo);

        Assert.Equal(matricula1.Id, matricula2.Id);
    }
}