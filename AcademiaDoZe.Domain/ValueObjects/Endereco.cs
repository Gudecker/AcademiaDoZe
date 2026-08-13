// Gustavo Decker Couto
using AcademiaDoZe.Domain.Common;
using AcademiaDoZe.Domain.Entities;
using AcademiaDoZe.Domain.Services;

namespace AcademiaDoZe.Domain.ValueObjects;

public class Endereco
{
    public Logradouro Logradouro { get; }
    public string Numero { get; }

    private Endereco(Logradouro logradouro, string numero)
    {
        Logradouro = logradouro;
        Numero = numero;
    }

    public static Result<Endereco> Criar(Logradouro? logradouro, string? numero)
    {
        var notifications = new List<Notification>();
        var numeroNormalizado = NormalizadoService.NormalizarTexto(numero);

        if (logradouro is null)
        {
            notifications.Add(new Notification("Endereco.Logradouro", "O logradouro é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(numeroNormalizado))
        {
            notifications.Add(new Notification("Endereco.Numero", "O número do endereço é obrigatório."));
        }

        if (notifications.Count > 0)
        {
            return Result<Endereco>.Failure(notifications);
        }

        return Result<Endereco>.Success(new Endereco(logradouro!, numeroNormalizado));
    }
}