using ChatReport.Core.Models;
using ChatReport.Core.Repositories;
using System;
using System.Collections.Generic;

namespace ChatReport.Services.ReportBuilders
{
    public abstract class ReportBuilderBase
    {
        protected readonly IChatEventsRepository repository;

        public ReportBuilderBase(IChatEventsRepository repository)
        {
            this.repository = repository;
        }

        public abstract IEnumerable<ChatReportItem> GetReport(DateTime dateTime);
    }
}
