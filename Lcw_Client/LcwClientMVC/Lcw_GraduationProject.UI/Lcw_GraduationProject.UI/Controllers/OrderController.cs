using Lcw_GraduationProject.UI.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Lcw_GraduationProject.UI.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult Index() //gelen offer'da '%' olma durumuna göre yönet.
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string size) //gelen offer'da '%' olma durumuna göre yönet.
        {
            return View();
        }
    }
}
