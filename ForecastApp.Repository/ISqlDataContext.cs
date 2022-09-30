using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ForecastApp.Repository
{
    public interface ISqlDataContext
    {
        Task<DataTable> ExecuteReaderAsync(string query, CommandType commandType = CommandType.Text, ICollection<SqlParameter> parameters = null);
    }
}