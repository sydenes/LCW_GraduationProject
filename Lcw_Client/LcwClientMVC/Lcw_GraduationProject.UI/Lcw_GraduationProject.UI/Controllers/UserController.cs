using Lcw_GraduationProject.UI.Models;
using Lcw_GraduationProject.UI.Models.Product;
using Lcw_GraduationProject.UI.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;

namespace Lcw_GraduationProject.UI.Controllers
{
    public class UserController : Controller
    {
        string baseUrl = "https://localhost:7061/";
        [HttpGet]
        public IActionResult Index() //LoginHome
        {
            //ViewBag.Login = Constants.loginControl;
            return View();
        }
        [HttpPost]
        public IActionResult Index(VM_Create_User user) //SignUp User
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
                        HttpContext.Session.SetString("isLogin", Constants2.loginSuccess.ToString());
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
                client.BaseAddress = new Uri(baseUrl);
                var responseTask = client.PostAsJsonAsync<VM_Create_User>($"api/user/Login", user);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AccessToken>();
                    readTask.Wait();

                    var a=readTask.Result.Token;
                    Response.Cookies.Append("jwt",readTask.Result.Token);
                    HttpContext.Session.SetString("isLogin", Constants2.loginSuccess.ToString());
                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    HttpContext.Session.SetString("isLogin", Constants2.loginFailed.ToString());
                    return RedirectToAction(nameof(Index));
                }
            }
        }
    }
}
