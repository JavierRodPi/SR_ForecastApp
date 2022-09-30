using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.Repository
{
    public class StateRepository
    {
        private readonly ISqlDataContext _sqlDataContext;
        public StateRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }

        public async Task<List<string>> GetStatesAsync()
        {
            var data = await _sqlDataContext.ExecuteReaderAsync("select distinct state from Orders order by state");

            var states = new List<string>();
            if (data == null)
            {
                return states;
            }
            foreach (DataRow row in data.Rows)
            {
                states.Add(row["State"].ToString());
            }
            return states;
        }
    }
}
