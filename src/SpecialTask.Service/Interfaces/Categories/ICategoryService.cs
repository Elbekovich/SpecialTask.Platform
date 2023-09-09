using SpecialTask.Application.Utils;
using SpecialTask.Domain.Entities.Categories;
using SpecialTask.Domain.Entities.Posts;
using SpecialTask.Persistance.Dtos.Categories;

namespace SpecialTask.Service.Interfaces.Categories
{
    public interface ICategoryService
    {
        public Task<bool> CreateAsync(CategoryCreateDto dto);
        public Task<bool> DeleteAsync(long categoryId);
        public Task<long> CountAsync();
        public Task<IList<Category>> GetAllAsync(PaginationParams @params);
        public Task<Category> GetByIdAsync(long categoryId);
        public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto);
        public Task<IList<Post>> GetPostsByCategory(long category);
    }
}
