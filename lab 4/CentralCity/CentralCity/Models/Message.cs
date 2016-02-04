using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralCity.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Subject { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime MessageDate { get; set; }
    }
}