using FluentAssertions;
using ForecastApp.Models;
using ForecastApp.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ForecastApp.UnitTest.Repository
{
    [TestFixture]
    internal class SalesRepositoryTests
    {

        [Test]
        public async Task GetSalesByYearAsync_GivenAYear_WhenData_ShouldReturnSales()
        {
            int year = 2022;
            var sales = new List<Sales>
            {
                new Sales{State = "State1", TotalSales= 10},
                new Sales{State = "State2", TotalSales= 20},
            };

            var dt = new DataTable();
            dt.Columns.Add("State");
            dt.Columns.Add("TotalSales");
            var row1 = dt.NewRow();
            row1["State"] = "State1";
            row1["TotalSales"] = "10";
            dt.Rows.Add(row1);
            var row2 = dt.NewRow();
            row2["State"] = "State2";
            row2["TotalSales"] = "20";
            dt.Rows.Add(row2);


            var sqlDataContextMoq = new Mock<ISqlDataContext>();
            sqlDataContextMoq.Setup(s => s.ExecuteReaderAsync("usp_GetSalesyYearAndState", CommandType.StoredProcedure, It.Is<List<SqlParameter>>(p => p.All(x => x.ParameterName == "Year" && ((int)x.Value) == year)))).ReturnsAsync(dt);


            var sut = new SalesRepository(sqlDataContextMoq.Object);

            var result = await sut.GetSalesByYearAsync(year);

            result.Should().BeEquivalentTo(sales);
        }

        private static IEnumerable<DataTable> EmptyDataTable
        {
            get
            {
                yield return new DataTable();
                yield return null;
            }
        }

        [Test, TestCaseSource(nameof(EmptyDataTable))]
        public async Task GetSalesByYearAsync_GivenAYear_WhenNoData_ShouldReturnEmptyList(DataTable dt)
        {
            int year = 2022;

            var sqlDataContextMoq = new Mock<ISqlDataContext>();
            sqlDataContextMoq.Setup(s => s.ExecuteReaderAsync("usp_GetSalesyYearAndState", CommandType.StoredProcedure, It.Is<List<SqlParameter>>(p => p.All(x => x.ParameterName == "Year" && ((int)x.Value) == year)))).ReturnsAsync(dt);


            var sut = new SalesRepository(sqlDataContextMoq.Object);

            var result = await sut.GetSalesByYearAsync(year);

            result.Should().BeEmpty();
        }


        [Test]
        public async Task GetSalesByYearAsync_GivenAYear_ShouldCallUsp()
        {
            int year = 2022;

            var sqlDataContextMoq = new Mock<ISqlDataContext>();
            sqlDataContextMoq.Setup(s => s.ExecuteReaderAsync("usp_GetSalesyYearAndState", CommandType.StoredProcedure, It.Is<List<SqlParameter>>(p => p.All(x => x.ParameterName == "Year" && ((int)x.Value) == year)))).ReturnsAsync(new DataTable());


            var sut = new SalesRepository(sqlDataContextMoq.Object);

            await sut.GetSalesByYearAsync(year);

            sqlDataContextMoq.Verify(s => s.ExecuteReaderAsync("usp_GetSalesyYearAndState", CommandType.StoredProcedure, It.Is<List<SqlParameter>>(p => p.All(x => x.ParameterName == "Year" && ((int)x.Value) == year))), Times.Once);
        }
    }
}
