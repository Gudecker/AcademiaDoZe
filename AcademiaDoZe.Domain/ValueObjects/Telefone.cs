// Gustavo Decker Couto
using AcademiaDoZe.Domain.Common;
using AcademiaDoZe.Domain.Services;

namespace AcademiaDoZe.Domain.ValueObjects;

public class Telefone
{
    public string DDD { get; }
    public string Numero { get; }

    private Telefone(string ddd, string numero)
    {
        DDD = ddd;
        Numero = numero;
    }

    public static Result<Telefone> Criar(string? ddd, string? numero)
    {
        var notifications = new List<Notification>();

        var dddLimpo = NormalizadoService.ApenasNumeros(ddd);
        var numeroLimpo = NormalizadoService.ApenasNumeros(numero);

        if (string.IsNullOrWhiteSpace(dddLimpo) || dddLimpo.Length != 2)
        {
            notifications.Add(new Notification("Telefone.DDD", "O DDD deve conter exatamente 2 dígitos."));
        }

        if (string.IsNullOrWhiteSpace(numeroLimpo) || (numeroLimpo.Length != 8 && numeroLimpo.Length != 9))
        {
            notifications.Add(new Notification("Telefone.Numero", "O número deve ter 8 dígitos (fixo) ou 9 dígitos (celular)."));
        }

        if (notifications.Count > 0)
        {
            return Result<Telefone>.Failure(notifications);
        }

        return Result<Telefone>.Success(new Telefone(dddLimpo, numeroLimpo));
    }
}