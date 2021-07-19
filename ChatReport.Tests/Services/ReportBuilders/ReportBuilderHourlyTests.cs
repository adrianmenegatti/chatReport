using ChatReport.Core.Repositories;
using ChatReport.Data.Repositories;
using ChatReport.Services.ReportBuilders;
using System;
using System.Linq;
using Xunit;

namespace ChatReport.Tests.Services.ReportBuilders
{
    public class ReportBuilderHourlyTests
    {
        private readonly IChatEventsRepository repository;
        private readonly ReportBuilderBase reportBuilder;
        private readonly DateTime dateTime;

        public ReportBuilderHourlyTests()
        {
            repository = new ChatEventsRepository();
            reportBuilder = new ReportBuilderHourly(repository);
            dateTime = new DateTime(2021, 6, 1);
        }

        [Fact]
        public void GetReportReturnsDataForTheGivenDate()
        {
            var result = reportBuilder.GetReport(dateTime);

            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetReportReturnsHourlyConsolidatedData()
        {
            var result = reportBuilder.GetReport(dateTime);

            Assert.Equal(4, result.Count());
        }
    }
}
