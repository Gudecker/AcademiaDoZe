// Gustavo Decker Couto
using AcademiaDoZe.Domain.Common;
using AcademiaDoZe.Domain.Services;

namespace AcademiaDoZe.Domain.Entities;

public class Arquivo
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public byte[] Conteudo { get; private set; }
    public string ContentType { get; private set; }

    private Arquivo(int id, string nome, byte[] conteudo, string contentType)
    {
        Id = id;
        Nome = nome;
        Conteudo = conteudo;
        ContentType = contentType;
    }

    public static Result<Arquivo> Criar(int id, string? nome, byte[]? conteudo, string? contentType)
    {
        var notifications = new List<Notification>();

        var nomeNormalizado = NormalizadoService.NormalizarTexto(nome);
        var contentTypeNormalizado = NormalizadoService.NormalizarTexto(contentType);

        if (string.IsNullOrWhiteSpace(nomeNormalizado))
        {
            notifications.Add(new Notification("Arquivo.Nome", "O nome do arquivo é obrigatório."));
        }

        if (conteudo == null || conteudo.Length == 0)
        {
            notifications.Add(new Notification("Arquivo.Conteudo", "O conteúdo do arquivo não pode estar vazio."));
        }

        if (string.IsNullOrWhiteSpace(contentTypeNormalizado))
        {
            notifications.Add(new Notification("Arquivo.ContentType", "O tipo de conteúdo (ContentType) é obrigatório."));
        }

        if (notifications.Count > 0)
        {
            return Result<Arquivo>.Failure(notifications);
        }

        return Result<Arquivo>.Success(new Arquivo(id, nomeNormalizado, conteudo!, contentTypeNormalizado));
    }
}