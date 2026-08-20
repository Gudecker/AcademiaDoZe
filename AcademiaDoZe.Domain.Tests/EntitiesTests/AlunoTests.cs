// Gustavo Decker Couto
using AcademiaDoZe.Domain.Entities;
using AcademiaDoZe.Domain.ValueObjects;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EntitiesTests;

public class AlunoTests
{
    private (Cpf Cpf, Email Email, Telefone Telefone, Endereco Endereco) ObterObjetosDeValorValidos()
    {
        var cpf = new Cpf("12345678901");
        var email = Email.Criar("aluno@ze.com").Value!;
        var telefone = Telefone.Criar("47", "999998888").Value!;
        var cep = Cep.Criar("88501000").Value!;
        var logradouro = Logradouro.Criar(1, "Rua Central", cep, "Centro", "Lages", "SC").Value!;
        var endereco = Endereco.Criar(logradouro, "100").Value!;

        return (cpf, email, telefone, endereco);
    }

    [Fact]
    public void Aluno_DeveInstanciarCorretamente_SemFoto()
    {
        var (cpf, email, telefone, endereco) = ObterObjetosDeValorValidos();
        var dataNascimento = new DateOnly(2000, 1, 1);

        var aluno = new Aluno(1, "Gustavo Decker", cpf, email, telefone, dataNascimento, endereco);

        Assert.NotNull(aluno);
        Assert.Equal(1, aluno.Id);
        Assert.Equal("Gustavo Decker", aluno.Nome);
        Assert.Equal(cpf, aluno.Cpf);
        Assert.Equal(email, aluno.Email);
        Assert.Equal(telefone, aluno.Telefone);
        Assert.Equal(dataNascimento, aluno.DataNascimento);
        Assert.Equal(endereco, aluno.Endereco);
        Assert.Null(aluno.Foto);
    }

    [Fact]
    public void Aluno_DeveInstanciarCorretamente_ComFoto()
    {
        var (cpf, email, telefone, endereco) = ObterObjetosDeValorValidos();
        var bytes = new byte[] { 0x01, 0x02 };
        var fotoResult = AcademiaDoZe.Domain.Entities.Arquivo.Criar(1, "foto.png", bytes, "image/png");
        Assert.True(fotoResult.IsSuccess);

        var aluno = new Aluno(2, "Aluno Com Foto", cpf, email, telefone, new DateOnly(1998, 5, 10), endereco, fotoResult.Value);

        Assert.NotNull(aluno.Foto);
        Assert.Equal("foto.png", aluno.Foto.Nome.ToLower());
    }

    [Fact]
    public void Alunos_ComMesmoId_DevemPossuirMesmoId()
    {
        var (cpf, email, telefone, endereco) = ObterObjetosDeValorValidos();
        var dataNasc = new DateOnly(2000, 1, 1);

        var aluno1 = new Aluno(10, "Aluno Um", cpf, email, telefone, dataNasc, endereco);
        var aluno2 = new Aluno(10, "Aluno Dois", cpf, email, telefone, dataNasc, endereco);

        Assert.Equal(aluno1.Id, aluno2.Id);
    }
}