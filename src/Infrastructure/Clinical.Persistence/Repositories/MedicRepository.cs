using System.Data;
using Clinical.Application.Dtos.Medic;
using Clinical.Application.Interface.Interfaces;
using Clinical.Domain.Entities;
using Clinical.Persistence.Context;
using Dapper;

namespace Clinical.Persistence.Repositories;

public class MedicRepository : GenericRepository<Medic>, IMedicRepository
{
    private readonly ApplicationDbContext _context;

    public MedicRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedicsAsync(string storedProcedure)
    {
        var connection = _context.CreateConnection;
        var medics = await connection.QueryAsync<GetAllMedicResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
        return medics;
    }
}