using ForecastApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForecastApp.Repository
{
    public interface ISalesRepository
    {
        Task<List<Sales>> GetSalesByYearAsync(int year);
    }
}