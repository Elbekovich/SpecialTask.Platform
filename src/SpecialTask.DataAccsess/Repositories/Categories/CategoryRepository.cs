﻿using Dapper;
using SpecialTask.Application.Utils;
using SpecialTask.DataAccsess.Interfaces.Categories;
using SpecialTask.Domain.Entities.Categories;
using SpecialTask.Domain.Entities.Posts;

namespace SpecialTask.DataAccsess.Repositories.Categories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from categories";
            var result = await _connection.QuerySingleAsync<long>(query);

            return result;
        }
        catch
        {
            return 0;
        }
        finally { await _connection.CloseAsync(); } 
    }

    public async Task<int> CreateAsync(Category entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.categories(name, created_at, updated_at) " +
                "VALUES (@Name, @CreatedAt, @UpdatedAt);";

            var result = await _connection.ExecuteAsync(query, entity);

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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM categories WHERE id=@Id";

            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch { return 0; }
        finally { await _connection.CloseAsync(); } 
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM categories order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<Category>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Category>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Category?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM categories where id=@Id";
            var result = await _connection.QuerySingleAsync<Category>(query, new { Id = id });
            
            return result;
        }
        catch { return null; }
        finally { await _connection.CloseAsync(); } 
    }

    public async Task<IList<Post>> GetPostsByCategory(long category)
    {
        string query = "SELECT * FROM posts WHERE category_id = @CategoryId";
        var paramaters = new {Category = category};
        var posts = await _connection.QueryAsync<Post>(query, paramaters);
        return posts.ToList();
        
    }

    public async Task<int> UpdateAsync(long id, Category entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.categories " +
                $"SET name=@Name, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                    $"WHERE id={id};";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch { return 0; }
        finally { await _connection.CloseAsync(); }
    }
}
