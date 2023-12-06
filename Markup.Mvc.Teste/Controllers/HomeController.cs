using System.Web.Mvc;

namespace Markup.Mvc.Teste.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Entre em contato conosco";

            return View();
        }
    }
}