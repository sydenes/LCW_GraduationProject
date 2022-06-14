using Lcw_GraduationProject.UI.Models.Offer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

namespace Lcw_GraduationProject.UI.Controllers
{
    public class OfferController : Controller
    {
        string baseUrl = "https://localhost:7061/"; //TODO:Constants'a koy.
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string price,string productId)
        {
            string userId=HttpContext.Session.GetString("userId");
            var floatPrice=float.Parse(price);
            VM_Create_Offer offer = new VM_Create_Offer() { UserId=userId,Price=floatPrice,ProductId=productId};
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var responseTask = client.PostAsJsonAsync<VM_Create_Offer>($"api/offer/", offer);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index),"Home");
                }
                else
                {
                    return NotFound();
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult WithdrawOffer(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var responseTask = client.DeleteAsync($"api/offer/{id}");
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
            return View();
        }
    }
}
