using System.Data;
using Clinical.Application.Dtos.Exam.Response;
using Clinical.Application.Interface.Interfaces;
using Clinical.Domain.Entities;
using Clinical.Persistence.Context;
using Dapper;

namespace Clinical.Persistence.Repositories;

public class ExamRepository : GenericRepository<Exam>, IExamRepository
{
    private readonly ApplicationDbContext _context;

    public ExamRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GetAllExamResponseDto>> GetAllExamsAsync(string storedProcedure)
    {
        using var connection = _context.CreateConnection;
        var exams = await connection.QueryAsync<GetAllExamResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
        return exams;
    }
}