using FluentAssertions;
using ForecastApp.Models;
using ForecastApp.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.UnitTest.Repository
{
    internal class SalesRepositoryTests
    {

        [Test]
        public async Task GetSalesByYearAsync_GivenAYear_Should_ReturnSales()
        {
            int year = 2022;
            var sales = new List<Sales>
            {
                new Sales{State = "Sate1", TotalSales= 10},
                new Sales{State = "Sate2", TotalSales= 20},
            };

            var dt = new DataTable();
            dt.Columns.Add("State");
            dt.Columns.Add("TotalSales");
            var row1 = dt.NewRow();
            row1["State"] = "Sate1";
            row1["TotalSales"] = "10";
            dt.Rows.Add(row1);
            var row2 = dt.NewRow();
            row2["State"] = "Sate2";
            row2["TotalSales"] = "20";
            dt.Rows.Add(row2);


            var sqlDataContextMoq = new Mock<ISqlDataContext>();
            sqlDataContextMoq.Setup(s => s.ExecuteReaderAsync("usp_GetSalesyYearAndState", CommandType.StoredProcedure, It.Is<List<SqlParameter>>(p => p.All(x => x.ParameterName == "Year" && ((int)x.Value) == year)))).ReturnsAsync(dt);


            var sut = new SalesRepository(sqlDataContextMoq.Object);

            var result = await sut.GetSalesByYearAsync(year);

            result.Should().BeEquivalentTo(sales);
        }
    }
}
