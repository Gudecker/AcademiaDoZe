//gustavo Decker Couto
using System.Text.RegularExpressions;

namespace AcademiaDoZe.Domain.Services;

public static class NormalizadoService
{
    public static string ApenasNumeros(string? texto)
    {
        if (string.IsNullOrWhiteSpace(texto)) return string.Empty;
        return Regex.Replace(texto, @"[^\d]", "");
    }

    public static string NormalizarTexto(string? texto)
    {
        if (string.IsNullOrWhiteSpace(texto)) return string.Empty;
        return texto.Trim();
    }

    public static string NormalizarEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email)) return string.Empty;
        return email.Trim().ToLowerInvariant();
    }
}