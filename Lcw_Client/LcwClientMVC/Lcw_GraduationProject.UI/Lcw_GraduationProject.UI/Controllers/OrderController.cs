using Lcw_GraduationProject.UI.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Lcw_GraduationProject.UI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index(string id, string offer) //gelen offer'da '%' olma durumuna göre yönet.
        {
            return View();
        }
    }
}
