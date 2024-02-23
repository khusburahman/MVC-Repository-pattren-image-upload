
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Webapp.DatabaseContext;
using Test.Webapp.Models.Base;

namespace Test.Webapp.Service;

public class RepositoryService<TEntity, IModel> : IRepositoryService<TEntity, IModel> where TEntity : AuditableEntity, new() where IModel : BaseEntity
{
    private readonly IMapper _mapper;
    private readonly StudentDbContext dbContext;

    public RepositoryService(StudentDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        this.dbContext = dbContext;
        DbSet= dbContext.Set<TEntity>();
    }
    public DbSet<TEntity> DbSet { get;}
    public async Task<IModel> DeleteAsync(long Id, CancellationToken cancellationToken)
    {
        var entity = await DbSet.FindAsync(Id);
        if (entity == null)
        {
            return null;
        }
        DbSet.Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        var deleteModel=_mapper.Map<TEntity,IModel>(entity);
        return deleteModel;
    }

    public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entites = await DbSet.Where(x=>!x.IsDelete) .ToListAsync(cancellationToken);
        if (entites == null) return null;
        var data = _mapper.Map<IEnumerable<IModel>>(entites);
        return data;
    }

    public async Task<IModel> GetByIdAsync(long Id, CancellationToken cancellationToken)
    {
        var entites = await DbSet.FindAsync(Id);
        if (entites == null) return null;
        var model=_mapper.Map<TEntity, IModel>(entites);
        return model;
    }

    public async Task<IModel> InsertAsync(IModel model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(model);
         entity.CreateDate = DateTime.Now;

        DbSet.Add(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        var insertModel = _mapper.Map<IModel>(entity);
        return insertModel;
    }

    public Task<IModel> InsertAsync(Microsoft.EntityFrameworkCore.Metadata.IModel model, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IModel> UpdateAsync(long Id, IModel model, CancellationToken cancellationToken)
    {
       var entity=await DbSet.FindAsync(Id);
        if (entity == null) return null;
        entity.ModifiedDate = DateTime.Now;

        _mapper.Map(model, entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        var updateModel=_mapper.Map<TEntity,IModel>(entity);
        return updateModel;

    }

  
}
