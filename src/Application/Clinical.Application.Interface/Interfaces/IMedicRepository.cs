using Clinical.Application.Dtos.Medic;
using Clinical.Domain.Entities;

namespace Clinical.Application.Interface.Interfaces;

public interface IMedicRepository:IGenericRepository<Medic>
{
    Task<IEnumerable<GetAllMedicResponseDto>> GetAllMedicsAsync(string storedProcedure);
}