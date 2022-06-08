using Lcw_GraduationProject.UI.Models;
using Lcw_GraduationProject.UI.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Lcw_GraduationProject.UI.Controllers
{
    public class HomeController : Controller
    {
        public MainLayoutViewModel MainLayoutViewModel { get; set; }

        public HomeController()
        {
            this.MainLayoutViewModel = new MainLayoutViewModel();//has property PageTitle
            this.MainLayoutViewModel.PageTitle = "my title";

            this.ViewData["MainLayoutViewModel"] = this.MainLayoutViewModel.PageTitle;
        }

        string baseUrl = "https://localhost:7061/";
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("isLogin")==null)
                HttpContext.Session.SetString("isLogin", Constants2.loginNull.ToString());

            IEnumerable<VM_Get_Product> products = new List<VM_Get_Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Request.Cookies["jwt"]}");
                var a=client.DefaultRequestHeaders.Authorization.ToString();

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
    public class MainLayoutViewModel
    {
        public string PageTitle { get; set; }
    }
}
