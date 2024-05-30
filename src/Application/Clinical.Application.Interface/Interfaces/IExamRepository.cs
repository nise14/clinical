using Clinical.Application.Dtos.Exam.Response;
using Clinical.Domain.Entities;

namespace Clinical.Application.Interface.Interfaces;

public interface IExamRepository:IGenericRepository<Exam>
{
    Task<IEnumerable<GetAllExamResponseDto>> GetAllExamsAsync(string storedProcedure);
}