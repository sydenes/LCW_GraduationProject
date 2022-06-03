using Lcw_GraduationProject.UI.Models;
using Lcw_GraduationProject.UI.Models.Product;
using Lcw_GraduationProject.UI.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

namespace Lcw_GraduationProject.UI.Controllers
{
    public class UserController : Controller
    {
        string baseUrl = "https://localhost:7061/";
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Login = Constants.loginControl;
            return View();
        }
        [HttpPost]
        public IActionResult Index(VM_Create_User user)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var responseTask = client.PostAsJsonAsync<VM_Create_User>($"api/user/", user);
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
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Login(VM_Create_User user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var responseTask = client.PostAsJsonAsync<VM_Create_User>($"api/user/Login", user);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Constants.loginControl = true;
                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    Constants.loginControl = false;
                    return RedirectToAction(nameof(Index));
                }
            }
        }
    }
}
