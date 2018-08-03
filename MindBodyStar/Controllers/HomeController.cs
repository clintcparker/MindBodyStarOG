using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ClassService;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var startDate = DateTime.Now.AddDays(-30);
            var endDate = DateTime.Now.AddDays(-1);


            List<ClientVisits> clientList;
            if (HttpContext.Cache["ClientList"] != null)
            {
                clientList = HttpContext.Cache["ClientList"] as List<ClientVisits>;
            }
            else
            {
                StarRewardService starRewardService = new StarRewardService();
            var classes = starRewardService.GetClasses(startDate, endDate);
            var clients = starRewardService.GetNames(classes);

            var sortedList = clients.OrderByDescending(pair => pair.Value);


                clientList = new List<ClientVisits>();

                foreach (var keyValuePair in sortedList)
                {
                    clientList.Add(new ClientVisits() {Name = keyValuePair.Key, NumberofVisits = keyValuePair.Value});
                }
                HttpContext.Cache["ClientList"] = clientList;
            }
            var leaderBoardModel = new LeaderboardModel() {ClientList = clientList, StartDate = startDate, EndDate = endDate};

            return View(leaderBoardModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class ClientVisits
    {
        public string Name { get; set; }
        public int NumberofVisits { get; set; }
    }
}