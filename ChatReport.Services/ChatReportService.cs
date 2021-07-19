using ChatReport.Core.Models;
using ChatReport.Core.Repositories;
using ChatReport.Core.Services;
using ChatReport.Services.ReportBuilders;
using System;
using System.Collections.Generic;

namespace ChatReport.Services
{
    public class ChatReportService : IChatReportService
    {
        private readonly IChatEventsRepository repository;

        public ChatReportService(IChatEventsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ChatReportItem> GetReport(DateTime dateTime, AggregationType aggregationType)
        {
            var reportBuilderCreator = ReportBuilderFactory.GetReportBuilder(aggregationType);
            var reportBuilder = reportBuilderCreator.GetReportBuilder(repository);

            return reportBuilder.GetReport(dateTime);
        }
    }
}
