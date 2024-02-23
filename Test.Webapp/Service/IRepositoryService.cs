using Microsoft.EntityFrameworkCore.Metadata;

namespace Test.Webapp.Service;

public interface IRepositoryService<TEntity,IModel>where TEntity : class,new() where IModel : class
{
    Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken);
    Task<IModel> InsertAsync(IModel model, CancellationToken cancellationToken);
    Task<IModel>UpdateAsync(long Id,IModel model, CancellationToken cancellationToken);
    Task<IModel> DeleteAsync(long Id,CancellationToken cancellationToken);
    Task<IModel>GetByIdAsync(long Id,CancellationToken cancellationToken);
}
