// Gustavo Decker Couto
using AcademiaDoZe.Domain.Common;
using AcademiaDoZe.Domain.Services;
using AcademiaDoZe.Domain.ValueObjects;

namespace AcademiaDoZe.Domain.Entities;

public class Colaborador
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public Email Email { get; private set; }
    public Telefone Telefone { get; private set; }
    public Endereco Endereco { get; private set; }
    public Arquivo? Foto { get; private set; }

    private Colaborador(int id, string nome, string cpf, Email email, Telefone telefone, Endereco endereco, Arquivo? foto)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        Foto = foto;
    }

    public static Result<Colaborador> Criar(
        int id, 
        string? nome, 
        string? cpf, 
        Email? email, 
        Telefone? telefone, 
        Endereco? endereco, 
        Arquivo? foto = null)
    {
        var notifications = new List<Notification>();

        var nomeNormalizado = NormalizadoService.NormalizarTexto(nome);
        var cpfLimpo = NormalizadoService.ApenasNumeros(cpf);

        if (string.IsNullOrWhiteSpace(nomeNormalizado))
        {
            notifications.Add(new Notification("Colaborador.Nome", "O nome é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(cpfLimpo) || cpfLimpo.Length != 11)
        {
            notifications.Add(new Notification("Colaborador.Cpf", "O CPF é obrigatório e deve conter 11 dígitos."));
        }

        if (email is null)
        {
            notifications.Add(new Notification("Colaborador.Email", "O e-mail é obrigatório."));
        }

        if (telefone is null)
        {
            notifications.Add(new Notification("Colaborador.Telefone", "O telefone é obrigatório."));
        }

        if (endereco is null)
        {
            notifications.Add(new Notification("Colaborador.Endereco", "O endereço é obrigatório."));
        }

        if (notifications.Count > 0)
        {
            return Result<Colaborador>.Failure(notifications);
        }

        return Result<Colaborador>.Success(new Colaborador(
            id, 
            nomeNormalizado, 
            cpfLimpo, 
            email!, 
            telefone!, 
            endereco!, 
            foto));
    }
}