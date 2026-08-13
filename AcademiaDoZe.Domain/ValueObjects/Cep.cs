//Gustavo Decker Couto
using AcademiaDoZe.Domain.Common;
using AcademiaDoZe.Domain.Services;

namespace AcademiaDoZe.Domain.ValueObjects;

public class Cep
{
    public string Valor { get; }
    private Cep(string valor)
    {
        Valor = valor;
    }
    public static Result<Cep> Criar(string? valor)
    {
        var notifications = new List<Notification>();
        var cepLimpo = NormalizadoService.ApenasNumeros(valor);

        if (string.IsNullOrWhiteSpace(cepLimpo))
        {
            notifications.Add(new Notification("Cep", "O CEP é obrigatório."));
        }
        else if (cepLimpo.Length != 8)
        {
            notifications.Add(new Notification("Cep", "O CEP deve conter exatamente 8 dígitos."));
        }

        if (notifications.Count > 0)
        {
            return Result<Cep>.Failure(notifications);
        }

        return Result<Cep>.Success(new Cep(cepLimpo));
    }
}