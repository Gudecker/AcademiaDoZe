// Gustavo Decker Couto
using AcademiaDoZe.Domain.Common;

namespace AcademiaDoZe.Domain.Entities;

public class AcessoColaborador : Entity, IAggregateRoot
{
    public int ColaboradorId { get; private set; }
    public DateTime DataHoraEntrada { get; private set; }
    public DateTime? DataHoraSaida { get; private set; }

    public AcessoColaborador(int id, int colaboradorId, DateTime dataHoraEntrada, DateTime? dataHoraSaida = null) : base(id)
    {
        ColaboradorId = colaboradorId;
        DataHoraEntrada = dataHoraEntrada;
        DataHoraSaida = dataHoraSaida;
    }
}