using System.Web.Mvc;

namespace LegacyOrderPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Legacy Order Portal";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Internal operations order management portal.";
            return View();
        }
    }
}
