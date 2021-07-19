using ChatReport.Core.Models;
using System;
using System.Collections.Generic;

namespace ChatReport.Core.Repositories
{
    public interface IChatEventsRepository
    {
        IEnumerable<ChatEvent> GetEvents(DateTime dateTime);
    }
}
