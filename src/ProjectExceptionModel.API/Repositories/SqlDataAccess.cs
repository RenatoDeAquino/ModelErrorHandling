using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ProjectExceptionModel.API.Repositories
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string data, U parameters, string connectionId = "Default");
    }

    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string data, U parameters, string connectionId = "Default")
        {
            try
            {
                using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
                return await connection.QueryAsync<T>(data, parameters, commandTimeout: 30);

            }
            catch (Exception ex)
            {
                return (IEnumerable<T>)ex;
            }

        }
    }
}
