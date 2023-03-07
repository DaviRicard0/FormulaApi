namespace FormulaApi.Repositories.Interfaces;

public interface IUnitOfWork
{
    IDriverRepository Drivers { get; }

    Task CompleteAsync();
}
