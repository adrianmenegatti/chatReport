using ChatReport.Core.Models;
using System;
using System.Collections.Generic;

namespace ChatReport.Services.ReportBuilders
{
    public static class ReportBuilderFactory
    {
        private static readonly Dictionary<AggregationType, Func<IReportBuilderCreator>> builders;

        static ReportBuilderFactory()
        {
            builders = new Dictionary<AggregationType, Func<IReportBuilderCreator>>
            {
                {AggregationType.MinuteByMinute, () => new ReportBuilderMinuteByMinuteCreator() },
                {AggregationType.Hourly, () => new ReportBuilderHourlyCreator() }
            };
        }

        public static IReportBuilderCreator GetReportBuilder(AggregationType aggregationType)
        {
            return builders[aggregationType]();
        }
    }
}
