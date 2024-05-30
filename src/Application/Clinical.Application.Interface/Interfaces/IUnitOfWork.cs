using Clinical.Domain.Entities;

namespace Clinical.Application.Interface.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Analysis> Analysis { get; }
    IExamRepository Exam { get; }
    IPatientRepository Patient { get; }
    IMedicRepository Medic { get; }
}