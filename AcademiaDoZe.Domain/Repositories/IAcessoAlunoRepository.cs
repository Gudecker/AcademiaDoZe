//Gustavo Decker Couto

using AcademiaDoZe.Domain.Entities;

namespace AcademiaDoZe.Domain.Repositories;

public interface IAcessoAlunoRepository : IRepository<AcessoAluno>
{
    Task<IEnumerable<AcessoAluno>> ObterPorAlunoIdAsync(int alunoId, CancellationToken cancellationToken = default);
}