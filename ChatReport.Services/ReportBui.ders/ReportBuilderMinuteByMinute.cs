using ChatReport.Core.Models;
using ChatReport.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatReport.Services.ReportBuilders
{
    public class ReportBuilderMinuteByMinute : ReportBuilderBase
    {
        public ReportBuilderMinuteByMinute(IChatEventsRepository repository) : base(repository)
        {
        }

        public override IEnumerable<ChatReportItem> GetReport(DateTime dateTime)
        {
            return repository.GetEvents(dateTime).Select(evt => new ChatReportItem(evt.DateTime, evt.GetDetailedString()));
        }
    }
}
