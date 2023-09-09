using SpecialTask.DataAccsess.Common;
using SpecialTask.Domain.Entities.Categories;

namespace SpecialTask.DataAccsess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>, IGetAll<Category>
{}
