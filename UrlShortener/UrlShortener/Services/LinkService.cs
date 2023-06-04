using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using UrlShortener.Context;
using UrlShortener.Helper;
using UrlShortener.Models;

namespace UrlShortener.Services
{
    public class LinkService :ILinkService
    {
        private readonly UrlShortenerContext _context;

        public LinkService(UrlShortenerContext context)
        {
            this._context = context;
        }
        public async Task<string> AddLink(string url)
        {
            int id = GenerateId();
            int userId = 1; // hardcoded for the moment
            Link link = new Link()
            {
                Id = id,
                ShortUrl = ShortUrlHelper.Encode(id),
                LongUrl = url,
                UserId = userId,
                CreationDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(1),
            };
            if (this._context.Users.Find(userId)?.Links.Count < 5 && this._context.Links.Count() < 20)
            {
                this._context.Links.Add(link);
                await this._context.SaveChangesAsync();
                return link.ShortUrl;
            }

            return null;
        }

        public List<Link> GetAllLinks()
        {
            return this._context.Links.ToList();
        }

        public async Task DeleteLink(int id)
        {
            Link linkToBeRemoved = this._context.Links.Find(id);
            if (linkToBeRemoved != null)
            {
                this._context.Set<Link>().Remove(linkToBeRemoved);
                await this._context.SaveChangesAsync();
            }
        }

        public string RedirectTo(string shortUrl)
        {
            return this._context.Links.FirstOrDefault(link => link.ShortUrl == shortUrl)?.LongUrl;
        }

        private int GenerateId()
        {
            Random generator = new Random();
            int id = generator.Next(100000, 1000000);
            if (this._context.Links.Any(link => link.Id == id)) return GenerateId();
            else return id;
        }

    }
}
