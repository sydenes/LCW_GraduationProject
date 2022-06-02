using Lcw_GraduationProject.UI.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Lcw_GraduationProject.UI.Controllers
{
    public class HomeController : Controller
    {
        string baseUrl = "https://localhost:7061/";
        public ActionResult Index()
        {
            IEnumerable<VM_Get_Product> products = new List<VM_Get_Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var responseTask = client.GetAsync("api/product");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<VM_Get_Product>>();
                    readTask.Wait();
                    products = readTask.Result;
                }
            }
            return View(products);
        }
    }
}
