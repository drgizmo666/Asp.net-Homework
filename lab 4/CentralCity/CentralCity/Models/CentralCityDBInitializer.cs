using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CentralCity.Models
{
    public class CentralCityDBInitializer : DropCreateDatabaseAlways<CentralCityDBContext>
    {
        protected override void Seed(CentralCityDBContext context)
        {
            DateTime bday1 = new DateTime(2015, 7, 25);
            DateTime bday2 = new DateTime(2927, 6, 30);
            Topic T1 = new Topic {TopicName = "Flash Sightings"};
            Topic T2 = new Topic {TopicName = "Odds and Ends"};
            Member Mem1 = new Member { MemberName = "Wally West", EMail = "Wallysnuts@live.com", Password = "Mem1", BDay = bday1 };
            Member Mem2 = new Member { MemberName = "Iris West Allen", EMail = "irisallen@yahoo.com", Password = "Mem2", BDay = bday2 };
            Message m1 = new Message { Subject = "I saw the flash", Title = "Flash seen at City Hall", Body = "Flash gets key to city", MessageDate = DateTime.Today, Author = Mem1.MemberName};
            Message m2 = new Message { Subject = "Omg it's the flash", Title = "Flash seen at Star Labs", Body = "Flash goes to Star Labs", MessageDate = DateTime.Today, Author = Mem2.MemberName };
            Message m3 = new Message { Subject = "Any Ladys in CC tonight", Title = "Hay", Body = "What is up", MessageDate = DateTime.Today, Author = Mem1.MemberName };
            Message m4 = new Message { Subject = "Where am I?", Title = "Are you my mommy?", Body = "Looking for my real parents", MessageDate = DateTime.Today, Author = Mem2.MemberName };

            Mem1.Messages.Add(m1);
            T1.Messages.Add(m1);
            Mem2.Messages.Add(m2);
            T1.Messages.Add(m2);

            Mem1.Messages.Add(m3);
            T2.Messages.Add(m3);
            Mem2.Messages.Add(m4);
            T2.Messages.Add(m4);

            context.Topics.Add(T1);
            context.Topics.Add(T2);
            context.Members.Add(Mem1);
            context.Members.Add(Mem2);
            context.Messages.Add(m1);
            context.Messages.Add(m2);
            context.Messages.Add(m3);
            context.Messages.Add(m4);
            base.Seed(context);
        }
        
    }
}