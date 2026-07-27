// Nome: Seu Nome Completo
namespace AcademiaDoZe.Domain.ValueObjects;

public record Arquivo
{
    public byte[] Conteudo { get; }
    public string NomeArquivo { get; }

    public Arquivo(byte[] conteudo, string nomeArquivo)
    {
        Conteudo = conteudo;
        NomeArquivo = nomeArquivo;
    }
}