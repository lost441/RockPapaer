
namespace RockPaper.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>The default landing page</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}