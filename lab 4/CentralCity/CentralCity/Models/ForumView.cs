using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralCity.Models
{
    public class ForumView
    {
        public int MessageID { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
        public string Name { get; set; }
        public string TopicName { get; set; }
    }
}