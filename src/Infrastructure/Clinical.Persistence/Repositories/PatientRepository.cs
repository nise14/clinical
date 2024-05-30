using System.Data;
using Clinical.Application.Dtos.Patient.Response;
using Clinical.Application.Interface.Interfaces;
using Clinical.Domain.Entities;
using Clinical.Persistence.Context;
using Dapper;

namespace Clinical.Persistence.Repositories;

public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    private readonly ApplicationDbContext _context;

    public PatientRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatientsAsync(string storedProcedureName)
    {
        var connection = _context.CreateConnection;
        var patients = await connection.QueryAsync<GetAllPatientResponseDto>(storedProcedureName, commandType: CommandType.StoredProcedure);
        return patients;
    }
}