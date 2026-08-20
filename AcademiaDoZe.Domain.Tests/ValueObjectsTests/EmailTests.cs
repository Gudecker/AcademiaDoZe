// Gustavo Decker Couto
using AcademiaDoZe.Domain.ValueObjects;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.ValueObjectsTests;

public class EmailTests
{
    [Theory]
    [InlineData("usuario@dominio.com")]
    [InlineData("gustavo.decker@academia.com.br")]
    [InlineData("aluno_ze@gmail.com")]
    [InlineData("TESTE@DOMINIO.COM")]
    public void Email_DeveCriarComSucesso_QuandoFormatoForValido(string endereco)
    {
        var result = Email.Criar(endereco);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.False(string.IsNullOrWhiteSpace(result.Value.Endereco));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Email_DeveFalhar_QuandoEnderecoForNuloOuVazio(string? endereco)
    {
        var result = Email.Criar(endereco);

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Theory]
    [InlineData("emailinvalido")]
    [InlineData("usuario@")]
    [InlineData("@dominio.com")]
    [InlineData("usuario@dominio")]
    [InlineData("usuario @dominio.com")]
    public void Email_DeveFalhar_QuandoFormatoForInvalido(string endereco)
    {
        var result = Email.Criar(endereco);

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }
}