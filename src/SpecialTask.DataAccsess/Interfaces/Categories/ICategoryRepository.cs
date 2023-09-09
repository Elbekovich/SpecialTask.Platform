using SpecialTask.DataAccsess.Common;
using SpecialTask.Domain.Entities.Categories;
using SpecialTask.Domain.Entities.Posts;

namespace SpecialTask.DataAccsess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>, IGetAll<Category>
{
    Task<IList<Post>> GetPostsByCategory(long category);
}
