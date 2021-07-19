using ChatReport.Core.Repositories;

namespace ChatReport.Services.ReportBuilders
{
    public interface IReportBuilderCreator
    {
        ReportBuilderBase GetReportBuilder(IChatEventsRepository repository);
    }
}
