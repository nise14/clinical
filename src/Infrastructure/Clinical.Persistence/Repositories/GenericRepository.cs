using System.Data;
using Clinical.Application.Interface.Interfaces;
using Clinical.Persistence.Context;
using Dapper;

namespace Clinical.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExecuteAsync(string storedProcedure, object parameters)
    {
        using var connection = _context.CreateConnection;
        var objParams = new DynamicParameters(parameters);
        var reccordAffected = await connection.ExecuteAsync(storedProcedure, param: objParams, commandType: CommandType.StoredProcedure);
        return reccordAffected > 0;
    }

    public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure)
    {
        using var connection = _context.CreateConnection;
        return await connection.QueryAsync<T>(storedProcedure, commandType: CommandType.StoredProcedure);
    }

    public async Task<T> GetByIdAsync(string storedProcedure, object parameter)
    {
        using var connection = _context.CreateConnection;
        var objParam = new DynamicParameters(parameter);
        var result = await connection
             .QuerySingleOrDefaultAsync<T>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);

        return result!;
    }
}