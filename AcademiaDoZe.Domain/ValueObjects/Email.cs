// Nome: Seu Nome Completo
namespace AcademiaDoZe.Domain.ValueObjects;

public record Email
{
    public string EnderecoEmail { get; }

    public Email(string enderecoEmail)
    {
        EnderecoEmail = enderecoEmail;
    }
}