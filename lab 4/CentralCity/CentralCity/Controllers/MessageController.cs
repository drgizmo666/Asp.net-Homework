using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentralCity.Models;

namespace CentralCity.Controllers
{
    public class MessageController : Controller
    {
        private CentralCityDBContext db = new CentralCityDBContext();

        // GET: /Message/
        public ActionResult Index()
        {
            return View(GetMessagesandTopics(0));
        }

        // GET: /Message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Message message = db.Messages.Find(id);
            ForumView message = GetMessageAndTopic(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: /Message/Create
        public ActionResult Create()
        {
            FillSelectLists();
            return View();
        }

        // POST: /Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageID,Subject,Title,Body,Author,MessageDate,TopicName")] ForumView forumVM, int MessageLocation, int WitchMember)
        {
            if (ModelState.IsValid)
            {
                Topic topic = (from t in db.Topics
                               where t.TopicID == MessageLocation
                               select t).FirstOrDefault();
                Member author = (from mem in db.Members
                                 where mem.MemberID == WitchMember
                                 select mem).FirstOrDefault();
                if(topic == null)
                {
                    topic = new Topic() { TopicName = forumVM.TopicName };
                    db.Topics.Add(topic);
                    db.SaveChanges();
                }

                Message message = new Message()
                {
                    MessageID = forumVM.MessageID,
                    TopicID = topic.TopicID,
                    MemberID = author.MemberID,
                    Author = author.MemberName,
                    Subject = forumVM.Subject,
                    Title = forumVM.Title,
                    Body = forumVM.Body,
                    MessageDate = forumVM.MessageDate
                };

                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            FillSelectLists();
            return View(forumVM);
        }

        // GET: /Message/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            //ForumView message = GetMessageAndTopic(id);
            FillSelectLists();
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: /Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageID, TopicID, MemberID, Subject,Title,Body,Author,MessageDate,TopicName")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            FillSelectLists();
            return View(message);
        }

        // GET: /Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: /Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(String searchTerm)
        {
            //TODO: Get a List of messages view models
            List<ForumView> forumVMs = new List<ForumView>();
            //TODO: Get the books that matches the search term
            var messages = (from m in db.Messages
                               where m.Body.Contains(searchTerm)
                               select m).ToList<Message>();
            //In a Loop:
                
                
            foreach(Message m in messages)
            {
                //TODO: Get the Stack that contains each book
                var topic = (from t in db.Topics
                             where t.TopicID == m.TopicID
                             select t).FirstOrDefault();
                //TODO: Create View models for the book and put them in the list
                forumVMs.Add(new ForumView()
                {
                    Title = m.Title,
                    Author = m.Author,
                    Body = m.Body,
                    TopicName = topic.TopicName,
                    Subject = m.Subject,
                    MessageDate = m.MessageDate
                });
            }

            //TODO: if there is just one book, display it
            if (forumVMs.Count == 1)
            {
                return View("Details", forumVMs[0]);
            }
            //TODO: if there is more than one book display the list of books
            else 
            {
                return View("Index", forumVMs);
            }

        }
        private List<ForumView> GetMessagesandTopics(int? messageId)
        {
            var messages = new List<ForumView>();
            var topics = from topic in db.Topics.Include("Messages")
                         select topic;

            foreach(Topic t in topics)
            {
                foreach(Message m in t.Messages)
                {
                        var forumVM = new ForumView();
                        forumVM.MessageID = m.MessageID;
                        forumVM.Body = m.Body;
                        forumVM.Subject = m.Subject;
                        forumVM.Title = m.Title;
                        forumVM.MessageDate = m.MessageDate;
                        forumVM.TopicName = t.TopicName;
                        forumVM.Author = m.Author;
                        messages.Add(forumVM);
                }
            }
            return messages;
        }

        private ForumView GetMessageAndTopic(int? MessageId)
        {
            var MessageVM = (from m in db.Messages
                            join t in db.Topics on m.TopicID equals t.TopicID
                            where m.MessageID == MessageId
                            select new ForumView
                            {
                                TopicName = t.TopicName,
                                Subject = m.Subject,
                                Title = m.Title,
                                Author = m.Author,
                                MessageDate = m.MessageDate,
                                Body = m.Body
                            }).FirstOrDefault();

            return MessageVM;
        }

        private void FillSelectLists()
        {
            ViewBag.MessageLocation = new SelectList(db.Topics.OrderBy(t => t.TopicName), "TopicID", "TopicName");
            ViewBag.WitchMember = new SelectList(db.Members.OrderBy(m => m.MemberName), "MemberID", "MemberName");
        }
    }
}
