using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Assassins.Models;
using System.Data.Entity;
using Assassins.Logic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;
using System.Collections.Generic;

namespace Assassins.Controllers
{
    public class AdminController : Controller
    {
        private LookupLogic logic = new LookupLogic();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult UserDetails(AdminMessageId? message)
        {
            ViewBag.StatusMessage =
                message == AdminMessageId.EditConfirm ? "Your changes have been successfully added."
                : message == AdminMessageId.DeleteConfirm ? "User has been removed from database."
                : "";

            return View(logic.GetPlayers().Where(p => !p.Admin).OrderByDescending(p => p.GameID).ThenBy(p => p.Name));
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(Event model)
        {
            if(ModelState.IsValid)
            {
                var eventEntity = new EventsDBEntities();
                eventEntity.Events.Add(model);
                eventEntity.SaveChanges();
                return RedirectToAction("EventDetails");
            }
            return View(model);
            
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(string id)
        {
            return View(logic.GetUserFromId(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, AspNetUser user)
        {
            if (user != null)
            {
                var userEntity = new AspNetUsersDBEntity();
                var currentUser = userEntity.AspNetUsers.FirstOrDefault(u => u.Id == user.Id);

                if(user.Alive != currentUser.Alive)
                {
                    currentUser.Alive = user.Alive;
                }
                if (user.CurrentTarget != currentUser.CurrentTarget)
                {
                    currentUser.CurrentTarget = user.CurrentTarget;
                }
                if (user.Description != currentUser.Description)
                {
                    currentUser.Description = user.Description;
                }
                if (user.GameID != currentUser.GameID)
                {
                    currentUser.GameID = user.GameID;
                }
                if (user.Kills != currentUser.Kills)
                {
                    currentUser.Kills = user.Kills;
                }
                if (user.Name != currentUser.Name)
                {
                    currentUser.Name = user.Name;
                }
                if(user.Family != currentUser.Family)
                {
                    currentUser.Family = user.Family;
                }

                userEntity.SaveChanges();

                return RedirectToAction("UserDetails", new { Message = AdminMessageId.EditConfirm });
            }
            return View();
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            return View(logic.GetUserFromId(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, AspNetUser user)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("UserDetails", new { Message = AdminMessageId.DeleteConfirm });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GameSettings()
        {
            return View();
        }

        public ActionResult EventDetails(AdminMessageId? message)
        {
            ViewBag.StatusMessage =
                message == AdminMessageId.EditConfirm ? "Your changes have been successfully added."
                : message == AdminMessageId.DeleteConfirm ? "Event has been removed from database."
                : "";

            return View(logic.GetEvents().OrderByDescending(m => m.date));
        }

        public ActionResult EditEvent(int id)
        {
            return View(logic.GetEvents().FirstOrDefault(evnt => evnt.Id == id));
        }

        [HttpPost]
        public ActionResult EditEvent(int id, Event eventEdit)
        {
            
            if (eventEdit != null)
            {
                var eventEntity = new EventsDBEntities();
                var evnt = eventEntity.Events.FirstOrDefault(u => u.Id == eventEdit.Id);

                if (eventEdit.comment != evnt.comment)
                {
                    evnt.comment = eventEdit.comment;
                }
                if (eventEdit.date != evnt.date)
                {
                    evnt.date = eventEdit.date;
                }
                if (eventEdit.gameid != evnt.gameid)
                {
                    evnt.gameid = eventEdit.gameid;
                }
                if (eventEdit.photourl != evnt.photourl)
                {
                    evnt.photourl = eventEdit.photourl;
                }
                if (eventEdit.target != evnt.target)
                {
                    evnt.target = eventEdit.target;
                }
                if (eventEdit.type != evnt.type)
                {
                    evnt.type = eventEdit.type;
                }
                if (eventEdit.user != evnt.user)
                {
                    evnt.user = eventEdit.user;
                }

                eventEntity.SaveChanges();
                return RedirectToAction("EventDetails", new { Message = AdminMessageId.EditConfirm });
            }

            return View();
        }

        public ActionResult DeleteEvent(int id )
        {
            return View(logic.GetEvents().FirstOrDefault(e => e.Id == id));
        }

        [HttpPost]
        public ActionResult DeleteEvent(Event evnt)
        {
            if(ModelState.IsValid)
            {
                var eventEntity = new EventsDBEntities();
                eventEntity.Events.Remove(eventEntity.Events.FirstOrDefault(e => e.Id == evnt.Id));

                eventEntity.SaveChanges();
                return RedirectToAction("EventDetails", new { Message = AdminMessageId.DeleteConfirm });
            }
            return View(evnt);
        }

        public ActionResult ManageGames(AdminMessageId? message)
        {
            ViewBag.StatusMessage =
                message == AdminMessageId.EditConfirm ? "Your changes have been successfully added."
                : message == AdminMessageId.DeleteConfirm ? "Game has been removed from database."
                : message == AdminMessageId.CreateConfirm ? "Game has been added to database."
                : message == AdminMessageId.GameStartedConfirm ? "Game has been started."
                : message == AdminMessageId.GameEndedConfirm ? "Game is no longer active."
                : message == AdminMessageId.ShuffleConfirm ? "Players have now been assigned targets."
                : message == AdminMessageId.UnknownError ? "An unexpected error has occurred."
                : "";

            return View(logic.GetAllGames());
        }

        public ActionResult EditGame(int id)
        {
            return View(logic.GetAllGames().FirstOrDefault(g => g.Id == id));
        }

        [HttpPost]
        public ActionResult EditGame(int id, Game gameEdit)
        {
            if (gameEdit != null)
            {
                var gameEntity = new GamesDBEntity();
                var gme = gameEntity.Games.FirstOrDefault(u => u.Id == gameEdit.Id);

                if (gameEdit.Active != gme.Active)
                {
                    gme.Active = gameEdit.Active;
                }
                if (gameEdit.Current != gme.Current)
                {
                    gme.Current = gameEdit.Current;
                }
                if (gameEdit.EndDate != gme.EndDate)
                {
                    gme.EndDate = gameEdit.EndDate;
                }
                if (gameEdit.Registration != gme.Registration)
                {
                    gme.Registration = gameEdit.Registration;
                }
                if (gameEdit.StartDate != gme.StartDate)
                {
                    gme.StartDate = gameEdit.StartDate;
                }

                gameEntity.SaveChanges();

                return RedirectToAction("ManageGames", new { Message = AdminMessageId.EditConfirm });
            }
            return View();
        }

        public ActionResult StartGame(int id)
        {
            return View(logic.GetAllGames().FirstOrDefault(g => g.Id == id));
        }

        [HttpPost]
        public ActionResult StartGame(Game game)
        {
            if(ModelState.IsValid)
            {
                var gameEntity = new GamesDBEntity();
                gameEntity.Games.FirstOrDefault(g => g.Id == game.Id).Active = true;

                gameEntity.SaveChanges();
                return RedirectToAction("ManageGames", new { Message = AdminMessageId.GameStartedConfirm });
            }
            return View(game);
        }

        public ActionResult EndGame(int id)
        {
            return View(logic.GetAllGames().FirstOrDefault(g => g.Id == id));
        }

        [HttpPost]
        public ActionResult EndGame(Game game)
        {
            if (ModelState.IsValid)
            {
                var gameEntity = new GamesDBEntity();
                gameEntity.Games.FirstOrDefault(g => g.Id == game.Id).Active = false;

                gameEntity.SaveChanges();
                return RedirectToAction("ManageGames", new { Message = AdminMessageId.GameEndedConfirm });
            }
            return View(game);
        }

        public ActionResult CreateGame()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGame(Game game)
        {

            if(ModelState.IsValid)
            {
                var gameEntity = new GamesDBEntity();
                gameEntity.Games.Add(game);

                gameEntity.SaveChanges();
                return RedirectToAction("ManageGames", new { Message = AdminMessageId.CreateConfirm });
            }
            return View(game);
        }

        public ActionResult DeleteGame(int id)
        {
            return View(logic.GetAllGames().FirstOrDefault(g => g.Id == id));
        }

        [HttpPost]
        public ActionResult DeleteGame(Game game)
        {
            if(ModelState.IsValid)
            {
                var gameEntity = new GamesDBEntity();
                gameEntity.Games.Remove(gameEntity.Games.FirstOrDefault(g => g.Id == game.Id));

                gameEntity.SaveChanges();
                return RedirectToAction("ManageGames", new { Message = AdminMessageId.DeleteConfirm });
            }
            return View(game);
        }

        public ActionResult AssignTargets(int id)
        {
            return View(logic.GetAllGames().FirstOrDefault(g => g.Id == id));
        }

        //view for list model
        [HttpPost]
        public ActionResult AssignTargetsConfirm(Game game)
        {
            if(ModelState.IsValid)
            {
                PlayerShuffleViewModel assignTargets = new PlayerShuffleViewModel();
                assignTargets.playerShuffle = getTargets();

                //TO-DO
                //displays viewmodel for assigntargets to a view
                return View(assignTargets.playerShuffle.OrderBy(m => m.user.family));
            }
            return View(game);
        }

        [HttpPost]
        public ActionResult AssignTargetsSave(IList<PlayerTargetViewModel> list)
        {
            if(ModelState.IsValid)
            {
                var userEntity = new AspNetUsersDBEntity();
                foreach(var user in list)
                {
                    var userInDb = userEntity.AspNetUsers.FirstOrDefault(u => u.Id == user.user.id);
                    userInDb.CurrentTarget = user.target.id;
                }
                userEntity.SaveChanges();

                var gameEntity = new GamesDBEntity();
                gameEntity.Games.FirstOrDefault(g => g.Current == true).Registration = false;
                gameEntity.SaveChanges();

                return RedirectToAction("ManageGames", new { Message = AdminMessageId.ShuffleConfirm });
            }
            return RedirectToAction("ManageGames", new { Message = AdminMessageId.UnknownError });
        }

        //assigns a target for each player
        public List<PlayerTargetViewModel> getTargets()
        {
            List<PlayerTargetViewModel> playerTargets = new List<PlayerTargetViewModel>();
            List<PlayerViewModel> allPlayers = getPlayers();

            //TO-DO
            Random rnd = new Random();
            foreach(var player in allPlayers)
            {
                PlayerTargetViewModel current = new PlayerTargetViewModel();
                current.user = player;
                playerTargets.Add(current);
            }

            Boolean check = false;
            while(!check)
            {
                //assign targets randomly while not in family
                foreach (var player in playerTargets)
                {
                    int i = 0;
                    while (player.target == null)
                    {
                        var target = allPlayers.ElementAt(rnd.Next(allPlayers.Count));
                        if (target != player.user)
                        {
                            if (target.family != player.user.family)
                            {
                                //player.target = target;
                                if (playerTargets.Where(m => m.target == target).Count() < 1)
                                {
                                    player.target = target;
                                    check = true;
                                }
                            }
                        }
                        i++;
                        if(i >= 100)
                        {
                            check = false;
                            break;
                        }
                    }
                    if(!check)
                    {
                        break;
                    }
                }
            }
            
            return playerTargets;
        }

        //populates players list with users in current game
        public List<PlayerViewModel> getPlayers()
        {
            var allPlayers = logic.GetPlayers();
            var players = new List<PlayerViewModel>();

            var currentGameId = logic.GetCurrentGameId();
            foreach (var user in allPlayers.Where(u => u.GameID == currentGameId && !u.Admin))
            {
                var player = new PlayerViewModel();
                player.id = user.Id;
                player.name = user.Name;
                player.family = user.Family;
                players.Add(player);
            }
            return players;
        }

        public ActionResult ResetPassword(string id)
        {
            return View(logic.GetUserFromId(id));
        }

        [HttpPost]
        public ActionResult ResetPassword(string id, AspNetUser user)
        {
            if (user != null)
            {
                var userEntity = new AspNetUsersDBEntity();
                var currentUser = userEntity.AspNetUsers.FirstOrDefault(u => u.Id == user.Id);

                userEntity.SaveChanges();

                return RedirectToAction("UserDetails", new { Message = AdminMessageId.EditConfirm });
            }
            return View();
        }

        public enum AdminMessageId
        {
            EditConfirm, 
            DeleteConfirm,
            CreateConfirm,
            GameStartedConfirm,
            GameEndedConfirm,
            ShuffleConfirm,
            UnknownError
        }
    }
}
