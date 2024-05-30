using Clinical.Application.Dtos.Patient.Response;
using Clinical.Domain.Entities;

namespace Clinical.Application.Interface.Interfaces;

public interface IPatientRepository : IGenericRepository<Patient>
{
    Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatientsAsync(string storedProcedureName);
}