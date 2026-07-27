// Nome: Seu Nome Completo
namespace AcademiaDoZe.Domain.ValueObjects;

public record Telefone
{
    public string Numero { get; }

    public Telefone(string numero)
    {
        Numero = numero;
    }
}