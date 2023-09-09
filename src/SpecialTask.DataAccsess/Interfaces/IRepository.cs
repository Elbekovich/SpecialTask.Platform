namespace SpecialTask.DataAccsess.Interfaces;

public interface IRepository<TEntity, TViewModel>
{
    public Task<int> CreateAsync(TEntity entity);
    public Task<int> UpdateAsync(long id, TEntity entity);
    public Task<int> DeleteAsync(long id);
    public Task<long> CountAsync();
    public Task<TViewModel?> GetByIdAsync(long id);
}
