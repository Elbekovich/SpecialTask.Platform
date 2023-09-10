using SpecialTask.DataAccsess.Interfaces.Categories;
using SpecialTask.DataAccsess.Interfaces.Posts;
using SpecialTask.DataAccsess.Interfaces.Users;
using SpecialTask.DataAccsess.Repositories.Categories;
using SpecialTask.DataAccsess.Repositories.Posts;
using SpecialTask.DataAccsess.Repositories.Users;

namespace SpecialTask.WebApi.Configurations.Layers
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureDataAccess(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
        }
    }
}
