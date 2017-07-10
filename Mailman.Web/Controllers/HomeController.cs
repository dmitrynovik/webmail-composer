using System.Web.Mvc;

namespace Mailman.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Email");
        }
    }
}