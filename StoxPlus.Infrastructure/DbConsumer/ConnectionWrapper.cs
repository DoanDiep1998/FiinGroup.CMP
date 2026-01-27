using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
namespace StoxPlus.Infrastructure.DbConsumer
{
    public class ConnectionWrapper
    {
        private readonly string _connectionString;

        public ConnectionWrapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> Query<T>(string sql, object parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 30)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return conn.Query<T>(sql, parameters, commandType: commandType, commandTimeout: commandTimeOut);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 30)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return await conn.QueryAsync<T>(sql, parameters, commandType: commandType, commandTimeout: commandTimeOut);
            }
        }

        public T QueryFirstOrDefault<T>(string sql, object parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return conn.QueryFirstOrDefault<T>(sql, parameters, commandType: commandType);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return await conn.QueryFirstOrDefaultAsync<T>(sql, parameters, commandType: commandType);
            }
        }

        public T ExecuteScalar<T>(string sql, object parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return conn.ExecuteScalar<T>(sql, parameters, commandType: commandType);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, object parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return await conn.ExecuteScalarAsync<T>(sql, parameters, commandType: commandType);
            }
        }

        public int Execute(string sql, object parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return conn.Execute(sql, parameters, commandType: commandType);
            }
        }

        public async Task<int> ExecuteAsync(string sql, object parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                return await conn.ExecuteAsync(sql, parameters, commandType: commandType);
            }
        }

        public async Task<T> QueryMultiAsync<T>(string sql, Func<SqlMapper.GridReader, T> processor, object parameters = null, CommandType commandType = CommandType.Text)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (var reader = await conn.QueryMultipleAsync(sql, param: parameters, commandType: commandType))
                {
                    return processor(reader);
                }
            }
        }


    }
}
