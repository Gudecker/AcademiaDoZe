//Gustavo Decker Couto

using AcademiaDoZe.Domain.Entities;

namespace AcademiaDoZe.Domain.Repositories;

public interface IColaboradorRepository : IRepository<Colaborador>
{
    Task<Colaborador?> ObterPorCpfAsync(string cpf, CancellationToken cancellationToken = default);
    Task<Colaborador?> ObterPorEmailAsync(string email, CancellationToken cancellationToken = default);
}