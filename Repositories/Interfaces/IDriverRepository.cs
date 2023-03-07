using FormulaApi.Models;

namespace FormulaApi.Repositories.Interfaces;

public interface IDriverRepository : IGenericRepository<Driver>
{
    Task<Driver?> GetByDriverNumber(int driverNumber);
}
