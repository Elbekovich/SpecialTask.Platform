using Npgsql;

namespace SpecialTask.DataAccsess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection("Host=db-postgresql-lon1-56814-do-user-14588545-0.b.db.ondigitalocean.com; Port=25060; Database=Ozodbek; User Id=doadmin; Password=AVNS_9n5XkthWFqLIltZLhLQ");
        //this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=exam; User Id=postgres; Password=9639;");
    }
}
