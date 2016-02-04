using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralCity.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public DateTime BDay { get; set; }

        List<Message> messages = new List<Message>();

        public List<Message> Messages
        {
            get { return messages; }
        }
    }
}