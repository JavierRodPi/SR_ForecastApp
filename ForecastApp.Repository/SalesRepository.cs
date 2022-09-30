using ForecastApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ForecastApp.Repository
{
    public class SalesRepository
    {
        private readonly ISqlDataContext _sqlDataContext;
        public SalesRepository (ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }

        public async Task<List<Sales>> GetSalesByYearAsync(int year)
        {

            var sqlParameters = new List<SqlParameter> {
                new SqlParameter("Year", year)
            };
            var data =await _sqlDataContext.ExecuteReaderAsync("usp_GetSalesyYearAndState", CommandType.StoredProcedure, sqlParameters);
            
            var salesByState = new List<Sales>();
            if (data == null)
            {
                return salesByState;
            }
            foreach (DataRow row in data.Rows)
            {
                salesByState.Add(new Sales
                {
                    State = row["State"].ToString(),
                    TotalSales = Decimal.Parse(row["TotalSales"].ToString())
                });
            }
            return salesByState;
        }
    }
}
