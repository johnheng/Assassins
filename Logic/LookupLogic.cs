using Assassins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assassins.Logic
{
    public class LookupLogic
    {
        public string GetNameFromId(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var query = from player in db.Users
                            select player;

                return query.FirstOrDefault(x => x.Id == id).Name;
            }
        }

        public string GetFamilyFromId(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var query = from player in db.Users
                            select player;

                return query.FirstOrDefault(x => x.Id == id).Family;
            }
        }

        public string GetFamilyColorFromId(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var query = from player in db.Users
                            select player;

                var family = query.FirstOrDefault(x => x.Id == id).Family;

                if (family.Equals("Shu"))
                {
                    return "success";
                }
                else if (family.Equals("Wu"))
                {
                    return "danger";
                }
                else if (family.Equals("Wei"))
                {
                    return "info";
                }
                else
                {
                    return "warning";
                }
            }
        }

        public List<Event> GetEvents()
        {
            var eventEntity = new EventsDBEntities();
            return eventEntity.Events.ToList();
        }

        public List<AspNetUser> GetPlayers()
        {
            var userEntity = new AspNetUsersDBEntity();
            return userEntity.AspNetUsers.OrderBy(user => user.Name).ToList();
        }

        public AspNetUser GetUserFromId(string id)
        {
            var userEntity = new AspNetUsersDBEntity();
            return userEntity.AspNetUsers.FirstOrDefault(x => x.Id == id);
        }

        public int GetCurrentGameId()
        {
            var gameEntity = new GamesDBEntity();
            return gameEntity.Games.FirstOrDefault(game => game.Current == true).Id;
        }

        public List<Event> GetKillsFromId(string id)
        {
            var eventEntity = new EventsDBEntities();
            return eventEntity.Events.Where(
                x => (x.user == id) && 
                (x.type == 0))
                .OrderBy(x => x.date)
                .ToList();
        }

        public string GetKillerFromId(string id)
        {
            var logic = new LookupLogic();
            var eventEntity = new EventsDBEntities();
            var kill = eventEntity.Events.OrderBy(x => x.date).FirstOrDefault(x => x.target == id).user;
            return logic.GetNameFromId(kill);
        }

        public List<Game> GetAllGames()
        {
            var gameEntity = new GamesDBEntity();
            return gameEntity.Games.ToList();
        }

        public Game GetCurrentGame()
        {
            var gameEntity = new GamesDBEntity();
            return gameEntity.Games.FirstOrDefault(g => g.Current == true);
        }
    }
}