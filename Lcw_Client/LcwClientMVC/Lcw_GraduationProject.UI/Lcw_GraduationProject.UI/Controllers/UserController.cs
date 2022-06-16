using Lcw_GraduationProject.UI.Models;
using Lcw_GraduationProject.UI.Models.Offer;
using Lcw_GraduationProject.UI.Models.Product;
using Lcw_GraduationProject.UI.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Lcw_GraduationProject.UI.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index() //LoginHome
        {
            string userId = HttpContext.Session.GetString("userId");
            if (userId != null)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(VM_Create_User user) //SignUp User
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.baseUrl);
                    var responseTask = client.PostAsJsonAsync<VM_Create_User>($"api/user/", user);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<AccessToken>();
                        readTask.Wait();
                        Response.Cookies.Append("jwt", readTask.Result.Token);
                        HttpContext.Session.SetString("isLogin", Constants2.loginSuccess.ToString());
                        HttpContext.Session.SetString("userId", readTask.Result.UserId);

                        return RedirectToAction(nameof(Index),"Home");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            HttpContext.Session.SetString("isLogin", Constants2.signUpFailed.ToString());
            return View(user);
        }
        [HttpPost]
        public IActionResult Login(VM_Create_User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.baseUrl);
                var responseTask = client.PostAsJsonAsync<VM_Create_User>($"api/user/Login", user);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AccessToken>();
                    readTask.Wait();
                    Response.Cookies.Append("jwt",readTask.Result.Token);
                    HttpContext.Session.SetString("isLogin", Constants2.loginSuccess.ToString());
                    HttpContext.Session.SetString("userId", readTask.Result.UserId);
                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    HttpContext.Session.SetString("isLogin", Constants2.loginFailed.ToString());
                    return RedirectToAction(nameof(Index));
                }
            }
        }

        [HttpGet]
        public IActionResult MyOffers()
        {
            string userId = HttpContext.Session.GetString("userId");
            List< VM_Get_OfferDetail > offers = new List< VM_Get_OfferDetail >();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.baseUrl);
                var responseTask = client.GetAsync($"api/offer/useroffers/{userId}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<VM_Get_OfferDetail>>();
                    readTask.Wait();
                    offers = readTask.Result;
                }
            }
            return View(offers);
        }
        [HttpGet]
        public IActionResult OthersOffers()
        {
            string userId = HttpContext.Session.GetString("userId");
            List<VM_Get_OfferDetail> offers = new List<VM_Get_OfferDetail>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.baseUrl);
                var responseTask = client.GetAsync($"api/offer/othersoffers/{userId}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<VM_Get_OfferDetail>>();
                    readTask.Wait();
                    offers = readTask.Result;
                }
            }
            return View(offers);
        }
    }
}
