using FormulaApi.Repositories;
using FormulaApi.Repositories.Interfaces;

namespace FormulaApi.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly FormulaApiContext _context;
    public IDriverRepository Drivers { get; private set; }

    public UnitOfWork(ILoggerFactory loggerFactory, FormulaApiContext context)
    {
        var _logger = loggerFactory.CreateLogger("logs");
        _context = context;

        Drivers = new DriverRepository(_logger, context);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
