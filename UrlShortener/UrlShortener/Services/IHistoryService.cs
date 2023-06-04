using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Services
{
    public interface IHistoryService
    {
        Task AddHistoryEvent();
    }
}
