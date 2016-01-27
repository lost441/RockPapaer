using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RockPaper.Web.Models;


namespace RockPaper.Web.Contracts
{
    public interface IDashboard
    {
        ActionResult Index();

        JsonResult GetResults(int offset = 0, int records = 10, FilterOption filter = FilterOption.None);

    }
}
