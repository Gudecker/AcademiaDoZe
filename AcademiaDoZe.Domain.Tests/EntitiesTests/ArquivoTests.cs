// Gustavo Decker Couto
using AcademiaDoZe.Domain.Entities;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.EntitiesTests;

public class ArquivoEntityTests
{
    [Fact]
    public void Arquivo_DeveCriarComSucesso_QuandoDadosForemValidos()
    {
        var id = 1;
        var nome = "documento.pdf";
        var conteudo = new byte[] { 0x20, 0x21, 0x22 };
        var contentType = "application/pdf";

        var result = Arquivo.Criar(id, nome, conteudo, contentType);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(id, result.Value.Id);
        Assert.Equal(nome, result.Value.Nome);
        Assert.Equal(conteudo, result.Value.Conteudo);
        Assert.Equal(contentType, result.Value.ContentType);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Arquivo_DeveFalhar_QuandoNomeForInvalido(string? nomeInvalido)
    {
        var conteudo = new byte[] { 0x01 };

        var result = Arquivo.Criar(1, nomeInvalido, conteudo, "image/png");

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Fact]
    public void Arquivo_DeveFalhar_QuandoConteudoForNulo()
    {
        var result = Arquivo.Criar(1, "foto.png", null, "image/png");

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Fact]
    public void Arquivo_DeveFalhar_QuandoConteudoForVazio()
    {
        var conteudoVazio = Array.Empty<byte>();

        var result = Arquivo.Criar(1, "foto.png", conteudoVazio, "image/png");

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Arquivo_DeveFalhar_QuandoContentTypeForInvalido(string? contentTypeInvalido)
    {
        var conteudo = new byte[] { 0x01 };

        var result = Arquivo.Criar(1, "foto.png", conteudo, contentTypeInvalido);

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Notifications);
    }

    [Fact]
    public void Arquivo_DeveAcumularNotificacoes_QuandoMúltiplosCamposForemInvalidos()
    {
        var result = Arquivo.Criar(1, null, null, null);

        Assert.False(result.IsSuccess);
        Assert.Equal(3, result.Notifications.Count);
    }
}
