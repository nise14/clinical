using Clinical.Application.Interface.Interfaces;
using Clinical.Domain.Entities;
using Clinical.Persistence.Context;

namespace Clinical.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IGenericRepository<Analysis> Analysis { get; }
    public IExamRepository Exam { get; }
    public IPatientRepository Patient { get; }
    public IMedicRepository Medic { get; }

    public UnitOfWork(ApplicationDbContext context, IGenericRepository<Analysis> analysis)
    {
        Analysis = analysis;
        Exam = new ExamRepository(context);
        _context = context;
        Patient = new PatientRepository(context);
        Medic = new MedicRepository(context);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}