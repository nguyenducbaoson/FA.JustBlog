using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Controllers
{
    public class ComentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
