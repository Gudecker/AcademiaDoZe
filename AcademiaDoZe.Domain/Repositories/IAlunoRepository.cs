//Gustavo Decker Couto

using AcademiaDoZe.Domain.Entities;

namespace AcademiaDoZe.Domain.Repositories;

public interface IAlunoRepository : IRepository<Aluno>
{
    Task<Aluno?> ObterPorCpfAsync(string cpf, CancellationToken cancellationToken = default);
    Task<Aluno?> ObterPorEmailAsync(string email, CancellationToken cancellationToken = default);
}