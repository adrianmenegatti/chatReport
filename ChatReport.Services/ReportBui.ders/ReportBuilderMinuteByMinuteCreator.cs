using ChatReport.Core.Repositories;

namespace ChatReport.Services.ReportBuilders
{
    public class ReportBuilderMinuteByMinuteCreator : IReportBuilderCreator
    {
        public ReportBuilderBase GetReportBuilder(IChatEventsRepository repository)
        {
            return new ReportBuilderMinuteByMinute(repository);
        }
    }
}
