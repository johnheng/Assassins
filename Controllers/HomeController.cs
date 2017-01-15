using Assassins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assassins.Logic;

namespace Assassins.Controllers
{
    public class HomeController : Controller
    {
        LookupLogic logic = new LookupLogic();
        public ActionResult Index(HomeMessageId? message)
        {
            ViewBag.StatusMessage =
                message == HomeMessageId.KillConfirm ? "Your target has been killed and your next target has been updated."
                : message == HomeMessageId.PhotoUpdate ? "Your photo has been successfully updated."
                : message == HomeMessageId.RegisterSuccess ? "You have successfully registered an account."
                : message == HomeMessageId.LogoutSuccess ? "You have been logged out."
                : message == HomeMessageId.JoinSuccess ? "You have joined the current game."
                : "";

            ViewData["event"] = new Event();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event model)
        {
            if(ModelState.IsValid)
            {
                if(model.type == 1 && model.comment == null)
                {
                    TempData["error"] = "<div class='alert alert-danger alert-dismissible' style='margin-top:15px;' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>Make sure your comment isn't empty!</div>";
                    return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }) + "#events");
                }
                else
                {
                    var eventEntity = new EventsDBEntities();
                    eventEntity.Events.Add(model);
                    eventEntity.SaveChanges();
                    return Redirect(Url.RouteUrl(new { controller = "Home", action = "Index" }) + "#events");
                }  
            }
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Weapons()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PastGame(int id)
        {
            ViewBag.GameId = id;
            return View(logic.GetAllGames().FirstOrDefault(g => g.Id == id));
        }

        public ActionResult PastGames()
        {
            var games = new GamesDBEntity();
            var currentGame = logic.GetCurrentGameId();
            return View(games.Games.Where(g => g.Id != currentGame).ToList());
        }

        public ActionResult KillReport(int id)
        {
            var eventsEntity = new EventsDBEntities();            
            return View(eventsEntity.Events.FirstOrDefault(e => e.Id == id));
        }

        public ActionResult PlayerProfile(string id)
        {
            var userEntity = new AspNetUsersDBEntity();
            return View(userEntity.AspNetUsers.FirstOrDefault(u => u.Id == id));
        }

        public enum HomeMessageId
        {
            KillConfirm,
            PhotoUpdate,
            RegisterSuccess, 
            LogoutSuccess,
            JoinSuccess
        }
    }
}