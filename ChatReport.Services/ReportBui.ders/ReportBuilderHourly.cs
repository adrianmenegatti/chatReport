using ChatReport.Core.Models;
using ChatReport.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatReport.Services.ReportBuilders
{
    public class ReportBuilderHourly : ReportBuilderBase
    {
        public ReportBuilderHourly(IChatEventsRepository repository) : base(repository)
        {
        }

        public override IEnumerable<ChatReportItem> GetReport(DateTime dateTime)
        {
            var events = repository.GetEvents(dateTime);

            var result = events.GroupBy(evt => new { evt.DateTime.Date, evt.DateTime.Hour, type = evt.GetType() })
                .Select(grp => new ChatReportItem(new DateTime(grp.Key.Date.Year, grp.Key.Date.Month, grp.Key.Date.Day, grp.Key.Hour, 0, 0), grp.FirstOrDefault().GetShortString(grp.ToList())));

            return result;
        }
    }
}
