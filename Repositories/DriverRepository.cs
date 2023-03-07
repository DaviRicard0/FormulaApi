using FormulaApi.Data;
using FormulaApi.Models;
using FormulaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(ILogger logger, FormulaApiContext context) : base(logger, context)
    {
    }

    public override async Task<IEnumerable<Driver>> GetAll()
    {
		try
		{
			return await _context.Drivers.AsNoTracking().ToListAsync();
		}
		catch (Exception)
		{

			throw;
		}
    }

    public override async Task<Driver?> GetById(Guid id)
    {
        try
        {
            return await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<Driver?> GetByDriverNumber(int driverNumber)
    {
        try
        {
            return await _context.Drivers.FirstOrDefaultAsync(x => x.DriverNumber == driverNumber);
        }
        catch (Exception)
        {

            throw;
        }
    }
}
