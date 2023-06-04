using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Context;
using UrlShortener.Helper;
using UrlShortener.Models;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly ILinkService linkService;
        public LinksController(ILinkService linkService)
        {
            this.linkService = linkService;
        }

        // GET: api/Links
        public IEnumerable<Link> Get(string url)
        {
            return this.linkService.GetAllLinks();
        }

        // POST: api/Links
        [Route("create")]
        public Task<string> Post([FromQuery] string url)
        {
            return this.linkService.AddLink(url);
        }

        // GET: api/Links
        [Route("redirect")]
        public IActionResult Redirect([FromQuery] string url)
        {
            string longUrl = this.linkService.RedirectTo(url);
            if (longUrl != null)
            {
                // Add history Event
                return Redirect(longUrl);
            }

            return NotFound();
        }
    }
}
