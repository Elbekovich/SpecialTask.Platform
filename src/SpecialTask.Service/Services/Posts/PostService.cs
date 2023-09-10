using SpecialTask.Application.Exceptions.Categories;
using SpecialTask.Application.Exceptions.Posts;
using SpecialTask.Application.Exceptions.Users;
using SpecialTask.Application.Utils;
using SpecialTask.DataAccsess.Common.Helpers;
using SpecialTask.DataAccsess.Interfaces.Categories;
using SpecialTask.DataAccsess.Interfaces.Posts;
using SpecialTask.DataAccsess.Interfaces.Users;
using SpecialTask.Domain.Entities.Posts;
using SpecialTask.Persistance.Dtos.Posts;
using SpecialTask.Service.Interfaces.Common;
using SpecialTask.Service.Interfaces.Posts;

namespace SpecialTask.Service.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IPaginator _paginator;
        private readonly ICategoryRepository _category;
        private readonly IUserRepository _user;
        public PostService(IPostRepository postRepository,
            IPaginator paginator)
        {
            this._paginator = paginator;
            this._postRepository = postRepository;
        }

        public async Task<bool> CreateAsync(PostCreateDto dto)
        {
            Post post = new Post()
            {
                CategoryId = dto.CategoryId,
                UserId = dto.UserId,
                Title = dto.Title,
                Price = dto.Price,
                Description = dto.Description,
                Region = dto.Region,
                PhoneNumber = dto.PhoneNumber,
                CreatedAt = TimeHelper.GetDateTime(),
                UpdatedAt = TimeHelper.GetDateTime(),
            };
            post.CategoryId = dto.CategoryId;
            var js = await _category.GetByIdAsync(post.CategoryId);
            if (js == null) throw new CategoryNotFoundException();
            post.UserId = dto.UserId;
            var cs = await _user.GetByIdAsync(post.UserId);
            if (cs == null) throw new UserNotFoundException();
            var res = await _postRepository.CreateAsync(post);

            return res > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var db = await _postRepository.GetByIdAsync(id);
            if (db is null) throw new PostNotFoundException();
            var dbResult = await _postRepository.DeleteAsync(id);

            return dbResult > 0;
        }

        public async Task<IList<Post>> GetAllAsync(PaginationParams @params)
        {
            var posts = await _postRepository.GetAllAsync(@params);
            var count = await _postRepository.CountAsync();
            _paginator.Paginate(count, @params);
            return posts;
        }

        public async Task<IList<Post>> GetAllPostById(long id)
        {
            var posts = await _postRepository.GetAllPostById(id);
            return posts;
        }

        public async Task<IList<Post>> GetByIdAsync(long id)
        {
            var posts = await _postRepository.GetByIdAsync(id);
            if (posts is null) throw new PostNotFoundException();

            return (IList<Post>)posts;
        }

        public async Task<IList<Post>> SearchAsync(string search, PaginationParams @params)
        {
            var posts = await _postRepository.SearchAsync(search, @params);
            int count = await _postRepository.SearchCountAsync(search);
            return posts;
        }

        public Task<int> SearchCountAsync(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(long id, PostUpdateDto dto)
        {
            var posts = await _postRepository.GetByIdAsync(id);
            if (posts is null) throw new PostNotFoundException();
            posts.CategoryId = dto.CategoryId;
            posts.UserId = dto.UserId;
            posts.Title = dto.Title;
            posts.Price = double.Parse(dto.Price.ToString());
            posts.Description = dto.Description;
            posts.Region = dto.Region;
            posts.PhoneNumber = dto.PhoneNumber;
            posts.UpdatedAt = TimeHelper.GetDateTime();
            var dbRes = await _postRepository.UpdateAsync(id, posts);

            return dbRes > 0;
        }
    }
}
