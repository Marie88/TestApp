using System;
using System.Data;
using System.Data.SqlClient;
using TestApp.BuildingBlocks.Infrastructure.Database;

namespace TestApp.ModuleIntegration.ModuleDataAccess
{
    internal class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public SqlConnectionFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open) return _connection;

            _connection = new SqlConnection(_connectionString);
            _connection.Open();

            return _connection;
        }

        public IDbConnection CreateNewConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            return connection;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public void Dispose()
        {
            if (_connection !=null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }
        }
    }
}