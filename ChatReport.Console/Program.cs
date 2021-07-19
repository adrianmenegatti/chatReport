using ChatReport.Core.Models;
using ChatReport.Core.Repositories;
using ChatReport.Core.Services;
using ChatReport.Data.Repositories;
using ChatReport.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChatReport.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = RegisterServices(new ServiceCollection());

            var service = serviceProvider.GetService<IChatReportService>();
            var dateTime = new DateTime(2021, 6, 1);

            BuildReport(service, dateTime);
        }

        public static void BuildReport(IChatReportService service, DateTime dateTime)
        {
            //minute by minute report
            var mbm = service.GetReport(dateTime, AggregationType.MinuteByMinute);

            System.Console.WriteLine("Minute by minute");
            foreach (var m in mbm)
            {
                System.Console.WriteLine($"{m.DateTime.ToShortTimeString()}: {m.Event}");
            }

            var hourly = service.GetReport(dateTime, AggregationType.Hourly);

            System.Console.WriteLine("");

            //hourly report
            System.Console.WriteLine("Hourly");

            var currentHour = "";
            var hour = "";
            foreach (var h in hourly)
            {
                if (h.DateTime.ToShortTimeString() != currentHour)
                {
                    currentHour = h.DateTime.ToShortTimeString();
                    hour = $"{currentHour}:";
                }

                System.Console.WriteLine($"{hour} {h.Event}");

                hour = new string(' ', currentHour.Length + 1);
            }

            System.Console.ReadLine();
        }

        private static ServiceProvider RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IChatEventsRepository, ChatEventsRepository>();
            services.AddTransient<IChatReportService, ChatReportService>();

            return services.BuildServiceProvider();
        }
    }
}
