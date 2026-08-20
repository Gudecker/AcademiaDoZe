// Gustavo Decker Couto
using AcademiaDoZe.Domain.Entities;
using AcademiaDoZe.Domain.ValueObjects;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EntitiesTests;

public class PessoaTests
{
    private class PessoaStub : Pessoa
    {
        public PessoaStub(
            int id,
            string nome,
            Cpf cpf,
            DateOnly dataNascimento,
            Telefone telefone,
            Email email,
            Endereco endereco,
            Senha senha,
            AcademiaDoZe.Domain.Entities.Arquivo foto) : base(id, nome, cpf, dataNascimento, telefone, email, endereco, senha, foto)
        {
        }
    }

    [Fact]
    public void Pessoa_DeveInstanciarPropriedadesCorretamente_AtravesDaDerivada()
    {
        var cpf = new Cpf("12345678901");
        var email = Email.Criar("pessoa@ze.com").Value!;
        var telefone = Telefone.Criar("47", "999998888").Value!;
        var senha = new Senha("Senha@123");
        var cep = Cep.Criar("88501000").Value!;
        var logradouro = Logradouro.Criar(1, "Rua Central", cep, "Centro", "Lages", "SC").Value!;
        var endereco = Endereco.Criar(logradouro, "100").Value!;
        var foto = AcademiaDoZe.Domain.Entities.Arquivo.Criar(1, "foto.png", new byte[] { 0x01 }, "image/png").Value!;
        var dataNascimento = new DateOnly(1995, 3, 15);

        var pessoa = new PessoaStub(
            1,
            "Carlos Silva",
            cpf,
            dataNascimento,
            telefone,
            email,
            endereco,
            senha,
            foto
        );

        Assert.NotNull(pessoa);
        Assert.Equal(1, pessoa.Id);
        Assert.Equal("Carlos Silva", pessoa.Nome);
        Assert.Equal(cpf, pessoa.Cpf);
        Assert.Equal(dataNascimento, pessoa.DataNascimento);
        Assert.Equal(telefone, pessoa.Telefone);
        Assert.Equal(email, pessoa.Email);
        Assert.Equal(endereco, pessoa.Endereco);
        Assert.Equal(senha, pessoa.Senha);
        Assert.Equal(foto, pessoa.Foto);
    }
}