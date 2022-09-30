using FluentAssertions;
using ForecastApp.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ForecastApp.UnitTest.Repository
{
    [TestFixture]
    internal class StateRepositoryTests
    {

        [Test]
        public async Task GetStatesAsync_WhenData_ShouldReturnStates()
        {
            var states = new List<string>
            {
                "State1",
                "State2"
            };

            var dt = new DataTable();
            dt.Columns.Add("State");
            var row1 = dt.NewRow();
            row1["State"] = "State1";
            dt.Rows.Add(row1);
            var row2 = dt.NewRow();
            row2["State"] = "State2";
            dt.Rows.Add(row2);


            var sqlDataContextMoq = new Mock<ISqlDataContext>();
            sqlDataContextMoq.Setup(s => s.ExecuteReaderAsync("select distinct state from Orders order by state", It.IsAny<CommandType>(), It.IsAny<List<SqlParameter>>())).ReturnsAsync(dt);


            var sut = new StateRepository(sqlDataContextMoq.Object);

            var result = await sut.GetStatesAsync();

            result.Should().BeEquivalentTo(states);
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
        public async Task GetStatesAsync_WhenNoData_ShouldReturnEmptyList(DataTable dt)
        {
            var sqlDataContextMoq = new Mock<ISqlDataContext>();
            sqlDataContextMoq.Setup(s => s.ExecuteReaderAsync("select distinct state from Orders order by state", default, default)).ReturnsAsync(dt);


            var sut = new StateRepository(sqlDataContextMoq.Object);

            var result = await sut.GetStatesAsync();

            result.Should().BeEmpty();
        }


        [Test]
        public async Task GetStatesAsync_ShouldExecuteQuery()
        {
            int year = 2022;

            var sqlDataContextMoq = new Mock<ISqlDataContext>();
            sqlDataContextMoq.Setup(s => s.ExecuteReaderAsync("select distinct state from Orders order by state", It.IsAny<CommandType>(), It.IsAny<List<SqlParameter>>())).ReturnsAsync(new DataTable());


            var sut = new StateRepository(sqlDataContextMoq.Object);

            await sut.GetStatesAsync();

            sqlDataContextMoq.Verify(s => s.ExecuteReaderAsync("select distinct state from Orders order by state", It.IsAny<CommandType>(), It.IsAny<List<SqlParameter>>()), Times.Once);
        }
    }
}
