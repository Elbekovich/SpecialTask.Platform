using SpecialTask.Application.Utils;

namespace SpecialTask.DataAccsess.Common;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}
