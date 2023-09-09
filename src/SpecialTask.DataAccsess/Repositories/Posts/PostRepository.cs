using Dapper;
using SpecialTask.Application.Utils;
using SpecialTask.DataAccsess.Interfaces.Posts;
using SpecialTask.Domain.Entities.Categories;
using SpecialTask.Domain.Entities.Posts;

namespace SpecialTask.DataAccsess.Repositories.Posts;

public class PostRepository : BaseRepository, IPostRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from posts";
            var result = await _connection.QuerySingleAsync<long>(query);

            return result;
        }
        catch { return 0; }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> CreateAsync(Post entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.posts(category_id, user_id, " +
                "post_image, title, price, description, region, phone_number, " +
                "created_at, updated_at)" +
                "VALUES (@CategoryId, @UserId, @PostImage, @Title, @Price, @Description, @Region, @PhoneNumber, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM posts WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });

            return result;

        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
        

    }

    public async Task<IList<Post>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM posts order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Post>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Post>();
        }
        finally { await _connection.CloseAsync(); }

            
    }

    public async Task<IList<Post>> GetAllPostById(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM posts where user_id=@Id";
            var res = await _connection.QueryAsync<Post>(query, new { Id = id });

            return (IList<Post>)res;
        }
        catch
        {
            return new List<Post>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Post?> GetByIdAsync(long id, Post result)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM posts where id=@Id";
            var res = await _connection.QuerySingleAsync<Post>(query, new { Id = id });
            return res;
        }
        catch { return null; }
        finally { await _connection.CloseAsync(); }
    }

    public Task<Post?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Post>> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.posts WHERE name ILIKE '%{search}%' " +
                    $"ORDER BY id DESC OFFSET {@params.GetSkipCount} LIMIT {@params.PageSize}";

            var ps = await _connection.QueryAsync<Post>(query);

            return ps.ToList();
        }
        catch { return new List<Post>(); }
        finally { await _connection.CloseAsync(); }
    }
    
    public async Task<int> SearchCountAsync(string search)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT COUNT(*) FROM public.posts WHERE name ILIKE '%{search}%'";
            var count = await _connection.ExecuteScalarAsync<int>(query);

            return count;
        }
        catch { return 0; }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> UpdateAsync(long id, Post entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.posts SET category_id=@CategoryId, user_id=@UserId, post_image=@PostImage, title=@Title, price=@Price, description=@Description, region=@Region, phone_number=@PhoneNumber, created_at=@CreatedAt, updated_at=@UpdatedAt" +
                $"WHERE  id={id};";
            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch { return 0; }
        finally { await _connection.CloseAsync(); }
    }
}
