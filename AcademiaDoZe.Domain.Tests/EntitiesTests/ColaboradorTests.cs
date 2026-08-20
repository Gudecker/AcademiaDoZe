// Gustavo Decker Couto
using AcademiaDoZe.Domain.Entities;
using AcademiaDoZe.Domain.ValueObjects;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EntitiesTests;

public class ColaboradorTests
{
    private (Cpf Cpf, Email Email, Telefone Telefone, Senha Senha, Endereco Endereco) ObterObjetosDeValorValidos()
    {
        var cpf = new Cpf("12345678901");
        var email = Email.Criar("colaborador@ze.com").Value!;
        var telefone = Telefone.Criar("47", "999998888").Value!;
        var senha = new Senha("Senha@123");
        var cep = Cep.Criar("88501000").Value!;
        var logradouro = Logradouro.Criar(1, "Rua Central", cep, "Centro", "Lages", "SC").Value!;
        var endereco = Endereco.Criar(logradouro, "100").Value!;

        return (cpf, email, telefone, senha, endereco);
    }

    [Fact]
    public void Colaborador_DeveInstanciarCorretamente_SemFoto()
    {
        var (cpf, email, telefone, senha, endereco) = ObterObjetosDeValorValidos();

        var colaborador = new Colaborador(1, "Gustavo Decker", cpf, email, telefone, senha, endereco);

        Assert.NotNull(colaborador);
        Assert.Equal(1, colaborador.Id);
        Assert.Equal("Gustavo Decker", colaborador.Nome);
        Assert.Equal(cpf, colaborador.Cpf);
        Assert.Equal(email, colaborador.Email);
        Assert.Equal(telefone, colaborador.Telefone);
        Assert.Equal(senha, colaborador.Senha);
        Assert.Equal(endereco, colaborador.Endereco);
        Assert.Null(colaborador.Foto);
    }

    [Fact]
    public void Colaborador_DeveInstanciarCorretamente_ComFoto()
    {
        var (cpf, email, telefone, senha, endereco) = ObterObjetosDeValorValidos();
        var bytes = new byte[] { 0x01, 0x02 };
        var fotoResult = AcademiaDoZe.Domain.Entities.Arquivo.Criar(1, "foto_colaborador.png", bytes, "image/png");
        Assert.True(fotoResult.IsSuccess);

        var colaborador = new Colaborador(2, "Colaborador Com Foto", cpf, email, telefone, senha, endereco, fotoResult.Value);

        Assert.NotNull(colaborador.Foto);
        Assert.Equal("foto_colaborador.png", colaborador.Foto.Nome.ToLower());
    }

    [Fact]
    public void Colaboradores_ComMesmoId_DevemPossuirMesmoId()
    {
        var (cpf, email, telefone, senha, endereco) = ObterObjetosDeValorValidos();

        var colaborador1 = new Colaborador(10, "Colaborador Um", cpf, email, telefone, senha, endereco);
        var colaborador2 = new Colaborador(10, "Colaborador Dois", cpf, email, telefone, senha, endereco);

        Assert.Equal(colaborador1.Id, colaborador2.Id);
    }
}