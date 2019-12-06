using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mini_Project.Models;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Mini_Project.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
            
        }
        public List<Event> GetEventList()
        {
            MajorProjectEntities sd = new MajorProjectEntities();
            List<Event> events = sd.Events.ToList();
            return events;
        }


        public ActionResult AdminViewPortal()
        {
            MajorProjectEntities sd = new MajorProjectEntities();
            ViewBag.EventList = new SelectList(GetEventList(), "event_id", "event_name");
            return View();
        }

        public ActionResult GetSportsList(int SLid)
        {
            MajorProjectEntities sd = new MajorProjectEntities();

            var mymodel = new MultiTable();
            mymodel.reg1 = sd.Sport_tournamentlist.ToList();
            mymodel.reg2 = sd.Cultural_eventlist.ToList();
            if (SLid == 1)
            {
                ViewBag.Sportslist = new SelectList(sd.Sport_tournamentlist, "sports_evid", "sport_name");
                ViewBag.Message = "sport";
            }
            else {
                ViewBag.Sportslist = new SelectList(sd.Cultural_eventlist, "cul_evid", "event_name");
                ViewBag.Message = "event";
            }
            return PartialView("DisplaySportsList");
        }

        public ActionResult ListofParticipants(int sportsid)
        {
            MajorProjectEntities sd = new MajorProjectEntities();

            List<Sports_reg> userids = sd.Sports_reg.Where(x => x.sport_id == sportsid).ToList();
            List<string> usernamelist = new List<string>();
            List<User> users = new List<User>();
            foreach (var item in userids)
            {
                users.Add(sd.Users.FirstOrDefault(x => x.uid == item.userid));
            }
            foreach (var item in users)
            {
                usernamelist.Add(item.username);
                Console.WriteLine(item.username);
            }
            ViewBag.listof = usernamelist;
            return PartialView("ListofParticipants");

        }
        public ActionResult ListofParticipants11(int event_id) {
            MajorProjectEntities sd = new MajorProjectEntities();

            List<Cultural_reg> culuserids = sd.Cultural_reg.Where(x => x.eventid == event_id).ToList();
            List<string> culusernamelist = new List<string>();
            List<User> culusers = new List<User>();
            foreach (var item in culuserids)
            {
                culusers.Add(sd.Users.FirstOrDefault(x => x.uid == item.userid));

            }
            foreach (var item in culusers)
            {
                culusernamelist.Add(item.username);
                Console.WriteLine(item.username);
            }
            ViewBag.listof1 = culusernamelist;

            return PartialView("ListofParticipants11");
        }

    }

 
}