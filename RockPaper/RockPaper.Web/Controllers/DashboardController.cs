using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RockPaper.Web.Contracts;
using RockPaper.Web.Models;

namespace RockPaper.Web.Controllers
{
    public class DashboardController : Controller, IDashboard
    {

        public ActionResult Index()
        {
            throw new NotImplementedException();
        }

        public JsonResult GetResults(int offset = 0, int records = 10, Models.FilterOption filter = FilterOption.None)
        {
            
        }
    }
}