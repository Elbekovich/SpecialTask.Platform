using Dapper;
using SpecialTask.Application.Utils;
using SpecialTask.DataAccsess.Interfaces.Users;
using SpecialTask.DataAccsess.ViewModels;
using SpecialTask.Domain.Entities.Users;
using static Dapper.SqlMapper;

namespace SpecialTask.DataAccsess.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from users";
            var result = await _connection.QuerySingleAsync<long>(query);

            return result;

        }
        catch { return 0; }
        finally { await _connection.CloseAsync(); }
    }

    public Task<int> CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM users WHERE id=@Id";
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

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        //throw new NotImplementedException();
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.users WHERE LENGTH(last_name) > 0 ORDER BY id DESC OFFSET {@params.GetSkipCount()} " +
            $"LIMIT {@params.PageSize}";

            var resUser = (await _connection.QueryAsync<User>(query)).ToList();

            var userViewModels = resUser.Select(user => new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ImagePath = user.ImagePath,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
            }).ToList();

            return userViewModels;
        }
        catch { return  new List<UserViewModel>(); }
        finally { await _connection.CloseAsync(); }
    }

    public Task<IList<UserViewModel>> GetALlPostByUserId(long userId)
    {
        throw new NotImplementedException();
    }

    public async Task<UserViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string qeury = $"SELECT * FROM users where id=@Id";
            var result = await _connection.QuerySingleAsync<UserViewModel>(qeury, new { Id = id });

            return result;
        }
        catch { return  null; }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        //throw new NotImplementedException();
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM public.users WHERE phone_number=@PhoneNumber;";
            var result = await _connection.QueryFirstOrDefaultAsync<User>(query, new { PhoneNumber = phone });

            return result;
        }
        catch
        {
            return null;
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<IList<UserViewModel>> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.users WHERE first_name ILIKE '%{search}%' " +
                    $"ORDER BY id DESC OFFSET {@params.GetSkipCount} LIMIT {@params.PageSize}";

            var user = await _connection.QueryAsync<UserViewModel>(query);

            return user.ToList();

        }
        catch { return null; }
        finally { await _connection.CloseAsync(); }
            

    }

    public async Task<int> SearchCountAsync(string search)
    {
        //throw new NotImplementedException();
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT COUNT(*) FROM public.users WHERE first_name ILIKE '%{search}%'";
            var count = await _connection.ExecuteScalarAsync<int>(query);

            return count;
        }
        catch
        {
            return 0;
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> UpdateAsync(long id, UserViewModel users)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.users " +
                $"SET first_name=@FirstName, last_name=@LastName," +
                    $" phone_number=@PhoneNumber, phone_numer_confirmed=@PhoneNumberConfirmed, " +
                        $"image_path=@ImagePath, password_hash=@PasswordHash, " +
                            $"salt=@Salt, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                                $"WHERE id = @Id";
            var paramaters = new User()
            {
                Id = id,
                FirstName = users.FirstName,
                LastName = users.LastName,
                PhoneNumber = users.PhoneNumber,
                PhoneNumerConfirmed = users.PhoneNumerConfirmed,
                ImagePath = users.ImagePath,
                UpdatedAt = users.UpdatedAt,
            };
            var res = await _connection.ExecuteAsync(query, paramaters);
            
            return res;
        }
        catch { return 0; }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.users " +
                $"SET first_name=@FirstName, last_name=@LastName," +
                    $" phone_number=@PhoneNumber, phone_numer_confirmed=@PhoneNumberConfirmed, " +
                        $"image_path=@ImagePath, password_hash=@PasswordHash, " +
                            $"salt=@Salt, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                                $"WHERE id = {id}";
            var res = await _connection.ExecuteAsync(query, entity);
            
            return res;
        }
        catch { return 0; }
        finally { await _connection.CloseAsync(); }
    }
}
