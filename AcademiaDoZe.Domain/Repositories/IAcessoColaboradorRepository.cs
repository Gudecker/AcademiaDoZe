//Gustavo Decker Couto

using AcademiaDoZe.Domain.Entities;

namespace AcademiaDoZe.Domain.Repositories;

public interface IAcessoColaboradorRepository : IRepository<AcessoColaborador>
{
    Task<IEnumerable<AcessoColaborador>> ObterPorColaboradorIdAsync(int colaboradorId, CancellationToken cancellationToken = default);
}