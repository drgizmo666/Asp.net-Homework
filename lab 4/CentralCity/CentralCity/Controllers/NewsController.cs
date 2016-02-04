using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentralCity.Models;

namespace CentralCity.Controllers
{
    public class NewsController : Controller
    {
        NewsView TodaysStory = new NewsView 
        { 
            Title = "Flash Saves The Day", 
            Author = "Iris Allen",
            Story = "Weather Wizard had escaped from Iron Heights and was terrorizing the citizens of Central City but before to much damage was done Flash swooped in and saved the day",
            DateCrated=DateTime.Today
        };

        NewsView YesterdayStory = new NewsView
        {
            Title = "Absolutely",
            Author = "Nine Days",
            Story = "This is the story of a girl Who cried a river and drowned the whole world And while she looked so sad in photographs I absolutely love her When she smiles. Now how many days in a year She woke up with hope But she only found tears And I can be so insincere Making her promises never for real As long as she stands there waiting Wearing the holes in the soles of her shoes Now how many days disappear When you look in the mirror So how do you choose. Your clothes never wear as well the next day And your hair never falls in quite the same way You never seem to run out of things to say",
            DateCrated = new DateTime(2016, 1, 18)
        };
        //
        // GET: /News/
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult TodaysNews()
        {
            ViewBag.Message = "Today's News";
            ViewBag.NewsTitle = TodaysStory.Title;
            ViewBag.NewsAuthor = TodaysStory.Author;
            ViewBag.NewsStory = TodaysStory.Story;
            ViewBag.NewsDate = TodaysStory.DateCrated.ToString("D");

            return View();
        }

        public ActionResult Archive()
        {
            ViewBag.Message = "News Archive";

            ViewBag.NewsTitle = YesterdayStory.Title;
            ViewBag.NewsAuthor = YesterdayStory.Author;
            ViewBag.NewsStory = YesterdayStory.Story;
            ViewBag.NewsDate = YesterdayStory.DateCrated.ToString("D");

            return View(TodaysStory);
        }
	}
}