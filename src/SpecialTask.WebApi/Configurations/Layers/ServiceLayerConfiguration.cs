using SpecialTask.Service.Interfaces.Auth;
using SpecialTask.Service.Interfaces.Categories;
using SpecialTask.Service.Interfaces.Common;
using SpecialTask.Service.Interfaces.Notifactions;
using SpecialTask.Service.Interfaces.Posts;
using SpecialTask.Service.Interfaces.Users;
using SpecialTask.Service.Services.Auth;
using SpecialTask.Service.Services.Categories;
using SpecialTask.Service.Services.Categories.Layers;
using SpecialTask.Service.Services.Commons;
using SpecialTask.Service.Services.Notifications;
using SpecialTask.Service.Services.Posts;
using SpecialTask.Service.Services.Users;

namespace SpecialTask.WebApi.Configurations.Layers
{
    public static class ServiceLayerConfiguration
    {
        public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IPaginator, Paginator>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<ISmsSender, SmsSender>();
            builder.Services.AddScoped<IPostService, PostService>();
        }
    }
}
