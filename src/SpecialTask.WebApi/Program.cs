using AspNetCoreRateLimit;
using Microsoft.AspNetCore.RateLimiting;
using SpecialTask.WebApi.Configurations;
using SpecialTask.WebApi.Configurations.Layers;
using SpecialTask.WebApi.Middlewares;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", options =>
    {
        options.PermitLimit = 5;
        options.Window = TimeSpan.FromSeconds(10);
    });

    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        await context.HttpContext.Response.WriteAsync(
        "Too many requests. Please try again later.", cancellationToken: token);
    };

    options.AddConcurrencyLimiter("concurrency", options =>
    {
        options.PermitLimit = 10;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 5;
    });

});


builder.ConfigureJwtAuth();
builder.ConfigureSwaggerAuth();

builder.ConfigureCORSPolicy();
builder.ConfigureServiceLayer();
builder.ConfigureDataAccess();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.UseRateLimiter();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseMiddleware<CrosOriginAccessMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();
