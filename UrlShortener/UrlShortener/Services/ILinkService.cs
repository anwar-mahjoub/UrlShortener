using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace UrlShortener.Services
{
    public interface ILinkService
    {
        Task<string> AddLink(string url);
        List<Link> GetAllLinks();
        Task DeleteLink(int id);
        string RedirectTo(string shortUrl);
    }
}
