using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PayOrg.Repository
{
    public abstract class BaseRepository
    {
        protected string _connectionString;
        private readonly IConfiguration _configuration;
        protected BaseRepository(IConfiguration config)
        {
            _configuration = config;
            _connectionString = _configuration.GetConnectionString("AppPagEmDia");

        }
        protected async Task<T> UseSqlConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var data = await getData(connection);

                    return data;
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
        }
    }
}
