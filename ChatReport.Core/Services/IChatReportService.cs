using ChatReport.Core.Models;
using System;
using System.Collections.Generic;

namespace ChatReport.Core.Services
{
    public interface IChatReportService
    {
        IEnumerable<ChatReportItem> GetReport(DateTime dateTime, AggregationType aggregationType);
    }
}
