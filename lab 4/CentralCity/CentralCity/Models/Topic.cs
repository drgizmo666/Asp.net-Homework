using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralCity.Models
{
    public class Topic
    {
        public int TopicID { get; set; }
        public int MessageID { get; set; }
        List<Message> messages = new List<Message>();
        public string TopicName { get; set; }
        public List<Message> Messages
        {
            get { return messages; }
        }
    }
}