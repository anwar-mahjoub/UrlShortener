using System;
using System.Collections.Generic;

namespace UrlShortener.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}
