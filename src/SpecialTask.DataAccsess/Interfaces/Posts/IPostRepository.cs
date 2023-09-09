using SpecialTask.Application.Utils;
using SpecialTask.DataAccsess.Common;
using SpecialTask.Domain.Entities.Posts;

namespace SpecialTask.DataAccsess.Interfaces.Posts
{
    public interface IPostRepository : IRepository<Post, Post>, IGetAll<Post>
    {
        public Task<IList<Post>> SearchAsync(string search, PaginationParams @params);
        public Task<int> SearchCountAsync(string search);
        public Task<IList<Post>> GetAllPostById(long id);
    }
}
