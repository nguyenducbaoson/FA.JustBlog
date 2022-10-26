using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
