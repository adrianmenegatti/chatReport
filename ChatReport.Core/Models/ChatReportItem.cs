using System;

namespace ChatReport.Core.Models
{
    public class ChatReportItem
    {
        public DateTime DateTime { get; private set; }
        public string Event { get; private set; }

        public ChatReportItem(DateTime dateTime, string chatEvent)
        {
            if (string.IsNullOrEmpty(chatEvent))
                throw new ArgumentNullException($"{nameof(chatEvent)} must be provided");

            DateTime = dateTime;
            Event = chatEvent;
        }
    }
}
