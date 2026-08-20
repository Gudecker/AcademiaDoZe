//Gustavo Decker Couto

using AcademiaDoZe.Domain.Common;

namespace AcademiaDoZe.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : IAggregateRoot
{
    Task<TEntity> AdicionarAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> AtualizarAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task RemoverAsync(int id, CancellationToken cancellationToken = default);
    Task<TEntity?> ObterPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> ObterTodosAsync(CancellationToken cancellationToken = default);
}