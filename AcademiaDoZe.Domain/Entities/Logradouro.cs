// Gustavo Decker Couto
using AcademiaDoZe.Domain.Common;
using AcademiaDoZe.Domain.Services;
using AcademiaDoZe.Domain.ValueObjects;

namespace AcademiaDoZe.Domain.Entities;

public class Logradouro : IAggregateRoot
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public Cep Cep { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Uf { get; private set; }
    private Logradouro(int id, string nome, Cep cep, string bairro, string cidade, string uf)
    {
        Id = id;
        Nome = nome;
        Cep = cep;
        Bairro = bairro;
        Cidade = cidade;
        Uf = uf;
    }

    public static Result<Logradouro> Criar(
        int id, 
        string? nome, 
        Cep? cep, 
        string? bairro, 
        string? cidade, 
        string? uf)
    {
        var notifications = new List<Notification>();

        var nomeNormalizado = NormalizadoService.NormalizarTexto(nome);
        var bairroNormalizado = NormalizadoService.NormalizarTexto(bairro);
        var cidadeNormalizada = NormalizadoService.NormalizarTexto(cidade);
        var ufNormalizada = NormalizadoService.NormalizarTexto(uf)?.ToUpperInvariant();

        if (cep is null)
        {
            notifications.Add(new Notification("Logradouro.Cep", "O CEP é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(nomeNormalizado))
        {
            notifications.Add(new Notification("Logradouro.Nome", "O nome do logradouro é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(bairroNormalizado))
        {
            notifications.Add(new Notification("Logradouro.Bairro", "O bairro é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(cidadeNormalizada))
        {
            notifications.Add(new Notification("Logradouro.Cidade", "A cidade é obrigatória."));
        }

        if (string.IsNullOrWhiteSpace(ufNormalizada) || ufNormalizada.Length != 2)
        {
            notifications.Add(new Notification("Logradouro.Uf", "A UF deve conter exatamente 2 letras."));
        }

        if (notifications.Count > 0)
        {
            return Result<Logradouro>.Failure(notifications);
        }

        return Result<Logradouro>.Success(new Logradouro(
            id, 
            nomeNormalizado, 
            cep!, 
            bairroNormalizado, 
            cidadeNormalizada, 
            ufNormalizada!));
    }
}