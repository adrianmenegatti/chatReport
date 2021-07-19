using ChatReport.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatReport.Services.ReportBuilders
{
    public class ReportBuilderHourlyCreator : IReportBuilderCreator
    {
        public ReportBuilderBase GetReportBuilder(IChatEventsRepository repository)
        {
            return new ReportBuilderHourly(repository);
        }
    }
}
