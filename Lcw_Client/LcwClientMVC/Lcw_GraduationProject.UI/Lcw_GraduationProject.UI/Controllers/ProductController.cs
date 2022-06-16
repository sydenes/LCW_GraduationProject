using Lcw_GraduationProject.UI.Models;
using Lcw_GraduationProject.UI.Models.Offer;
using Lcw_GraduationProject.UI.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Lcw_GraduationProject.UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        //[Route("get")]
        public ActionResult Index()
        {
            IEnumerable<VM_Get_Product> products=new List<VM_Get_Product>();
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.baseUrl);
                var responseTask=client.GetAsync("api/product");
                responseTask.Wait();

                var result=responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask=result.Content.ReadAsAsync<IEnumerable<VM_Get_Product>>();
                    readTask.Wait();
                    products=readTask.Result;
                }
            }
            return View(products);
        }
        [HttpGet]
        public ActionResult MyProducts()
        {
            string userId = HttpContext.Session.GetString("userId");
            if (userId == null)
            {
                return RedirectToAction(nameof(Index), "User");
            }
            IEnumerable<VM_Get_Product> products = new List<VM_Get_Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.baseUrl);
                var responseTask = client.GetAsync($"api/product/myproducts/{userId}");
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

        // GET: ProductController/Details/5
        public ActionResult Details(string id)
        {
            string userId = HttpContext.Session.GetString("userId");
            if (userId == null)
            {
                return RedirectToAction(nameof(Index), "User");
            }

            VM_Get_Product product = new VM_Get_Product();
            VM_Get_Offer offer = new VM_Get_Offer();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.baseUrl);

                var responseTask = client.GetAsync($"api/product/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<VM_Get_Product>();
                    readTask.Wait();
                    product = readTask.Result;
                }

                var responseTaskOffer = client.GetAsync($"api/offer/{id}/{userId}");
                responseTaskOffer.Wait();
                var resultOffer = responseTaskOffer.Result;
                if (resultOffer.IsSuccessStatusCode)
                {
                    var readTask = resultOffer.Content.ReadAsAsync<VM_Get_Offer>();
                    readTask.Wait();
                    offer = readTask.Result;
                    if (offer!=null)
                    {
                        ViewBag.offer = offer;
                    }
                }
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View(new VM_Create_Product());
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VM_Create_Product model)
        {
            string userId = HttpContext.Session.GetString("userId"); 
            if (userId == null)
            {
                return RedirectToAction(nameof(Index), "User");
            }
            model.UserId = userId;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.baseUrl);
                var responseTask = client.PostAsJsonAsync<VM_Create_Product>($"api/product/",model);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(MyProducts));
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(string id)
        {
            VM_Update_Product product = new VM_Update_Product();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.baseUrl);
                var responseTask = client.GetAsync($"api/product/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<VM_Update_Product>();
                    readTask.Wait();
                    product = readTask.Result;
                }
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, VM_Update_Product model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.baseUrl);
                var responseTask = client.PutAsJsonAsync<VM_Update_Product>($"api/product", model);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(MyProducts));
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(string id)
        {
            VM_Get_Product product = new VM_Get_Product();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.baseUrl);
                var responseTask = client.GetAsync($"api/product/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<VM_Get_Product>();
                    readTask.Wait();
                    product = readTask.Result;
                }
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, VM_Get_Product model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.baseUrl);
                var responseTask = client.DeleteAsync($"api/product/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(MyProducts));
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
