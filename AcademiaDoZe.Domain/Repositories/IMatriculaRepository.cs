//Gustavo Decker Couto

using AcademiaDoZe.Domain.Entities;

namespace AcademiaDoZe.Domain.Repositories;

public interface IMatriculaRepository : IRepository<Matricula>
{
    Task<IEnumerable<Matricula>> ObterPorAlunoIdAsync(int alunoId, CancellationToken cancellationToken = default);
}