using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string ResourceKey { get; set; }
        public string ResourcceValue { get; set; }
        public int CultureId { get; set; }

    }
}
