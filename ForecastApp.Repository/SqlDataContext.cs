using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ForecastApp.Repository
{
    public class SqlDataContext : ISqlDataContext
    {
        private SqlConnection _connection;
        private readonly string _connectionString;


        public SqlDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        private void CreateConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException("Connection string cannot be null");
            }

            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }

            if (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
            {
                _connection.Open();
            }
        }

        public async Task<DataTable> ExecuteReaderAsync(string query, CommandType commandType = CommandType.Text, ICollection<SqlParameter> parameters = null)
        {

            CreateConnection();
            using (var cmd = new SqlCommand(query, _connection))
            {
                cmd.CommandType = commandType;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    return dataTable;
                }
            }
        }
    }
}
