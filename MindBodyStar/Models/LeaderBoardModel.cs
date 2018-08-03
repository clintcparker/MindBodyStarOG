using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Controllers;

namespace WebApplication1.Models
{
    public class LeaderboardModel
    {
        public List<ClientVisits> ClientList { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double getTotalDays()
        {
            return EndDate.Subtract(StartDate).TotalDays + 1;
        }
    }
}