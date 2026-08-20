// Gustavo Decker Couto
using AcademiaDoZe.Domain.Common;
using AcademiaDoZe.Domain.ValueObjects;

namespace AcademiaDoZe.Domain.Entities;

public class Aluno : Entity, IAggregateRoot
{
    public string Nome { get; private set; }
    public Cpf Cpf { get; private set; }
    public Email Email { get; private set; }
    public Telefone Telefone { get; private set; }
    public DateOnly DataNascimento { get; private set; }
    public Endereco Endereco { get; private set; }
    public Arquivo? Foto { get; private set; }

    public Aluno(
        int id,
        string nome,
        Cpf cpf,
        Email email,
        Telefone telefone,
        DateOnly dataNascimento,
        Endereco endereco,
        Arquivo? foto = null) : base(id)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        DataNascimento = dataNascimento;
        Endereco = endereco;
        Foto = foto;
    }
}