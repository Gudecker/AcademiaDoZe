//Gustavo Decker Couto
using System.Text.RegularExpressions;
using AcademiaDoZe.Domain.Common;
using AcademiaDoZe.Domain.Services;

namespace AcademiaDoZe.Domain.ValueObjects;

public class Email
{
    public string Endereco { get; }

    private Email(string endereco)
    {
        Endereco = endereco;
    }

    public static Result<Email> Criar(string? endereco)
    {
        var notifications = new List<Notification>();
        var emailNormalizado = NormalizadoService.NormalizarEmail(endereco);

        if (string.IsNullOrWhiteSpace(emailNormalizado))
        {
            notifications.Add(new Notification("Email", "O e-mail é obrigatório."));
        }
        else
        {
            var regexEmail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!regexEmail.IsMatch(emailNormalizado))
            {
                notifications.Add(new Notification("Email", "O formato do e-mail é inválido."));
            }
        }

        if (notifications.Count > 0)
        {
            return Result<Email>.Failure(notifications);
        }

        return Result<Email>.Success(new Email(emailNormalizado));
    }
}