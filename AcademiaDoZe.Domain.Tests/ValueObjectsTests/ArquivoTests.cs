// Gustavo Decker Couto
using AcademiaDoZe.Domain.ValueObjects;
using Xunit;

namespace AcademiaDoZe.Domain.Tests.ValueObjectsTests;

public class ArquivoTests
{
    [Fact]
    public void Arquivo_DeveInstanciarCorretamente_QuandoDadosForemValidos()
    {
        var bytes = new byte[] { 0x20, 0x21, 0x22 };
        var nome = "foto_perfil.png";

        var arquivo = new Arquivo(bytes, nome);

        Assert.NotNull(arquivo);
        Assert.Equal(bytes, arquivo.Conteudo);
        Assert.Equal(nome, arquivo.NomeArquivo);
    }

    [Fact]
    public void Arquivo_ComMesmosValores_DevemSerIguais()
    {
        var bytes = new byte[] { 1, 2, 3 };
        var arquivo1 = new Arquivo(bytes, "documento.pdf");
        var arquivo2 = new Arquivo(bytes, "documento.pdf");

        Assert.Equal(arquivo1, arquivo2);
    }

    [Fact]
    public void Arquivo_ComNomesDiferentes_NaoDevemSerIguais()
    {
        var bytes = new byte[] { 1, 2, 3 };
        var arquivo1 = new Arquivo(bytes, "foto1.jpg");
        var arquivo2 = new Arquivo(bytes, "foto2.jpg");

        Assert.NotEqual(arquivo1, arquivo2);
    }
}