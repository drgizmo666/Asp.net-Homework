using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralCity.Models
{
    public class NewsView
    {
        public string Title { get; set; }
        public string Story { get; set; }
        public string Author { get; set; }
        public DateTime DateCrated { get; set; }
    }
}