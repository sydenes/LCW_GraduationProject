using Lcw_GraduationProject.UI.Models.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

namespace Lcw_GraduationProject.UI.Controllers
{
    public class OrderController : Controller
    {
        string baseUrl = "https://localhost:7061/";

        [HttpGet]
        public IActionResult Index() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(VM_Create_Order order) 
        {
            order.UserId=HttpContext.Session.GetString("userId");
            if (order.UserId!=null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var responseTask = client.PostAsJsonAsync<VM_Create_Order>($"api/order/", order);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), "Home");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return RedirectToAction(nameof(Index), "User");
            }
        }
    }
}
